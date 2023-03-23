using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    internal class Arrays
    {
        public static void AnArray()
        {
            Console.WriteLine("Arrays \n");

            int[] arr1 = { 1, 2, 3 };

            Console.WriteLine("For Each Loop");

            foreach (int i in arr1)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("For Loop");

            for (int i = 0; i < arr1.Length; i++)
            {
                Console.WriteLine(arr1[i]);
            }

            Console.WriteLine("Method");

            PrintAnArray(arr1);


            //multidimensional array 
            int[,] numbers = { { 1, 4, 2 }, { 3, 6, 8 }, { 7, 9, 0 } };
            foreach (int i in numbers)
            {
                Console.WriteLine(i);
            }

            int[,] number = { { 1, 4, 2 }, { 3, 6, 8 } };

            for (int i = 0; i < number.GetLength(0); i++) //==> getlength =?
            {
                for (int j = 0; j < number.GetLength(1); j++)
                {
                    Console.WriteLine(number[i, j]);
                }
            }

            //3D Array
            int[] a1 = { 1, 2, 3 };
            PrintAnArray(a1);
            //2D ARRAY
            int[,] a3 = new int[3, 3];
            a3[0, 1] = 2;
            int[,,] a2 = { { { 15, 16, 17 }, { 1, 2, 3 }, { 9, 10, 30 } }, { { 20, 30, 40 }, { 34, 87, 90 }, { 34, 12, 45 } }, { { 45, 56, 78 }, { 87, 90, 43 }, { 8, 2, 1 } } };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        Console.Write(" index of i : " + i + " index f j: " + j + " index of k: " + k + " " + a2[i, j, k] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            int[][] arr = new int[2][];
            arr[0] = new int[] { 1, 2 };
            arr[1] = new int[] { 3, 4 };


            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j]);
                }
                Console.WriteLine();
            }


            Console.WriteLine("\n");


        }
        public static void PrintAnArray(int[] arr)
        {
            foreach (int i in arr)
            {
                Console.WriteLine(i);
            }
        }


    }

}
