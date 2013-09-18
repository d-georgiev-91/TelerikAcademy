/** 1. Write a SQL query to find the names and salaries of the employees 
  * that take the minimal salary in the 
  * company. Use a nested SELECT statement.
  */

SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary = (SELECT MIN(Salary) FROM Employees)

/** 2. Write a SQL query to find the names and salaries of the employees 
  * that have a salary that is up to 10% higher than the minimal salary for the company.
  */

DECLARE @MinSalary money
SET @MinSalary = (SELECT MIN(Salary) FROM Employees)

SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary BETWEEN @MinSalary and @MinSalary * 1.1

/**
  * 3. Write a SQL query to find the full name, salary and department of the 
  *	employees that take the minimal salary in their department. 
  *	Use a nested SELECT statement.
  */

SELECT e.FirstName, e.LastName, e.Salary, d.Name AS DepartmentName
FROM Employees e
	JOIN Departments d
		ON e.DepartmentId = d.DepartmentId
			WHERE Salary = 
				(SELECT MIN(e.Salary)
				 FROM Employees e
				 WHERE e.DepartmentId = d.DepartmentId)

/**
  * 4. Write a SQL query to find the average salary in the department #1.
  */

SELECT DepartmentID, AVG(Salary) AS AverageSalary
FROM Employees
WHERE DepartmentID = 1
GROUP BY DepartmentID

/**
  * 5. Write a SQL query to find the average salary  in the "Sales" department.
  */
SELECT d.Name, AVG(Salary) AS AverageSalary
FROM Employees e
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID AND d.Name = 'Sales'
GROUP BY d.Name

/**
  * 6. Write a SQL query to find the number of employees in the "Sales" department.
  */
SELECT d.Name, COUNT(*) As EmployeesCount
FROM Employees e
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID AND d.Name = 'Sales'
GROUP BY d.Name

/**
  * 7. Write a SQL query to find the number of all employees that have manager.
  */

SELECT COUNT(*) As EmployeesCountWithManager
FROM Employees e
WHERE e.ManagerID IS NOT NULL

/**
  * 8. Write a SQL query to find the number of all employees that have no manager.
  */

SELECT COUNT(*) As EmployeesCountWithNoManager
FROM Employees e
WHERE e.ManagerID IS NULL

/**
  *	9. Write a SQL query to find all departments and the average salary for each of them.
  */

SELECT d.Name, AVG(e.Salary) 
FROM Departments d
	JOIN Employees e
		ON d.DepartmentID = e.EmployeeID
GROUP BY d.Name

/**
  * 10. Write a SQL query to find the count of all employees in each department and for each town.
  */
SELECT t.Name as TownName, d.Name as DepartmentName, COUNT(*) as EmployeesCount
FROM Employees e
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
	JOIN Addresses a
		On e.AddressID = a.AddressID
	JOIN Towns t
		ON a.TownID = t.TownID
GROUP BY t.Name, d.Name

/**
  * 11. Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
  */
SELECT m.FirstName, m.LastName
FROM Employees m
	JOIN Employees e
		ON e.ManagerID = m.EmployeeID
GROUP BY m.FirstName, m.LastName
HAVING COUNT(*) = 5
ORDER BY m.FirstName, m.LastName

/**
  * 12. Write a SQL query to find all employees along with their managers.
  * For employees that do not have manager display the value "(no manager)".
  */
SELECT 
	e.FirstName + ' ' + e.LastName AS Employee,
	ISNULL(m.FirstName + ' ' + m.LastName, '(no manager)') AS Manager
FROM Employees e
	LEFT JOIN Employees m
		ON e.ManagerID = m.EmployeeID
ORDER BY m.FirstName + ' ' + m.LastName

/**
  * 13. Write a SQL query to find the names of all employees whose last 
  * name is exactly 5 characters long. Use the built-in LEN(str) function.
  */
SELECT EmployeeID, FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5

/**
  * 14. Write a SQL query to display the current date and time in the following format 
  * "day.month.year hour:minutes:seconds:milliseconds". 
  * Search in  Google to find how to format dates in SQL Server.
  */

SELECT FORMAT(GETDATE(), 'd.M.yyyy HH:mm:ss:fff')

/**
  * 15. Write a SQL statement to create a table Users. 
  * Users should have username, password, full name and last login time.
  * Choose appropriate data types for the table fields. 
  * Define a primary key column with a primary key constraint. 
  * Define the primary key column as identity to facilitate inserting records. 
  * Define unique constraint to avoid repeating usernames. 
  * Define a check constraint to ensure the password is at least 5 characters long.
  */

IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL
  DROP TABLE dbo.Users
CREATE TABLE Users (
  UserID INT IDENTITY,
  Username NVARCHAR(100) NOT NULL UNIQUE,
  UserPassword NVARCHAR(100) NOT NULL CHECK(LEN(UserPassword) >= 5),
  FullName NVARCHAR(100) NOT NULL,
  LastLogin DATETIME NOT NULL
)

/**
  * 16. Write a SQL statement to create a view that displays the users 
  * from the Users table that have been in the system today. Test if the view works correctly.
  */
IF OBJECT_ID('dbo.UsersLoggedToday', 'U') IS NOT NULL
  DROP TABLE dbo.UsersLoggedToday

EXEC('
	CREATE VIEW UsersLoggedToday AS 
	SELECT Username, FullName
	FROM Users
	WHERE DAY(LastLogin) = DAY(GETDATE())
')

/**
  * 17. Write a SQL statement to create a table Groups. 
  * Groups should have unique name (use unique constraint). Define primary key and identity column.
  */ 

IF OBJECT_ID('dbo.Groups', 'U') IS NOT NULL
  DROP TABLE dbo.Groups
CREATE TABLE Groups (
  GroupID INT IDENTITY,
  Name NVARCHAR(100) NOT NULL UNIQUE,
)

/**
  * 18. Write a SQL statement to add a column GroupID to the table Users. 
  * Fill some data in this new column and as well in the Groups table. 
  * Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.
  */

ALTER TABLE Users
ADD GroupID INT

ALTER TABLE Users
ADD CONSTRAINT FK_Users_Group FOREIGN KEY(GroupID) References Groups(GroupId)

/**
  * 19. Write SQL statements to insert several records in the Users and Groups tables.
  */

INSERT INTO Users (Username, UserPassword, FullName, LastLogin)
VALUES
	('stamat', 'asdadas', 'Stamat Stamatov', GETDATE()),
	('pesho', 'assdaf', 'Pesho Peshev', GETDATE())

INSERT INTO Groups (Name)
VALUES
	('Mnogo qki pichove'),
	('Oshte po-qki pichove')

/**
  * 20. Write SQL statements to update some of the records in the Users and Groups tables.
  *
  */
UPDATE Users
SET Username = 'Pesho Masinata'
WHERE Username = 'pesho'


UPDATE Groups
SET Name = REPLACE(name, 'pichove', 'hora')

/**
  * 21. Write SQL statements to delete some of the records from the Users and Groups tables.
  */

DELETE 
FROM Users
WHERE Username = 'stamat'

DELETE 
FROM Groups
WHERE Name LIKE '%nai-%'

/**
  * 22. Write SQL statements to insert in the Users table the names of all 
  * employees from the Employees table. Combine the first and last names as a full name. 
  * For username use the first letter of the first name + the last name (in lowercase). 
  * Use the same for the password, and NULL for last login time.
  */

INSERT INTO Users (Username, UserPassword, FullName)
SELECT LOWER(LEFT(FirstName, 3) + LastName), LOWER(FirstName + LastName), FirstName + ' ' + LastName
FROM Employees

/**
  * 23. Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
  */

UPDATE Users
SET UserPassword = NULL
WHERE LastLogin <= CAST('10.03.2010' AS DATETIME);

/**
  * 24. Write a SQL statement that deletes all users without passwords (NULL password).
  */

DELETE 
FROM Users
WHERE UserPassword IS NULL

/**
  * 25. Write a SQL query to display the average employee salary by department and job title.
  */ 

SELECT 
	d.Name AS DepartmentName,
	e.JobTitle AS JobTitle,
	AVG(e.Salary) AS AverageSalary
FROM Employees e
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle
ORDER BY d.Name

/**
  * 26. Write a SQL query to display the minimal employee salary by 
  * department and job title along with the name of some of the employees that take it.
  */
SELECT d.Name AS DepartmentName, e.JobTitle, e.FirstName + ' ' + e.LastName AS EmployeeName, MIN(e.Salary) AS MinSalary
FROM Employees e
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle, e.FirstName + ' ' + e.LastName
ORDER BY MIN(e.Salary)

/**
  * 27. Write a SQL query to display the town where maximal number of employees work.
  */
SELECT TOP 1 t.Name AS TownName, COUNT(e.EmployeeID) AS EmployeesCount
	FROM Employees e
		JOIN Addresses a
			ON e.AddressID = a.AddressID
		JOIN Towns t
			ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY EmployeesCount DESC

/**
  * 28. Write a SQL query to display the number of managers from each town.
  */

SELECT t.Name AS TownName, COUNT(e.EmployeeID) AS ManagersCount
	FROM Employees e
		RIGHT JOIN Employees m
			ON m.EmployeeID = e.ManagerID
		JOIN Addresses a
			ON m.AddressID = a.AddressID
		JOIN Towns t
			ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY t.Name


SELECT e.FirstName + ' ' + e.LastName as emp, m.FirstName + ' ' + m.LastName
	FROM Employees e
		RIGHT JOIN Employees m
			ON m.EmployeeID = e.ManagerID
--ORDER BY e.FirstName