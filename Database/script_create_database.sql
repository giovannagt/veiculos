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

INSERT INTO Veiculos VALUES ('ABC1010', 7, 'Onix 1.4 LTZ', 2019, 2020, 'Branco', 2, 3);

GO

CREATE PROCEDURE [dbo].[sp_listarMarcas]
AS
	SELECT MarcaId, Descricao FROM Marcas 

GO

CREATE PROCEDURE [dbo].[sp_listarTiposVeiculo]
AS
	SELECT TipoVeiculoId, Descricao FROM TiposVeiculo 

GO

CREATE PROCEDURE [dbo].[sp_listarCombustiveis]
AS
	SELECT CombustivelId, Descricao FROM Combustiveis 

GO

CREATE PROCEDURE [dbo].[sp_listarVeiculos]
AS
	SELECT VeiculoId, Placa, Marcas.Descricao as Marca, Modelo, AnoFabricacao, AnoModelo, Cor, TiposVeiculo.Descricao as TipoVeiculo, Combustiveis.Descricao as Combustivel 
	FROM Veiculos 
	LEFT JOIN Marcas ON Marcas.MarcaId = Veiculos.MarcaId
	LEFT JOIN TiposVeiculo ON TiposVeiculo.TipoVeiculoId = Veiculos.TipoVeiculoId
	LEFT JOIN Combustiveis ON Combustiveis.CombustivelId = Veiculos.CombustivelId

GO

CREATE PROCEDURE [dbo].[sp_buscarVeiculo]
(
	@Placa VARCHAR(7) NULL,
	@VeiculoId INT = 0
)
AS
	SELECT VeiculoId, Placa, MarcaId, Modelo, AnoFabricacao, AnoModelo, Cor, TipoVeiculoId, CombustivelId
	FROM Veiculos
	WHERE (@Placa IS NULL OR Placa = @Placa) AND (@VeiculoId = 0 OR VeiculoId = @VeiculoId)


GO

CREATE PROCEDURE [dbo].[sp_incluirVeiculo]
(	
	@Placa VARCHAR(7),
	@MarcaId INT,
	@Modelo VARCHAR(50),
	@AnoFabricacao INT,
	@AnoModelo INT,
	@Cor VARCHAR(15),
	@TipoVeiculoId INT,
	@CombustivelId INT
)
AS
	INSERT INTO Veiculos (Placa, MarcaId, Modelo, AnoFabricacao, AnoModelo, Cor, TipoVeiculoId,	CombustivelId)
	VALUES (@Placa, @MarcaId, @Modelo, @AnoFabricacao, @AnoModelo, @Cor, @TipoVeiculoId, @CombustivelId);
	
	SELECT SCOPE_IDENTITY(); 


GO
	
CREATE PROCEDURE [dbo].[sp_alterarVeiculo]
(	
	@VeiculoId INT,
	@Placa VARCHAR(7),
	@MarcaId INT,
	@Modelo VARCHAR(50),
	@AnoFabricacao INT,
	@AnoModelo INT,
	@Cor VARCHAR(15),
	@TipoVeiculoId INT,
	@CombustivelId INT
)
AS
	UPDATE Veiculos SET Placa = @Placa, MarcaId = @MarcaId, Modelo = @Modelo, AnoFabricacao = @AnoFabricacao, AnoModelo = @AnoModelo, Cor = @Cor, TipoVeiculoId = @TipoVeiculoId, CombustivelId = @CombustivelId
	WHERE VeiculoId = @VeiculoId;

GO

CREATE PROCEDURE [dbo].[sp_excluirVeiculo]
(
	@VeiculoId INT
)
AS
	DELETE FROM Veiculos WHERE VeiculoId = @VeiculoId;
	
	