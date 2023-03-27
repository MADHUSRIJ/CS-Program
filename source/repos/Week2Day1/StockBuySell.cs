using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
namespace Week2Day1
{
    /*You want to maximize your profit by choosing a single day to buy one stock and choosing 
      a different day in the future to sell that stock.Return the maximum profit you can achieve 
      from this transaction.If you cannot achieve any profit, return 0.
    Input: prices = [7, 1, 5, 3, 6, 4]
    Output: 5
    Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
    Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.*/
    internal class StockBuySell
    {
        public void mainMethod()
        {
            int[] prices = { 7, 1, 5, 3, 6, 4 };            

            int day = 0;
            bool bought = false;
            int profit = 0;
            int buy = 0;
            int maxProfit = 0;
            while(day < prices.Length - 1)
            {
                if (prices[day] < prices[day + 1])
                {
                    buy = prices[day];
                    bought = true;
                    break;
                }
                day++;
            }
            if (bought)
            {
                while (day < prices.Length)
                {
                    profit = prices[day] - buy;
                    if (profit > maxProfit)
                    {
                        maxProfit = profit;
                    }
                    day++;
                }

            }

            Console.WriteLine("Maximum Profit - " + maxProfit);
        }
    }
}
