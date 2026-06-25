
DROP TABLE IF EXISTS `alumnos`;

  `idalumno` varchar(20) CHARACTER SET armscii8 NOT NULL,
  `idcarrera` varchar(20) NOT NULL,
  `nombre` varchar(50) CHARACTER SET armscii8 NOT NULL,
  `apellidos` varchar(50) NOT NULL,
  `telefono` varchar(20) NOT NULL,
  `direccion` varchar(100) NOT NULL,
  PRIMARY KEY (`idalumno`),
  KEY `alumnos_ibfk_1` (`idcarrera`),
  CONSTRAINT `alumnos_ibfk_1` FOREIGN KEY (`idcarrera`) REFERENCES `carreras` (`IdCarrera`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `alumnos` WRITE;

INSERT INTO `alumnos` VALUES ('201212071','20121002','Edgar Daniel','Perez  Gomez','9841256548','Puebla Mexico');

UNLOCK TABLES;


DROP TABLE IF EXISTS `carreras`;

CREATE TABLE `carreras` (
  `idCarrera` varchar(20) NOT NULL,
  `nombre` varchar(50) NOT NULL,
  PRIMARY KEY (`idCarrera`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


LOCK TABLES `carreras` WRITE;
/*!40000 ALTER TABLE `carreras` DISABLE KEYS */;
INSERT INTO `carreras` VALUES ('20121001','Informatica'),('20121002','Enfermeria'),('20121003','Zootecnia'),('20121004','Biologia'),('20121005','Forestal');

UNLOCK TABLES;
