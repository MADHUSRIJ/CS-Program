namespace Asynchronous
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
             List <int> ints = new List<int>() { 1,2,3,4,5,6,7 };

             Func<List<int>, int> maxFinder = (ints) => ints.Max();
            Console.WriteLine("Maximum = " + maxFinder(ints));
             
             Console.ReadLine();


             int n = 5;
             Func<int, int> factorial = null;

            factorial = (x) => x == 0 ? 1 : x * factorial(x - 1); 

             int result = factorial(n); 
             Console.WriteLine($"The factorial of {n} is {result}");

        }
    }
}