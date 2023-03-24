using System.Drawing;
using System.Linq.Expressions;

namespace ChocolateDispenser
{
    internal class Program
    {
        public static Dictionary<string, int> _dispenser;
        public static void Main(string[] args)
        {
            _dispenser = new Dictionary<string, int>();
            Console.WriteLine(" Press 1 - Add Chocolates \n Press 2 - remove Chocolates \n Press 3 - Dispense Chocolates \n" +
                "Press 4 - Fav color Chocolates \n Press 5 - No of Chocolates \n Press 6 - Sort Chocolates \n" +
                "Enter the Number :");

            int m = Convert.ToInt32(Console.ReadLine());

            Program cd = new Program();

            if(m == 1)
            {
                cd.addChocolate();
            }
            else if(m == 2)
            {
                Console.WriteLine("Give Count");
                int count = Convert.ToInt32(Console.ReadLine());
                cd.removeChocolate(count);
            }
            else if(m == 3)
            {
                Console.WriteLine("Give Count");
                int count = Convert.ToInt32(Console.ReadLine());
                cd.dispenseChocolates(count);
            }
            else if (m == 4)
            {
                Console.WriteLine("Give Color and Count");
                String color = Console.ReadLine();
                int count = Convert.ToInt32(Console.ReadLine());
                cd.dispenseChocolatesOfColor(color,count);
            }
            else if(m == 5)
            {
                cd.noOfChocolates();
            }
            else if(m == 6)
            {
                cd.sortChocolateBasedOnCount();
            }

        }

        public void addChocolate()
        {
            Console.WriteLine("Give Color and Count");
            String color = Console.ReadLine();
            int count = Convert.ToInt32(Console.ReadLine());
            _dispenser.Add(color, count);
        }

        public Dictionary<string,int> removeChocolate(int no) { 
            
            Dictionary<string,int> _removedChocolated = new Dictionary<string,int>();
            
            int item_to_be_removed = no;
            while(item_to_be_removed < no && _dispenser.Count > 0)
            {
                int count = _dispenser.Count;
                if(_dispenser.ElementAt(count - 1).Value > item_to_be_removed)
                {
                    _removedChocolated.Add(_dispenser.ElementAt(count - 1).Key, item_to_be_removed);
                    String color = _dispenser.ElementAt(count - 1).Key;
                    int remaining = _dispenser.ElementAt(count - 1).Value - item_to_be_removed;
                    _dispenser.Remove(color);
                    _dispenser.Add(color, remaining);
                }
                else
                {
                    _removedChocolated.Add(_dispenser.ElementAt(count - 1).Key, _dispenser.ElementAt(count - 1).Value);
                    String color = _dispenser.ElementAt(count - 1).Key;
                    _dispenser.Remove(color);
                    item_to_be_removed -= _dispenser.ElementAt(count - 1).Value;
                }
                
            }

            return _removedChocolated;
        }

        public Dictionary<string, int> dispenseChocolates(int no)
        {
            Dictionary<string, int> _dispensedChocolated = new Dictionary<string, int>();
            int item_to_be_dispensed = no;
            int i = 0;
            while (item_to_be_dispensed < no && _dispenser.Count > 0)
            {
                if (_dispenser.ElementAt(0).Value > item_to_be_dispensed)
                {
                    _dispensedChocolated.Add(_dispenser.ElementAt(0).Key, item_to_be_dispensed);
                    String color = _dispenser.ElementAt(0).Key;
                    int remaining = _dispenser.ElementAt(0).Value - item_to_be_dispensed;
                    _dispenser.Remove(color);
                    _dispenser.Add(color, remaining);
                }
                else
                {
                    _dispensedChocolated.Add(_dispenser.ElementAt(0).Key, _dispenser.ElementAt(0).Value);
                    String color = _dispenser.ElementAt(0).Key;
                    _dispenser.Remove(color);
                    item_to_be_dispensed -= _dispenser.ElementAt(0).Value;
                }


            }
            return _dispensedChocolated;
        }

        public Dictionary<string, int> dispenseChocolatesOfColor(String color, int count)
        {
            Dictionary<string, int> _dispensedChocolated = new Dictionary<string, int>();

            int i = 0;
            int k = 0;

            while(i< _dispenser.Count && k<count)
            {
                if(_dispenser.ElementAt(i).Key == color)
                {
                    _dispensedChocolated.Add(color, _dispenser.ElementAt(i).Value );
                    k += _dispenser.ElementAt(i).Value;
                }
            }

            return _dispensedChocolated;

        }

        public Dictionary<string,int> noOfChocolates()
        {
            Dictionary<string, int> _noChocolated = new Dictionary<string, int>();
            _noChocolated.Add("Green", 0);
            _noChocolated.Add("Silver", 0);
            _noChocolated.Add("Blue", 0);
            _noChocolated.Add("Crimson", 0);
            _noChocolated.Add("Purple", 0);
            _noChocolated.Add("Red", 0);
            _noChocolated.Add("Pink", 0);

            for(int i=0;i<_dispenser.Count;i++)
            {
                String color = _dispenser.ElementAt(i).Key;
                int count = _dispenser.ElementAt(i).Value;

                if(_noChocolated.ContainsKey(color))
                {
                    _noChocolated.Add(color, _noChocolated[color]+count);
                }
            }

            return _noChocolated;

        }

        public void sortChocolateBasedOnCount()
        {
            foreach (var item in _dispenser.OrderByDescending(i => i.Value))
            {
                Console.WriteLine(item);
            }
        }
    }
}