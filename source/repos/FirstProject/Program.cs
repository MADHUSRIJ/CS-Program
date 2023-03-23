using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;

namespace FirstProject
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ControlStatement.Loops();
            
            FunctionsRef.GetInput();
            
            Strings.WorkWithString();
            
            Arrays.AnArray();

            Constructor cons = new Constructor("Madhu");

            Console.WriteLine(cons.GetDetails());

        }

    }

    }
