using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    internal class Override
    {
        public void MethodRide() 
        {
            Console.WriteLine("Hello ");
        }

        public void MethodRide(int i)
        {
            Console.WriteLine("Hello " + i);
        }
    }
}
