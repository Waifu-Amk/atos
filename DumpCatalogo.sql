CREATE DATABASE  IF NOT EXISTS `catalogo` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `catalogo`;
-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: catalogo
-- ------------------------------------------------------
-- Server version	5.7.41

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
-- Table structure for table `Categorias`
--

DROP TABLE IF EXISTS `Categorias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Categorias` (
  `Id` int(11) NOT NULL,
  `Name` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Categorias`
--

LOCK TABLES `Categorias` WRITE;
/*!40000 ALTER TABLE `Categorias` DISABLE KEYS */;
INSERT INTO `Categorias` VALUES (1,'Bebida'),(2,'Fritura'),(3,'Dulce'),(4,'Galleta'),(5,'Cafe'),(6,'Leche Blanca');
/*!40000 ALTER TABLE `Categorias` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Marcas`
--

DROP TABLE IF EXISTS `Marcas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Marcas` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `CategoriaId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_Categoria_idx` (`CategoriaId`),
  CONSTRAINT `fk_Categoria` FOREIGN KEY (`CategoriaId`) REFERENCES `Categorias` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Marcas`
--

LOCK TABLES `Marcas` WRITE;
/*!40000 ALTER TABLE `Marcas` DISABLE KEYS */;
INSERT INTO `Marcas` VALUES (1,'Coca Cola',1),(2,'Pepsi',1),(3,'Dr Pepper',1),(4,'Fanta',1),(5,'Sprite',1),(6,'Doritos',2),(7,'Sabritas',2),(8,'Pringles',2),(9,'Cheetos',2),(10,'Ruffles',2),(11,'Ricolino',3),(12,'De la Rosa',3),(13,'HersheyLand',3),(14,'Gamesa',4),(15,'Tres Estrellas',4),(16,'Cuetara',4),(17,'Oreo',4),(18,'Nescafe',5),(19,'Volcanica',5),(20,'Jablum',5),(21,'Java House',5),(22,'Alpura',6),(23,'Lala',6),(24,'NutriLeche',6);
/*!40000 ALTER TABLE `Marcas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Productos`
--

DROP TABLE IF EXISTS `Productos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Productos` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `MarcaId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_producto_marca_idx` (`MarcaId`),
  CONSTRAINT `fk_producto_marca` FOREIGN KEY (`MarcaId`) REFERENCES `Marcas` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Productos`
--

LOCK TABLES `Productos` WRITE;
/*!40000 ALTER TABLE `Productos` DISABLE KEYS */;
INSERT INTO `Productos` VALUES (1,'Original',1),(2,'Normal',2),(3,'Normal',3),(4,'Naranja',4),(5,'Normal',5),(6,'Nacho',6),(7,'Queso',6),(8,'Dinamita',6),(9,'Adobadas',7),(10,'Original',7),(11,'Limon',7),(12,'FlaminHot',9),(13,'Bocadin',11),(14,'Bubu Lubu',11),(15,'Chocoletas',11),(16,'Duvalin',11),(17,'Panditas',11),(18,'Mazapan',12),(19,'Hershey',13),(20,'Marias',14),(21,'Polvoron',15),(22,'Oreos',17),(23,'Normal',18),(24,'Hawaiien Kona Extra Fancy',19),(25,'Blue Montain Jamaican',20),(26,'Kenia AA',21),(27,'Entera',22),(28,'Entera',23),(29,'Entera',24);
/*!40000 ALTER TABLE `Productos` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-03-14 22:36:14
