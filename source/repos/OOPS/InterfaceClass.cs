using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    public interface InterfaceClass
    {
        public void m1();
        public void m2(int age);
        public void m3(string name)
        {
            Console.WriteLine("Hi Interface " + name);
        }

    }

    public class MyClass1 : InterfaceClass
    {
        public void m1()
        {
            Console.WriteLine("Inside m1");
        }

        public void m2(int age)
        {
            Console.WriteLine("Inside m2 with "+age);
        }

        
    }
}
