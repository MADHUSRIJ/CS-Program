namespace RationalNumber
{
    public class Program
    {
        static void Main(string[] args)
        {
           
            Rational r1 = new Rational(1, 2);
            Rational r2 = new Rational(10,8);
            Rational r3 = new Rational(2,-1);

            /*Rational r4 = r1 + r2; 
            Console.WriteLine(r4.ToString());
            Console.WriteLine((r1 * r3).ToString());
            Console.WriteLine((r2 - new Rational(-1, 4)).ToString());
            var r5 = (r1 + r2) / r3;
            Console.WriteLine(r5.ToString());
            Console.WriteLine((-r1).ToString());
            Console.WriteLine((-r3).ToString());
            Console.WriteLine((r1 - -r2).ToString());*/

            Console.WriteLine(r3.Sign());

        }
    }
}