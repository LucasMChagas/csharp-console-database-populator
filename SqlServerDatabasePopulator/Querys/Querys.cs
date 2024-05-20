using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;
using SqlServerDatabasePopulator.Models;

namespace SqlServerDatabasePopulator.Querys;
public static class Querys
{
    public static void QueryInsertPlanet(List<Planet> planets, SqlConnection connection)
    {
        var query = @"SET IDENTITY_INSERT dbo.Planets ON;
                                            
                INSERT INTO dbo.Planets(Id,Name,RotationPeriod,OrbitalPeriod,Diameter,Climate,Gravity,Terrain,SurfaceWater,Population,CreatedAt,UpdatedAt) 
                VALUES(@id, 
                @name, 
                @rotationPeriod, 
                @orbitalPeriod, 
                @diameter, 
                @climate, 
                @gravity, 
                @terrain, 
                @surfaceWater, 
                @population, 
                @created, 
                @edited);
                
                SET IDENTITY_INSERT dbo.Planets OFF;";

        using var command = new SqlCommand(query, connection);
        connection.Open();
        foreach (var planet in planets)
        {
            command.Parameters.Add(new SqlParameter("@id", planet.id));
            command.Parameters.Add(new SqlParameter("@name", planet.name));
            command.Parameters.Add(new SqlParameter("@rotationPeriod", planet.rotation_period));
            command.Parameters.Add(new SqlParameter("@orbitalPeriod", planet.orbital_period));
            command.Parameters.Add(new SqlParameter("@diameter", planet.diameter));
            command.Parameters.Add(new SqlParameter("@climate", planet.climate));
            command.Parameters.Add(new SqlParameter("@gravity", planet.gravity));
            command.Parameters.Add(new SqlParameter("@terrain", planet.terrain));
            command.Parameters.Add(new SqlParameter("@surfaceWater", planet.surface_water));
            command.Parameters.Add(new SqlParameter("@population", planet.population));
            command.Parameters.Add(new SqlParameter("@created", planet.created));
            command.Parameters.Add(new SqlParameter("@edited", planet.edited));
            command.ExecuteNonQuery();
            command.Parameters.Clear();            
        };
        connection.Close();
    }
    public static void QueryInsertFilms(List<Film> films, SqlConnection connection)
    {
        var query = @"SET IDENTITY_INSERT dbo.Films ON;
                      
                INSERT INTO dbo.Films(Id,Title,EpisodeId,OpeningCrawl,Director,Producer,ReleaseDate,CreatedAt,UpdatedAt) 
                VALUES(@id, 
                @title, 
                @episodeId, 
                @openingCrawl, 
                @director, 
                @producer, 
                @releaseDate,                 
                @created, 
                @edited);
                
                SET IDENTITY_INSERT dbo.Films OFF;
                ";

        using var command = new SqlCommand(query, connection);
        connection.Open();
        foreach (var film in films)
        {
            command.Parameters.Add(new SqlParameter("@id", film.id));
            command.Parameters.Add(new SqlParameter("@title", film.title));
            command.Parameters.Add(new SqlParameter("@episodeId", film.episode_id));
            command.Parameters.Add(new SqlParameter("@openingCrawl", film.opening_crawl));
            command.Parameters.Add(new SqlParameter("@director", film.director));
            command.Parameters.Add(new SqlParameter("@producer", film.producer));
            command.Parameters.Add(new SqlParameter("@releaseDate", film.release_date));
            command.Parameters.Add(new SqlParameter("@created", film.created));
            command.Parameters.Add(new SqlParameter("@edited", film.edited));
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        };
        connection.Close();
    }
    public static void QueryInsertPeople(List<People> people, SqlConnection connection)
    {
        var query = @"SET IDENTITY_INSERT dbo.Characters ON;
                      
                INSERT INTO dbo.Characters(Id,Name,Height,Mass,HomeWorld,HairColor,SkinColor,EyeColor,BirthYear,Gender,CreatedAt,UpdatedAt) 
                VALUES(@id, 
                @name, 
                @height,
                @mass, 
                @homeworld, 
                @hairColor, 
                @skinColor, 
                @eyeColor, 
                @birthYear, 
                @gender, 
                @created, 
                @edited);
                
                SET IDENTITY_INSERT dbo.Characters OFF;";
        string pattern = @"\/(\d+)\/";
        using var command = new SqlCommand(query, connection);
        connection.Open();
        foreach (var person in people)
        {
            command.Parameters.Add(new SqlParameter("@id", person.id));
            command.Parameters.Add(new SqlParameter("@name", person.name));
            command.Parameters.Add(new SqlParameter("@height", person.height));
            command.Parameters.Add(new SqlParameter("@mass", person.mass));
            Match match = Regex.Match(person.homeworld, pattern);
            command.Parameters.Add(new SqlParameter("@homeworld", int.Parse(match.Groups[1].Value)));
            command.Parameters.Add(new SqlParameter("@hairColor", person.hair_color));
            command.Parameters.Add(new SqlParameter("@skinColor", person.skin_color));
            command.Parameters.Add(new SqlParameter("@eyeColor", person.eye_color));
            command.Parameters.Add(new SqlParameter("@birthYear", person.birth_year));
            command.Parameters.Add(new SqlParameter("@gender", person.gender));
            command.Parameters.Add(new SqlParameter("@created", person.created));
            command.Parameters.Add(new SqlParameter("@edited", person.edited));
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        };
        connection.Close();
    }
    public static void QueryInsertSpecies(List<Specie> species, SqlConnection connection)
    {
        var query = @"SET IDENTITY_INSERT dbo.Species ON;
                      
                INSERT INTO dbo.Species(Id,Name,Classification,Designation,AverageHeight,SkinColors,HairColors,Homeworld,AverageLifespan,Language,CreatedAt,UpdatedAt) 
                VALUES(@id, 
                @name, 
                @classification,
                @designation,
                @averageHeight, 
                @skinColor, 
                @hairColor, 
                @homeworld, 
                @averageLifespan, 
                @language, 
                @created, 
                @edited);
                
                SET IDENTITY_INSERT dbo.Species OFF;";
        string pattern = @"\/(\d+)\/";
        using var command = new SqlCommand(query, connection);
        connection.Open();
        foreach (var specie in species)
        {
            command.Parameters.Add(new SqlParameter("@id", specie.id));            
            command.Parameters.Add(new SqlParameter("@name", specie.name));            
            command.Parameters.Add(new SqlParameter("@classification", specie.classification));            
            command.Parameters.Add(new SqlParameter("@designation", specie.designation));            
            command.Parameters.Add(new SqlParameter("@averageHeight", specie.average_height));            
            command.Parameters.Add(new SqlParameter("@skinColor", specie.skin_colors));            
            command.Parameters.Add(new SqlParameter("@hairColor", specie.hair_colors));
            Match match = Regex.Match(specie.homeworld, pattern);            
            command.Parameters.Add(new SqlParameter("@homeworld", int.Parse(match.Groups[1].Value)));            
            command.Parameters.Add(new SqlParameter("@averageLifespan", specie.average_lifespan));            
            command.Parameters.Add(new SqlParameter("@language", specie.language));            
            command.Parameters.Add(new SqlParameter("@created", specie.created));            
            command.Parameters.Add(new SqlParameter("@edited", specie.edited));                        
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        };
        connection.Close();
    }
    public static void QueryInsertVehicles(List<Vehicle> vehicles, SqlConnection connection)
    {
        var query = @"SET IDENTITY_INSERT dbo.Vehicles ON;
                      
                INSERT INTO dbo.Vehicles(Id,Name,Model,Manufacturer,CostInCredit,lenght,MaxAtmospheringSpeed,Crew,Passengers,CargoCapacity,Consumables,VehicleClass,CreatedAt,UpdatedAt) 
                VALUES(@id, 
                @name,                
                @model, 
                @manufacturer,
                @costInCredit, 
                @lenght, 
                @maxAtmospheringSpeed, 
                @crew, 
                @passengers, 
                @cargoCapacity, 
                @Consumables, 
                @vehicleClass, 
                @created, 
                @edited);
                
                SET IDENTITY_INSERT dbo.Vehicles OFF;";

        using var command = new SqlCommand(query, connection);
        connection.Open();
        foreach (var vehicle in vehicles)
        {
            command.Parameters.Add(new SqlParameter("@id", vehicle.id));            
            command.Parameters.Add(new SqlParameter("@name", vehicle.name));            
            command.Parameters.Add(new SqlParameter("@model", vehicle.model));            
            command.Parameters.Add(new SqlParameter("@manufacturer", vehicle.manufacturer));            
            command.Parameters.Add(new SqlParameter("@costInCredit", vehicle.cost_in_credits));            
            command.Parameters.Add(new SqlParameter("@lenght", vehicle.length));            
            command.Parameters.Add(new SqlParameter("@maxAtmospheringSpeed", vehicle.max_atmosphering_speed));            
            command.Parameters.Add(new SqlParameter("@crew", vehicle.crew));            
            command.Parameters.Add(new SqlParameter("@passengers", vehicle.passengers));            
            command.Parameters.Add(new SqlParameter("@cargoCapacity", vehicle.cargo_capacity));            
            command.Parameters.Add(new SqlParameter("@Consumables", vehicle.consumables));            
            command.Parameters.Add(new SqlParameter("@vehicleClass", vehicle.vehicle_class));            
            command.Parameters.Add(new SqlParameter("@created", vehicle.created));            
            command.Parameters.Add(new SqlParameter("@edited", vehicle.edited));                        
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        };
        connection.Close();
    }

    public static void QueryInsertStarships(List<Starship> starships, SqlConnection connection)
    {
        var query = @"SET IDENTITY_INSERT dbo.Starships ON;
                      
                INSERT INTO dbo.Starships(Id,Name,Model,Manufacturer,CostInCredit,lenght,MaxAtmospheringSpeed,Crew,Passengers,CargoCapacity,Consumables,HyperdriveRating,MGLT,StarshipClass,CreatedAt,UpdatedAt) 
                VALUES(@id, 
                @name,                 
                @model, 
                @manufacturer,
                @costInCredits, 
                @lenght, 
                @maxAtmospheringSpeed, 
                @crew, 
                @passengers, 
                @cargoCapacity, 
                @Consumables,
                @hyperdriveRating,
                @mglt, 
                @starshipClass, 
                @created, 
                @edited);
                
                SET IDENTITY_INSERT dbo.Starships OFF;";

        using var command = new SqlCommand(query, connection);
        connection.Open();
        foreach (var starship in starships)
        {
            command.Parameters.Add(new SqlParameter("@id", starship.id));            
            command.Parameters.Add(new SqlParameter("@name", starship.name));            
            command.Parameters.Add(new SqlParameter("@model", starship.model));            
            command.Parameters.Add(new SqlParameter("@manufacturer", starship.manufacturer));            
            command.Parameters.Add(new SqlParameter("@costInCredits", starship.cost_in_credits));            
            command.Parameters.Add(new SqlParameter("@lenght", starship.length));            
            command.Parameters.Add(new SqlParameter("@maxAtmospheringSpeed", starship.max_atmosphering_speed));            
            command.Parameters.Add(new SqlParameter("@crew", starship.crew));            
            command.Parameters.Add(new SqlParameter("@passengers", starship.passengers));            
            command.Parameters.Add(new SqlParameter("@cargoCapacity", starship.cargo_capacity));            
            command.Parameters.Add(new SqlParameter("@Consumables", starship.consumables));            
            command.Parameters.Add(new SqlParameter("@hyperdriveRating", starship.hyperdrive_rating));            
            command.Parameters.Add(new SqlParameter("@mglt", starship.MGLT));            
            command.Parameters.Add(new SqlParameter("@starshipClass", starship.starship_class));                       
            command.Parameters.Add(new SqlParameter("@created", starship.created));            
            command.Parameters.Add(new SqlParameter("@edited", starship.edited));                        
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        };
        connection.Close();
    }
}

