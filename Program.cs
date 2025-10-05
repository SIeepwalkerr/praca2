using System;
using System.IO;

namespace Workbook2
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Рабочая тетрадь №2 — Алгоритмы и циклы";
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===============================================");
                Console.WriteLine("     Рабочая тетрадь №2 — Алгоритмы и циклы");
                Console.WriteLine("===============================================");
                Console.WriteLine("1 — Ряды (разложение Маклорена)");
                Console.WriteLine("2 — Счастливый билет");
                Console.WriteLine("3 — Сокращение дроби (НОД)");
                Console.WriteLine("4 — Угадай число (0–63)");
                Console.WriteLine("5 — Кофейный аппарат");
                Console.WriteLine("6 — Лабораторный опыт");
                Console.WriteLine("7 — Колонизация Марса");
                Console.WriteLine("0 — Выход");
                Console.Write("Ваш выбор: ");
                string choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1": Zad1(); break;
                    case "2": Zad2(); break;
                    case "3": Zad3(); break;
                    case "4": Zad4(); break;
                    case "5": Zad5(); break;
                    case "6": Zad6(); break;
                    case "7": Zad7(); break;
                    case "0":
                        Console.WriteLine("Выход из программы...");
                        return;
                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
                Console.ReadKey();
            }
        }

        // ---------- ЗАДАНИЕ 1 ----------
        static void Zad1()
        {
            Console.WriteLine("=== Задание 1: Ряды (разложение Маклорена) ===");
            Console.Write("Введите x: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Введите точность (ε < 0.01): ");
            double epsilon = double.Parse(Console.ReadLine());

            double sum = 0, term = 1;
            int n = 0;
            while (Math.Abs(term) > epsilon)
            {
                sum += term;
                n++;
                term = Math.Pow(x, n) / Factorial(n);
            }

            Console.WriteLine($"e^x ≈ {sum:F4}");
            Console.Write("Введите номер члена n: ");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine($"n-й член ряда: {Math.Pow(x, num) / Factorial(num):F6}");
        }

        static double Factorial(int n)
        {
            double res = 1;
            for (int i = 1; i <= n; i++) res *= i;
            return res;
        }

        // ---------- ЗАДАНИЕ 2 ----------
        static void Zad2()
        {
            Console.WriteLine("=== Задание 2: Счастливый билет ===");
            Console.Write("Введите шестизначное число: ");
            int num = int.Parse(Console.ReadLine());

            int d1 = num / 100000 % 10;
            int d2 = num / 10000 % 10;
            int d3 = num / 1000 % 10;
            int d4 = num / 100 % 10;
            int d5 = num / 10 % 10;
            int d6 = num % 10;

            if (d1 + d2 + d3 == d4 + d5 + d6)
                Console.WriteLine("Билет счастливый!");
            else
                Console.WriteLine("Билет обычный.");
        }

        // ---------- ЗАДАНИЕ 3 ----------
        static void Zad3()
        {
            Console.WriteLine("=== Задание 3: Сокращение дроби ===");
            Console.Write("Введите числитель M: ");
            int m = int.Parse(Console.ReadLine());
            Console.Write("Введите знаменатель N: ");
            int n = int.Parse(Console.ReadLine());

            int gcd = GCD(m, n);
            Console.WriteLine($"Несократимая дробь: {m / gcd}/{n / gcd}");
        }

        static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        // ---------- ЗАДАНИЕ 4 ----------
        static void Zad4()
        {
            Console.WriteLine("=== Задание 4: Угадай число (0–63) ===");
            Console.WriteLine("Отвечайте 1 (да) или 0 (нет)");
            int number = 0;
            for (int bit = 0; bit < 6; bit++)
            {
                int mask = 1 << bit;
                Console.Write($"Ваше число >= {number + mask}? ");
                if (Console.ReadLine() == "1")
                    number |= mask;
            }
            Console.WriteLine($"Ваше число: {number}");
        }

        // ---------- ЗАДАНИЕ 5 ----------
        static void Zad5()
        {
            Console.WriteLine("=== Задание 5: Кофейный аппарат ===");
            Console.Write("Введите количество воды (мл): ");
            int water = int.Parse(Console.ReadLine());
            Console.Write("Введите количество молока (мл): ");
            int milk = int.Parse(Console.ReadLine());

            int americanoCount = 0, latteCount = 0, money = 0;

            while (true)
            {
                Console.WriteLine("\n1 — Американо (300 мл воды, 150 руб)");
                Console.WriteLine("2 — Латте (30 мл воды, 270 мл молока, 170 руб)");
                Console.WriteLine("0 — Завершить");
                Console.Write("Ваш выбор: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    if (water >= 300)
                    {
                        water -= 300;
                        americanoCount++;
                        money += 150;
                        Console.WriteLine("Американо готов!");
                    }
                    else Console.WriteLine("Недостаточно воды.");
                }
                else if (choice == "2")
                {
                    if (water >= 30 && milk >= 270)
                    {
                        water -= 30;
                        milk -= 270;
                        latteCount++;
                        money += 170;
                        Console.WriteLine("Латте готов!");
                    }
                    else Console.WriteLine("Недостаточно ингредиентов.");
                }
                else if (choice == "0") break;
                else Console.WriteLine("Неверный выбор.");
            }

            Console.WriteLine($"\nОстаток воды: {water} мл, молока: {milk} мл");
            Console.WriteLine($"Приготовлено: {americanoCount} американо, {latteCount} латте");
            Console.WriteLine($"Заработано: {money} руб.");
        }

        // ---------- ЗАДАНИЕ 6 ----------
        static void Zad6()
        {
            Console.WriteLine("=== Задание 6: Лабораторный опыт ===");
            Console.Write("Введите количество бактерий N: ");
            int N = int.Parse(Console.ReadLine());
            Console.Write("Введите количество капель антибиотика X: ");
            int X = int.Parse(Console.ReadLine());

            int hour = 0;
            int bacteria = N;
            int killPower = X * 10;

            while (killPower > 0 && bacteria > 0)
            {
                hour++;
                bacteria *= 2;
                bacteria -= killPower;
                if (bacteria < 0) bacteria = 0;
                killPower -= X;
                Console.WriteLine($"Час {hour}: бактерий = {bacteria}, антибиотик = {killPower}");
            }

            Console.WriteLine($"\nЭксперимент завершён. Прошло часов: {hour}");
            Console.WriteLine($"Конечное количество бактерий: {bacteria}");
        }

        // ---------- ЗАДАНИЕ 7 ----------
        static void Zad7()
        {
            Console.WriteLine("=== Задание 7: Колонизация Марса ===");
            Console.Write("Введите количество модулей n: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Введите размеры модуля (a b): ");
            var mod = Console.ReadLine().Split();
            int a = int.Parse(mod[0]), b = int.Parse(mod[1]);
            Console.Write("Введите размеры поля (h w): ");
            var fld = Console.ReadLine().Split();
            int h = int.Parse(fld[0]), w = int.Parse(fld[1]);

            int maxD = CalculateMaxD(n, a, b, h, w);
            if (maxD < 0)
                Console.WriteLine("Размещение невозможно.");
            else
                Console.WriteLine($"Максимальная толщина защиты: {maxD} м");
        }

        static int CalculateMaxD(int n, int a, int b, int h, int w)
        {
            if (!CanPlace(n, a, b, h, w, 0)) return -1;
            int left = 0, right = Math.Min(h, w) / 2, result = 0;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (CanPlace(n, a, b, h, w, mid))
                {
                    result = mid;
                    left = mid + 1;
                }
                else right = mid - 1;
            }
            return result;
        }

        static bool CanPlace(int n, int a, int b, int h, int w, int d)
        {
            int aD = a + 2 * d, bD = b + 2 * d;
            return (Fit(n, aD, bD, h, w) || Fit(n, bD, aD, h, w));
        }

        static bool Fit(int n, int a, int b, int h, int w)
        {
            int perRow = w / b, perCol = h / a;
            return perRow * perCol >= n;
        }
    }
}
