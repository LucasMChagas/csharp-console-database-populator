CREATE DATABASE [Starwars]

USE[Starwars]

CREATE TABLE[Films]
(
    [Id] INT NOT NULL IDENTITY(1,1),
    [Title] VARCHAR(100),
    [EpisodeId] INT,
    [OpeningCrawl] TEXT,
    [Director] VARCHAR(100),
    [Producer] VARCHAR(100),
    [ReleaseDate] DATE,
    [CreatedAt] DATETIME,
    [UpdatedAt] DATETIME,

    CONSTRAINT[PK_Film] PRIMARY KEY([Id])
);

CREATE TABLE[Planets]
(
    [Id] INT NOT NULL IDENTITY(1,1),
    [Name] VARCHAR(100),
    [RotationPeriod] VARCHAR(100),
    [OrbitalPeriod] VARCHAR(100),
    [Diameter] VARCHAR(100),
    [Climate] VARCHAR(100),
    [Gravity] VARCHAR(100),
    [Terrain] VARCHAR(100),
    [SurfaceWater] VARCHAR(100),
    [Population] VARCHAR(100),
    [CreatedAt] DATETIME,
    [UpdatedAt] DATETIME,

    CONSTRAINT[PK_Planet] PRIMARY KEY([Id]) 
);

CREATE TABLE[Characters]
(
    [Id] INT NOT NULL IDENTITY(1,1),
    [Name] VARCHAR(100),
    [Height] VARCHAR(100),
    [Mass] VARCHAR(100),
    [HomeWorld] INT NOT NULL,
    [HairColor] VARCHAR(100),
    [SkinColor] VARCHAR(100),
    [EyeColor] VARCHAR(100),
    [BirthYear] VARCHAR(100),
    [Gender] VARCHAR(100),
    [CreatedAt] DATETIME,
    [UpdatedAt] DATETIME,

    CONSTRAINT[PK_Character] PRIMARY KEY([Id]),
    CONSTRAINT[FK_Character_Planet] FOREIGN KEY([HomeWorld]) REFERENCES[Planets]([Id])
);

CREATE TABLE[Species]
(
    [Id] INT NOT NULL IDENTITY(1,1),
    [Name] VARCHAR(100),
    [Classification] VARCHAR(100),
    [Designation] VARCHAR(100),
    [AverageHeight] VARCHAR(100),
    [SkinColors] VARCHAR(100),
    [HairColors] VARCHAR(100),
    [HomeWorld] INT NOT NULL,
    [AverageLifespan] VARCHAR(100),
    [Language] VARCHAR(100),
    [CreatedAt] DATETIME,
    [UpdatedAt] DATETIME,

    CONSTRAINT[PK_Specie] PRIMARY KEY([Id]),
    CONSTRAINT[FK_Specie_Planet] FOREIGN KEY ([HomeWorld]) REFERENCES[Planets]([Id])
);

CREATE TABLE[Vehicles]
(
    [Id] INT NOT NULL IDENTITY(1,1),
    [Name] VARCHAR(100),
    [Model] VARCHAR(100),
    [Manufacturer] VARCHAR(100),
    [CostInCredit] VARCHAR(100),
    [lenght] VARCHAR(100),
    [MaxAtmospheringSpeed] VARCHAR(100),
    [Crew] VARCHAR(100),
    [Passengers] VARCHAR(100),
    [CargoCapacity] VARCHAR(100),
    [Consumables] VARCHAR(100),
    [VehicleClass] VARCHAR(100),
    [CreatedAt] DATETIME,
    [UpdatedAt] DATETIME,

    CONSTRAINT[PK_Vehicles] PRIMARY KEY([Id]),
);

CREATE TABLE[Starships]
(
    [Id] INT NOT NULL IDENTITY(1,1),
    [Name] VARCHAR(100),
    [Model] VARCHAR(100),
    [Manufacturer] VARCHAR(100),
    [CostInCredit] VARCHAR(100),
    [lenght] VARCHAR(100),
    [MaxAtmospheringSpeed] VARCHAR(100),
    [Crew] VARCHAR(100),
    [Passengers] VARCHAR(100),
    [CargoCapacity] VARCHAR(100),
    [Consumables] VARCHAR(100),
    [HyperdriveRating] VARCHAR(100),
    [MGLT] VARCHAR(100),
    [StarshipClass] VARCHAR(100),
    [CreatedAt] DATETIME,
    [UpdatedAt] DATETIME,

    CONSTRAINT[PK_Starship] PRIMARY KEY([Id]),
);

CREATE TABLE[FilmStarships]
(
    [FilmId] INT NOT NULL,
    [StarshipId] INT NOT NULL,

    CONSTRAINT[PK_FilmStarships] PRIMARY KEY([FilmId],[StarshipId]),
    CONSTRAINT[FK_FilmStarships_Films_FilmId] FOREIGN KEY([FilmId]) REFERENCES [Films]([Id]),
    CONSTRAINT[FK_FilmStarships_Starships_StarshipId] FOREIGN KEY([StarshipId]) REFERENCES [Starships]([Id])
);

CREATE TABLE[FilmSpecies]
(
    [FilmId] INT NOT NULL,
    [SpecieId] INT NOT NULL,

    CONSTRAINT[PK_FilmSpecies] PRIMARY KEY([FilmId],[SpecieId]),
    CONSTRAINT[FK_FilmsSpecies_Films_FilmId] FOREIGN KEY([FilmId]) REFERENCES [Films]([Id]),
    CONSTRAINT[FK_FilmsSpecies_Species_SpecieId] FOREIGN KEY([SpecieId]) REFERENCES [Species]([Id])
);

CREATE TABLE[FilmPlanets]
(
    [IdFilm] INT NOT NULL,
    [IdPlanet] INT NOT NULL,

    CONSTRAINT[PK_FilmPlanets] PRIMARY KEY([IdFilm],[IdPlanet]),
    CONSTRAINT[FK_FilmPlanets_Film_FilmId] FOREIGN KEY([IdFilm]) REFERENCES [Films]([Id]),
    CONSTRAINT[FK_FilmPlanets_Planet_PlanetId] FOREIGN KEY([IdPlanet]) REFERENCES [Planets]([Id])
);

CREATE TABLE[FilmVehicles]
(
    [IdFilm] INT NOT NULL,
    [IdVehicle] INT NOT NULL,

    CONSTRAINT[PK_FilmVehicles] PRIMARY KEY([IdFilm],[IdVehicle]),
    CONSTRAINT[FK_FilmVehicles_Films_FilmId] FOREIGN KEY([IdFilm]) REFERENCES [Films]([Id]),
    CONSTRAINT[FK_FilmVehicles_Vehicles_VehicleId] FOREIGN KEY([IdVehicle]) REFERENCES [Vehicles]([Id])
);

CREATE TABLE[FilmCharacters]
(
    [IdFilm] INT NOT NULL,
    [IdCharacter] INT NOT NULL,

    CONSTRAINT[PK_FilmCharacters] PRIMARY KEY([IdFilm],[IdCharacter]),
    CONSTRAINT[FK_FilmCharacters_Films_FilmId] FOREIGN KEY([IdFilm]) REFERENCES [Films]([Id]),
    CONSTRAINT[FK_FilmCharacters_Characters_CharacterId] FOREIGN KEY([IdCharacter]) REFERENCES [Characters]([Id])
);

CREATE TABLE[SpecieCharacters]
(
    [IdSpecie] INT NOT NULL,
    [IdCharacter] INT NOT NULL,

    CONSTRAINT[PK_SpecieCharacters] PRIMARY KEY([IdSpecie],[IdCharacter]),
    CONSTRAINT[FK_SpecieCharacters_Species_SpecieId] FOREIGN KEY([IdSpecie]) REFERENCES [Species]([Id]),
    CONSTRAINT[FK_SpecieCharacters_Characters_CharacterId] FOREIGN KEY([IdCharacter]) REFERENCES [Characters]([Id])
);

CREATE TABLE[CharacterStarships]
(
    [IdCharacter] INT NOT NULL,
    [IdStarship] INT NOT NULL,

    CONSTRAINT[PK_CharacterStarships] PRIMARY KEY([IdCharacter],[IdStarship]),
    CONSTRAINT[FK_CharacterStarships_Characters_CharacterId] FOREIGN KEY([IdCharacter]) REFERENCES [Characters]([Id]),
    CONSTRAINT[FK_CharacterStarships_Starships_StarshipsId] FOREIGN KEY([IdStarship]) REFERENCES [Starships]([Id])
);

CREATE TABLE[CharacterVehicles]
(
    [IdCharacter] INT NOT NULL,
    [IdVehicle] INT NOT NULL,

    CONSTRAINT[PK_CharacterVehicles] PRIMARY KEY([IdCharacter],[IdVehicle]),
    CONSTRAINT[FK_CharacterVehicles_Characters_CharacterId] FOREIGN KEY([IdCharacter]) REFERENCES [Characters]([Id]),
    CONSTRAINT[FK_CharacterVehicles_Vehiicles_VehiclesId] FOREIGN KEY([IdVehicle]) REFERENCES [Vehicles]([Id])
);




