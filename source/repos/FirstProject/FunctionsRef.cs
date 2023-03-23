using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    internal class FunctionsRef
    {
        public static void GetInput() {

            Console.WriteLine("Functions \n");

            //reading the input from the user:
            Console.WriteLine("enter your age");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("your entered age is : " + age);
            if (age < 30)
            {
                Console.WriteLine("young champ!! welcome");
            }
            else if (age >= 30)
            {
                Console.WriteLine(":(( getting older");
            }
            else
            {
                Console.WriteLine("specify the correct age in proper format!");
            }

            // function calling using ref and without ref
            int a1 = 10;
            Console.WriteLine("before function call: " + a1);
            func1(ref a1);
            Console.WriteLine("after the function call " + a1);


            Console.WriteLine("\n");

        }

        public static void func1(ref int a1) //value will be updated after the execution of the function and reflected outside the function
        {
            a1 = 20;
            Console.WriteLine("inside the function : " + a1);
        }
    }
}
