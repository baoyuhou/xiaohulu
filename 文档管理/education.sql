/*
Navicat MySQL Data Transfer

Source Server         : 169.254.152.246_3306
Source Server Version : 50717
Source Host           : 169.254.152.246:3306
Source Database       : education

Target Server Type    : MYSQL
Target Server Version : 50717
File Encoding         : 65001

Date: 2018-11-05 19:36:33
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `candidate`
-- ----------------------------
DROP TABLE IF EXISTS `candidate`;
CREATE TABLE `candidate` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `Sex` varchar(100) DEFAULT NULL,
  `Photo` varchar(100) DEFAULT NULL,
  `ExamNumber` varchar(10) DEFAULT NULL,
  `DocumentType` varchar(10) DEFAULT NULL,
  `Certificates` varchar(20) DEFAULT NULL,
  `ExamRoomID` varchar(20) DEFAULT NULL,
  `Field` varchar(100) DEFAULT NULL,
  `SeatNumber` varchar(100) DEFAULT NULL,
  `TestRoomID` varchar(10) DEFAULT NULL,
  `CompanyID` varchar(10) DEFAULT NULL,
  `Enable` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of candidate
-- ----------------------------

-- ----------------------------
-- Table structure for `company`
-- ----------------------------
DROP TABLE IF EXISTS `company`;
CREATE TABLE `company` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of company
-- ----------------------------

-- ----------------------------
-- Table structure for `examinationsituation`
-- ----------------------------
DROP TABLE IF EXISTS `examinationsituation`;
CREATE TABLE `examinationsituation` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ExamNumber` varchar(100) DEFAULT NULL,
  `QuestionBankId` varchar(100) DEFAULT NULL,
  `Answer` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of examinationsituation
-- ----------------------------

-- ----------------------------
-- Table structure for `examroom`
-- ----------------------------
DROP TABLE IF EXISTS `examroom`;
CREATE TABLE `examroom` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of examroom
-- ----------------------------

-- ----------------------------
-- Table structure for `explain`
-- ----------------------------
DROP TABLE IF EXISTS `explain`;
CREATE TABLE `explain` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Description` varchar(500) DEFAULT NULL,
  `Address` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of explain
-- ----------------------------
INSERT INTO `explain` VALUES ('1', '1', '1');
INSERT INTO `explain` VALUES ('11', '1', '1');
INSERT INTO `explain` VALUES ('12', '1', '11');

-- ----------------------------
-- Table structure for `items`
-- ----------------------------
DROP TABLE IF EXISTS `items`;
CREATE TABLE `items` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `QuestionBankId` int(11) DEFAULT NULL,
  `AnswerA` varchar(10) DEFAULT NULL,
  `AnswerB` varchar(10) DEFAULT NULL,
  `AnswerC` varchar(10) DEFAULT NULL,
  `AnswerD` varchar(10) DEFAULT NULL,
  `AnswerE` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of items
-- ----------------------------

-- ----------------------------
-- Table structure for `jurisdiction`
-- ----------------------------
DROP TABLE IF EXISTS `jurisdiction`;
CREATE TABLE `jurisdiction` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `level` int(11) DEFAULT NULL,
  `Father` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of jurisdiction
-- ----------------------------

-- ----------------------------
-- Table structure for `questionbank`
-- ----------------------------
DROP TABLE IF EXISTS `questionbank`;
CREATE TABLE `questionbank` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Subject` varchar(100) DEFAULT NULL,
  `Answer` varchar(100) DEFAULT NULL,
  `Phone` varchar(100) DEFAULT NULL,
  `TypeOfExam` varchar(100) DEFAULT NULL,
  `Enable` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of questionbank
-- ----------------------------

-- ----------------------------
-- Table structure for `role`
-- ----------------------------
DROP TABLE IF EXISTS `role`;
CREATE TABLE `role` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of role
-- ----------------------------

-- ----------------------------
-- Table structure for `roleandjurisdiction`
-- ----------------------------
DROP TABLE IF EXISTS `roleandjurisdiction`;
CREATE TABLE `roleandjurisdiction` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoleId` int(11) DEFAULT NULL,
  `JurisdictionId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of roleandjurisdiction
-- ----------------------------

-- ----------------------------
-- Table structure for `testroom`
-- ----------------------------
DROP TABLE IF EXISTS `testroom`;
CREATE TABLE `testroom` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of testroom
-- ----------------------------

-- ----------------------------
-- Table structure for `testtime`
-- ----------------------------
DROP TABLE IF EXISTS `testtime`;
CREATE TABLE `testtime` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ExamNumberId` varchar(100) DEFAULT NULL,
  `LongExam` double DEFAULT NULL,
  `TimeUsed` double DEFAULT NULL,
  `RemainderLength` double DEFAULT NULL,
  `ProgressOfAnswer` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of testtime
-- ----------------------------

-- ----------------------------
-- Table structure for `texttype`
-- ----------------------------
DROP TABLE IF EXISTS `texttype`;
CREATE TABLE `texttype` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ExamType` varchar(10) DEFAULT NULL,
  `Enable` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of texttype
-- ----------------------------

-- ----------------------------
-- Table structure for `userandrole`
-- ----------------------------
DROP TABLE IF EXISTS `userandrole`;
CREATE TABLE `userandrole` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) DEFAULT NULL,
  `RoleId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of userandrole
-- ----------------------------

-- ----------------------------
-- Table structure for `users`
-- ----------------------------
DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `Password` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of users
-- ----------------------------
