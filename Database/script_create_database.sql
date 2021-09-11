CREATE DATABASE Veiculos;
GO
USE Veiculos;
GO


CREATE TABLE [Tipos] (
  [TipoId] INT IDENTITY(1,1),
  [Descricao] VARCHAR(30) NOT NULL,
  
  CONSTRAINT [PK_Tipos_TipoId] PRIMARY KEY ([TipoId])
);

CREATE TABLE [Combustiveis] (
  [CombustivelId] INT IDENTITY(1,1),
  [Descricao] VARCHAR(30) NOT NULL,
  
  CONSTRAINT [PK_Combustiveis_CombustivelId] PRIMARY KEY ([CombustivelId])
);

CREATE TABLE [Marcas] (
  [MarcaId] INT IDENTITY(1,1),
  [Descricao] VARCHAR(30) NOT NULL,
  
  CONSTRAINT [PK_Marcas_MarcaId] PRIMARY KEY ([MarcaId])
);

CREATE TABLE [Veiculos] (
  [VeiculoId] INT IDENTITY(1,1),
  [Placa] VARCHAR(7) NOT NULL,
  [MarcaId] INT NOT NULL,
  [Modelo] VARCHAR(50) NOT NULL,  
  [AnoFabricacao] INT NOT NULL,
  [AnoModelo] INT NOT NULL,
  [Cor] VARCHAR(15) NOT NULL,
  [TipoId] INT NOT NULL,  
  [CombustivelId] INT NOT NULL,  

  CONSTRAINT [PK_Veiculos_VeiculoId] PRIMARY KEY ([VeiculoId]),
  CONSTRAINT [FK_Veiculos_CombustivelId] FOREIGN KEY ([CombustivelId]) REFERENCES [Combustiveis]([CombustivelId]),
  CONSTRAINT [FK_Veiculos_TipoId] FOREIGN KEY ([TipoId]) REFERENCES [Tipos]([TipoId]),
  CONSTRAINT [FK_Veiculos_MarcaId] FOREIGN KEY ([MarcaId]) REFERENCES [Marcas]([MarcaId])
);


INSERT INTO Tipos VALUES ('Motocicleta');
INSERT INTO Tipos VALUES ('Automovel');
INSERT INTO Tipos VALUES ('Microonibus');
INSERT INTO Tipos VALUES ('Onibus');
INSERT INTO Tipos VALUES ('Caminhonete');
INSERT INTO Tipos VALUES ('Caminhao');
INSERT INTO Tipos VALUES ('Camioneta');
INSERT INTO Tipos VALUES ('Utilitario');

INSERT INTO Combustiveis VALUES ('Gasolina');
INSERT INTO Combustiveis VALUES ('Etanol');
INSERT INTO Combustiveis VALUES ('Flex');
INSERT INTO Combustiveis VALUES ('Diesel');
INSERT INTO Combustiveis VALUES ('GNV');

INSERT INTO Marcas VALUES ('Toyota');
INSERT INTO Marcas VALUES ('Volkswagen');
INSERT INTO Marcas VALUES ('Ford');
INSERT INTO Marcas VALUES ('Honda');
INSERT INTO Marcas VALUES ('Hyundai');
INSERT INTO Marcas VALUES ('Nissan');
INSERT INTO Marcas VALUES ('Chevrolet');
INSERT INTO Marcas VALUES ('FIAT');