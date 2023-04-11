namespace BalancedParantheses
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Get the number of pairs from the user
            Console.Write("Enter Pairs: ");
            int numberOfPairs = Convert.ToInt32(Console.ReadLine());

            Program program = new Program();

            List<string> ValidParantheses = program.ParanthesesBalance(numberOfPairs);

            foreach(string parantheses in ValidParantheses)
            {
                Console.WriteLine(parantheses);
            }
        }

        public List<string> ParanthesesBalance(int numberOfPairs)
        {
            // Store all combinations of well-formed parentheses in PossibleParantheses List.
            List<string> ValidParantheses = new List<string>();

            GetBalancedParantheses(ValidParantheses, "", numberOfPairs, numberOfPairs);

            return ValidParantheses;
        }

        public void GetBalancedParantheses(List<string> ValidParantheses, string Parantheses, int OpenCount, int CloseCount)
        {
            //Number of Open Paranthese and Close Parantheses are same and Equal to number of pairs is valid and added to List.
            if (OpenCount == 0 && CloseCount == 0)
            {
                ValidParantheses.Add(Parantheses);
                return;
            }

            // Using Recurssion and Backtracking to Match the Open and Close Parantheses
            if (OpenCount > 0)
            {
                GetBalancedParantheses(ValidParantheses, Parantheses + '(',OpenCount - 1, CloseCount);
            }
            if (CloseCount > OpenCount)
            {
                GetBalancedParantheses(ValidParantheses, Parantheses + ')', OpenCount, CloseCount - 1);
            }
        }
    }
}