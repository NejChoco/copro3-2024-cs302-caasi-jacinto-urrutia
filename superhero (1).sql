-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 12, 2024 at 08:50 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `super`
--

-- --------------------------------------------------------

--
-- Table structure for table `superhero`
--

CREATE TABLE `superhero` (
  `uid` int(11) NOT NULL,
  `uname` varchar(255) NOT NULL,
  `HoV` varchar(255) NOT NULL,
  `gender` varchar(255) NOT NULL,
  `race` varchar(255) NOT NULL,
  `height` varchar(255) NOT NULL,
  `weight` varchar(255) NOT NULL,
  `age` varchar(255) NOT NULL,
  `build` varchar(255) NOT NULL,
  `sColor` varchar(255) NOT NULL,
  `eColor` varchar(255) NOT NULL,
  `bMod` varchar(255) NOT NULL,
  `hair` varchar(255) NOT NULL,
  `hColor` varchar(255) NOT NULL,
  `tClothes` varchar(255) NOT NULL,
  `bPants` varchar(255) NOT NULL,
  `hasSide` varchar(3) NOT NULL,
  `mPower` varchar(255) NOT NULL,
  `sPower` varchar(255) NOT NULL,
  `orb` varchar(255) NOT NULL,
  `str` varchar(255) NOT NULL,
  `vit` varchar(255) NOT NULL,
  `mana` varchar(255) NOT NULL,
  `atk` varchar(255) NOT NULL,
  `agi` varchar(255) NOT NULL,
  `def` varchar(255) NOT NULL,
  `luck` varchar(255) NOT NULL,
  `intel` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `superhero`
--

INSERT INTO `superhero` (`uid`, `uname`, `HoV`, `gender`, `race`, `height`, `weight`, `age`, `build`, `sColor`, `eColor`, `bMod`, `hair`, `hColor`, `tClothes`, `bPants`, `hasSide`, `mPower`, `sPower`, `orb`, `str`, `vit`, `mana`, `atk`, `agi`, `def`, `luck`, `intel`) VALUES
(39, 'Fictious', 'Hero', 'Male', 'Human', 'Very Short', 'Very Light', 'Teenager (13–19)', 'Athletic', 'Pale', 'Black', 'Tattoos', 'Short hair', 'Black', 'T-Shirt', 'Jeans', '0', 'Super Strength', 'Vampirism', 'Fire (Physical buff)', '5', '5', '5', '5', '0', '0', '0', '0'),
(41, 'Silver', 'Hero', 'Male', 'Human', 'Very Short', 'Very Light', 'Teenager (13–19)', 'Athletic', 'Pale', 'Black', 'Tattoos', 'Short hair', 'Black', 'T-Shirt', 'Jeans', '0', 'Super Strength', 'Vampirism', 'Fire (Physical buff)', '5', '5', '5', '5', '0', '0', '0', '0'),
(42, 'hero01', 'Hero', 'Male', 'Human', 'Very Short', 'Very Light', 'Teenager (13–19)', 'Athletic', 'Pale', 'Black', 'Tattoos', 'Short hair', 'Black', 'T-Shirt', 'Jeans', 'No', 'Super Strength', 'Vampirism', 'Fire (Physical buff)', '5', '5', '5', '5', '0', '0', '0', '0'),
(43, 'hero02', 'Hero', 'Male', 'Human', 'Very Short', 'Very Light', 'Teenager (13–19)', 'Athletic', 'Pale', 'Black', 'Tattoos', 'Short hair', 'Black', 'T-Shirt', 'Jeans', 'No', 'Super Strength', 'Vampirism', 'Fire (Physical buff)', '5', '5', '5', '5', '0', '0', '0', '0'),
(44, 'hero03', 'Hero', 'Male', 'Human', 'Very Short', 'Very Light', 'Teenager (13–19)', 'Athletic', 'Pale', 'Black', 'Tattoos', 'Short hair', 'Black', 'T-Shirt', 'Jeans', 'No', 'Super Strength', 'Vampirism', 'Fire (Physical buff)', '5', '5', '5', '5', '0', '0', '0', '0'),
(45, 'hero04', 'Hero', 'Male', 'Human', 'Very Short', 'Very Light', 'Teenager (13–19)', 'Athletic', 'Pale', 'Black', 'Tattoos', 'Short hair', 'Black', 'T-Shirt', 'Jeans', 'Yes', 'Super Strength', 'Vampirism', 'Fire (Physical buff)', '5', '5', '5', '5', '0', '0', '0', '0');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `superhero`
--
ALTER TABLE `superhero`
  ADD PRIMARY KEY (`uid`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `superhero`
--
ALTER TABLE `superhero`
  MODIFY `uid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=47;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
