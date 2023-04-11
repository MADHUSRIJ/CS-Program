using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RationalNumber
{
    public struct Number
    {
        public int Numerator;
        public int Denominator;
    }
    public class Rational
    {
        Number number;
        public Rational(int numerator,int denominator)
        {
            try
            {
                if( denominator == 0)
                {
                    throw new DivideByZeroException("Denominator cannot be zero");
                }
                else
                {
                    number = new Number();

                    int gcd = Gcd(numerator, denominator);

                    number.Numerator = numerator/gcd;
                    number.Denominator = denominator/gcd;
                }
            }
            catch(Exception error)
            { 
                Console.WriteLine(error.Message);
            }
        }

        

        public static Rational operator +(Rational r1, Rational r2)
        {
            
            int numerator = 0;
            int denominator = 0;

            numerator = (r1.number.Numerator * r2.number.Denominator) + (r1.number.Denominator * r2.number.Numerator);
            denominator = r1.number.Denominator * r2.number.Denominator;

            int gcd = Gcd(numerator,denominator);

            return new Rational(numerator/gcd, denominator/gcd);
        }


        public static Rational operator -(Rational r1, Rational r2)
        {

            int numerator = 0;
            int denominator = 0;

            numerator = (r1.number.Numerator * r2.number.Denominator) - (r1.number.Denominator * r2.number.Numerator);
            denominator = r1.number.Denominator * r2.number.Denominator;

            int gcd = Gcd(numerator, denominator);

            return new Rational(numerator / gcd, denominator / gcd);
        }

        public static Rational operator *(Rational r1, Rational r2)
        {

            int numerator = 0;
            int denominator = 0;

            numerator = r1.number.Numerator  * r2.number.Numerator;
            denominator = r1.number.Denominator * r2.number.Denominator;

            int gcd = Gcd(numerator, denominator);

            return new Rational(numerator / gcd, denominator / gcd);
        }

        public static Rational operator /(Rational r1, Rational r2)
        {

            int numerator = 0;
            int denominator = 0;

            numerator = r1.number.Numerator *  r2.number.Denominator;
            denominator = r1.number.Denominator * r2.number.Numerator;

            int gcd = Gcd(numerator, denominator);

            return new Rational(numerator / gcd, denominator / gcd);
        }

        public static Rational operator -(Rational r)
        {
            return new Rational(-r.number.Numerator, r.number.Denominator);
        }

        public static bool operator ==(Rational r1, Rational r2)
        {
            if(r1.number.Numerator == r2.number.Numerator && r1.number.Denominator == r2.number.Denominator)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Rational r1, Rational r2)
        {
            if(r1 == r2)
            {
                return false;
            }
            return true;
        }

        public static bool operator <(Rational r1, Rational r2)
        {
            if(r1.number.Numerator * r2.number.Denominator < r2.number.Numerator * r1.number.Denominator)
            {
                return true;
            }
            return false;
        }

        public static bool operator <=(Rational r1, Rational r2)
        {
            if (r1.number.Numerator * r2.number.Denominator <= r2.number.Numerator * r1.number.Denominator)
            {
                return true;
            }
            return false;
        }

        public static bool operator >(Rational r1, Rational r2)
        {
            if (r1.number.Numerator * r2.number.Denominator > r2.number.Numerator * r1.number.Denominator)
            {
                return true;
            }
            return false;
        }

        public static bool operator >=(Rational r1, Rational r2)
        {
            if (r1.number.Numerator * r2.number.Denominator >= r2.number.Numerator * r1.number.Denominator)
            {
                return true;
            }
            return false;
        }


        private static int Gcd(int a, int b)
        {
            return b == 0 ? a : Gcd(b, a % b);
        }

        public int Sign()
        {
            if(number.Denominator < 0 || number.Numerator < 0)
            {
                return -1;
            }
            if (number.Numerator == 0)
            {
                return 0;
            }
            return 1;
        }

        public override string ToString()
        {
            if(number.Denominator == 1)
            {
                return $"{number.Numerator}";
            }
            if (number.Denominator < 0)
            {
                number.Numerator = - number.Numerator;
                number.Denominator = -number.Denominator;
            }

            if (number.Numerator == 0)
            {
                return "0";
            }
            return $"{number.Numerator}/{number.Denominator}";
        }

    }
}
