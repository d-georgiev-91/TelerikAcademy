/**
 * 1. Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) 
 * and Accounts(Id(PK), PersonId(FK), Balance). Insert few records for testing.
 * Write a stored procedure that selects the full names of all persons.
 */
CREATE DATABASE CustomersDB
GO

USE CustomersDB

CREATE TABLE People 
(
	PersonId int IDENTITY,
	CONSTRAINT PK_PersonsID PRIMARY KEY(PersonId),
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	SSN NVARCHAR(10) NOT NULL
)
GO

CREATE TABLE Accounts 
(
	AccountId int IDENTITY,
	CONSTRAINT PK_AccountId PRIMARY KEY(AccountId),
	PersonId int NOT NULL,
	CONSTRAINT FK_PersonId FOREIGN KEY(PersonId)
                REFERENCES People(PersonId),
	Balance money NOT NULL
	DEFAULT 0
)
GO

INSERT INTO People 
VALUES 
	('Pesho', 'Ivanov', '4281481490'),
	('Gosho', 'Goshov', '4142414120'),
	('Petyr', 'Petrov', '4421842180'),
	('Minka', 'Svirkata', '6489987990'),
	('PisnaMi', 'DaMislqImena', '7874646970')
GO

INSERT INTO Accounts
	(PersonId, Balance)
VALUES 
	(1, 532423.342),
	(2, 3432.4)
GO

INSERT INTO Accounts
	(PersonId)
VALUES
	(3),
	(4),
	(5)
GO

CREATE PROCEDURE usp_GetPeopleFullNames 
AS
BEGIN
   SELECT FirstName + ' ' + LastName AS FullName 
   FROM People
END
GO

EXEC usp_GetPeopleFullNames
GO

/**
  * 2. Create a stored procedure that accepts a number as a parameter and returns all persons 
  *	who have more money in their accounts than the supplied number.
  */

CREATE PROCEDURE usp_GetPeopleWithGreaterBalanceThan(@balance money)
AS
BEGIN
	SELECT p.FirstName + ' ' + p.LastName AS FullName, a.Balance
	FROM People p
		JOIN Accounts a
			ON p.PersonId = a.PersonId
	WHERE a.Balance > @balance
END
GO

EXEC usp_GetPeopleWithGreaterBalanceThan 4000
GO

/**
  * 3. Create a function that accepts as parameters – sum, yearly interest rate and number of months. 
  * It should calculate and return the new sum. Write a SELECT to test whether the function works as expected.
  */

CREATE FUNCTION ufn_CalcNewSumByInterestRate(@sum MONEY, @interestRate DECIMAL, @numberOfMonths INT)
RETURNS MONEY
AS
BEGIN
	DECLARE @result MONEY
	SET @result = @sum + (@numberOfMonths / 12.0) * ((@interestRate * @sum) / 100)
	RETURN @result
END
GO

SELECT dbo.ufn_CalcNewSumByInterestRate(1000, 5, 5)
GO

/**
  * 4. Create a stored procedure that uses the function from the previous example to give an 
  * interest to a person's account for one month. It should take the AccountId and the interest rate as parameters
  */

CREATE PROCEDURE ups_AddMonthInterestForAccount(@accountId int, @interestRate decimal)
AS
BEGIN
	DECLARE @accountBalance MONEY = 
	(SELECT Balance FROM Accounts
	WHERE AccountId = @accountId)

	SELECT 
		@accountId as AccountID,
		dbo.ufn_CalcNewSumByInterestRate(@accountBalance, @interestRate, 1) AS MonthInterest
END
GO

EXEC ups_AddMonthInterestForAccount 2, 24
GO

/**
  * 5. Add two more stored procedures WithdrawMoney( AccountId, money) 
  * and DepositMoney (AccountId, money) that operate in transactions.
  */

CREATE PROCEDURE ups_WithdrawMoney(@accountId int, @money money)
AS
	BEGIN TRANSACTION
	DECLARE @moneyInAccount MONEY = 
		(SELECT Balance FROM Accounts
		 WHERE AccountId = @accountId)
	IF(@moneyInAccount >= @money)
		BEGIN
			UPDATE Accounts
			SET Balance = Balance - @money
			WHERE AccountId = @accountId
			COMMIT
		END
	ELSE
		BEGIN
			RAISERROR ('Not enough money in account.', 16, 1)
            ROLLBACK TRAN
		END
GO

EXEC ups_WithdrawMoney 2, 3000
GO

CREATE PROCEDURE ups_DepositMoney(@accountId int, @money money)
AS
	BEGIN TRANSACTION
	BEGIN
		UPDATE Accounts
		SET Balance = Balance + @money
		WHERE AccountId = @accountId
		COMMIT
	END
GO

EXEC ups_DepositMoney 2, 3000

/**
  * 6. Create another table – Logs(LogID, AccountID, OldSum, NewSum). 
  * Add a trigger to the Accounts table that enters a new entry into 
  * the Logs table every time the sum on an account changes
  */

CREATE TABLE Logs 
(
	LogId int IDENTITY,
	CONSTRAINT PK_LogId PRIMARY KEY(LogId),
	AccountId int NOT NULL,
	CONSTRAINT FK_AccountId FOREIGN KEY(AccountId)
                REFERENCES Accounts(AccountId),
	OldSum MONEY NOT NULL
	DEFAULT 0,
	NewSum MONEY NOT NULL
	DEFAULT 0,
	ChangeTime DATETIME NOT NULL
	DEFAULT GETDATE()
)
GO

CREATE TRIGGER tr_BalanceUpdate ON Accounts FOR UPDATE
AS
	DECLARE @accountId int = (SELECT AccountId FROM inserted)
	DECLARE @oldSum MONEY = (SELECT Balance FROM deleted)
	DECLARE @newSum MONEY = (SELECT Balance FROM inserted)
	INSERT INTO Logs
	(AccountId, OldSum, NewSum)
	VALUES 
		(@accountId, @oldSum, @newSum)
GO

EXEC ups_DepositMoney 2, 3000
EXEC ups_DepositMoney 5, 3000

SELECT * FROM Logs

/**
  * 7. Define a function in the database TelerikAcademy that returns all Employee's names 
  * (first or middle or last name) and all town's names that are comprised of given set of letters. 
  * Example 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.
  */
USE TelerikAcademy
GO

ALTER FUNCTION ufn_ContainsLetters (@setOfCharacters nvarchar(200), @word nvarchar(200))
RETURNS BIT
AS
BEGIN
	DECLARE @charIndex INT = 1
	DECLARE @containsLetters BIT = 0
	WHILE(@charIndex <= LEN(@word))
		BEGIN
			IF (NOT(@setOfCharacters LIKE ('%' + SUBSTRING(@word, @charIndex, 1) + '%')) AND (@word IS NOT NULL))
				BEGIN
					RETURN 0
				END
			SET @charIndex = @charIndex + 1
		END
	RETURN 1
END
GO


ALTER PROC usp_GetNameAndTownsMatchingCharacterSet(@setOfCharacters nvarchar(200))
AS
BEGIN
	SELECT e.FirstName, e.MiddleName, e.LastName, t.Name as Town
	FROM Employees e
		JOIN Addresses a
			ON e.AddressID = a.AddressID
		JOIN Towns t
			ON a.AddressID = t.TownID 
	WHERE 
		([dbo].ufn_ContainsLetters(@setOfCharacters, FirstName) = 1 OR 
		[dbo].ufn_ContainsLetters(@setOfCharacters, MiddleName) = 1 OR
		[dbo].ufn_ContainsLetters(@setOfCharacters, LastName) = 1) OR
		[dbo].ufn_ContainsLetters(@setOfCharacters, t.Name) = 1
END
GO

EXEC usp_GetNameAndTownsMatchingCharacterSet 'oistmiahf'
GO

/**
  * 8. Using database cursor write a T-SQL script that scans all employees and their 
  * addresses and prints all pairs of employees that live in the same town.
  */

DECLARE empCursor CURSOR READ_ONLY FOR
 
SELECT e1.FirstName, e1.LastName, t1.Name, e2.FirstName, e2.LastName
FROM Employees e1
	JOIN Addresses a1
		ON e1.AddressID = a1.AddressID
	JOIN Towns t1
		ON a1.TownID = t1.TownID,
		Employees e2
		JOIN Addresses a2
			ON e2.AddressID = a2.AddressID
		JOIN Towns t2
			ON a2.TownID = t2.TownID
WHERE t1.Name = t2.Name AND 
	e1.EmployeeID <> e2.EmployeeID
ORDER BY e1.FirstName, e2.FirstName
 
OPEN empCursor
DECLARE @firstName1 NVARCHAR(50)
DECLARE @lastName1 NVARCHAR(50)
DECLARE @town NVARCHAR(50)
DECLARE @firstName2 NVARCHAR(50)
DECLARE @lastName2 NVARCHAR(50)
FETCH NEXT FROM empCursor
        INTO @firstName1, @lastName1, @town, @firstName2, @lastName2
 
WHILE @@FETCH_STATUS = 0
	BEGIN
		PRINT @firstName1 + ' ' + @lastName1 +
				'     ' + @town + '      ' + @firstName2 + ' ' + @lastName2
		FETCH NEXT FROM empCursor
				INTO @firstName1, @lastName1, @town, @firstName2, @lastName2
	END
 
CLOSE empCursor
DEALLOCATE empCursor


/**
  * 10. Define a .NET aggregate function StrConcat that takes as input a sequence of strings and 
  * return a single string that consists of the input strings separated by ','. 
  * For example the following SQL statement should return a single string:
  * SELECT StrConcat(FirstName + ' ' + LastName)
  * FROM Employees
  */

IF OBJECT_ID('dbo.StrConcat') IS NOT NULL DROP Aggregate StrConcat 
GO 

IF EXISTS (SELECT * FROM sys.assemblies WHERE name = 'concat_assembly') 
       DROP assembly concat_assembly; 
GO      

CREATE Assembly concat_assembly 
   AUTHORIZATION dbo 
   FROM 'D:\Projects\TelerikAcademy\Databases\Transact-SQL\StrConcat.dll' /* <= Here you put the absolute path to the dll*/
   WITH PERMISSION_SET = SAFE; 
GO 

CREATE AGGREGATE dbo.StrConcat ( 

    @Value NVARCHAR(MAX) 
  , @Delimiter NVARCHAR(4000) 

) RETURNS NVARCHAR(MAX) 
EXTERNAL Name concat_assembly.StrConcat; 
GO

sp_configure 'clr enabled', 1
GO
RECONFIGURE
GO

SELECT dbo.StrConcat(FirstName + ' ' + LastName, ',') 
FROM Employees