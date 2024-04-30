using System;
using System.Collections.Generic;
using System.IO;
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
        return $"Имя: {name}, Местоположение: {location}";
    }
}

class Superhero : Hero
{
    private double agility;

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
        return base.ToString() + $", Ловкость: {agility}";
    }
}

class Agency
{
    private static List<Hero> heroes = new List<Hero>();

    public static void ReadHeroesFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath, Encoding.UTF8); 
            foreach (string line in lines)
            {
                string[] parts = line.Split('/');
                string name = parts[0].Trim();
                string location = parts[1].Trim();

                bool isSuperhero = name.EndsWith("*");
                if (isSuperhero)
                {
                    name = name.TrimEnd('*');
                    double agility = new Random().NextDouble() * 4 + 1; 
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
            Console.WriteLine("Файл не найден.");
        }
    }


    public static void Main(string[] args)
    {
        string filePath = "C:\\Users\\admin\\Desktop\\Programm\\heroes\\heroes\\heroes.txt";
        ReadHeroesFromFile(filePath);

        foreach (Hero hero in heroes)
        {
            if (hero is Superhero)
            {
                Superhero superhero = (Superhero)hero;
                Console.WriteLine($"Супергерой {superhero.GetName()} спасает людей...");
                int peopleInDanger = 100;
                int savedPeople = superhero.SavePeople(peopleInDanger);
                Console.WriteLine($"Спасено {savedPeople} человек\n");
            }
        }

        foreach (Hero hero in heroes)
        {
            Console.WriteLine(hero.ToString());
        }
    }
}
