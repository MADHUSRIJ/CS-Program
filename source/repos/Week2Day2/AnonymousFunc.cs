using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Day2
{
    internal class AnonymousFunc
    {
        public static void Run()
        {

            List<int> nums = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };

            var square = (int n) => { return n * n; };

            foreach (int num in nums)
            {
                Console.WriteLine(square(num));
            }

        }

       
    }
}
