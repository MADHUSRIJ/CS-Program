using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    internal class Strings
    {
        public static void WorkWithString()
        {
            Console.WriteLine("Strings \n");

            //String handling
            string a = "A"; //65   A to Z ==> 65 to 90
            string b = "j"; //   a to z ==> 97 to 122
            //Console.WriteLine(a.Substring(0,5) +" "+ b.ToLower());//substring and lowercase
            Console.WriteLine(string.Concat(a, b)); //concatenation
            Console.WriteLine(string.Compare(a, b, StringComparison.Ordinal)); // 0 ==> identical 1==> a<b (in ascii value -1==> a>b
            bool result = a.Equals(b, StringComparison.OrdinalIgnoreCase); //oridinal tells the difference between specified character in forms of ascii value
            //oridinal ignorecase ==> ignores the upper and lowercase which is in the difference of 32
            Console.WriteLine(result);

            string name = Console.ReadLine();
            string demo = "hello and  \"welcome\" everyone";
            Console.WriteLine(demo);
            string exp = $"this is pancake tuesday , welcome {name} have fun";
            Console.WriteLine(exp);

            //arrays
            string[] names = { "Madhu", "Nithin", "Meenu" };
            Console.WriteLine(names[0]);
            Console.WriteLine("length of the string: " + names.Length);
            foreach (string named in names)
            {
                Console.WriteLine(named);

            }
            //array declaration
            string[] arr1 = new string[9]; // if the size is known prior
            string[] arr2 = new string[3] { "dog", "cat", "bird" }; //==> 0, 1, 2
            string[] arr3 = { "", "", "" };
            int[] num1 = new int[5];
            foreach (int i in num1)
            {
                num1[i] = Convert.ToInt32(Console.ReadLine());
            }
            foreach (int i in num1)
            {
                Console.WriteLine(num1[i]);
            }


            for (int i = 0; i < 5; i++)
            {
                //reading array elements from the user   
                num1[i] = Convert.ToInt32(Console.ReadLine());
            }

            // accessing array elements using the for loop  
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(num1[i]);
            }
            
            int[] num2 = { 12, 24, 67, 89 };
            Console.WriteLine("MAXIMUM : " + num2.Max());
            Console.WriteLine("SUM :" + num2.Sum());
            int number= Convert.ToInt32(Console.ReadLine());
            string res = $"your mark is {number}!";
            Console.WriteLine(res);

            Console.WriteLine("Please enter your name: ");
            string your_name = Console.ReadLine();
            Console.WriteLine("Please enter your roll number: ");
            int roll_no = Convert.ToInt32(Console.ReadLine());

            namingfunc(your_name, roll_no);
            //method overloading ==> multiple methods can  have same name with diferent parameters


            Console.WriteLine("\n");

        }

        static void namingfunc(string your_name, int roll_no)
        {
          string name = $"Warm Welcome '{your_name}' , " +
                       $"have a wonderful wednesday! " +
                       $"your rollno. is '{roll_no}'";
          Console.WriteLine(name);
        }
    }
}
