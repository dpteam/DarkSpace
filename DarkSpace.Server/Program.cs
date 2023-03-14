using DarkSpace.Core.Generators;
using System.Diagnostics;
using System.Text.Json;
using static DarkSpace.Core.Generators.UniverseGenerator;

namespace DarkSpace
{
    internal class Program
    {
        static void Main()
        {
            var ServerPort = 20042;
            Trace.AutoFlush = true;
            Trace.Listeners.Clear();
            Trace.Listeners.Add(new ConsoleTraceListener());
            Trace.Listeners.Add(new TextWriterTraceListener(System.IO.Path.GetFileNameWithoutExtension(typeof(Program).Assembly.GetName().Name) + "-server.log"));
            Process currentProcess = Process.GetCurrentProcess();
            currentProcess.PriorityClass = ProcessPriorityClass.High;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Trace.WriteLine($"Server started at port {ServerPort}");

            // Создаем корабль, героя и деньги
            Spaceship myShip = new(500, 300, "Pretty Good Ship", "123-456-789");
            Character myHero = new("Jane", "Doe", 25, "Human");
            Money myMoney = new(1000, "credits");

            // Записываем данные в JSON-файл
            WriteDataToJson(myShip, myHero, myMoney, "game_data.json");

            // Читаем данные из JSON-файла
            Tuple<Spaceship, Character, Money> myData = ReadDataFromJson("game_data.json");

            // Выводим информацию на консоль
            Console.WriteLine("Spaceship:");
            Console.WriteLine($"Name: {myData.Item1.Name}");
            Console.WriteLine($"Fuel: {myData.Item1.Fuel}");
            Console.WriteLine($"Max Speed: {myData.Item1.MaxSpeed}");
            Console.WriteLine($"Registration Number: {myData.Item1.RegistrationNumber}");
            Console.WriteLine();
            Console.WriteLine("Hero:");
            Console.WriteLine($"First Name: {myData.Item2.FirstName}");
            Console.WriteLine($"Last Name: {myData.Item2.LastName}");
            Console.WriteLine($"Age: {myData.Item2.Age}");
            Console.WriteLine($"Race: {myData.Item2.Race}");
            Console.WriteLine();
            Console.WriteLine("Money:");
            Console.WriteLine($"Amount: {myData.Item3.Amount}");
            Console.WriteLine($"Currency: {myData.Item3.Currency}");

            SpacecraftBuilder builder = new SpacecraftBuilder();
            Spacecraft spacecraft = builder
            .SetPart(new Hull("Aluminum", 100, 5))
            .SetPart(new Engine("Ion Thruster", 200, 10))
            .SetPart(new Weapon("Plasma Cannon", 50, 3000))
            .Build();

            Console.WriteLine(spacecraft);
        }

        static void WriteDataToJson(Spaceship myShip, Character myHero, Money myMoney, string filename)
        {
            Dictionary<string, object> dataDict = new()
            {
                { "Spaceship", myShip },
                { "Hero", myHero },
                { "Money", myMoney }
            };

            string jsonData = JsonSerializer.Serialize(dataDict);
            File.WriteAllText(filename, jsonData);
        }

        static Tuple<Spaceship, Character, Money> ReadDataFromJson(string filename)
        {
            string jsonData = File.ReadAllText(filename);
            Dictionary<string, object> dataDict = JsonSerializer.Deserialize <Dictionary<string,object>>(jsonData);

            Spaceship myShip = JsonSerializer.Deserialize<Spaceship>(dataDict["Spaceship"].ToString());
            Character myHero = JsonSerializer.Deserialize<Character>(dataDict["Hero"].ToString());
            Money myMoney = JsonSerializer.Deserialize<Money>(dataDict["Money"].ToString());

            return Tuple.Create(myShip, myHero, myMoney);
        }

        class Spaceship
        {
            public int Fuel { get; set; }
            public int MaxSpeed { get; set; }
            public string Name { get; set; }
            public string RegistrationNumber { get; set; }

            public Spaceship(int fuel, int maxSpeed, string name, string registrationNumber)
            {
                Fuel = fuel;
                MaxSpeed = maxSpeed;
                Name = name;
                RegistrationNumber = registrationNumber;
            }
        }

        class Character
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string Race { get; set; }

            public Character(string firstName, string lastName, int age, string race)
            {
                FirstName = firstName;
                LastName = lastName;
                Age = age;
                Race = race;
            }
        }

        class Money
        {
            public int Amount { get; set; }
            public string Currency { get; set; }

            public Money(int amount, string currency)
            {
                Amount = amount;
                Currency = currency;
            }
        }

        private static void NewGame()
        {
            Universe universe = UniverseGenerator.GenerateUniverse(3, 4, 5);
            UniverseGenerator.SaveUniverseToJson(universe, "universe.json");
        }

        private static void LoadGame()
        {
            _ = UniverseGenerator.LoadUniverseFromJson("universe.json");
        }

        class Spacecraft
        {
            public Hull Hull { get; set; }
            public Engine Engine { get; set; }
            public Weapon Weapon { get; set; }

            public Spacecraft(Hull hull, Engine engine, Weapon weapon)
            {
                Hull = hull;
                Engine = engine;
                Weapon = weapon;
            }

            public override string ToString()
            {
                return $"Spacecraft:\nHull: {Hull}\nEngine: {Engine}\nWeapon: {Weapon}";
            }
        }

        class SpacecraftBuilder
        {
            private Hull hull;
            private Engine engine;
            private Weapon weapon;

            public SpacecraftBuilder SetPart(Hull hull)
            {
                this.hull = hull;
                return this;
            }

            public SpacecraftBuilder SetPart(Engine engine)
            {
                this.engine = engine;
                return this;
            }

            public SpacecraftBuilder SetPart(Weapon weapon)
            {
                this.weapon = weapon;
                return this;
            }

            public Spacecraft Build()
            {
                return new Spacecraft(hull, engine, weapon);
            }
        }

        class Hull
        {
            public string Material { get; set; }
            public int Integrity { get; set; }
            public int Mass { get; set; }

            public Hull(string material, int integrity, int mass)
            {
                Material = material;
                Integrity = integrity;
                Mass = mass;
            }

            public override string ToString()
            {
                return $"Material: {Material}, Integrity: {Integrity}, Mass: {Mass}";
            }
        }

        class Engine
        {
            public string Type { get; set; }
            public int Power { get; set; }
            public int Mass { get; set; }

            public Engine(string type, int power, int mass)
            {
                Type = type;
                Power = power;
                Mass = mass;
            }

            public override string ToString()
            {
                return $"Type: {Type}, Power: {Power}, Mass: {Mass}";
            }
        }

        class Weapon
        {
            public string Type { get; set; }
            public int Damage { get; set; }
            public int Range { get; set; }

            public Weapon(string type, int damage, int range)
            {
                Type = type;
                Damage = damage;
                Range = range;
            }

            public override string ToString()
            {
                return $"Type: {Type}, Damage: {Damage}, Range: {Range}";
            }
        }

        class Race
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public double Strength { get; set; }
            public double Intelligence { get; set; }
            public double Agility { get; set; }
            public double Charisma { get; set; }

            public Race(string name, string description, double strength, double intelligence, double agility, double charisma)
            {
                Name = name;
                Description = description;
                Strength = strength;
                Intelligence = intelligence;
                Agility = agility;
                Charisma = charisma;
            }
        }

        // Класс, представляющий город
        class City
        {
            public string Name { get; set; }
            public double Population { get; set; }
            public double Wealth { get; set; }
            public double Safety { get; set; }
            public Religion Religion { get; set; }
            public Community Community { get; set; }

            public City(string name, double population, double wealth, double safety, Religion religion, Community community)
            {
                Name = name;
                Population = population;
                Wealth = wealth;
                Safety = safety;
                Religion = religion;
                Community = community;
            }
        }

        // Класс, представляющий инфраструктуру
        class Infrastructure
        {
            public double Transportation { get; set; }
            public double Education { get; set; }
            public double Healthcare { get; set; }
            public Economy Economy { get; set; }

            public Infrastructure(double transportation, double education, double healthcare, Economy economy)
            {
                Transportation = transportation;
                Education = education;
                Healthcare = healthcare;
                Economy = economy;
            }
        }

        // Класс, представляющий экономику
        class Economy
        {
            public double GDP { get; set; }
            public double Inflation { get; set; }
            public double Growth { get; set; }
            public double Debt { get; set; }

            public Economy(double gdp, double inflation, double growth, double debt)
            {
                GDP = gdp;
                Inflation = inflation;
                Growth = growth;
                Debt = debt;
            }
        }
        
        // Класс, представляющий религию
        class Religion
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public double Believers { get; set; }

            public Religion(string name, string description, double believers)
            {
                Name = name;
                Description = description;
                Believers = believers;
            }
        }

        public class Community
        {
            //public List<City>? Cities { get; set; }

            public double Happiness { get; set; }

            public static Community Generate(int numCities)
            {
                var community = new Community();
                /*community.Cities = new List<City>(numCities);
                for (int i = 0; i < numCities; i++)
                {
                    community.Cities.Add(City.Generate());
                }
                community.Happiness = Random.Range(0f, 1f);*/
                return community;
            }
        }
    }
}