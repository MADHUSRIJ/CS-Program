using System.Security.Cryptography;

namespace Week2Day2
{
    //delegates
    delegate void SumDelegate (int x,int y);
    delegate int DelegateForSum(int x, int y);
    delegate void Print(String msg);
    delegate void Display();
    internal class Program
    {
        static void Main(string[] args)
        {

            /*LambdaExp.Exp();
            LambdaExp.List();
            LambdaExp.Dict();
            LambdaExp.SortedList();
            AnonymousFunc.Run();*/

            RotateMatrix.Matrix();

            /*Program pgm = new Program ();
            int x = 12;
            int y = 6;
            SumDelegate sumDelegate = sum;
            //multicast delecate
            sumDelegate += pgm.subtract;
            //sumDelegate(x,y);
            sumDelegate.Invoke(x,y);

            SumDelegate sumDelegate1 = sum;
            SumDelegate sumDelegate2= pgm.subtract;
            SumDelegate sumDelegate3 = mul;
            SumDelegate sumDelegate4 = pgm.div;
            SumDelegate sumDelegate5 = sumDelegate1 + sumDelegate2 + sumDelegate3 + sumDelegate4;
            Delegate[] arr = sumDelegate5.GetInvocationList();

            foreach(var item in arr)
            {
                Console.WriteLine(item);
            }

            sumDelegate5.Invoke(34, 2);

          
            // Anonymous Method
            DelegateForSum dAdd = delegate (int a, int b) { return a + b; };
            Console.WriteLine(dAdd(10, 20));

            Print print = delegate (string msg) { Console.WriteLine(msg); };

            print.Invoke("Hello");*/


            //Built-In Delegates
            //Display d = helloWorld;
            //d();

            Action<string> act = (msg) => Console.WriteLine(msg);      //Action delegate
            act("from action delegate");

            Func<int, int, int> fun = (a, b) => a + b;      //FUNC delegate
            Console.WriteLine(fun(2, 3));

            Predicate<int> p = (a) => { return a > 5; };     //Predicate delegate
            Console.WriteLine(p(7));
        }

        static void helloWorld()
        {
            Console.WriteLine("hello");
        }
        public static void sum(int x,int y)
        {
            Console.WriteLine("Sum "+(x + y));
        }

        public void subtract(int x,int y)
        {
            Console.WriteLine("Subtract " + (x-y));
        }

        public static void mul(int x, int y)
        {
            Console.WriteLine("Multiply " + (x * y));
        }

        public void div(int x, int y)
        {
            Console.WriteLine("Dividie " + (x / y));
        }

    }
}