-- phpMyAdmin SQL Dump
-- version 4.6.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Aug 29, 2017 at 09:59 PM
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
-- Table structure for table `erp_users`
--

DROP TABLE IF EXISTS `erp_users`;
CREATE TABLE `erp_users` (
  `id` smallint(5) UNSIGNED NOT NULL,
  `name` varchar(32) NOT NULL,
  `pwd` char(61) NOT NULL,
  `posx` float NOT NULL,
  `posy` float NOT NULL,
  `posz` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `erp_users`
--

INSERT INTO `erp_users` (`id`, `name`, `pwd`, `posx`, `posy`, `posz`) VALUES
(100, 'Lewis_Connor', '$2a$10$nhNBr4WegtttptQtCduKYu94Ljp2xTzAXCeOWv36smutGv3jtg/Vi', 106.224, -1940.63, 20.8037);

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
(0, 1001, 'Lisa_Crown', -624529134, 2, 2, 111.884, -1944.83, 20.7625);

--
-- Indexes for dumped tables
--

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
  MODIFY `id` smallint(5) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=101;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
