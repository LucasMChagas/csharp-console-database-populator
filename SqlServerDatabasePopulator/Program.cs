using System.Diagnostics;
using System.Text.Json;
using Microsoft.Data.SqlClient;
using SqlServerDatabasePopulator.Models;
using SqlServerDatabasePopulator.Querys;

var stopwatch = new Stopwatch();
stopwatch.Start();

var connectionString = "Server=(localdb)\\mssqllocaldb;Database=Starwars;Trusted_Connection=True;MultipleActiveResultSets=true";
var path = @"D:\Lucas\Projetos\jsonFiles\";

var jsonFile = "StarWarsPlanet.json";
var jsonString = File.ReadAllText(path+jsonFile);
var planets = JsonSerializer.Deserialize<List<Planet>>(jsonString);

var connection = new SqlConnection(connectionString);

Querys.QueryInsertPlanet(planets, connection);

jsonFile = "StarWarsFilms.json"; 
jsonString = File.ReadAllText(path+jsonFile);
var films = JsonSerializer.Deserialize<List<Film>>(jsonString);

Querys.QueryInsertFilms(films, connection);

jsonFile = "StarWarsPeople.json";
jsonString = File.ReadAllText(path+jsonFile);
var characters = JsonSerializer.Deserialize<List<People>>(jsonString);

Querys.QueryInsertPeople(characters, connection);

jsonFile = "StarWarsSpecies.json";
jsonString = File.ReadAllText(path+jsonFile);
var species = JsonSerializer.Deserialize<List<Specie>>(jsonString);

Querys.QueryInsertSpecies(species, connection);

jsonFile = "StarWarsVehicles.json";
jsonString = File.ReadAllText(path+jsonFile);
var vehicles = JsonSerializer.Deserialize<List<Vehicle>>(jsonString);

Querys.QueryInsertVehicles(vehicles, connection);

jsonFile = "StarWarsStarships.json";
jsonString = File.ReadAllText(path+jsonFile);
var starships = JsonSerializer.Deserialize<List<Starship>>(jsonString);

Querys.QueryInsertStarships(starships, connection);

stopwatch.Stop();
Console.WriteLine($"Tempo passado: {stopwatch.Elapsed}");



