CREATE DATABASE PartitioningDB;

USE PartitioningDB;

CREATE TABLE Logs(
	LogId int NOT NULL AUTO_INCREMENT,
	LogDate datetime,
	LogText nvarchar(300),
	CONSTRAINT PK_Logs_LogId PRIMARY KEY(LogId, LogDate)
) PARTITION BY RANGE(YEAR(LogDate))(
	PARTITION p0 VALUES LESS THAN (1990),
    PARTITION p1 VALUES LESS THAN (2000),
	PARTITION p2 VALUES LESS THAN (2010),
	PARTITION p3 VALUES LESS THAN MAXVALUE
);

DELIMITER $$

DROP PROCEDURE IF EXISTS insert_million_rows $$

CREATE PROCEDURE insert_million_rows () 
BEGIN
	DECLARE count INT DEFAULT 1;
	START TRANSACTION;
	WHILE count <= 1000000 DO
		INSERT INTO Logs(LogDate, LogText)
		VALUES(TIMESTAMPADD(DAY, FLOOR(1 + RAND() * 10000), '1987-12-22'),
		CONCAT('This is log #', count));
		SET count = count + 1;
	END WHILE;
END $$

DELIMITER ;

CALL insert_million_rows();

SELECT * FROM logs PARTITION(p2) WHERE YEAR(LogDate) = 2008;

SELECT * FROM logs WHERE YEAR(LogDate) = 2008;