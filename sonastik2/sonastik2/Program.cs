using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static Dictionary<string, string>? dictionaryRussian;
    static Dictionary<string, string>? dictionaryEstonian;

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
                    dictionary[line.Trim()] = "";
                }
            }
        }
        return dictionary;
    }

    static void WriteDictionary(string filePath, Dictionary<string, string>? dictionary)
    {
        if (dictionary == null)
            return;

        using (StreamWriter file = new StreamWriter(filePath))
        {
            foreach (var pair in dictionary)
            {
                if (!string.IsNullOrEmpty(pair.Value))
                {
                    file.WriteLine($"{pair.Key}-{pair.Value}");
                }
                else
                {
                    file.WriteLine(pair.Key);
                }
            }
        }
    }

    static void ViewRussianDictionary()
    {
        dictionaryRussian = LoadDictionary("C:\\Users\\admin\\Desktop\\Programm\\sonastik2\\sonastik2\\dictionary_rus.txt");

        if (dictionaryRussian != null && dictionaryRussian.Count == 0)
        {
            Console.WriteLine("Russian dictionary is empty.");
            return;
        }

        foreach (var pair in dictionaryRussian!)
        {
            Console.WriteLine($"{pair.Key}  {pair.Value}");
        }
    }

    static void ViewEstonianDictionary()
    {
        dictionaryEstonian = LoadDictionary("C:\\Users\\admin\\Desktop\\Programm\\sonastik2\\sonastik2\\dictionary_est.txt");

        if (dictionaryEstonian != null && dictionaryEstonian.Count == 0)
        {
            Console.WriteLine("Estonian dictionary is empty.");
            return;
        }

        foreach (var pair in dictionaryEstonian!)
        {
            Console.WriteLine($"{pair.Key}  {pair.Value}");
        }
    }

    static void AddNewWord(string language)
    {
        Dictionary<string, string>? dictionary = language == "Russian" ? dictionaryRussian : dictionaryEstonian;

        if (dictionary == null)
            return;

        Console.Write($"Enter the {language} word: ");
        string word = Console.ReadLine().Trim();

        if (dictionary.ContainsKey(word))
        {
            Console.WriteLine("This word already exists in the dictionary.");
        }
        else
        {
            dictionary[word] = "";
            Console.WriteLine($"Word added: {word}");
            WriteDictionary(language == "Russian" ? "C:\\Users\\admin\\Desktop\\Programm\\sonastik2\\sonastik2\\dictionary_rus.txt" : "C:\\Users\\admin\\Desktop\\Programm\\sonastik2\\sonastik2\\dictionary_est.txt", dictionary);
        }
    }

    static void RemoveWord(string language)
    {
        Dictionary<string, string>? dictionary = language == "Russian" ? dictionaryRussian : dictionaryEstonian;

        if (dictionary == null)
            return;

        Console.Write($"Enter the {language} word to remove: ");
        string word = Console.ReadLine().Trim();

        if (dictionary.ContainsKey(word))
        {
            dictionary.Remove(word);
            Console.WriteLine($"Word '{word}' removed from the dictionary.");
            WriteDictionary(language == "Russian" ? "C:\\Users\\admin\\Desktop\\Programm\\sonastik2\\sonastik2\\dictionary_rus.txt" : "C:\\Users\\admin\\Desktop\\Programm\\sonastik2\\sonastik2\\dictionary_est.txt", dictionary);
        }
        else
        {
            Console.WriteLine($"Word '{word}' not found in the {language} dictionary.");
        }
    }

    static void ModifyWord(string language)
    {
        Dictionary<string, string>? dictionary = null;

        if (language.ToLower() == "russian")
        {
            dictionary = dictionaryRussian;
        }
        else if (language.ToLower() == "estonian")
        {
            dictionary = dictionaryEstonian;
        }

        if (dictionary == null)
        {
            Console.WriteLine("Invalid language specified.");
            return;
        }

        Console.Write($"Enter the word to modify ({language}): ");
        string word = Console.ReadLine().Trim(); //удаление пробелов

        if (dictionary.TryGetValue(word, out string? currentTranslation))
        {
            Console.Write($"Current translation for the word '{word}': {currentTranslation}\n");
            Console.Write("Enter the new translation: ");
            string newTranslation = Console.ReadLine();

            // Проверка на null перед присваиванием
            if (dictionary != null)
            {
                dictionary[word] = newTranslation;
                Console.WriteLine($"Word '{word}' modified in the dictionary.");
            }
        }
        else
        {
            Console.WriteLine("Word not found in the dictionary.");
        }
    }


    static void Main(string[] args)
    {
        bool continueLoop = true;

        while (continueLoop)
        {
            Console.WriteLine("\nChoose an action:");
            Console.WriteLine("1. View Russian dictionary");
            Console.WriteLine("2. View Estonian dictionary");
            Console.WriteLine("3. Add a new word to the Russian dictionary");
            Console.WriteLine("4. Remove a word from the Russian dictionary");
            Console.WriteLine("5. Modify a word in the Russian dictionary");
            Console.WriteLine("6. Add a new word to the Estonian dictionary");
            Console.WriteLine("7. Remove a word from the Estonian dictionary");
            Console.WriteLine("8. Modify a word in the Estonian dictionary");
            Console.WriteLine("9. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\nRussian dictionary:");
                    ViewRussianDictionary();
                    break;
                case "2":
                    Console.WriteLine("\nEstonian dictionary:");
                    ViewEstonianDictionary();
                    break;
                case "3":
                    AddNewWord("Russian");
                    break;
                case "4":
                    RemoveWord("Russian");
                    break;
                case "5":
                    ModifyWord("Russian");
                    break;
                case "6":
                    AddNewWord("Estonian");
                    break;
                case "7":
                    RemoveWord("Estonian");
                    break;
                case "8":
                    ModifyWord("Estonian");
                    break;
                case "9":
                    continueLoop = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }
}
