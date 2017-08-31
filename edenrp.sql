-- phpMyAdmin SQL Dump
-- version 4.6.4
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 31 Ağu 2017, 20:53:16
-- Sunucu sürümü: 5.7.14
-- PHP Sürümü: 5.6.25

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `edenrp`
--
CREATE DATABASE IF NOT EXISTS `edenrp` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `edenrp`;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `erp_users`
--

CREATE TABLE `erp_users` (
  `id` smallint(5) UNSIGNED NOT NULL,
  `name` varchar(32) NOT NULL DEFAULT 'New_Character',
  `pwd` char(61) NOT NULL,
  `posx` float NOT NULL,
  `posy` float NOT NULL,
  `posz` float NOT NULL,
  `firstlogin` tinyint(1) NOT NULL DEFAULT '1',
  `money` int(11) NOT NULL DEFAULT '0',
  `bankaccount` mediumint(8) UNSIGNED NOT NULL,
  `bankmoney` int(11) NOT NULL,
  `skin` int(11) NOT NULL,
  `age` tinyint(3) UNSIGNED NOT NULL DEFAULT '18',
  `level` tinyint(3) UNSIGNED NOT NULL DEFAULT '0',
  `experience` tinyint(3) UNSIGNED NOT NULL DEFAULT '0',
  `adminlevel` tinyint(3) UNSIGNED NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Tablo döküm verisi `erp_users`
--

INSERT INTO `erp_users` (`id`, `name`, `pwd`, `posx`, `posy`, `posz`, `firstlogin`, `money`, `bankaccount`, `bankmoney`, `skin`, `age`, `level`, `experience`, `adminlevel`) VALUES
(100, 'Lewis_Connor', '$2a$10$nhNBr4WegtttptQtCduKYu94Ljp2xTzAXCeOWv36smutGv3jtg/Vi', 402.404, -1002.67, -99.0041, 0, 0, 0, 0, 0, 0, 0, 0, 5),
(101, 'Lisa_Crown', '$2a$10$nhNBr4WegtttptQtCduKYu94Ljp2xTzAXCeOWv36smutGv3jtg/Vi', -551.321, -1968.2, 26.9494, 0, 0, 0, 0, 0, 0, 0, 0, 5);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `erp_vehicles`
--

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
-- Tablo döküm verisi `erp_vehicles`
--

INSERT INTO `erp_vehicles` (`vehid`, `ownerclientid`, `ownername`, `modelhash`, `c1`, `c2`, `x`, `y`, `z`) VALUES
(0, 101, 'Lisa Crown', -1647941228, 3, 3, -395.827, -761.128, 36.8895),
(1, 101, 'Lisa Crown', 1394036463, 2, 2, -405.782, -761.202, 37.099),
(2, 101, 'Lisa Crown', -1647941228, 2, 2, -397.734, -756.876, 37.2709);

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `erp_users`
--
ALTER TABLE `erp_users`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `erp_vehicles`
--
ALTER TABLE `erp_vehicles`
  ADD PRIMARY KEY (`vehid`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `erp_users`
--
ALTER TABLE `erp_users`
  MODIFY `id` smallint(5) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=102;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
