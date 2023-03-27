using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    public class Test
    {
        private Test1 a = new Test1();
        public void method()
        {
            a.methodTest1();
            Console.WriteLine("Inside Test");
        }

        private void method2() 
        { 
            Console.WriteLine("inside private");
        }

        private class Test1
        {
            public void methodTest1()
            {
                Console.WriteLine("Inside private class");
            }
        }
    }
    
}
