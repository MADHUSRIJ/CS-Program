using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class Chocolate
    {
        List<String> chocos = new List<String>();
        
        public static void ChocolateDispenser()
        {
            int k;
            Chocolate cait = new Chocolate();
            do
            {
                Console.WriteLine("Welcome to Cait's Chocolate Dispenser \n" +
                    "Press \n1 - Add Chocolates \n" +
                    "2 - Remove Chocolate \n" +
                    "3 - Dispense Chocolate \n" +
                    "4 - Dispense Chocolate of Color \n" +
                    "5 - No. of Chocolates \n" +
                    "6 - Sort Chocolate Based On Count \n" +
                    "7 - Change Chocolate Color \n" +
                    "8 - Change Chocolate Color All Of x Count \n" +
                    "9 - Removing Chocolate of Color \n" +
                    "10 - Dispense Rainbow Chocolates \n" +
                    "0 - Exit");
                k = Convert.ToInt32(Console.ReadLine());
                switch(k)
                {
                    case 1:
                        cait.addChocolates();
                        cait.ListOfChocolates();
                        break;

                    case 2:
                        List<String> removedChocolates = cait.removeChocolates();
                        Console.WriteLine("List of Removed Chocolates");
                        foreach(String m in removedChocolates)
                        {
                            Console.Write(m + ", ");
                        }
                        Console.WriteLine();
                        cait.ListOfChocolates();
                        Console.WriteLine();
                        break;

                    case 3:
                        List<String> dispensedChocolates = cait.dispenseChocolates();
                        Console.WriteLine("List of Dispensed Chocolates");
                        foreach (String m in dispensedChocolates)
                        {
                            Console.Write(m + ", ");
                        }
                        Console.WriteLine();
                        cait.ListOfChocolates();
                        Console.WriteLine();
                        break;

                    case 4:
                        cait.ListOfChocolates();
                        Console.WriteLine();
                        List<String> dcc = cait.dispenseChocolatesOfColor();
                        Console.WriteLine("After Dispensing Chocolate of Given Color");
                        cait.ListOfChocolates();
                        break;

                    case 5:
                        cait.noOfChocolates();
                        break;

                    case 6:
                        cait.sortChocolateBasedOnCount();
                        break;

                    case 7:
                        cait.changeChocolateColor();
                        Console.WriteLine("After Changing Chocolate Color");
                        cait.ListOfChocolates();
                        break;

                    case 8:
                        int x = cait.changeChocolateColorAllOfxCount();
                        Console.Write("No. of Chocolates changes color : "+x);
                        cait.ListOfChocolates();
                        break;

                    case 9:
                        cait.removeChocolateOfColor();
                        Console.WriteLine("After Removing Chocolate of Given Color");
                        cait.ListOfChocolates();
                        break;
                    case 10:
                        cait.dispenseRainbowChocolates();
                        break;

                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
            while (k!= 0);

        }

        public void ListOfChocolates()
        {
            Console.WriteLine("List of Chocolates");
            foreach (String c in chocos)
            {
                Console.Write(c + ", ");
            }

            Console.WriteLine();
        }
        public void addChocolates()
        {
            Console.WriteLine("Enter color and count of Chocolate \n");
            Console.WriteLine("Available Chocolate Colors \n" +
                "1 - green \n"+
                "2 - silver \n" +
                "3 - blue \n" +
                "4 - crimson \n" +
                "5 - purple \n" +
                "6 - red \n" +
                "7 - pink \n");

            String[] colors = {"green", "silver", "blue", "crimson", "purple", "red", "pink"};
            Console.Write("Color : ");
            int m = Convert.ToInt32(Console.ReadLine());
            String color = colors[m - 1];
            Console.WriteLine();

            Console.Write("Count : ");
            int count = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            for(int i = 0; i < count; i++) {
                chocos.Add(color);
            }
        }
        public List<String> removeChocolates()
        {
            List<String> removedChocolates = new List<String>();
            Console.Write("Enter the number of chocolates to be removed : ");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine() ;

            while (m > 0)
            {
                removedChocolates.Add(chocos[chocos.Count - 1]);
                chocos.RemoveAt(chocos.Count - 1);
                m--;
            }
            return removedChocolates;
        }
        public List<String> dispenseChocolates()
        {
            List<String> dispensedChocolates = new List<String>();
            Console.Write("Enter the number of chocolates to be dispensed : ");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            while (m > 0)
            {
                dispensedChocolates.Add(chocos[0]);
                chocos.RemoveAt(0);
                m--;
            }
            return dispensedChocolates;

        }
        public List<String> dispenseChocolatesOfColor()
        {
            
            List<String> dcc = new List<String>();
            Console.WriteLine("Enter color and count of Chocolate \n");
            Console.WriteLine("Chocolate Colors \n" +
                "1 - green \n" +
                "2 - silver \n" +
                "3 - blue \n" +
                "4 - crimson \n" +
                "5 - purple \n" +
                "6 - red \n" +
                "7 - pink \n");

            String[] colors = { "green", "silver", "blue", "crimson", "purple", "red", "pink" };
            Console.Write("Color : ");
            int m = Convert.ToInt32(Console.ReadLine());
            String color = colors[m - 1];
            Console.WriteLine();

            Console.Write("Count : ");
            int count = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            int ind = 0;

            while (count > 0)
            {
                if (chocos[ind] == color)
                {
                    dcc.Add(chocos[ind]);
                    chocos.RemoveAt(ind);
                    count--;
                }
                ind++;
            }
            return dcc;
        }
        public void noOfChocolates()
        {
            Dictionary<string, int> colorCounts = new Dictionary<string, int>();


            for (int i = 0; i < chocos.Count; i++)
            {
                if (colorCounts.ContainsKey(chocos[i]))
                {
                    colorCounts[chocos[i]]++;
                }
                else
                {
                    colorCounts[chocos[i]] = 1;
                }
            }


            foreach (String k in colorCounts.Keys)
            {
                Console.WriteLine(k+" - " + colorCounts[k]);
            }


            Console.WriteLine();
        }
        public void sortChocolateBasedOnCount()
        {
            var groupedValues = chocos.GroupBy(x => x).OrderByDescending(g => g.Count()); 

            foreach (var group in groupedValues)
            {
                Console.WriteLine("Value: {0}, Count: {1}", group.Key, group.Count());
            }
        }
        public void changeChocolateColor()
        {
            Console.WriteLine("Enter color and count of Chocolate \n");
            Console.WriteLine("Chocolate Colors \n" +
                "1 - green \n" +
                "2 - silver \n" +
                "3 - blue \n" +
                "4 - crimson \n" +
                "5 - purple \n" +
                "6 - red \n" +
                "7 - pink \n");

            String[] colors = { "green", "silver", "blue", "crimson", "purple", "red", "pink" };
            Console.Write("Color : ");
            int m = Convert.ToInt32(Console.ReadLine());
            String color = colors[m - 1];
            Console.WriteLine();

            Console.Write("Count : ");
            int count = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Final Color : ");
            int mn = Convert.ToInt32(Console.ReadLine());
            String fcolor = colors[mn - 1];
            Console.WriteLine();

            int ind = chocos.Count-1;

            while(count > 0)
            {
                if (chocos[ind] == color)
                {
                    chocos[ind] = fcolor;
                    count--;
                }
                ind--;
            }
        }
        public int changeChocolateColorAllOfxCount()
        {
            int count = 0;
            Console.WriteLine("Enter color and final color of Chocolate \n");
            Console.WriteLine("Chocolate Colors \n" +
                "1 - green \n" +
                "2 - silver \n" +
                "3 - blue \n" +
                "4 - crimson \n" +
                "5 - purple \n" +
                "6 - red \n" +
                "7 - pink \n");

            String[] colors = { "green", "silver", "blue", "crimson", "purple", "red", "pink" };
            Console.Write("Color : ");
            int m = Convert.ToInt32(Console.ReadLine());
            String color = colors[m - 1];
            Console.WriteLine();

            Console.Write("Final Color : ");
            int mn = Convert.ToInt32(Console.ReadLine());
            String fcolor = colors[mn - 1];
            Console.WriteLine();

            int ind = 0;

            while (ind < chocos.Count)
            {
                if (chocos[ind] == color)
                {
                    chocos[ind] = fcolor;
                    count++;
                }
                ind++;
            }
            return count;
        }
        public void removeChocolateOfColor()
        {
            Console.WriteLine("Enter color of Chocolate to be removed\n");
            Console.WriteLine("Chocolate Colors \n" +
                "1 - green \n" +
                "2 - silver \n" +
                "3 - blue \n" +
                "4 - crimson \n" +
                "5 - purple \n" +
                "6 - red \n" +
                "7 - pink \n");

            String[] colors = { "green", "silver", "blue", "crimson", "purple", "red", "pink" };
            Console.Write("Color : ");
            int m = Convert.ToInt32(Console.ReadLine());
            String color = colors[m - 1];
            Console.WriteLine();

            int ind = 0;
            int k = chocos.Count - 1;
            while (ind < chocos.Count)
            {
                if (chocos[ind] == color)
                {
                    chocos.RemoveAt(ind);
                    break;
                }
                k--;
                ind++;
            }
            if(ind == chocos.Count)
            {
                Console.WriteLine("No chocolate was found in the given color");
            }
        }
        public void dispenseRainbowChocolates()
        {
            Console.Write("Enter no. of rainbow chocolate to be dispensed : ");
            int count = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Dictionary<string, int> colorCounts = new Dictionary<string, int>();

            
            for (int i=0;i<count;i++)
            {
                if (colorCounts.ContainsKey(chocos[i]))
                {
                    colorCounts[chocos[i]]++;
                }
                else
                {
                    colorCounts[chocos[i]] = 1;
                }
            }

            int numRainbowChocolates = 0;

            foreach (int k in colorCounts.Values)
            {
                numRainbowChocolates += k / 3;
            }

            Console.WriteLine("No. of Rainbow chocolate dispensed within " + count + " chocolates of the dispenser are " + numRainbowChocolates);
        }

    }
}
