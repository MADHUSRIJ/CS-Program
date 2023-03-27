namespace OOPS
{
    //sealed class cant be inherited
    //sealed method cant be overriden but can be extracted from other class
    internal class Program 
    {
        static void Main(string[] args)
        {
            //Test obj = new Test();
            //obj.method();
            //obj.method2();

            //Program specifiers = new Program();
            /*AccessSpecifiers specifiers = new AccessSpecifiers();
            specifiers.Display("Hello there!");
            Console.WriteLine(specifiers.name);

            Ninja nj = new Ninja();
            nj.Test();
            nj.MaxSpeed(30);
            nj.ABS();
*/
            //Student student = new Student("Madhu", 21, 118, 102,new Marks(489,5));
            //student.Display();

            MyClass1 mc = new MyClass1();
            InterfaceClass ic = new MyClass1();
            mc.m1();
            mc.m2(21);
            ic.m3("Madhu");

        }
    }
}