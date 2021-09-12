CREATE DATABASE Veiculos;
GO
USE Veiculos;
GO


CREATE TABLE [TiposVeiculo] (
  [TipoVeiculoId] INT IDENTITY(1,1),
  [Descricao] VARCHAR(30) NOT NULL,
  
  CONSTRAINT [PK_TiposVeiculo_TipoVeiculoId] PRIMARY KEY ([TipoVeiculoId])
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
  [TipoVeiculoId] INT NOT NULL,  
  [CombustivelId] INT NOT NULL,  

  CONSTRAINT [PK_Veiculos_VeiculoId] PRIMARY KEY ([VeiculoId]),
  CONSTRAINT [FK_Veiculos_CombustivelId] FOREIGN KEY ([CombustivelId]) REFERENCES [Combustiveis]([CombustivelId]),
  CONSTRAINT [FK_Veiculos_TipoVeiculoId] FOREIGN KEY ([TipoVeiculoId]) REFERENCES [TiposVeiculo]([TipoVeiculoId]),
  CONSTRAINT [FK_Veiculos_MarcaId] FOREIGN KEY ([MarcaId]) REFERENCES [Marcas]([MarcaId])
);


INSERT INTO TiposVeiculo VALUES ('Motocicleta');
INSERT INTO TiposVeiculo VALUES ('Automovel');
INSERT INTO TiposVeiculo VALUES ('Microonibus');
INSERT INTO TiposVeiculo VALUES ('Onibus');
INSERT INTO TiposVeiculo VALUES ('Caminhonete');
INSERT INTO TiposVeiculo VALUES ('Caminhao');
INSERT INTO TiposVeiculo VALUES ('Camioneta');
INSERT INTO TiposVeiculo VALUES ('Utilitario');

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

GO

CREATE PROCEDURE [dbo].[sp_listarMarcas]
AS
	SELECT * FROM Marcas 

GO

CREATE PROCEDURE [dbo].[sp_listarTiposVeiculo]
AS
	SELECT * FROM TiposVeiculo 

GO

CREATE PROCEDURE [dbo].[sp_listarCombustiveis]
AS
	SELECT * FROM Combustiveis 

GO

CREATE PROCEDURE [dbo].[sp_listarVeiculos]
AS
	SELECT * FROM Veiculos 