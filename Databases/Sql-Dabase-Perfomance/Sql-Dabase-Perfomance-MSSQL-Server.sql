/* 1. Create a table in SQL Server with 10 000 000 log entries (date + text). 
 * Search in the table by date range. Check the speed (without caching).
 */

CREATE DATABASE LogSystem;
GO

USE LogSystem;
GO

CREATE TABLE Logs(
  LogId int NOT NULL IDENTITY,
  LogDate datetime,
  LogText nvarchar(300),
  CONSTRAINT PK_Logs_LogId PRIMARY KEY (LogId)
)
GO

DECLARE @Count int = 1
DECLARE @LogDate datetime
WHILE @Count <= 1000000
BEGIN
  SET @LogDate = DATEADD(month, CONVERT(varbinary, newid()) % (50 * 12), getdate())
  INSERT INTO Logs(LogDate, LogText)
  VALUES (@LogDate, 'Some log text #' + CONVERT(varchar, @Count))
  SET @Count = @Count + 1
END

/* Empty Cache */
CHECKPOINT; DBCC DROPCLEANBUFFERS; 

SELECT * FROM Logs
WHERE LogDate 
BETWEEN CONVERT(datetime, '1994-01-01') AND CONVERT(datetime, '2004-12-12');

/* 2. Add an index to speed-up the search by date. Test the search speed (after cleaning the cache). */

CREATE INDEX IDX_LogDate_Logs ON Logs(LogDate);

/* Empty the SQL Server cache */
CHECKPOINT; DBCC DROPCLEANBUFFERS; 

SELECT * FROM Logs 
WHERE LogDate 
BETWEEN CONVERT(datetime, '1994-01-01') AND CONVERT(datetime, '2004-12-12');


/* 
 * 3. Add a full text index for the text column. 
 * Try to search with and without the full-text 
 * index and compare the speed. */

CREATE FULLTEXT CATALOG LogsFullTextIndex
WITH ACCENT_SENSITIVITY = OFF

CREATE FULLTEXT INDEX ON Logs(LogText)
KEY INDEX PK_Logs_LogId
ON LogsFullTextIndex
WITH CHANGE_TRACKING AUTO

/* Empty the SQL Server cache */
CHECKPOINT; DBCC DROPCLEANBUFFERS;

/* Full text search*/
SELECT * FROM Logs
WHERE LogText LIKE '%485202%'

--Empty the SQL Server cache
CHECKPOINT; DBCC DROPCLEANBUFFERS;
--Search from full text
SELECT * FROM Logs
WHERE CONTAINS(LogText,'485202')