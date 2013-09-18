CREATE DATABASE  IF NOT EXISTS `UniversityDB` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `UniversityDB`;
-- MySQL dump 10.13  Distrib 5.5.32, for Linux (x86_64)
--
-- Host: localhost    Database: UniversityDB
-- ------------------------------------------------------
-- Server version	5.5.32

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Courses`
--

DROP TABLE IF EXISTS `Courses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Courses` (
  `CourseId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  PRIMARY KEY (`CourseId`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Courses`
--

LOCK TABLES `Courses` WRITE;
/*!40000 ALTER TABLE `Courses` DISABLE KEYS */;
INSERT INTO `Courses` VALUES (1,'Programming with C#'),(2,'Biology'),(3,'Structure Data And Algorithms'),(4,'Linux Course'),(5,'Drawing');
/*!40000 ALTER TABLE `Courses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `CoursesStudents`
--

DROP TABLE IF EXISTS `CoursesStudents`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `CoursesStudents` (
  `CourseStudentId` int(11) NOT NULL AUTO_INCREMENT,
  `CourseId` int(11) NOT NULL,
  `StudentId` int(11) NOT NULL,
  PRIMARY KEY (`CourseStudentId`),
  KEY `fk_CoursesStudents_Courses1_idx` (`CourseId`),
  KEY `fk_CoursesStudents_Students1_idx` (`StudentId`),
  CONSTRAINT `fk_CoursesStudents_Courses1` FOREIGN KEY (`CourseId`) REFERENCES `Courses` (`CourseId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_CoursesStudents_Students1` FOREIGN KEY (`StudentId`) REFERENCES `Students` (`StudentId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `CoursesStudents`
--

LOCK TABLES `CoursesStudents` WRITE;
/*!40000 ALTER TABLE `CoursesStudents` DISABLE KEYS */;
INSERT INTO `CoursesStudents` VALUES (10,1,2),(11,1,3),(12,1,4),(13,1,4),(14,4,2),(15,4,4),(16,2,4),(17,2,1),(18,5,1);
/*!40000 ALTER TABLE `CoursesStudents` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Departments`
--

DROP TABLE IF EXISTS `Departments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Departments` (
  `DepartmentId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `FacultyId` int(11) NOT NULL,
  PRIMARY KEY (`DepartmentId`),
  KEY `fk_Departments_Faculties_idx` (`FacultyId`),
  CONSTRAINT `fk_Departments_Faculties` FOREIGN KEY (`FacultyId`) REFERENCES `Faculties` (`FacultyId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Departments`
--

LOCK TABLES `Departments` WRITE;
/*!40000 ALTER TABLE `Departments` DISABLE KEYS */;
INSERT INTO `Departments` VALUES (1,'Computer Science',1),(2,'Mathematics',1),(3,'MicroBiology',2);
/*!40000 ALTER TABLE `Departments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Faculties`
--

DROP TABLE IF EXISTS `Faculties`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Faculties` (
  `FacultyId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  PRIMARY KEY (`FacultyId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Faculties`
--

LOCK TABLES `Faculties` WRITE;
/*!40000 ALTER TABLE `Faculties` DISABLE KEYS */;
INSERT INTO `Faculties` VALUES (1,'FMI'),(2,'Biological');
/*!40000 ALTER TABLE `Faculties` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Professors`
--

DROP TABLE IF EXISTS `Professors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Professors` (
  `ProfessorId` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(45) NOT NULL,
  `LastName` varchar(45) NOT NULL,
  `DepartmentId` int(11) NOT NULL,
  PRIMARY KEY (`ProfessorId`),
  KEY `fk_Professors_Departments1_idx` (`DepartmentId`),
  CONSTRAINT `fk_Professors_Departments1` FOREIGN KEY (`DepartmentId`) REFERENCES `Departments` (`DepartmentId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Professors`
--

LOCK TABLES `Professors` WRITE;
/*!40000 ALTER TABLE `Professors` DISABLE KEYS */;
INSERT INTO `Professors` VALUES (1,'Ivan','Ivanov',1),(2,'Super','Pesho',2),(3,'Stamat','Georgiev',3),(4,'Pesho','Peshev',2);
/*!40000 ALTER TABLE `Professors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ProfessorsCourses`
--

DROP TABLE IF EXISTS `ProfessorsCourses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ProfessorsCourses` (
  `ProfessorCourseId` int(11) NOT NULL AUTO_INCREMENT,
  `ProfessorId` int(11) NOT NULL,
  `CourseId` int(11) NOT NULL,
  PRIMARY KEY (`ProfessorCourseId`),
  KEY `fk_ProfessorsCourses_Professors1_idx` (`ProfessorId`),
  KEY `fk_ProfessorsCourses_Courses1_idx` (`CourseId`),
  CONSTRAINT `fk_ProfessorsCourses_Professors1` FOREIGN KEY (`ProfessorId`) REFERENCES `Professors` (`ProfessorId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ProfessorsCourses_Courses1` FOREIGN KEY (`CourseId`) REFERENCES `Courses` (`CourseId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ProfessorsCourses`
--

LOCK TABLES `ProfessorsCourses` WRITE;
/*!40000 ALTER TABLE `ProfessorsCourses` DISABLE KEYS */;
INSERT INTO `ProfessorsCourses` VALUES (13,2,1),(14,2,1),(15,3,2),(16,2,1);
/*!40000 ALTER TABLE `ProfessorsCourses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ProfessorsTitles`
--

DROP TABLE IF EXISTS `ProfessorsTitles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ProfessorsTitles` (
  `ProfessorTitleId` int(11) NOT NULL AUTO_INCREMENT,
  `ProfessorId` int(11) NOT NULL,
  `TitleId` int(11) NOT NULL,
  PRIMARY KEY (`ProfessorTitleId`),
  KEY `fk_ProfessorsTittles_Professors1_idx` (`ProfessorId`),
  KEY `fk_ProfessorsTittles_Tittles1_idx` (`TitleId`),
  CONSTRAINT `fk_ProfessorsTittles_Professors1` FOREIGN KEY (`ProfessorId`) REFERENCES `Professors` (`ProfessorId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ProfessorsTittles_Tittles1` FOREIGN KEY (`TitleId`) REFERENCES `Titles` (`TitleId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ProfessorsTitles`
--

LOCK TABLES `ProfessorsTitles` WRITE;
/*!40000 ALTER TABLE `ProfessorsTitles` DISABLE KEYS */;
INSERT INTO `ProfessorsTitles` VALUES (5,1,3),(6,3,2),(7,2,3),(8,2,1);
/*!40000 ALTER TABLE `ProfessorsTitles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Students`
--

DROP TABLE IF EXISTS `Students`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Students` (
  `StudentId` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(45) NOT NULL,
  `LastName` varchar(45) NOT NULL,
  `FacultyId` int(11) NOT NULL,
  PRIMARY KEY (`StudentId`),
  KEY `fk_Students_Faculties1_idx` (`FacultyId`),
  CONSTRAINT `fk_Students_Faculties1` FOREIGN KEY (`FacultyId`) REFERENCES `Faculties` (`FacultyId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Students`
--

LOCK TABLES `Students` WRITE;
/*!40000 ALTER TABLE `Students` DISABLE KEYS */;
INSERT INTO `Students` VALUES (1,'Mincho','Popov',2),(2,'Mimi','Peneva',1),(3,'Penka','Stoqnova',2),(4,'Pesho','Peshev',2);
/*!40000 ALTER TABLE `Students` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Titles`
--

DROP TABLE IF EXISTS `Titles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Titles` (
  `TitleId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  PRIMARY KEY (`TitleId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Titles`
--

LOCK TABLES `Titles` WRITE;
/*!40000 ALTER TABLE `Titles` DISABLE KEYS */;
INSERT INTO `Titles` VALUES (1,'Ph.D'),(2,'Academic'),(3,'Senior Assitent');
/*!40000 ALTER TABLE `Titles` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-07-13 17:01:27
