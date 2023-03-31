using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hands_On
{
    internal class Calc
    {
        static void Calcul(string[] args)
        {
            NormalCalculator normalCalc = new NormalCalculator();

            Console.WriteLine("2 Operands");
            Console.WriteLine($"Normal Addition: {normalCalc.Add(10, 5)}");
                      Console.WriteLine($"Normal Subtraction: {normalCalc.Subtract(10, 5)}");

                      Console.WriteLine("3 Operands");
                      Console.WriteLine($"Normal Addition: {normalCalc.Add(10, 5, 3)}");
                      Console.WriteLine($"Normal Subtraction: {normalCalc.Subtract(10, 5, 3)}");

                      OppositeCalculator oppositeCalc = new OppositeCalculator();

                      Console.WriteLine("2 Operands");
                      Console.WriteLine($"Opposite Addition: {oppositeCalc.Add(10, 5)}");
                      Console.WriteLine($"Opposite Subtraction: {oppositeCalc.Subtract(10, 5)}");

                      Console.WriteLine("3 Operands");
                      Console.WriteLine($"Opposite Addition: {oppositeCalc.Add(10, 5, 3)}");
                      Console.WriteLine($"Opposite Subtraction: {oppositeCalc.Subtract(10, 5, 3)}");
                  }
              }

              class NormalCalculator
              {
                  public virtual int Add(int a, int b)
                  {
                      return a + b;
                  }

                  public virtual int Add(int a, int b, int c)
                  {
                      return a + b + c;
                  }

                  public virtual int Subtract(int a, int b)
                  {
                      return a - b;
                  }

                  public virtual int Subtract(int a, int b, int c)
                  {
                      return a - b - c;
                  }
              }


              class OppositeCalculator : NormalCalculator
              {
                  public override int Add(int a, int b)
                  {
                      return a - b;
                  }

                  public override int Add(int a, int b, int c)
                  {
                      return a - b - c;
                  }

                  public override int Subtract(int a, int b)
                  {
                      return a + b;
                  }
                  public override int Subtract(int a, int b, int c)
                  {
                      return a + b + c;
                  }
              }
    
}
