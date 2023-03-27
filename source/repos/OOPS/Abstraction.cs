using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    abstract public class Abstraction
    {
        abstract public void Abmethod(int m, int n);
        public void Abmethod2()
        {
            Console.WriteLine("Inside the abstract class's non abstract method");
        }
    }

    public class MyClass : Abstraction 
    {
        override public void Abmethod(int m,int n)
        {
            Console.WriteLine("Hello");
            Console.WriteLine(n + m);
        }

        public void Test()
        {
            Console.WriteLine("Test Method");
        }
        
    }
}
