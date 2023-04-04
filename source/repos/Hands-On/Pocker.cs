using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*In this challenge, you have to establish which kind of Poker combination is 
 * present in a deck of five cards.Every card is a string containing the card 
 * value (with the upper-case initial for face-cards) and the lower-case initial 
 * for suits, as in the examples below:

"Ah" ➞ Ace of hearts
"Ks" ➞ King of spades
"3d" ➞ Three of diamonds
"Qc" ➞ Queen of clubs
"10c" ➞ Ten of clubs
There are 10 different combinations. Here's the list, in decreasing order of importance:

Name Description
-- Royal Flush A, K, Q, J, 10, all with the same suit.
-- Straight Flush Five cards in sequence, all with the same suit.
-- Four of a Kind Four cards of the same rank.  4-1, 3-2, 3-0,2-2,2-0
-- Full House Three of a Kind with a Pair.
-- Flush Any five cards of the same suit, not in sequence.
-- Straight Five cards in a sequence, but not of the same suit.
-- Three of a Kind Three cards of the same rank.
-- Two Pair Two different Pair.
-- Pair Two cards of the same rank.
-- High Card No other valid combination.
Given an array hand containing five strings being the cards,
implement a function that returns a string with the name of the highest combination obtained, accordingly to the table above.

Examples
PokerHandRanking({ "10h", "Jh", "Qh", "Ah", "Kh" }) ➞ "Royal Flush"

PokerHandRanking({ "3h", "5h", "Qs", "9h", "Ad" }) ➞ "High Card"

PokerHandRanking({ "10s", "10c", "8d", "10d", "10h" }) ➞ "Four of a Kind"*/

namespace Hands_On
{

    public class Pocker
    {
        public static Dictionary<string, int> MapSuit;

        public Pocker() 
        {
            MapSuit = new Dictionary<string, int>();
            MapSuit.Add("2", 2);
            MapSuit.Add("3", 3);
            MapSuit.Add("4", 4);
            MapSuit.Add("5", 5);
            MapSuit.Add("6", 6);
            MapSuit.Add("7", 7);
            MapSuit.Add("8", 8);
            MapSuit.Add("9", 9);
            MapSuit.Add("10", 10);
            MapSuit.Add("J", 11);
            MapSuit.Add("Q", 12);
            MapSuit.Add("K", 13);
            MapSuit.Add("A", 14);

            
        }
        
        public void PockerCombination()
        {
            //Get the cards from the user
            string[] cards = new string[5];
            for(int index=0; index<cards.Length; index++)
            {
                cards[index] = Console.ReadLine();
            }
            
            Console.WriteLine(PockerHandRanking(cards));
        }

        public string PockerHandRanking(string[] cards)
        {
            foreach (string key in MapSuit.Keys)
            {
                Console.WriteLine(key+" " + MapSuit[key]);
            }

            List<char> kind = new List<char>();
            List<int> suit = new List<int>();
            int index = 0;

           foreach(string card in cards)
            {
                String temp = card.Substring(0, card.Length - 1);
                //Console.WriteLine("Temp - " + temp);

                suit.Add(MapSuit[temp]);


                if (!kind.Contains(card[card.Length - 1]))
                {
                    kind.Add(card[card.Length - 1]);
                }
                index++;
            }
            List<int> sortedSuit = suit;
            sortedSuit.Sort();


            if (kind.Count == 1 && suit.Count == 5)
            {
                if (suit.Contains(14) && suit.Contains(13) && suit.Contains(12) && suit.Contains(11) && suit.Contains(10))
                {
                    return "Royal Flush";
                }

                if ((sortedSuit[4] - sortedSuit[0]) == 4)
                {
                    return "Straight Flush";
                }
                else
                {
                    return "Flush";
                }
            }
            else if ((sortedSuit[4] - sortedSuit[0]) == 4)
            {
                return "Straight";
            }

            Dictionary<int, int> rankCount = new Dictionary<int, int>();
            List<int> ranks = new List<int>();
            for (int indexSortedSuit = 0; indexSortedSuit < 5; indexSortedSuit++)
            {
                if (rankCount.ContainsKey(sortedSuit[indexSortedSuit]))
                {
                   rankCount[sortedSuit[indexSortedSuit]]+=1;
                }
                else
                {
                    rankCount.Add(sortedSuit[indexSortedSuit], 1);
                    ranks.Add(sortedSuit[indexSortedSuit]);
                }
            }

            foreach(int tank in ranks)
            {
                Console.Write(tank + " - " + rankCount[tank]);
            }
            Console.WriteLine();

            if (ranks.Count == 2)
            {
                int rank1 = rankCount[ranks[0]];
                int rank2 = rankCount[ranks[1]];
                if ((rank1 == 4 && rank2 == 1) || (rank1 == 1 && rank2 == 4))
                {
                    return "Four of a Kind";
                }
                if ((rank1 == 3 && rank2 == 2) || (rank1 == 2 && rank2 == 3))
                {
                    return "Full House";
                }
            }
            else if (ranks.Count == 3)
            {
                int rank1 = rankCount[ranks[0]];
                int rank2 = rankCount[ranks[1]];
                int rank3 = rankCount[ranks[2]];

                if (rank1 == 3 || rank2 == 3 || rank3 == 3)
                {
                    return "Three of a Kind";
                }
                if ((rank1 == 2 && rank2 == 2) || (rank1 == 2 && rank3 == 2) || (rank2 == 2 && rank3 == 2))
                {
                    return "Two Pair";
                }
            }
            else
            {
                foreach (int rank in rankCount.Keys)
                {
                    if (rankCount[rank] == 2)
                    {
                        return "Pair";
                    }
                }
            }

            return "High Card";

        }

    }
}
