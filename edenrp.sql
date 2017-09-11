-- phpMyAdmin SQL Dump
-- version 4.6.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 11, 2017 at 10:39 PM
-- Server version: 5.7.14
-- PHP Version: 5.6.25

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `edenrp`
--
DROP DATABASE `edenrp`;
CREATE DATABASE IF NOT EXISTS `edenrp` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `edenrp`;

-- --------------------------------------------------------

--
-- Table structure for table `erp_facialdata`
--

DROP TABLE IF EXISTS `erp_facialdata`;
CREATE TABLE `erp_facialdata` (
  `id` smallint(5) UNSIGNED NOT NULL,
  `mom` tinyint(4) UNSIGNED NOT NULL,
  `dad` tinyint(4) UNSIGNED NOT NULL,
  `shapemix` float NOT NULL,
  `skinmix` float NOT NULL,
  `eyecolor` tinyint(4) UNSIGNED NOT NULL,
  `hairstyle` tinyint(4) UNSIGNED NOT NULL,
  `haircolor` tinyint(4) UNSIGNED NOT NULL,
  `highlight` tinyint(4) UNSIGNED NOT NULL,
  `eyebrow` tinyint(4) UNSIGNED NOT NULL,
  `ebcolor` tinyint(4) UNSIGNED NOT NULL,
  `facialhair` tinyint(4) UNSIGNED NOT NULL,
  `fhcolor` tinyint(4) UNSIGNED NOT NULL,
  `blemishes` tinyint(4) UNSIGNED NOT NULL,
  `aging` tinyint(4) UNSIGNED NOT NULL,
  `complexion` tinyint(4) UNSIGNED NOT NULL,
  `sundamage` tinyint(4) UNSIGNED NOT NULL,
  `freckles` tinyint(4) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `erp_facialdata`
--

INSERT INTO `erp_facialdata` (`id`, `mom`, `dad`, `shapemix`, `skinmix`, `eyecolor`, `hairstyle`, `haircolor`, `highlight`, `eyebrow`, `ebcolor`, `facialhair`, `fhcolor`, `blemishes`, `aging`, `complexion`, `sundamage`, `freckles`) VALUES
(100, 21, 0, 0.5, 0.5, 0, 0, 0, 0, 34, 0, 29, 0, 255, 255, 255, 255, 255),
(101, 23, 1, 0.275, 0.8, 4, 21, 8, 7, 0, 0, 29, 0, 0, 0, 0, 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `erp_users`
--

DROP TABLE IF EXISTS `erp_users`;
CREATE TABLE `erp_users` (
  `id` smallint(5) UNSIGNED NOT NULL,
  `name` varchar(32) NOT NULL DEFAULT 'New_Character',
  `pwd` char(61) NOT NULL,
  `posx` float NOT NULL,
  `posy` float NOT NULL,
  `posz` float NOT NULL,
  `firstlogin` tinyint(1) NOT NULL DEFAULT '1',
  `gender` tinyint(1) NOT NULL COMMENT '0 female | 1 male',
  `money` int(11) NOT NULL DEFAULT '0',
  `bankaccount` mediumint(8) UNSIGNED NOT NULL,
  `bankmoney` int(11) NOT NULL,
  `skin` int(11) NOT NULL,
  `age` tinyint(3) UNSIGNED NOT NULL DEFAULT '18',
  `level` tinyint(3) UNSIGNED NOT NULL DEFAULT '0',
  `experience` tinyint(3) UNSIGNED NOT NULL DEFAULT '0',
  `adminlevel` tinyint(3) UNSIGNED NOT NULL DEFAULT '0',
  `factionid` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `erp_users`
--

INSERT INTO `erp_users` (`id`, `name`, `pwd`, `posx`, `posy`, `posz`, `firstlogin`, `gender`, `money`, `bankaccount`, `bankmoney`, `skin`, `age`, `level`, `experience`, `adminlevel`, `factionid`) VALUES
(100, 'Lewis_Connor', '$2a$10$nhNBr4WegtttptQtCduKYu94Ljp2xTzAXCeOWv36smutGv3jtg/Vi', 403.529, -998.904, -99.004, 0, 0, 0, 0, 0, 0, 23, 5, 0, 5, 0),
(101, 'Lisa_Crown', '$2a$10$nhNBr4WegtttptQtCduKYu94Ljp2xTzAXCeOWv36smutGv3jtg/Vi', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 5, 0);

-- --------------------------------------------------------

--
-- Table structure for table `erp_vehicles`
--

DROP TABLE IF EXISTS `erp_vehicles`;
CREATE TABLE `erp_vehicles` (
  `vehid` int(11) NOT NULL,
  `ownerclientid` int(11) NOT NULL,
  `ownername` text NOT NULL,
  `modelhash` int(11) NOT NULL,
  `c1` int(11) NOT NULL,
  `c2` int(11) NOT NULL,
  `x` float NOT NULL,
  `y` float NOT NULL,
  `z` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `erp_vehicles`
--

INSERT INTO `erp_vehicles` (`vehid`, `ownerclientid`, `ownername`, `modelhash`, `c1`, `c2`, `x`, `y`, `z`) VALUES
(0, 100, 'Lewis Connor', -1647941228, 3, 3, -395.827, -761.128, 36.8895),
(1, 101, 'Lisa Crown', 1394036463, 2, 2, -554.358, -1976.01, 51.0551),
(2, 101, 'Lisa Crown', -1647941228, 2, 2, 8.2686, -1562.66, 28.9631),
(3, 101, 'Lisa Crown', -1943285540, 33, 33, 497.93, -996.975, 27.132),
(4, 101, 'Lisa Crown', 1876516712, 3, 2, 370.951, -847.164, 28.7431);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `erp_facialdata`
--
ALTER TABLE `erp_facialdata`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `erp_users`
--
ALTER TABLE `erp_users`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `erp_vehicles`
--
ALTER TABLE `erp_vehicles`
  ADD PRIMARY KEY (`vehid`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `erp_users`
--
ALTER TABLE `erp_users`
  MODIFY `id` smallint(5) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=102;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
