using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class SaraPsycology
    {
        public static void SaraMain()
        {
            int k = 4;
            do
            {
                Console.WriteLine(" Press \n 1 - Be a Mentalist \n 2 - Mimic Ptolemy \n 3 - Calendar man \n 0 - Exit \n");
                k = Convert.ToInt32(Console.ReadLine());
                SaraPsycology sp = new SaraPsycology();
                switch (k)
                {
                    case 1:
                        sp.iteration1();
                        break;

                    case 2:
                        sp.iteration2();
                        break;

                    case 3:
                        sp.iteration3();
                        break;

                    default:
                        Console.WriteLine("Invalid Input \n");
                        break;

                }
            }
            while(k!=0);

        }
        public void iteration1()
        {
            Console.WriteLine("What is your favorite Rainbow Color ? \n Press \n 1 - Violet \n 2 - Indigo \n" +
                " 3 - Blue \n 4 - Green \n 5 - Yellow \n 6 - Orange \n 7 - Red \n");
            int color = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Tell a number from 1 to 10 \n"); 
            int no = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            if (no < 1 || no > 10 || color < 1 || color > 7)
            {
                Console.WriteLine("Invalid Input");
                return;
            }
            else if(color < 4 && no <= 5)
            {
                Console.WriteLine("You are an energetic and passionate person, but impulsive");
            }
            else if(color >= 4 && no <= 5){
                Console.WriteLine("You are confident and ambitious, with a natural leadership ability");
            }
            else if (color < 4 && no > 5)
            {
                Console.WriteLine("You have a creative mind and a deep appreciation for art and beauty");
            }
            else if (color >= 4 && no > 5)
            {
                Console.WriteLine("You have a great sense of humor and find joy in making others laugh");
            }
            Console.WriteLine();

            Console.WriteLine("If the personality trait matches you, \n Press 1 otherwise Press 2");

            int match = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            if (match == 1)
            {
                Console.WriteLine("Thanks for your Response !");
            }
            else if(match == 2) 
            {
                Console.WriteLine("Sorry. We regret !");
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
            Console.WriteLine();

        }
        public void iteration2()
        {
            Console.WriteLine("What is your birth month (1-12)");
            int month = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            String[] zodiac = { "Aries","Taurus","Gemini","Cancer","Leo","Virgo",
                "Libra","Scorpio","Sagittarius","Capricorn","Aquarius","Pisces" };
            String[] character = { "Creative", "Extrovert", "Open to experience","Consious",
                "Funny","Ambitious","Flexible","Honest","Confident","Kind","Loyal","Responsible" };
            if (month > 0 && month < 13)
            {
                Console.WriteLine("Your zodiac sign is " + zodiac[month - 1] + " and your partner will be " + character[12 - month]+ " ans their zodiac sign will be" +
                    " "+ zodiac[12-month]);
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
            Console.WriteLine();
        }
        public void iteration3()
        {
            Console.WriteLine("Enter your Birth Date (dd/mm/yyyy)");

            string bd = Console.ReadLine();
            DateTime dob;

            try
            {
                dob = DateTime.Parse(bd);
                DateTime now = DateTime.Today;

                int age = now.Year - dob.Year;

                Console.WriteLine("Your age is " + age);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error :"+e.ToString());
            }
            Console.WriteLine();

        }
    }
}
