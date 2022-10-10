CREATE TABLE `endereco` (
  `enderecoId` int NOT NULL AUTO_INCREMENT,
  `pessoaId` int NOT NULL,
  `logradouro` varchar(45) DEFAULT NULL,
  `numero` int DEFAULT NULL,
  `bairro` varchar(45) DEFAULT NULL,
  `cidade` varchar(45) DEFAULT NULL,
  `uf` varchar(2) DEFAULT NULL,
  `cadastro` datetime DEFAULT NULL,
  `alteracao` datetime DEFAULT NULL,
  PRIMARY KEY (`enderecoId`),
  KEY `pessoaId_idx` (`pessoaId`),
  CONSTRAINT `pessoaId` FOREIGN KEY (`pessoaId`) REFERENCES `pessoas` (`pessoaId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;


CREATE TABLE `pessoas` (
  `pessoaId` int NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) DEFAULT NULL,
  `dataNascimento` varchar(45) NOT NULL,
  `idade` int NOT NULL,
  `email` varchar(45) DEFAULT NULL,
  `telefone` varchar(45) DEFAULT NULL,
  `celular` varchar(45) DEFAULT NULL,
  `cadastro` datetime DEFAULT NULL,
  `alteracao` datetime DEFAULT NULL,
  PRIMARY KEY (`pessoaId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

CREATE TABLE `users` (
  `id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  `role` int NOT NULL,
  `status` varchar(45) DEFAULT NULL,
  `cadastro` datetime DEFAULT NULL,
  `alteracao` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3