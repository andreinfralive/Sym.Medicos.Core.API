-- MySQL dump 10.13  Distrib 8.0.21, for Win64 (x86_64)
--
-- Host: localhost    Database: symdb
-- ------------------------------------------------------
-- Server version	8.0.21

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
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20201207145710_InitialDatabase','5.0.0'),('20201207150619_AlterandoClasseMedico','5.0.0'),('20201208115534_AlteracaoVinculoConsultorioMedico','5.0.0'),('20201208123319_AlteracaoTabelaVinculo','5.0.0'),('20201208123901_AlteracaoTabelaVinculoLocalizacaoCampo','5.0.0');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `consultorios`
--

DROP TABLE IF EXISTS `consultorios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `consultorios` (
  `IdConsultorio` int NOT NULL AUTO_INCREMENT,
  `NomeConsultorio` varchar(100) NOT NULL,
  `EnderecoConsultorio` varchar(200) NOT NULL,
  `TelefoneConsultorio` varchar(20) NOT NULL,
  PRIMARY KEY (`IdConsultorio`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `consultorios`
--

LOCK TABLES `consultorios` WRITE;
/*!40000 ALTER TABLE `consultorios` DISABLE KEYS */;
INSERT INTO `consultorios` VALUES (1,'Consultório São José','Rua São Paulo 1710','31997832975'),(2,'Consultório Maria de Nazaré','Rua Mario Pena 3421','31 32216638');
/*!40000 ALTER TABLE `consultorios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `medicos`
--

DROP TABLE IF EXISTS `medicos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `medicos` (
  `IdMedico` int NOT NULL AUTO_INCREMENT,
  `Crm` varchar(10) NOT NULL,
  `NomeMedico` varchar(100) NOT NULL,
  `Telefone` varchar(20) NOT NULL,
  `ValorConsulta` decimal(19,2) NOT NULL,
  PRIMARY KEY (`IdMedico`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `medicos`
--

LOCK TABLES `medicos` WRITE;
/*!40000 ALTER TABLE `medicos` DISABLE KEYS */;
INSERT INTO `medicos` VALUES (1,'CRM12345','André de Oliveira Pereira','31997832975',100.25),(3,'CRM12346','Larissa Emery','3732216638',125.50);
/*!40000 ALTER TABLE `medicos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuarios` (
  `IdUsuario` int NOT NULL AUTO_INCREMENT,
  `NomeUsuario` varchar(50) NOT NULL,
  `SobreNomeUsuario` varchar(50) NOT NULL,
  `Email` varchar(150) NOT NULL,
  `Senha` varchar(50) NOT NULL,
  `EhAdministrador` tinyint(1) NOT NULL,
  PRIMARY KEY (`IdUsuario`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES (1,'Andre','Oliveira','andreinfra@hotmail.com','sa772003',1),(6,'Elza','Silva','elzasilva@hotmail.com','sa772003',1),(8,'Maria Lourdes','Emery','mariinha@hotmail.com','sa772003',0);
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vinculomedicoconsultorios`
--

DROP TABLE IF EXISTS `vinculomedicoconsultorios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vinculomedicoconsultorios` (
  `IdVinculoMedicoConsultorio` int NOT NULL AUTO_INCREMENT,
  `IdMedico` int NOT NULL,
  `IdConsultorio` int NOT NULL,
  `CRM` varchar(10) NOT NULL DEFAULT '',
  `NomeConsultorio` varchar(100) NOT NULL DEFAULT '',
  `NomeMedico` varchar(100) NOT NULL DEFAULT '',
  PRIMARY KEY (`IdVinculoMedicoConsultorio`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vinculomedicoconsultorios`
--

LOCK TABLES `vinculomedicoconsultorios` WRITE;
/*!40000 ALTER TABLE `vinculomedicoconsultorios` DISABLE KEYS */;
INSERT INTO `vinculomedicoconsultorios` VALUES (1,1,1,'CRM12345','Consultório São José','André de Oliveira Pereira'),(8,3,1,'CRM12346','Consultório São José','Larissa Emery'),(9,3,2,'CRM12346','Consultório Maria de Nazaré','Larissa Emery');
/*!40000 ALTER TABLE `vinculomedicoconsultorios` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-12-09 14:47:26
