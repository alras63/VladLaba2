using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VladLab2
{
    class GenerateMatrix
    {
        public int[,] GenerateMatrixFunc(int a, int b)
        {
            int[,] matrix = new int[a, b];

            Random rnd = new Random();
            for (var i = 0; i < a; i++)
            {
                for (var j = 0; j < b; j++)
                {
                    matrix[i, j] = rnd.Next(-5, 5);
                }
            }

            return matrix;
        }
    }

   
}
