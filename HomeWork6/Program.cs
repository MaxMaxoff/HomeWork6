using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupportLibrary;
using System.IO;
using System.Text.RegularExpressions;

/// <summary>
/// Максим Торопов
/// Ярославль
/// Домашняя работа 6 урока
/// 
/// Достаточно решить 3 задачи.
/// Старайтесь разбивать программы на подпрограммы.
/// Переписывайте в начало программы условие и свою фамилию.
/// Все программы сделать в одном решении.
/// </summary>
namespace HomeWork6
{
    /// <summary>
    /// Описываем делегат.
    /// В делегате описывается сигнатура методов, на которые сможет ссылаться делегат в дальнейшем (хранить в себе)
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>    
    public delegate double Fun(double x, double y);

    /// <summary>
    /// Делегат для функции с одним параметром
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public delegate double Func(double x);

    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                SupportMethods.PrepareConsoleForHomeTask("1 - Task 1\n" +
                  "2 - Task 2\n" +
                  "3 - Task 3\n" +
                  "4 - Task 4\n" +
                  "5 - Task 5\n" +
                  "6 - Task 6\n" +
                  "0 (Esc) - Exit\n");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        Task1();
                        break;
                    case ConsoleKey.D2:
                        Task2();
                        break;
                    case ConsoleKey.D3:
                        Task3();
                        break;
                    case ConsoleKey.D4:
                        Task4();
                        break;
                    case ConsoleKey.D5:
                        Task5();
                        break;
                    case ConsoleKey.D6:
                        Task6();
                        break;
                    case ConsoleKey.D0:
                    case ConsoleKey.Escape:
                        return;
                    default:
                        break;
                }
            } while (true);
        }

        /// <summary>
        /// Создаем метод, который принимает делегат.
        /// Т.е. на практике, этот метод сможет принимать любой метод с такой же сигнатурой как у делегата
        /// </summary>
        /// <param name="F"></param>
        /// <param name="x"></param>
        /// <param name="b"></param>
        public static void Table(Fun F, double x, double y, double b)
        {
            double y1 = 0D;
            Console.WriteLine("A \tX \tF(x, a)");
            while (x <= b)
            {
                y1 = y;
                while (y1 <= b)
                {
                    Console.WriteLine($"{y1:0.000} \t{x:0.000} \t{F(x, y1):0.000}");
                    y1 += 2;
                }
                x += 2;
            }
            Console.WriteLine("---------------------");
        }

        /// <summary>
        /// Создаем метод для передачи его в качестве параметра в Table
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double MyFunc1(double x, double y)
        {
            return y * x * x;
        }

        /// <summary>
        /// Создаем метод для передачи его в качестве параметра в Table
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double MyFunc2(double x, double y)
        {
            return y * Math.Sin(x);
        }

        /// <summary>
        /// Задача 1.
        /// 
        /// Изменить программу вывода функции так, чтобы можно было передавать функции типа double(double,double).
        /// Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).
        /// </summary>
        static void Task1()
        {
            //Prepare console
            SupportMethods.PrepareConsoleForHomeTask("Изменить программу вывода функции так, чтобы можно было передавать функции типа double(double,double).\n" +
                "Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).");



            // Создаем новый делегат и передаем ссылку на него в метод Table
            Console.WriteLine("Таблица функции MyFunc:");

            // Параметры метода и тип возвращаемого значения, должны совпадать с делегатом
            //Table(new Fun(MyFunc1), -2, 2);
            //Console.WriteLine("Еще раз та же таблица, но вызов организован по новому");

            // Упрощение(c C# 2.0).Делегат создается автоматически.
            Console.WriteLine("Таблица функции a * x^2:");
            Table(MyFunc1, -2, -2, 2);

            Console.WriteLine("Таблица функции a * sin(x):");
            Table(MyFunc2, -2, -2, 2); // Можно передавать уже созданные методы

            // Упрощение(с C# 2.0). Использование анонимного метода
            //Table(delegate (double x) { return x * x; }, 0, 3);

            SupportMethods.Pause();

        }

        /// <summary>
        /// Method function F1
        /// return x ^ 2 - 50 * x + 10;
        /// </summary>
        /// <param name="x"></param>
        /// <returns> double F</returns>
        public static double F1(double x)
        {
            return x * x - 50 * x + 10;
        }

        /// <summary>
        /// Method function F2
        /// x ^ 2 + 20 * x + 5;
        /// </summary>
        /// <param name="x"></param>
        /// <returns> double F</returns>
        public static double F2(double x)
        {
            return x * x + 20 * x + 5;
        }

        /// <summary>
        /// Method function F3 x ^ 2
        /// </summary>
        /// <param name="x"></param>
        /// <returns> double F</returns>
        public static double F3(double x)
        {
            return x * x;
        }

        /// <summary>
        /// Method function F4 sin(x)
        /// </summary>
        /// <param name="x"></param>
        /// <returns> double F</returns>
        public static double F4(double x)
        {
            return Math.Sin(x);
        }

        /// <summary>
        /// Method function F5 x ^ 3
        /// </summary>
        /// <param name="x"></param>
        /// <returns> double F</returns>
        public static double F5(double x)
        {
            return x * x * x;
        }

        /// <summary>
        /// Method save to file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="h"></param>
        public static void SaveFunc(Func F, string fileName, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(F(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }

        /// <summary>
        /// Method load from file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static double Load(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double min = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return min;
        }

        /// <summary>
        /// Задача 2.
        /// 
        /// *Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
        /// Сделать меню с различными функциями и представьте пользователю выбор для какой функции и на каком отрезке находить минимум.
        /// Используйте массив делегатов.
        /// </summary>
        static void Task2()
        {
            // Создание и инициализация массива делегатов
            Func[] functions = new Func[5];

            // Заполнение массива делегатов
            functions[0] = F1;
            functions[1] = F2;
            functions[2] = F3;
            functions[3] = F4;
            functions[4] = F5;

            // Меню выбора функций
            do
            {
                SupportMethods.PrepareConsoleForHomeTask("*Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.\n" +
                "Сделать меню с различными функциями и представьте пользователю выбор для какой функции и на каком отрезке находить минимум.\n" +
                "Используйте массив делегатов.\n" +
                "1 - функция: x ^ 2 - 50 * x + 10\n" +
                "2 - функция: x ^ 2 + 20 * x + 5\n" +
                "3 - функция: x ^ 2\n" +
                "4 - функция: sin(x)\n" +
                "5 - функция: x ^ 3\n" +
                "0 (Esc) - Exit\n");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.D2:
                    case ConsoleKey.D3:
                    case ConsoleKey.D4:
                    case ConsoleKey.D5:
                        SaveFunc(functions[int.Parse(key.KeyChar.ToString()) - 1],
                            "data.bin",
                            SupportMethods.RequestIntValue("Введите начало отрезка, например -100: "),
                            SupportMethods.RequestIntValue("Введите конец отрезка, например 100: "),
                            SupportMethods.RequestDoubleValue("Введите точность, например 0,5: "));

                        SupportMethods.Pause($"Минимум функции на заданном отрезке с заданной точностью равен {Load("data.bin"):F2}");
                        break;
                    case ConsoleKey.D0:
                    case ConsoleKey.Escape:
                        return;
                    default:
                        break;
                }
            } while (true);


        }

        /// <summary>
        /// Задача 3.
        /// 
        /// Подсчитать количество студентов:
        /// а) учащихся на 5 и 6 курсах;
        /// б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся(частотный массив);
        /// в) отсортировать список по возрасту студента;
        /// г) *отсортировать список по курсу и возрасту студента.
        /// </summary>
        static void Task3()
        {
            //Создаем список студентов
            List<Student> list = new List<Student>();

            StreamReader sr = null;
            try
            {
                sr = new StreamReader("students_1.csv");
                Student t;
                while (!sr.EndOfStream)
                {
                    try
                    {
                        string[] s = sr.ReadLine().Split(';');
                        t = new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]);
                        list.Add(t);
                    }
                    catch (ArgumentNullException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (ArgumentException exc)
                    {
                        Console.WriteLine(exc.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (sr != null) sr.Close();
            }

            // Количество студентов на 5-6 курсах
            // подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся(частотный массив);
            int sum = 0;
            int[] ar = new int[6];
            foreach (Student st in list)
            {
                if (st.GetCourse >= 5) sum++;
                if (st.GetAge >= 18 && st.GetAge <= 20) ar[st.GetCourse - 1]++;
            }
            SupportMethods.Pause($"Количество студентов на 5-6 курсах {sum}");
            SupportMethods.Pause($"Распределение студентов от 18 до 20 лет по курсам:\n{Student.FrequencyArrayToString(ref ar, "курс", "студентов")}");

            Console.WindowWidth = 120;
            Console.BufferWidth = 120;

            // в) отсортировать список по возрасту студента;
            // Сортируем по возрасту и выводим
            Console.WriteLine("Список, отсортированный по возрасту:");
            list.Sort(CompareByAge);
            foreach (Student st in list) Console.WriteLine(st.ToString());
            SupportMethods.Pause();

            // г) *отсортировать список по курсу и возрасту студента.
            // Сортируем по курсу и возрасту и выводим
            Console.WriteLine("Список, отсортированный по курсу и затем по возрасту:");
            list.Sort(CompareByCourseAge);
            foreach (Student st in list) Console.WriteLine(st.ToString());
            SupportMethods.Pause();
        }

        /// <summary>
        /// Method Compare by Course
        /// </summary>
        /// <param name="st1">первый студент</param>
        /// <param name="st2">второй студент</param>
        /// <returns></returns>
        static int CompareByCource(Student st1, Student st2)
        {
            if (st1.GetCourse > st2.GetCourse) return 1;
            if (st1.GetCourse < st2.GetCourse) return -1;
            return 0;
        }

        /// <summary>
        /// Method Compare by Age
        /// </summary>
        /// <param name="st1">первый студент</param>
        /// <param name="st2">второй студент</param>
        /// <returns></returns>
        static int CompareByAge(Student st1, Student st2)
        {
            if (st1.GetAge > st2.GetAge) return 1;
            if (st1.GetAge < st2.GetAge) return -1;
            return 0;
        }

        /// <summary>
        /// Method Compare by LastName then FirstName
        /// </summary>
        /// <param name="st1">первый студент</param>
        /// <param name="st2">второй студент</param>
        /// <returns></returns>
        static int CompareByName(Student st1, Student st2)
        {
            //Сравниваем две фамилии
            int res = String.Compare(st1.GetLastName, st2.GetLastName);

            //Если фамилии одинаковы, то сравниваем имена
            if (res == 0) return String.Compare(st1.GetFirstName, st2.GetFirstName); else return res;
        }

        /// <summary>
        /// Method Compare by Course & Age
        /// </summary>
        /// <param name="st1">первый студент</param>
        /// <param name="st2">второй студент</param>
        /// <returns></returns>
        static int CompareByCourseAge(Student st1, Student st2)
        {
            int res = st1.GetCourse.CompareTo(st2.GetCourse);
            if (res == 0) return st1.GetAge.CompareTo(st2.GetAge);
            else return res;
        }

        /// <summary>
        /// **В файле могут встречаться номера телефонов, записанные в формате xx-xx-xx, xxx-xxx или xxx-xx-xx.
        /// Вывести все номера телефонов, которые содержатся в файле.
        /// </summary>
        static void Task4()
        {
            // Prepare Console
            SupportMethods.Pause($"**В файле могут встречаться номера телефонов, записанные в формате xx-xx-xx, xxx-xxx или xxx-xx-xx.\n" +
                $"Вывести все номера телефонов, которые содержатся в файле.");

            // Regex pattern for xx-xx-xx, xxx-xxx или xxx-xx-xx in text
            string pattern = @"((\d{2}-\d{2}-\d{2})|(\d{3}-\d{2}-\d{2})|(\d{3}-\d{3}))";

            // Create and initialize new regex
            Regex rgx = new Regex(pattern);

            // Check if file exist
            if (File.Exists("file.dat"))
            {
                // Read all text from file into string
                string text = File.ReadAllText("file.dat");

                SupportMethods.Pause($"Текущее содержание файла:\n{text}");

                // try to get one matches
                Console.WriteLine("\nНайденные номера:\n");

                foreach (var c in rgx.Matches(text))
                    Console.WriteLine($"{c}");
            }
            else Console.WriteLine("File not found!");

            SupportMethods.Pause();

        }

        /// <summary>
        /// **Модифицировать задачу “Сложную задачу” ЕГЭ так, чтобы она решала задачу с 10 000 000 элементов менее чем за минуту.
        /// 
        /// Для заданной последовательности неотрицательных целых чисел необходимо найти максимальное произведение двух её элементов, номера которых различаются не менее, чем на 8.
        /// Значение каждого элемента последовательности не превышает 100 000.
        /// Количество элементов последовательности равно 100 000.
        /// Сгенерировать файл из случайных чисел и решить эту задачу
        /// </summary>
        static void Task5()
        {
            // Prepare Console
            SupportMethods.Pause($"**Модифицировать задачу “Сложную задачу” ЕГЭ так, чтобы она решала задачу с 10 000 000 элементов менее чем за минуту.\n" +
                $"Press any key to continue...");

            int i, j, max;

            ClassTask5.SaveToFile("data_for_task5.bin", 10000000);

            DateTime d = DateTime.Now;
            Console.WriteLine($"Время начала: {d}");

            ClassTask5 t = new ClassTask5("data_for_task5.bin");
            t.Max(out i, out j, out max);
            SupportMethods.Pause($"Максимальное произведение двух элементов равно {max}\n" +
                $"номера элементов {i} и {j}\n" +
                $"Время выполнения {DateTime.Now - d}");

            //SupportMethods.Pause("Максимальное произведение двух элементов равно 1409865409\n");
        }

        /// <summary>
        /// ***В заданной папке найти во всех html файлах теги <img src=...> и вывести названия картинок.
        /// Использовать регулярные выражения.
        /// </summary>
        static void Task6()
        {
            // Prepare Console
            SupportMethods.Pause($"***В заданной папке найти во всех html файлах теги <img src=...> и вывести названия картинок." +
                $"Использовать регулярные выражения.\n");

            // Получаем список файлов в папке. AllDirectories - сканировать также и подпапки
            string[] fs = Directory.GetFiles("C:\\tmp\\test", "*.html", SearchOption.AllDirectories);

            string pattern = @"\<img src=""(.*?)\""";

            // Просматриваем каждый файл в массиве
            foreach (var filename in fs)
            {
                // Создаем регулярное выражения дя поиска тегов                
                Regex regex = new Regex(pattern);
                
                // Считываем файл
                string s = File.ReadAllText(filename);
                Console.WriteLine($"\n{filename}:");
                
                // Выводим найденные адреса на экран
                foreach (Match c in regex.Matches(s))
                    //Console.WriteLine($"{c} {regex.Matches(s)}");
                    Console.WriteLine($"{c.Groups[1].Value}");
            }
            Console.ReadKey();
        }
    }
}

