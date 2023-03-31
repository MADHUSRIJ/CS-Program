using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Day2
{
    internal class RotateMatrix
    {
        public static void Matrix()
        {
            int m = Convert.ToInt32(Console.ReadLine());
            int n = Convert.ToInt32(Console.ReadLine());

            int[,] mat = new int[m,n];

            for(int i = 0; i < m; i++) 
            {
                for(int j = 0; j < n; j++)
                {
                    mat[i,j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            Console.WriteLine("Original Matrix");

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(mat[i,j]+" ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nRotated Matrix");

            for(int i = 0; i < n;i++)
            {
                for(int j = m-1; j >=0 ; j--)
                {
                    Console.Write(mat[j, i]+" ");
                }
                Console.WriteLine();
            }



        }
    }
}
