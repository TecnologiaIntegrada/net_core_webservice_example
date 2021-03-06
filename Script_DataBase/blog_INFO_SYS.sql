CREATE DATABASE  IF NOT EXISTS `blog` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `blog`;
-- MySQL dump 10.13  Distrib 8.0.18, for Win64 (x86_64)
--
-- Host: 192.168.2.47    Database: blog
-- ------------------------------------------------------
-- Server version	8.0.19

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `INFO_SYS`
--

DROP TABLE IF EXISTS `INFO_SYS`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `INFO_SYS` (
  `ID_INSTRUCT` int NOT NULL AUTO_INCREMENT,
  `ORDER_PROCESS` int NOT NULL,
  `TITLE` varchar(180) DEFAULT NULL,
  `PROCESS` varchar(255) DEFAULT NULL,
  `ORDER_CATEGORY` int DEFAULT NULL,
  `CATEGORY` varchar(50) DEFAULT NULL,
  `AUTHOR` varchar(80) DEFAULT NULL,
  `DATE_PUBLISHED` date DEFAULT NULL,
  `DESCRIPTION` longtext,
  PRIMARY KEY (`ID_INSTRUCT`,`ORDER_PROCESS`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `INFO_SYS`
--

LOCK TABLES `INFO_SYS` WRITE;
/*!40000 ALTER TABLE `INFO_SYS` DISABLE KEYS */;
INSERT INTO `INFO_SYS` VALUES (1,1,'Login process','Auth',1,'POST','Alexandre Novaes Iosimura','2020-03-28','Main autentication - POST - Send User/Passwd'),(2,2,'Search Doc 1','Search by name (ending with)',1,'GET','Alexandre Novaes Iosimura','2020-03-28','Search document by name (End with %)');
/*!40000 ALTER TABLE `INFO_SYS` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-03-28 15:53:36
