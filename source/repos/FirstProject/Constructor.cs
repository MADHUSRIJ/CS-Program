using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    internal class Constructor
    {
        public static String myName;
        public Constructor(String name) {
            //Console.WriteLine("My name is " + name);
            Console.WriteLine("I am into Constructor Class");
            myName = name;

        }

        public String GetDetails()
        {
            return myName;
        }

    }
}
