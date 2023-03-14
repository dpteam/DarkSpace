using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.IO;

namespace DarkSpace.Core.Generators
{
    public class UniverseGenerator
    {
        private static readonly Random random = new();

        public class Universe
        {
            public List<Galaxy> Galaxies { get; set; }
        }

        public class Galaxy
        {
            public string Name { get; set; }
            public List<StarSystem> Systems { get; set; }
        }

        public class StarSystem
        {
            public string Name { get; set; }
            public List<Planet> Planets { get; set; }
        }

        public class Planet
        {
            public string Name { get; set; }
            public double Mass { get; set; }
            public double Radius { get; set; }
            public double DistanceFromStar { get; set; }
            public bool HasAtmosphere { get; set; }
        }

        public static Universe GenerateUniverse(int galaxyCount, int systemCount, int planetCount)
        {
            Universe universe = new()
            {
                Galaxies = new List<Galaxy>()
            };

            for (int gi = 0; gi < galaxyCount; gi++)
            {
                Galaxy galaxy = new()
                {
                    Name = $"Galaxy-{gi}",
                    Systems = new List<StarSystem>()
                };
                universe.Galaxies.Add(galaxy);

                for (int si = 0; si < systemCount; si++)
                {
                    StarSystem system = new()
                    {
                        Name = $"StarSystem-{gi}-{si}",
                        Planets = new List<Planet>()
                    };
                    galaxy.Systems.Add(system);

                    for (int pi = 0; pi < planetCount; pi++)
                    {
                        Planet planet = new()
                        {
                            Name = $"Planet-{gi}-{si}-{pi}",
                            Mass = random.NextDouble() * 10 + 1,
                            Radius = random.NextDouble() * 5 + 1,
                            DistanceFromStar = random.NextDouble() * 10 + 1,
                            HasAtmosphere = random.Next(2) == 0
                        };
                        system.Planets.Add(planet);
                    }
                }
            }

            return universe;
        }

        public static void SaveUniverseToJson(Universe universe, string filename)
        {
            JsonSerializerOptions serializerOptions = new()
            {
                WriteIndented = true,
                IgnoreNullValues = true,
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
            };

            string jsonString = JsonSerializer.Serialize(universe, serializerOptions);
            File.WriteAllText(filename, jsonString);
        }

        public static Universe LoadUniverseFromJson(string filename)
        {
            string jsonString = File.ReadAllText(filename);
            JsonSerializerOptions serializerOptions = new()
                { Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) } };

            Universe universe = JsonSerializer.Deserialize<Universe>(jsonString, serializerOptions);
            return universe;
        }
    }
}
