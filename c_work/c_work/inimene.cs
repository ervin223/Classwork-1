using System;

namespace functions
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Valige ülesanne:");
                Console.WriteLine("1. Tervitus");
                Console.WriteLine("2. Korrutustabel");
                Console.WriteLine("3. Osta elevant");
                Console.WriteLine("4. Kasutaja andmed");
                Console.WriteLine("5. Suurim neljakohaline arv");
                Console.WriteLine("6. Juhuslike numbrite ruudud");
                Console.WriteLine("7. Massiivi toimingud");
                Console.WriteLine("8. Arva ära number");
                Console.WriteLine("9. Välju");

                Console.Write("Sisestage ülesande number: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        TervitaKasutajat();
                        break;
                    case "2":
                        Tabel();
                        break;
                    case "3":
                        Slon();
                        break;
                    case "4":
                        Kasutaja();
                        break;
                    case "5":
                        SuurimNeljakohaline();
                        break;
                    case "6":
                        Juhuslikud();
                        break;
                    case "7":
                        MassiiviToimingud();
                        break;
                    case "8":
                        Arva();
                        break;
                    case "9":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Vale sisend. Palun proovige uuesti.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void TervitaKasutajat()
        {
            Console.WriteLine("Tere");
        }

        static void Tabel()
        {
            Console.WriteLine("Korrutustabel:");
            Console.Write("    ");
            for (int i = 1; i <= 10; i++)
            {
                Console.Write($"{i,5}");
            }
            Console.WriteLine("\n");

            for (int i = 1; i <= 10; i++)
            {
                Console.Write($"{i,3}");
                for (int j = 1; j <= 10; j++)
                {
                    Console.Write($"{i * j,5}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void Slon()
        {
            string input;
            do
            {
                Console.WriteLine("Osta elevant!");
                input = Console.ReadLine();
            } while (!input.ToLower().Equals("elevant"));

            Console.WriteLine("Täname, et ostsite elevandi!");
        }

        static void Kasutaja()
        {
            string[] nimed = new string[5];
            int[] vanused = new int[5];
            int koguVanus = 0;
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Sisestage {i + 1}-nda kasutaja nimi: ");
                nimed[i] = Console.ReadLine();

                Console.Write($"Sisestage {i + 1}-nda kasutaja vanus: ");
                vanused[i] = int.Parse(Console.ReadLine());
                koguVanus += vanused[i];
            }
            double keskmineVanus = (double)koguVanus / vanused.Length;
            Console.WriteLine($"Kogu vanus: {koguVanus}");
            Console.WriteLine($"Keskmine vanus: {keskmineVanus}");
            Console.WriteLine("Nooremad kasutajad:");
            for (int i = 0; i < 5; i++)
            {
                if (vanused[i] < keskmineVanus)
                {
                    Console.WriteLine($"Nimi: {nimed[i]}, Vanus: {vanused[i]}");
                }
            }
            Console.WriteLine();
        }

        static void SuurimNeljakohaline()
        {
            Console.WriteLine("Sisestage 4 numbrit:");
            string kasutajaSisend = Console.ReadLine();
            int number;
            while (kasutajaSisend.Length != 4 || !int.TryParse(kasutajaSisend, out number))
            {
                Console.WriteLine("Vale sisend. Palun sisestage neljakohaline arv.");
                Console.WriteLine("Sisestage 4 numbrit:");
                kasutajaSisend = Console.ReadLine();
            }
            char[] numbrid = kasutajaSisend.ToCharArray();
            Array.Sort(numbrid);
            Array.Reverse(numbrid);
            Console.WriteLine($"Suurim neljakohaline arv: {new string(numbrid)}");
        }

        static void Juhuslikud()
        {
            Random juhuslik = new Random();

            int N = juhuslik.Next(-100, 100);
            int M = juhuslik.Next(-100, 100);

            if (N > M)
            {
                int temp = N;
                N = M;
                M = temp;
            }

            int pikkus = M - N + 1;

            int[] numbrid = new int[pikkus];

            for (int i = 0; i < pikkus; i++)
            {
                numbrid[i] = N + i;
            }

            foreach (int number in numbrid)
            {
                int ruut = number * number;
                Console.WriteLine($"Arvu {number} ruut: {ruut}");
            }
        }

        static void MassiiviToimingud()
        {
            int[] numbrid = new int[5];

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Sisestage {i + 1}-nes number: ");
                numbrid[i] = int.Parse(Console.ReadLine());
            }

            int summa = 0;
            foreach (int number in numbrid)
            {
                summa += number;
            }

            double keskmine = (double)summa / numbrid.Length;

            int korrutis = 1;
            foreach (int number in numbrid)
            {
                korrutis *= number;
            }

            Console.WriteLine($"Numbrite summa: {summa}");
            Console.WriteLine($"Keskmine: {keskmine}");
            Console.WriteLine($"Korrutis: {korrutis}");
        }

        static void Arva()
        {
            Random juhuslik = new Random();
            int juhuslikNumber = juhuslik.Next(1, 101);

            Console.WriteLine("Arv on vahemikus 1 kuni 100. Proovige arvata seda.");

            for (int i = 0; i < 5; i++)
            {
                Console.Write("Teie " + (i + 1) + ". katse: ");
                int arvamus = Convert.ToInt32(Console.ReadLine());

                if (arvamus == juhuslikNumber)
                {
                    Console.WriteLine("Õige! Arvuti arvas numbri " + juhuslikNumber);
                    break;
                }
                else
                {
                    if (i < 4)
                    {
                        if (arvamus < juhuslikNumber)
                        {
                            Console.WriteLine("Arvuti number on suurem kui " + arvamus + ". Palun proovige uuesti.");
                        }
                        else
                        {
                            Console.WriteLine("Arvuti number on väiksem kui " + arvamus + ". Palun proovige uuesti.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Kahjuks said katset läbi. Õige number oli " + juhuslikNumber);
                    }
                }
            }

            Console.WriteLine("Mäng on läbi.");
        }
    }
}
