using System.ComponentModel;

namespace Assessment2
{

    /*You have to get a new driver's license. You show up at the office at the 
     * same time as four other people. The office says they will see everyone 
     * in alphabetical order and it takes 20 minutes for them to process each new license. 
     * All of the agents are available now, and they can each see one customer at a time. 
     * How long will it take for you to walk out with your new license?

    Your input will be a string of your name me, an integer of the number of available agents, 
    and a string of the other four names separated by spaces others.

    Return the number of minutes it will take to get your license.

    Examples
    License("Eric", 2, "Adam Caroline Rebecca Frank") ➞ 40
    // As you are in the second group of people.

    License("Zebediah", 1, "Bob Jim Becky Pat") ➞ 100
    // As you are the last person.

    License("Aaron", 3, "Jane Max Olivia Sam") ➞ 20
    // As you are the first.*/
    public class Program
    {
        public int totalTime = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your Name");
            string yourName = Console.ReadLine();
            Console.WriteLine("Enter Number od agents available");
            int numberOfAgents = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Names of other four people separated by space");
            string peopleNames = Console.ReadLine();
            Program program = new Program();
            program.totalTimeToGetNewLicense(yourName,numberOfAgents,peopleNames);
            Console.WriteLine("Total Time - "+program.totalTime);

        }

        public void totalTimeToGetNewLicense(String yourName, int numberOfAgents, string peopleNames)
        {
            String[] peopleArray = peopleNames.Split(" ");

            List<string> people = new List<string>();

            foreach (string person in peopleArray)
            {
                people.Add(person);
            }

            people.Add(yourName);
            people.Sort();
           

            int index = people.IndexOf(yourName);
            
            for(int i = 0; i < people.Count; i += numberOfAgents)
            {
                totalTime += 20;
                if(index>=i && index < i + numberOfAgents - 1)
                {
                    break;
                }
            }
        }
    }
}