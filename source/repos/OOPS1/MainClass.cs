using OOPS;

namespace OOPS1
{
    internal class MainClass : AccessSpecifiers
    {
        static void Main(string[] args)
        {
            //MainClass specifiers = new MainClass(); ;
            AccessSpecifiers specifiers = new AccessSpecifiers();
            specifiers.Display("Hello there!");
            Console.WriteLine(specifiers.name);
        }
    }
}