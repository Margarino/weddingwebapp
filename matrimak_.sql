-- phpMyAdmin SQL Dump
-- version 5.0.3
-- https://www.phpmyadmin.net/
--
-- Servidor: localhost:3306
-- Tiempo de generación: 13-11-2022 a las 00:11:51
-- Versión del servidor: 10.3.36-MariaDB
-- Versión de PHP: 7.4.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `matrimak_`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ordenregalo`
--

CREATE TABLE `ordenregalo` (
  `idOrdenRegalo` int(4) NOT NULL COMMENT 'idoredn reglao',
  `correo` varchar(200) NOT NULL COMMENT 'correo del pelagato',
  `nota` varchar(300) DEFAULT NULL COMMENT 'nota en el regalo',
  `montoRegalo` int(7) NOT NULL COMMENT 'monto total del regalo'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `regalo`
--

CREATE TABLE `regalo` (
  `idRegalo` int(2) NOT NULL COMMENT 'idregalo',
  `nombreRegalo` varchar(20) NOT NULL COMMENT 'nombre del regalo',
  `costoRegalo` int(7) NOT NULL COMMENT 'costo regalo',
  `descripcionRegalo` varchar(280) NOT NULL COMMENT 'descripcion del regalo',
  `path` text NOT NULL COMMENT 'imagepath'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `ordenregalo`
--
ALTER TABLE `ordenregalo`
  ADD PRIMARY KEY (`idOrdenRegalo`);

--
-- Indices de la tabla `regalo`
--
ALTER TABLE `regalo`
  ADD PRIMARY KEY (`idRegalo`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `ordenregalo`
--
ALTER TABLE `ordenregalo`
  MODIFY `idOrdenRegalo` int(4) NOT NULL AUTO_INCREMENT COMMENT 'idoredn reglao';

--
-- AUTO_INCREMENT de la tabla `regalo`
--
ALTER TABLE `regalo`
  MODIFY `idRegalo` int(2) NOT NULL AUTO_INCREMENT COMMENT 'idregalo';
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
