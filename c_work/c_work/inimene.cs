using System;

namespace functions
{
    class Program
    {
        static void Main(string[] args)
        {
            GreetUser();
            Table();
            Elephant();
            User();
            LargestNum();
            Random();
            ArrayOperations();
            Rand_();
        }

        static void GreetUser()
        {
            Console.WriteLine("Привет");
        }

        //* Korrutustabel väljata ekraanile sellisel kujul:
        static void Table()
        {
            Console.WriteLine("Таблица умножения:");
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

        //* Ütle kasutajale "Osta elevant ära!". Senikaua korda küsimust, kuni kasutaja lõpuks ise kirjutab "elevant".
        static void Elephant()
        {
            string input;
            do
            {
                Console.WriteLine("Купи слона!");
                input = Console.ReadLine();
            } while (!input.ToLower().Equals("слон"));

            Console.WriteLine("Спасибо, что купили слона!");
        }


        //* Küsi viielt kasutajalt nimed ja vanused, salvesta nende andmeid massiivi ning väljasta summaarne vanus, aritmeetiline keskmine, vaanema ja noorema inimeste nimed ja vanused.
        static void User()
        {
            string[] names = new string[5];
            int[] ages = new int[5];
            int totalAge = 0;
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Введите имя {i + 1}-го пользователя: ");
                names[i] = Console.ReadLine();

                Console.Write($"Введите возраст {i + 1}-го пользователя: ");
                ages[i] = int.Parse(Console.ReadLine());
                totalAge += ages[i];
            }
            double averageAge = (double)totalAge / ages.Length;
            Console.WriteLine($"Общий возраст: {totalAge}");
            Console.WriteLine($"Средний возраст: {averageAge}");
            Console.WriteLine("Пользователи моложе:");
            for (int i = 0; i < 5; i++)
            {
                if (ages[i] < averageAge)
                {
                    Console.WriteLine($"Имя: {names[i]}, Возраст: {ages[i]}");
                }
            }
            Console.WriteLine();
        }

        //* Küsi kasutajalt 4 arvu ning väljasta nendest koostatud suurim neliarvuline arv.
        static void LargestNum()
        {
            Console.WriteLine("Введите 4 цифры:");
            string userInput = Console.ReadLine();
            int number;
            while (userInput.Length != 4 || !int.TryParse(userInput, out number))
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите четырехзначное число.");
                Console.WriteLine("Введите 4 цифры:");
                userInput = Console.ReadLine();
            }
            char[] digits = userInput.ToCharArray();
            Array.Sort(digits);
            Array.Reverse(digits);
            Console.WriteLine($"Наибольшее четырехзначное число: {new string(digits)}");
        }

        //* Loo  juhuslikult arvud N ja M ja sisesta massiivi arvud N'st M'ni. Trüki arvude ruudud ekraanile. N ja M arvud on vahemikus (-100,100).
        static void Random()
        {
            Random random = new Random();

            int N = random.Next(-100, 100);
            int M = random.Next(-100, 100);

            if (N > M)
            {
                int temp = N;
                N = M;
                M = temp;
            }

            int length = M - N + 1;

            int[] numbers = new int[length];

            for (int i = 0; i < length; i++)
            {
                numbers[i] = N + i;
            }

            foreach (int num in numbers)
            {
                int square = num * num;
                Console.WriteLine($"Квадрат числа {num}: {square}");
            }
        }

        //* Küsi kasutajalt viis arvu, salvesta neid massiivi ning väljasta nende summa, aritmeetiline keskmine ja korrutis.
        static void ArrayOperations()
        {
            int[] numbers = new int[5];

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Введите {i + 1}-е число: ");
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
            }

            double average = (double)sum / numbers.Length;

            int multiplication = 1;
            foreach (int num in numbers)
            {
                multiplication *= num;
            }

            Console.WriteLine($"Сумма чисел: {sum}");
            Console.WriteLine($"Среднее арифметическое: {average}");
            Console.WriteLine($"Произведение чисел: {multiplication}");
        }

        // Mis arv mõtles välja arvuti? Kasuta vähemalt 5 katset, et seda teada
        static void Rand_()
        {
            Random rand = new Random();
            int randomNumber = rand.Next(1, 101);

            Console.WriteLine("Есть число от 1 до 100. Попробуйте угадать это число.");

            for (int i = 0; i < 5; i++)
            {
                Console.Write("Ваша " + (i + 1) + "-я попытка: ");
                int guess = Convert.ToInt32(Console.ReadLine());

                if (guess == randomNumber)
                {
                    Console.WriteLine("Верно! Компьютер загадал число " + randomNumber);
                    break;
                }
                else
                {
                    if (i < 4)
                    {
                        if (guess < randomNumber)
                        {
                            Console.WriteLine("Компьютерское число больше " + guess + ". Попробуйте еще раз.");
                        }
                        else
                        {
                            Console.WriteLine("Компьютерское число меньше " + guess + ". Попробуйте еще раз.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("К сожалению, у вас закончились попытки. Правильное число было " + randomNumber);
                    }
                }
            }

            Console.WriteLine("Игра завершена.");
        }
    }
}
