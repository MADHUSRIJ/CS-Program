namespace Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int k;
            do
            {
                Console.WriteLine(" Press \n 1 - Sara Psychology \n 2 - Chocolate Dispenser \n 0 - Exit");
                k = Convert.ToInt32(Console.ReadLine());
                switch (k)
                {
                    case 1:
                        SaraPsycology.SaraMain();
                        break;
                    case 2:
                        Chocolate.ChocolateDispenser();
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
            while (k != 0);
        }
    }
}