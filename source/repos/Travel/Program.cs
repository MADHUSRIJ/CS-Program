using System.Linq;
using System.Text.RegularExpressions;

namespace Travel
{
    /*Travelling through Europe one needs to pay attention to
    how the license plate in the given country is displayed.
    When crossing the border you need to park on the shoulder,
    unscrew the plate, re-group the characters according to
    the local regulations, attach it back and proceed with the journey.

    Create a solution that can format the dmv number
    into a plate number with correct grouping.
    The function input consists of string s and group length n.
     The output has to be upper case characters and digits.
    The new groups are made from right to left and connected by -.
     The original order of the dmv number is preserved.

    Examples
    LicensePlate("5F3Z-2e-9-w", 4) ➞ "5F3Z-2E9W"

    LicensePlate("2-5g-3-J", 2) ➞ "2-5G-3J"

    LicensePlate("2-4A0r7-4k", 3) ➞ "24-A0R-74K"

    LicensePlate("nlj-206-fv", 3) ➞ "NL-J20-6FV"*/
    public class Program
    {
        public string newDmv = "";
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the dmv number");
            string originalDmv = Console.ReadLine();
            Console.WriteLine("Enter the number");
            int number = Convert.ToInt32(Console.ReadLine());

            Program program = new Program();
            program.LicensePlate(originalDmv,number);

            Console.WriteLine("New DMV Number - " + program.newDmv);


        }

        public void LicensePlate(string originalDmv,int number)
        {
            string[] originalDmvSeparation = originalDmv.Split("-");


            string dmv = "";
            foreach (string s in originalDmvSeparation)
            {
                String upper = s.ToUpper();
                dmv+=upper;
            }

            String tempDmv = "";
            int count = 0;

            for(int i = dmv.Length - 1; i >= 0; i--)
            {
                if(count == number)
                {
                    tempDmv+="-";
                    count = 0;
                }
                tempDmv+=dmv[i];
                count++;
            }

            string tempDmv2 = "";

            for(int i=tempDmv.Length - 1;i >= 0; i--)
            {
                tempDmv2 += tempDmv[i];
            }
            newDmv = tempDmv2;
            //Console.WriteLine(tempDmv);

        }
    }
}