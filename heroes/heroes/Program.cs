using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class Hero
{
    private string name;
    private string location;

    public Hero(string name, string location)
    {
        this.name = name;
        this.location = location;
    }

    public string GetName()
    {
        return name;
    }

    public void SetName(string name)
    {
        this.name = name;
    }

    public string GetLocation()
    {
        return location;
    }

    public void SetLocation(string location)
    {
        this.location = location;
    }

    public virtual int SavePeople(int peopleInDanger)
    {
        return (int)(peopleInDanger * 0.95);
    }

    public override string ToString()
    {
        return $"Name: {name}, Location: {location}";
    }
}

class Superhero : Hero
{
    private double agility;
    public static Random random = new Random();

    public Superhero(string name, string location, double agility) : base(name, location)
    {
        this.agility = agility;
    }

    public override int SavePeople(int peopleInDanger)
    {
        return (int)(peopleInDanger * (95 + agility) / 100);
    }

    public override string ToString()
    {
        return base.ToString() + $", Agility: {agility}";
    }
}

class Agency
{
    private static List<Hero> heroes = new List<Hero>();
    private const int BASE_SAVED_PERCENTAGE = 95;
    private const int MAX_AGILITY_BONUS = 4;
    private const int PEOPLE_IN_DANGER = 100;
    private static Random random = new Random();

    public static void ReadHeroesFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath, Encoding.Default);
            foreach (string line in lines)
            {
                string[] parts = line.Split('/'); // разбив строки с помощью /
                string name = parts[0].Trim(); // извлечение первого героя и удаление пробелов 
                string location = parts[1].Trim();

                bool isSuperhero = name.EndsWith("*");
                if (isSuperhero)
                {
                    name = name.TrimEnd('*'); // удаление в конце, если герой
                    double agility = random.NextDouble() * MAX_AGILITY_BONUS + 1;
                    Superhero superhero = new Superhero(name, location, agility);
                    heroes.Add(superhero);
                }
                else
                {
                    Hero hero = new Hero(name, location);
                    heroes.Add(hero);
                }
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    public static void ShowAllHeroes()
    {
        Console.WriteLine("All Heroes:");
        foreach (Hero hero in heroes)
        {
            Console.WriteLine(hero.ToString());
        }
        Console.WriteLine();
    }

    public static void ShowSuperheroes()
    {
        Console.WriteLine("Superheroes:");
        foreach (Hero hero in heroes)
        {
            if (hero is Superhero superhero)
            {
                Console.WriteLine(superhero.ToString());
            }
        }
        Console.WriteLine();
    }

    public static void ShowRescueStats()
    {
        int totalPeopleSaved = 0;
        foreach (Hero hero in heroes)
        {
            totalPeopleSaved += hero.SavePeople(PEOPLE_IN_DANGER);
        }

        double rescuePercentage = (double)totalPeopleSaved / (PEOPLE_IN_DANGER * heroes.Count) * 100;

        Console.WriteLine($"Total People Saved: {totalPeopleSaved}");
        Console.WriteLine($"Rescue Percentage: {rescuePercentage:F2}%\n");
    }

    public static void AddCustomHero()
    {
        Console.WriteLine("Enter hero name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter hero location:");
        string location = Console.ReadLine();

        Console.WriteLine("Is this hero a superhero? (y/n)");
        bool isSuperhero = Console.ReadLine().ToLower() == "y";

        if (isSuperhero)
        {
            Console.WriteLine("Enter hero's agility:");
            double agility;
            if (!double.TryParse(Console.ReadLine(), out agility))
            {
                Console.WriteLine("Invalid agility input. Default agility will be used.");
                agility = random.NextDouble() * MAX_AGILITY_BONUS + 1;
            }
            Superhero superhero = new Superhero(name, location, agility);
            heroes.Add(superhero);
        }
        else
        {
            Hero hero = new Hero(name, location);
            heroes.Add(hero);
        }

        Console.WriteLine("Custom hero added.\n");
    }

    public static void RemoveHeroByName(string name)
    {
        Hero heroToRemove = heroes.FirstOrDefault(h => h.GetName() == name);
        if (heroToRemove != null)
        {
            heroes.Remove(heroToRemove);
            Console.WriteLine($"Hero {name} removed.\n");
        }
        else
        {
            Console.WriteLine($"Hero {name} not found.\n");
        }
    }

    public static void Main(string[] args)
    {
        string filePath = "C:\\Users\\admin\\Desktop\\Programm\\heroes\\heroes\\heroes.txt";
        ReadHeroesFromFile(filePath);

        while (true)
        {
            // Вывод меню
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Show all heroes");
            Console.WriteLine("2. Show superheroes only");
            Console.WriteLine("3. Show rescue statistics");
            Console.WriteLine("4. Add custom hero");
            Console.WriteLine("5. Remove hero by name");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            // Считывание выбора пользователя
            string choice = Console.ReadLine();

            // Обработка выбора
            switch (choice)
            {
                case "1":
                    ShowAllHeroes();
                    break;
                case "2":
                    ShowSuperheroes();
                    break;
                case "3":
                    ShowRescueStats();
                    break;
                case "4":
                    AddCustomHero();
                    break;
                case "5":
                    Console.WriteLine("Enter the name of the hero to remove:");
                    string heroName = Console.ReadLine();
                    RemoveHeroByName(heroName);
                    break;
                case "6":
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
