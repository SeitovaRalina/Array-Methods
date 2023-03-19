using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace абобааф
{
    internal class Menu
    {
        static int Move(int i, int n, ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.UpArrow)
            {
                i = (n + i - 1) % n;
            }

            if (key.Key == ConsoleKey.DownArrow)
            {
                i = (i + 1) % n;
            }

            return i;
        }
        static void Main(string[] args)
        {
            int i = 0;  
            Methods a = new Methods();
            while (true) 
            {
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\t\t\t\t\t - Лабораторная работа: Методы Array -");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("1. Заполнение array"); 
                Console.WriteLine("2. Сортировка"); // Sort (части массива)
                Console.WriteLine("3. Изменение порядка элементов"); //Reverse (сколько элементов начиная с какого индекса)
                Console.WriteLine("4. Бинарный поиск");     
                Console.WriteLine("5. Копирование элементов из другого массива в array"); // Copy (из лекции)
                Console.WriteLine("6. Изменение размера"); // Resize (ref array, num)
                Console.WriteLine("7. Поиск индекса элемента"); // IndexOf() LastIndexOf() FindIndex() FindLastIndex()
                Console.WriteLine("8. Изменение значения по индексу"); //SetValue()
                Console.WriteLine("9. Получение значения по индексу"); //GetValue()
                Console.WriteLine("10. Наличие элементов, удовлетворяющих условию"); // Array.Exists<T>(T[], Predicate<T>) Метод
                Console.WriteLine("11. Очищение массива"); // Clear
                Console.SetCursorPosition(55, i+2);
                ConsoleKeyInfo key = Console.ReadKey();

                if (i == 0 && key.Key == ConsoleKey.Enter)
                {
                    a.Vvod();
                }

                if (i == 1 && key.Key == ConsoleKey.Enter)
                {
                    a.Sort();
                }

                if (i == 2 && key.Key == ConsoleKey.Enter)
                {
                    a.Reverse();
                }

                if (i == 3 && key.Key == ConsoleKey.Enter)
                {
                    a.BinarySearch();
                }

                if (i == 4 && key.Key == ConsoleKey.Enter)
                {
                    a.Copy();
                }

                if (i == 5 && key.Key == ConsoleKey.Enter)
                {
                    a.Resize();
                }

                if (i == 6 && key.Key == ConsoleKey.Enter)
                {
                    a.Index();
                }

                if (i == 7 && key.Key == ConsoleKey.Enter)
                {
                    a.SetValue();
                }

                if (i == 8 && key.Key == ConsoleKey.Enter)
                {
                    a.GetValue();
                }
                if (i == 9 && key.Key == ConsoleKey.Enter)
                {
                    a.Exist();
                }
                if (i == 10 && key.Key == ConsoleKey.Enter)
                {
                    a.Clear();
                }
                i = Move(i, 11, key);
            }
        }
    }
}