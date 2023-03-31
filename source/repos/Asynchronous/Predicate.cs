using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asynchronous
{
    internal class Predicate
    {
        public static void Printer()
        {

            List<int> numbers = new List<int> { 2, 7, 4, 9, 1, 5, 6, 3 };
            Predicate<int> p = x => x > 5;
            List<int> greaterThanFive = numbers.FindAll(p);
            Console.WriteLine(string.Join(" ", greaterThanFive));

        }
    }
}
