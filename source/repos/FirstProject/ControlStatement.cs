using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    internal class ControlStatement
    {
        public static void Loops()
        {
            Console.WriteLine("Control Statements \n");

            //for loop and initializatio
            Console.WriteLine("Hello Everyone");
            int a = 10;
            int b = (int)20.2;
            for (int i = 0; i < a; i++)
            {
                //Console.WriteLine(a*b/0); ==> shows unchecked exception
                Console.WriteLine(i);
            }


            //if and nested if
            float ac = 10;
            int bc = (int)20.2;
            for (int i = 0; i < ac; i++)
            {
                if (i == 5 && bc >= 0)
                {
                    if (ac / 2 == i)
                    {
                        Console.WriteLine("inside nested-if condn");
                    }
                    else
                    {
                        Console.WriteLine("inside nested-else condn");
                    }
                }
                else
                {
                    Console.WriteLine("else condn");
                }
            }

            //while and do-while
            int j = 0;
            while (j <= 5)
            {
                Console.WriteLine(j);
                j++;
            }
            int k = 0;
            do
            {
                Console.WriteLine("inside do while loop");
                if (k >= 1)
                {
                    Console.WriteLine("after while condition " + k);
                }
                k++;
            } while (k <= 5);
            //break and
            //goto statements ==> works on c# but java


            int c = 0;
            for (c = 0; c < 10; c++)
            {
                if (c == 7)
                {
                    //break; ==> breaks the loop and exit from the running state
                    // continue; ==> skips the current iteration and take the next value into te loop


                    goto warning;

                }
                Console.WriteLine(c);
            warning:  // however tis statement gonna run but goto indicates that to run again (not advisable to use)
                Console.WriteLine("inside label");
            }


            Console.WriteLine("\n");

        }
    }
}
