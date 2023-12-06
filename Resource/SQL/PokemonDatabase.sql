USE master
GO
DROP DATABASE Pokemon;
GO
CREATE DATABASE Pokemon;
GO
USE Pokemon;
GO

CREATE TABLE PokemonSpecie(
	NationalNo INT IdENTITY(1,1) PRIMARY KEY,
	SpecieName NVARCHAR(50),
	Type1 INT,
	Type2 INT,
	BaseHp INT,
	BaseAtk INT,
	BaseDef INT,
	BaseSpA INT,
	BaseSpD INT,
	BaseSpe INT,
	[Description] NVARCHAR(500),
);

CREATE TABLE Pokemon(
	PokemonId INT IdENTITY(1,1) PRIMARY KEY,
	PokemonName NVARCHAR(50),
	PokemonLevel INT,
	IvHp INT,
	IvAtk INT,
	IvDef INT,
	IvSpA INT,
	IvSpD INT,
	IvSpe INT,
	EvHp INT,
	EvAtk INT,
	EvDef INT,
	EvSpA INT,
	EvSpD INT,
	EvSpe INT,
	Nature INT,
	
);

CREATE TABLE PokemonMove(
	MoveId INT IdENTITY(1,1) PRIMARY KEY,
	MoveName NVARCHAR(50),
	Damage INT,
	MoveType INT,
	[Description] NVARCHAR(500),
);

CREATE TABLE PokemonLearnedMove(
	PokemonId INT  NOT NULL,
	MoveId INT  NOT NULL,
	FOREIGN KEY (PokemonId) REFERENCES Pokemon(PokemonId),
	FOREIGN KEY (MoveId) REFERENCES PokemonMove(MoveId)
   
);

CREATE TABLE PokemonLearnableMove(
	NationalNo INT  NOT NULL,
	MoveId INT  NOT NULL,
	FOREIGN KEY (NationalNo) REFERENCES PokemonSpecie(NationalNo),
	FOREIGN KEY (MoveId) REFERENCES PokemonMove(MoveId)
   
);