using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static Dictionary<string, string> LoadDictionary(string filePath)
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        using (StreamReader file = new StreamReader(filePath, System.Text.Encoding.UTF8))
        {
            string line;
            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains("-"))
                {
                    string[] parts = line.Trim().Split('-');
                    dictionary[parts[0]] = parts[1];
                }
                else
                {
                    Console.WriteLine(line.Trim());
                }
            }
        }
        return dictionary;
}

    static void WriteDictionary(string filePath, Dictionary<string, string> dictionary)
    {
        using (StreamWriter file = new StreamWriter(filePath))
        {
            foreach (var pair in dictionary)
            {
                file.WriteLine($"{pair.Key}-{pair.Value}");
            }
        }
    }

    static string TranslateWord(Dictionary<string, string> dictionary, string word)
    {
        if (dictionary.ContainsKey(word))
        {
            return dictionary[word];
        }
        return null;
    }

    static void AddNewWord(Dictionary<string, string> dictionary, string russianWord, string estonianWord)
    {
        dictionary[russianWord] = estonianWord;
        Console.WriteLine($"Sõna lisatud: {russianWord} - {estonianWord}");
    }

    static void FixMistake(Dictionary<string, string> dictionary, string russianWord)
    {
        if (dictionary.ContainsKey(russianWord))
        {
            Console.WriteLine($"Aktuaalne eestikeelne tõlge sõnale '{russianWord}': {dictionary[russianWord]}");
            Console.Write("Sisestage uus eestikeelne tõlge: ");
            string newEstonianTranslation = Console.ReadLine();
            dictionary[russianWord] = newEstonianTranslation;
            Console.WriteLine($"Viga parandatud: {russianWord} - {newEstonianTranslation}");
        }
        else
        {
            Console.WriteLine($"Sõna '{russianWord}' ei leitud sõnastikust.");
        }
    }

    static void TestKnowledge(Dictionary<string, string> dictionary)
    {
        int correctAnswers = 0;
        int totalQuestions = 0;

        Console.Write("Mitu küsimust soovite vastata? ");
        int repetition = int.Parse(Console.ReadLine());

        Random random = new Random();
        foreach (var pair in dictionary)
        {
            for (int i = 0; i < repetition; i++)
            {
                string russianWord = pair.Key;
                Console.Write($"Kuidas tõlgite sõna '{russianWord}' eesti keelde? ");
                string estonianTranslation = Console.ReadLine().Trim();
                string correctTranslation = pair.Value;
                if (estonianTranslation.Equals(correctTranslation, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Õige vastus!");
                    correctAnswers++;
                }
                else
                {
                    Console.WriteLine($"Vale vastus! Õige vastus on: {correctTranslation}");
                }
                totalQuestions++;
            }
        }

        double percentage = (double)correctAnswers / totalQuestions * 100;
        Console.WriteLine($"\nKokku õigeid vastuseid: {correctAnswers} {totalQuestions} kohta. Tulemus: {percentage:F2}%\n");
    }

    static void Main(string[] args)
    {
        string russianFileName = "C:\\Users\\admin\\Desktop\\Programm\\sonastik2\\sonastik2\\dictionary_rus.txt";
        string estonianFileName = "C:\\Users\\admin\\Desktop\\Programm\\sonastik2\\sonastik2\\dictionary_est.txt";

        Dictionary<string, string> dictionary = LoadDictionary(russianFileName);

        Console.Write("Sisestage vene sõna: ");
        string russianWord = Console.ReadLine().Trim();
        string estonianTranslation = TranslateWord(dictionary, russianWord);

        if (estonianTranslation != null)
        {
            Console.WriteLine($"Tõlge: {estonianTranslation}");
        }
        else
        {
            Console.WriteLine("Seda sõna pole tõlgitud. Palun kirjuta tõlke");
            AddNewWord(dictionary, russianWord, Console.ReadLine().Trim());
        }

        Console.Write("Kas soovite parandada vigu? (yes/not): ");
        string fixChoice = Console.ReadLine().ToLower();
        if (fixChoice == "yes")
        {
            Console.Write("Sisestage vene sõna, mille tõlget soovite parandada: ");
            string wordToFix = Console.ReadLine().Trim();
            FixMistake(dictionary, wordToFix);
        }

        Console.Write("Kas soovite kontrollida sõnade tundmist? (yes/not): ");
        string testChoice = Console.ReadLine().ToLower();
        if (testChoice == "yes")
        {
            TestKnowledge(dictionary);
        }

        WriteDictionary(russianFileName, dictionary);
    }
}
