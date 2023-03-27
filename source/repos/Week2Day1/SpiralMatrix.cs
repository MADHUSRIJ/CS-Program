using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Day1
{
    internal class SpiralMatrix
    {
        public void matrix()
        {
            Console.WriteLine("Enter the size of the square matrix : ");
            //int n = Convert.ToInt32(Console.ReadLine());
            int n = 3;

            int[,] mat = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 } ,{9,10,11,12 },{ 13,14,15,16} };
            //int[,] mat = { { 1, 2, 3 }, { 4, 5, 6 }, { 7,8,9 } };

            int k = 0;
            int m = n;

            List<int> no = new List<int>();

            while(k!=m) 
            {
                int a = k;
                int b = 0;

                while (b < m)
                {
                    no.Add(mat[a,b]);
                    b++;
                }
                a++;
                b--;
                while (a < m)
                {
                    no.Add(mat[a,b]);
                    a++;
                }
                b = m-2;
                a = m-1;
                while (b >= k)
                {
                    no.Add(mat[a,b]);
                    b--;
                }
               
                b = k;
                a = m-2;
                while (a > b+1)
                {
                    no.Add(mat[a,b]);
                    a--;
                }
                k++;
                m--;

            }

            foreach(int i in no)
            {
                Console.Write(i+" ");
            }
            Console.WriteLine();

        }
    }
}
