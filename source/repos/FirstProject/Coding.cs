using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    internal class Coding
    {
        public static void Programs1() {
            int k = Convert.ToInt32(Console.ReadLine());    
            int[] arr = new int[k];
            for(int i = 0; i < k; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            List<int> list = new List<int>();
            List<int> duplicates = new List<int>();  

            foreach(int i in arr)
            {
                if (!list.Contains(i))
                {
                    list.Add(i);
                }
                else
                {
                    duplicates.Add(i);
                }
            }

            Console.WriteLine("No. of Duplicate Elements " + duplicates.Count);

        }

        public static void Programs2() {
            Console.WriteLine("Length");
            int k = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Array 1");
            int[] arr = new int[k];
            for (int i = 0; i < k; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Array 2");
            int[] arr1 = new int[k];
            for (int i = 0; i < k; i++)
            {
                arr1[i] = Convert.ToInt32(Console.ReadLine());
            }


            int[] ans = new int[(2*k)+1];

            for( int i = 0; i < k; i++)
            {
                ans[i] = arr[i];
            }

            for (int i = k; i < 2*k; i++)
            {
                ans[i] = arr1[i-k];
            }

            int temp = 0;

            for (int i = 0; i <= ans.Length - 1; i++)
            {
                for (int j = i + 1; j < ans.Length; j++)
                {
                    if (ans[i] > ans[j])
                    {
                        temp = ans[i];
                        ans[i] = ans[j];
                        ans[j] = temp;
                    }
                }
            }
            Console.WriteLine("Array sort in asscending order");
            foreach (int m in ans)
            {
                Console.Write(m+" ");
            }
            Console.ReadLine();
        }

        public static void Programs3()
        {
            Console.WriteLine("Length");
            int k = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Array");
            int[] arr = new int[k];
            for (int i = 0; i < k; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            List<int> odd = new List<int>();    
            List<int> even = new List<int>();   

            foreach(int i in arr)
            {
                if(i%2 == 0)
                {
                    even.Add(i); 
                }
                else
                {
                    odd.Add(i);
                }
            }

            Console.WriteLine("Even");
            foreach(int i in even)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n");
            Console.WriteLine("Odd");
            foreach (int i in odd)
            {
                Console.Write(i + " ");
            }
        }
    }
}
