-- --------------------------------------------------------
-- Servidor:                     127.0.0.1
-- Versão do servidor:           5.7.31 - MySQL Community Server (GPL)
-- OS do Servidor:               Win64
-- HeidiSQL Versão:              11.2.0.6213
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
	IN `subTotal` DOUBLE
)
BEGIN
UPDATE `listadecompras`.`listadecompras` SET `nome`=nome, `quantidade`=quantidade, `preco`= preço, `subTotal` = subTotal WHERE  `id`=id1;
END//
DELIMITER ;

-- Copiando estrutura para procedure listadecompras.cadastrarItem
DROP PROCEDURE IF EXISTS `cadastrarItem`;
DELIMITER //
CREATE PROCEDURE `cadastrarItem`(
	IN `nome` VARCHAR(500),
	IN `quantidade` DOUBLE,
	IN `preco` DOUBLE,
	IN `subTotal` DOUBLE
)
BEGIN
INSERT INTO `listadecompras`.`listadecompras` (`nome`, `quantidade`, `preco`, `subTotal`) VALUES (nome, quantidade, preco, subTotal);
END//
DELIMITER ;

-- Copiando estrutura para tabela listadecompras.listadecompras
DROP TABLE IF EXISTS `listadecompras`;
CREATE TABLE IF NOT EXISTS `listadecompras` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(500) DEFAULT '0',
  `quantidade` double DEFAULT '0',
  `preco` double DEFAULT '0',
  `subTotal` double DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela listadecompras.listadecompras: 8 rows
/*!40000 ALTER TABLE `listadecompras` DISABLE KEYS */;
INSERT INTO `listadecompras` (`id`, `nome`, `quantidade`, `preco`, `subTotal`) VALUES
	(1, 'Arroz 5 kg', 2, 22.5, 45),
	(2, 'Óleo 900 ml', 3, 6.79, 20.37),
	(3, 'Açucar 5 kg', 2, 12.49, 24.98),
	(4, 'Sabão em pó', 2, 8.29, 16.58),
	(5, 'Amaciante 2 L', 1, 5.99, 5.99),
	(6, 'Creme Dental 90 g', 1, 3.69, 3.69),
	(7, 'Leite 1 L', 1, 2.99, 2.99),
	(8, 'Detergente 500 ml', 1, 1.79, 1.79);
/*!40000 ALTER TABLE `listadecompras` ENABLE KEYS */;

-- Copiando estrutura para procedure listadecompras.listaItens
DROP PROCEDURE IF EXISTS `listaItens`;
DELIMITER //
CREATE PROCEDURE `listaItens`()
BEGIN
SELECT l.id AS "Id", l.nome AS "Nome", l.quantidade AS "Quantidade", l.preco AS "Preco", l.subTotal AS "Subtotal" FROM listadecompras AS l;
END//
DELIMITER ;

-- Copiando estrutura para procedure listadecompras.removerItem
DROP PROCEDURE IF EXISTS `removerItem`;
DELIMITER //
CREATE PROCEDURE `removerItem`(
	IN `id1` INT
)
BEGIN
DELETE FROM `listadecompras`.`listadecompras` WHERE `id`=id1;
END//
DELIMITER ;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
