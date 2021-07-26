-- --------------------------------------------------------
-- Servidor:                     127.0.0.1
-- Versão do servidor:           10.4.20-MariaDB - mariadb.org binary distribution
-- OS do Servidor:               Win64
-- HeidiSQL Versão:              11.3.0.6295
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Copiando estrutura do banco de dados para listadecompras
DROP DATABASE IF EXISTS `listadecompras`;
CREATE DATABASE IF NOT EXISTS `listadecompras` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `listadecompras`;

-- Copiando estrutura para procedure listadecompras.alterarItens
DROP PROCEDURE IF EXISTS `alterarItens`;
DELIMITER //
CREATE PROCEDURE `alterarItens`(
	IN `id1` INT,
	IN `nome` VARCHAR(500),
	IN `quantidade` DOUBLE,
	IN `preco` DOUBLE,
	IN `subTotal` DOUBLE,
	IN `idUsuario` INT
)
BEGIN
UPDATE `listadecompras`.`listadecompras` SET `nome`=nome, `quantidade`=quantidade, `preco`= preço, `subTotal` = subTotal WHERE  `id`=id1 AND listadecompras.idUsuario = idUsuario;
END//
DELIMITER ;

-- Copiando estrutura para procedure listadecompras.cadastrarItem
DROP PROCEDURE IF EXISTS `cadastrarItem`;
DELIMITER //
CREATE PROCEDURE `cadastrarItem`(
	IN `nome` VARCHAR(500),
	IN `quantidade` DOUBLE,
	IN `preco` DOUBLE,
	IN `subTotal` DOUBLE,
	IN `idUsuario` INT
)
BEGIN
INSERT INTO `listadecompras`.`listadecompras` (`nome`, `quantidade`, `preco`, `subTotal`,`idUsuario`) VALUES (nome, quantidade, preco, subTotal, idUsuario);
END//
DELIMITER ;

-- Copiando estrutura para procedure listadecompras.cadastrarUsuario
DROP PROCEDURE IF EXISTS `cadastrarUsuario`;
DELIMITER //
CREATE PROCEDURE `cadastrarUsuario`(
	IN `usuario` VARCHAR(200),
	IN `senha` VARCHAR(200)
)
BEGIN
INSERT INTO `listadecompras`.`usuarios` (`nome`, `senha`) VALUES (usuario, senha);
END//
DELIMITER ;

-- Copiando estrutura para procedure listadecompras.consultaSenha
DROP PROCEDURE IF EXISTS `consultaSenha`;
DELIMITER //
CREATE PROCEDURE `consultaSenha`(
	IN `usuario` VARCHAR(200),
	IN `senha` VARCHAR(200)
)
BEGIN
Select usuarios.id from usuarios where usuarios.nome = usuario and usuarios.senha = senha;
END//
DELIMITER ;

-- Copiando estrutura para tabela listadecompras.listadecompras
DROP TABLE IF EXISTS `listadecompras`;
CREATE TABLE IF NOT EXISTS `listadecompras` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(500) DEFAULT '0',
  `quantidade` double DEFAULT 0,
  `preco` double DEFAULT 0,
  `subTotal` double DEFAULT NULL,
  `idUsuario` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_listadecompras_usuarios` (`idUsuario`)
) ENGINE=MyISAM AUTO_INCREMENT=14 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela listadecompras.listadecompras: 8 rows
/*!40000 ALTER TABLE `listadecompras` DISABLE KEYS */;
INSERT INTO `listadecompras` (`id`, `nome`, `quantidade`, `preco`, `subTotal`, `idUsuario`) VALUES
	(1, 'Arroz 5 kg', 2, 22.5, 45, 10),
	(2, 'Óleo 900 ml', 3, 6.79, 20.37, 10),
	(3, 'Açucar 5 kg', 2, 12.49, 24.98, 10),
	(4, 'Sabão em pó', 2, 8.29, 16.58, 10),
	(5, 'Amaciante 2 L', 1, 5.99, 5.99, 10),
	(6, 'Creme Dental 90 g', 1, 3.69, 3.69, 10),
	(7, 'Leite 1 L', 1, 2.99, 2.99, 10),
	(8, 'Detergente 500 ml', 1, 1.79, 1.79, 11),
	(9, 'joao2', 1, 111.11, 111.11, 13),
	(10, 'joaooo', 2, 222.22, 444.44, 13),
	(12, 'pedro', 1, 0.01, 0.01, 14);
/*!40000 ALTER TABLE `listadecompras` ENABLE KEYS */;

-- Copiando estrutura para procedure listadecompras.listaItens
DROP PROCEDURE IF EXISTS `listaItens`;
DELIMITER //
CREATE PROCEDURE `listaItens`(
	IN `idUsuario` INT
)
BEGIN
SELECT l.id AS "Id", l.nome AS "Nome", l.quantidade AS "Quantidade", l.preco AS "Preco", l.subTotal AS "Subtotal" 
FROM listadecompras AS l, usuarios WHERE l.idUsuario = idUsuario AND usuarios.id = idUsuario;
END//
DELIMITER ;

-- Copiando estrutura para procedure listadecompras.removerItem
DROP PROCEDURE IF EXISTS `removerItem`;
DELIMITER //
CREATE PROCEDURE `removerItem`(
	IN `id1` INT,
	IN `idUsuario` INT
)
BEGIN
DELETE FROM `listadecompras`.`listadecompras` WHERE `id`=id1 AND listadecompras.idUsuario = idUsuario;
END//
DELIMITER ;

-- Copiando estrutura para tabela listadecompras.usuarios
DROP TABLE IF EXISTS `usuarios`;
CREATE TABLE IF NOT EXISTS `usuarios` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(200) DEFAULT NULL,
  `senha` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela listadecompras.usuarios: ~3 rows (aproximadamente)
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` (`id`, `nome`, `senha`) VALUES
	(10, 'kleber', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4'),
	(11, 'kleber2', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4'),
	(12, 'kleber2', '12'),
	(13, 'joao', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4'),
	(14, 'pedro', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4');
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
