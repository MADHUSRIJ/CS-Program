using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    public class Inheritance
    {
        public void MaxSpeed(int speed)
        {
            int maxSpeed = speed;
        }

        public void ABS() 
        {
            Console.WriteLine("ABS is applied");
        }
    }

    public class Ninja : Inheritance
    {
        public void Test()
        {
            Console.WriteLine("It is tested");
            MaxSpeed(1);
            ABS();
        }

        public void ABS()
        {
            Console.WriteLine("Advance abs is applied");
        }

    }

    public class NinjaSports : Ninja
    {
        
        public void SportsBike()
        {
            Console.WriteLine("It is a sports bike");
        }


    }



}
