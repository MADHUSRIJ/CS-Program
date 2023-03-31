using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hands_On
{
    internal class Predictor
    {
        static void Pred(string[] args)
        {
            DateTime dateOfBirth = DateTime.ParseExact(Console.ReadLine()!, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            NumberPredictor np = new NumberPredictor();
            int luckyNumber = np.GetLuckynumber(dateOfBirth);
            Console.WriteLine("\nYour lucky number is " + luckyNumber);
        }
    }
    public class NumberPredictor
    {
        public int GetLuckynumber(DateTime dateOfBirth)
        {
            int num = dateOfBirth.Day;
            int fib1 = 0;
            int fib2 = 1;
            int fib3 = 1;

            while (fib3 <= num)
            {
                fib3 = fib1 + fib2;
                fib1 = fib2;
                fib2 = fib3;
            }

            Console.Write($"{fib1} ");
            Console.Write($"{fib2} ");

            return (Math.Abs(num - fib1) < Math.Abs(num - fib2)) ? fib1 : fib2;
        }

        public int GetUnluckynumber(DateTime dateOfBirth)
        {
            return 0;
        }
    }
}
