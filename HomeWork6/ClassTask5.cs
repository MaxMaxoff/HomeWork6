using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/// <summary>
/// Максим Торопов
/// Ярославль
/// Домашняя работа 6 урока
/// </summary>
namespace HomeWork6
{
    /// <summary>
    /// Просто класс, чтобы не засорять основной код
    /// </summary>
    class ClassTask5
    {
        int[] a;

        /// <summary>
        /// 
        /// </summary>
        public ClassTask5()
        {
            Console.WriteLine("File not found!");
        }

        /// <summary>
        /// Initialize and fill array
        /// </summary>
        /// <param name="fileName"></param>
        public ClassTask5(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            a = new int[fs.Length / 4];

            for (int i = 0; i < fs.Length / 4; i++) // int занимает 4 байта
            {
                a[i] = br.ReadInt32();
            }

            br.Close();
            fs.Close();
        }

        /// <summary>
        /// Method SaveToFile
        /// Generate file for Task5
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="n"></param>
        public static void SaveToFile(string fileName, int n)
        {
            Random rnd = new Random();
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            for (int i = 1; i < n; i++)
            {
                bw.Write(rnd.Next(0, 100000)); // int -занимает 4 байта
            }
            fs.Close();
            bw.Close();
        }

        /// <summary>
        /// Method LoadFromFile
        /// Load data from file
        /// </summary>
        /// <param name="fileName"></param>
        public void Max(out int max1, out int max2, out int max)
        {
            // 3 Переменные типа int для вывода результата
            max = 0;
            max1 = 0;
            max2 = 0;

            // массив 17 максимальных элементов из всей последовтельности
            int[] arrOfMax = new int[17];

            // признак наличия элемента в массиве
            bool isInArrOfMax;

            // заполняем массив индексами 17-и максимальных элементов из всей последовательности
            for (int j = 0; j < 17; j++)
                for (int i = 0; i < a.Length; i++)
                    if (a[i] >= a[arrOfMax[j]])
                    {
                        isInArrOfMax = false;
                        for (int k = 0; k < 17; k++)
                            if (i == arrOfMax[k]) isInArrOfMax = true;
                        if (!isInArrOfMax) arrOfMax[j] = i;
                    }

            // ищем максимальное произведение элементов в последовательности
            for (int i = 0; i < 17; i++)
            {
                for (int j = 0; j < 17 && Math.Abs(arrOfMax[i] - arrOfMax[j]) >= 8; j++)
                    if (a[arrOfMax[i]] * a[arrOfMax[j]] > max)
                    {
                        max = a[arrOfMax[i]] * a[arrOfMax[j]];
                        max1 = arrOfMax[i];
                        max2 = arrOfMax[j];
                    }
                Console.WriteLine($"Index: {arrOfMax[i]}; Value: {a[arrOfMax[i]]}");
            }
        }
    }
}
