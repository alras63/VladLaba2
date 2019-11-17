using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VladLab2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * a - длина матрицы, b - ее ширина
             */

            int aInt, bInt;
            string aStr, bStr;
            Console.WriteLine("Введите длину a прямоугольной матрицы");
            aStr = Console.ReadLine();
            while(!Int32.TryParse(aStr, out aInt))
            {
                Console.WriteLine("Я ожидал получить целое число...");
                aStr = Console.ReadLine();
            }

            Console.WriteLine("Введите длину b прямоугольной матрицы");
            bStr = Console.ReadLine();
            while (!Int32.TryParse(bStr, out bInt))
            {
                Console.WriteLine("Я ожидал получить целое число...");
                bStr = Console.ReadLine();
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Генерируем случайную матрицу с параметрами a={0}, b={1}", aInt, bInt);
            Console.ResetColor();
            GenerateMatrix generate = new GenerateMatrix();
            int[,] matrix = generate.GenerateMatrixFunc(aInt, bInt);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Выводим сгенерированную матрицу");
            Console.ResetColor();

            for (var i = 0; i < aInt; i++)
            {
                for (var j = 0; j < bInt; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Посчитаем, сколько получилось столбцов, не содержащих ни одного нуля");
            Console.ResetColor();

            bool[] hasZero = new bool[aInt*bInt];
            int hasZerocount = 0;
            for (var j = 0; j < bInt; j++)
            {
                for (var i = 0; i < aInt; i++)
                {
                    if(matrix[i, j] == 0 && !hasZero[j])
                    {
                        hasZero[j] = true;
                        hasZerocount++;
                    }
                   
                }
            }

            Console.WriteLine();
            Console.WriteLine("Таких столбцов " + (hasZerocount));



            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Расположим строки исходной матрицы в порядке, зависящем от суммы четных положительных элементов в этой строке");

            int[] lineSum = new int[aInt];
            for (var i = 0; i < aInt; i++)
            {
                for (var j = 0; j < bInt; j++)
                {
                    if((matrix[i, j] > 0) && (matrix[i, j] % 2 == 0))
                    {
                        lineSum[i] += matrix[i, j];
                    }
                   
                }
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Суммы четных положительных элементов в строках: ");

            Console.ResetColor();

            foreach(var el in lineSum)
            {
                Console.Write(el + "\t");
            }
            Console.WriteLine();

            int[,] sortedMatr = new int[aInt, bInt];
             for (int i = 0; i< aInt; i++)
             {
                 try
                 {
                     if (lineSum[i + 1] < lineSum[i])
                     {
                         for (int j = 0; j < bInt; j++)
                         {

                             int buf = matrix[i, j];
                             matrix[i, j] = matrix[i + 1, j];
                             matrix[i + 1, j] = buf;
                         }

                         int lineBuf = lineSum[i];
                         lineSum[i] = lineSum[i + 1];
                         lineSum[i + 1] = lineBuf;
                         i = 0;
                     }
                 }
                 catch{}

             }

          /*  int y, tmp;
            for(int i =0; i< aInt-1; i++)
            {
               
                for(y = 0; y < aInt-1-i; y++)
                {
                  
                    if (lineSum[y] > lineSum[y+1]) {
                        for (int j = 0; j < bInt; j++)
                        {
                            tmp = matrix[y, j];
                            matrix[y, j] = matrix[y+1, j];
                            matrix[y+1, j] = tmp;
                        }
                    } 
                    
                }
            } */
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Выводим отсортированную матрицу");
            Console.ResetColor();

            for (var i = 0; i < aInt; i++)
            {
                for (var j = 0; j < bInt; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Суммы элементов в строках: ");

            Console.ResetColor();

            foreach (var el in lineSum)
            {
                Console.Write(el + "\t");
            }
            Console.WriteLine();
            Console.ReadLine();

        }

      
    }
}
