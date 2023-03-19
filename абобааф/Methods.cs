using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace абобааф
{
    internal class Methods
    {
        private Object[] array;
        public void Print(Object[] copy, Object[] array)
        {
            Console.WriteLine();
            Console.WriteLine("Массив до: \t[" + String.Join(", ", copy) + "]");
            Console.WriteLine("Массив после: \t[" + String.Join(", ", array) + "]");
            Console.WriteLine();
        }
        public void Check()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("!Проверка!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" Массив : [{String.Join(", ", array)}]");
            Console.WriteLine();
        }
        public void End(Object[] copy)
        {
            Console.Write("Сохранить изменения? ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("[да - Enter] ");
            Console.ForegroundColor = ConsoleColor.White;
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key != ConsoleKey.Enter)
            {
                array = copy;
                
            }
            Console.Write("Нажмите любую клавишу, чтобы выйти : ");
            Console.ReadKey();
            Console.Clear();
        }
        public void End()
        {
            Console.Write("Нажмите любую клавишу, чтобы выйти : ");
            Console.ReadKey();
            Console.Clear();
        }
        public void Vvod()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t - Введите массив типа int/string-");
            Console.Write("Размерность : ");
            int n = int.Parse(Console.ReadLine());
            array = new Object[n];
            int a_1 = 0;
            string a_2;
            for (int i = 0; i < n; i++) 
            {
                Console.Write($"[{i}] = ");
                a_2 = Console.ReadLine();
                bool a = int.TryParse(a_2, out a_1);
                if (a)
                {
                    array[i] = a_1;
                } else
                {
                    array[i] = a_2;
                    array[i].ToString();
                }
            }
            End();
        }
        public void Sort()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t - Отсортировать часть массива по возрастанию -");
            Console.WriteLine($"Размерность : {array.Length}");
            Console.Write($"Индекс, с которого начать сортировку : ");
            int index = int.Parse(Console.ReadLine());
            Console.Write($"Сколько элементов сортировать? (max = {array.Length - index}) ");
            int cnt = int.Parse(Console.ReadLine());
            Object[] copy = new object[array.Length];
            array.CopyTo(copy, 0);
            
            Array.Sort(array, index, cnt);
            Print(copy, array);
            End(copy);
        }
        public void Reverse()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t - Изменение порядка массива - ");
            Console.WriteLine($"Размерность : {array.Length}");
            Console.Write($"Индекс, с которого начать изменение : ");
            int index = int.Parse(Console.ReadLine());
            Console.Write($"Для скольких элементов изменить порядок? (max = {array.Length - index}) ");
            int cnt = int.Parse(Console.ReadLine());
            Object[] copy = new object[array.Length];
            array.CopyTo(copy, 0);

            Array.Reverse(array, index, cnt);
            Print(copy, array);
            End(copy);
        }
        public void BinarySearch()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t - Бинарный поиск - ");
            Object[] copy = new object[array.Length];
            array.CopyTo(copy, 0);
            Array.Sort(copy);

            bool flag = true;

            for (int i = 0; i < copy.Length; i++)
            {
                if (copy[i] != array[i])
                {
                    flag = false;
                    break;
                }
            }

            if (flag)
            {
                Console.Write($"Какой объект найти? ");
                Object o;
                int puk1 = 0;
                string puk2 = Console.ReadLine();
                bool a = int.TryParse(puk2, out puk1);
                if (a)
                {
                    o = puk1;
                }
                else
                {
                    o = puk2;
                    o.ToString();
                }

                int index = Array.BinarySearch(array, o);
                if (index < 0)
                {
                    Console.WriteLine($"Объект \"{o}\" в результате поиска не найден.");
                }
                else
                {
                    Console.WriteLine(" Объект \"{0}\" находится по индексу {1}.", o, index);
                }
                Check();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("!Ошибка! Массив не отсортирован");
                Console.WriteLine("Вернитесь назад и отсортируйте массив");
                Console.ForegroundColor = ConsoleColor.White;
            }
            End();
        }
        public void Copy()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t - Копирование части (всего) массива в введенный -");
            Type t = array[0].GetType();
            object?[] mass = null;
            if (t.Equals(typeof(int)))
            {
                mass = new object[array.Length];
                for (int i = 0; i < mass.Length; i++)
                {
                    mass[i] = i;
                    int.Parse(mass[i].ToString());
                }
            }
            else
            {
                mass = new string[] { "Tarelka", "Capibara", "Boba", "Kishmish", "Kate", "Alice", "Beluga", };
            }
            
            Console.WriteLine("Массив, из которого будут копироваться элементы в введенный: [" + String.Join(", ", mass) + "]");
            Console.Write($"Сколько элементов с начала копировать? ");
            int length = int.Parse(Console.ReadLine());
            Object[] copy = new object[array.Length];
            array.CopyTo(copy, 0);

            Array.Copy(mass, array, length);
            Print(copy, array);
            End(copy);
        }
        public void Resize()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t - Изменение размера массива -");
            Console.WriteLine($"Текущая размерность : {array.Length}");
            Console.Write($"Введите новую размерность: ");
            int size = int.Parse(Console.ReadLine());
            Object[] copy = new object[array.Length];
            array.CopyTo(copy, 0);

            Array.Resize(ref array, size);
            Print(copy, array);
            End(copy);
        }
        public void Index()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t - Поиск индекса элемента -");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Желательно, что бы в массиве были повторяющиеся элементы :)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Введите элемент : ");
            Object o;
            int puk1 = 0;
            string puk2 = Console.ReadLine();
            bool a = int.TryParse(puk2, out puk1);
            if (a)
            {
                o = puk1;
                Console.WriteLine($"Индекс первого вхождения '{o}': {Array.IndexOf(array, o)}");
                Console.WriteLine($"Индекс последнего вхождения '{o}': {Array.LastIndexOf(array, o)}");
                Console.WriteLine();
                Console.Write($"Найдем элементы, которые > ");
                int zn = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Object[] group = Array.FindAll(array, bup => (int)bup > zn);
                Console.WriteLine($"Индекс первого вхождения : {Array.FindIndex(array, bup => (int)bup > zn)}");
                Console.WriteLine($"Индекс последнего вхождения : {Array.FindLastIndex(array, bup => (int)bup > zn)}");
                Console.WriteLine($"Найденные элементы: {String.Join(", ", group)}");
            
            }
            else
            {
                o = puk2;
                o.ToString();
                Console.WriteLine($"Индекс первого вхождения '{o}': {Array.IndexOf(array, o)}");
                Console.WriteLine($"Индекс последнего вхождения '{o}': {Array.LastIndexOf(array, o)}");
                Console.WriteLine();
                Console.Write($"Найдем элементы, длина которых > ");
                int zn = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Object[] group = Array.FindAll(array, bup => bup.ToString().Length > zn);
                Console.WriteLine($"Индекс первого вхождения : {Array.FindIndex(array, bup => bup.ToString().Length > zn)}");
                Console.WriteLine($"Индекс последнего вхождения : {Array.FindLastIndex(array, bup => bup.ToString().Length > zn)}");
                Console.WriteLine($"Найденные элементы: {String.Join(", ", group)}");
            }
            Check();
            End();

        }
        public void SetValue()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t - Изменение значения по индексу -");
            Console.Write("Введите индекс : ");
            int index = int.Parse(Console.ReadLine());
            Console.Write("Какое значение присвоить? ");
            Object value;
            int puk1 = 0;
            string puk2 = Console.ReadLine();
            bool a = int.TryParse(puk2, out puk1);
            if (a)
            {
                value = puk1;
            }
            else
            {
                value = puk2;
                value.ToString();
            }
            Object[] copy = new object[array.Length];
            array.CopyTo(copy, 0);

            array.SetValue(value, index);
            Print(copy, array);
            End(copy);
        }
        public void GetValue()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t - Получение значения по индексу -");
            Console.Write("Введите индекс : ");
            int index = int.Parse(Console.ReadLine());
            Console.WriteLine("Значение по данному индексу: {0}", array.GetValue(index));
            Check();
            End();
        }
        public void Exist()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t - Наличие элементов, удовлетворяющих условию -");
            Type t = array[0].GetType();
            if (t.Equals(typeof(int)))
            {
                Console.WriteLine("Узнаем, есть ли числа, лежащие в заданном диапазоне.");
                Console.Write("start = ");
                int start = int.Parse(Console.ReadLine());
                Console.Write("end = ");
                int end = int.Parse(Console.ReadLine());
                bool flag = false;
                for (int i = start; i <= end; i++)
                {
                    if (Array.Exists(array, num => (int)num == i))
                    {
                        flag = true;
                        break;
                    }
                }
                Console.WriteLine($"Результат поиска : {flag}");
            }
            else
            {
                Console.WriteLine("Узнаем, есть ли слова, начинающиеся на какую-нибудь букву. ");
                Console.Write("Введите букву: ");
                string bukva = Console.ReadLine();
                Console.WriteLine($"Результат поиска : {Array.Exists(array, el => el.ToString().StartsWith(bukva))}");
            }
            Check();
            End();
        }
        public void Clear()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t - Очищение всего массива или его части - ");
            Console.WriteLine($"Размерность : {array.Length}");
            Console.Write($"Начальный индекс диапазона элементов, которые необходимо очистить : ");
            int index = int.Parse(Console.ReadLine());
            Console.Write($"Число элементов, подлежащих очистке (max = {array.Length - index}) ");
            int cnt = int.Parse(Console.ReadLine());
            Object[] copy = new object[array.Length];
            array.CopyTo(copy, 0);

            Array.Clear(array, index, cnt);
            Print(copy, array);
            End(copy);
        }
    }
}