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
-- Four of a Kind Four cards of the same rank.  4-1, 3-2, 3-(1-1),2-2-1,2-1-1-1
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
            //define and map each suit with a number
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
            
            List<char> kind = new List<char>(); //kind of cards withoud dublicates
            List<int> suit = new List<int>(); // rank of cards
            int index = 0;

            //iterate the deck of cards and get kind and rank of each card
           foreach(string card in cards)
            {
                String temp = card.Substring(0, card.Length - 1);
                suit.Add(MapSuit[temp]);

                if (!kind.Contains(card[card.Length - 1]))
                {
                    kind.Add(card[card.Length - 1]);
                }
                index++;
            }

            //sort the rank of cards
            List<int> sortedSuit = suit;
            sortedSuit.Sort();

            //deck with all 5 cards same
            if (kind.Count == 1 && suit.Count == 5)
            {
                //Royal Flush contains {K,Q,J,A,10}
                if (suit.Contains(14) && suit.Contains(13) && suit.Contains(12) && suit.Contains(11) && suit.Contains(10))
                {
                    return "Royal Flush";
                }

                //Straight Flush is consecutive cards of same kind
                if ((sortedSuit[4] - sortedSuit[0]) == 4)
                {
                    return "Straight Flush";
                }

                //Flush is non sequence cards of same kind
                else
                {
                    return "Flush";
                }
            }
            //Straight is sequence card of various kinds
            else if ((sortedSuit[4] - sortedSuit[0]) == 4)
            {
                return "Straight";
            }

            // "Js", "Jh", "3s", "3c", "2h"
            Dictionary<int, int> rankCount = new Dictionary<int, int>();// 11:2, 3:2, 2:1
            List<int> ranks = new List<int>();//11,3,2

            // Combination of Cards
            //4 - 1,
            //3 - 2,
            //3 - (1 - 1),
            //2 - 2 - 1,
            //2 - 1 - 1 - 1

            //Get distinct rank and their counts
            for (int indexSortedSuit = 0; indexSortedSuit < 5; indexSortedSuit++)
            {
                if (rankCount.ContainsKey(sortedSuit[indexSortedSuit]))
                {
                    //if rankcount containts the rank just increase the count by 1
                   rankCount[sortedSuit[indexSortedSuit]]+=1;
                }
                else
                {
                    //if rankcount does not containts the rank, add it to the dict and list
                    rankCount.Add(sortedSuit[indexSortedSuit], 1);
                    ranks.Add(sortedSuit[indexSortedSuit]);
                }
            }


            //for 4-1 and 3-2 combinations
            if (ranks.Count == 2)
            {
                int rank1 = rankCount[ranks[0]];
                int rank2 = rankCount[ranks[1]];

                //any one of the rank count is four
                if ((rank1 == 4 && rank2 == 1) || (rank1 == 1 && rank2 == 4))
                {
                    return "Four of a Kind";
                }

                //one of the rank count is four and other is two
                if ((rank1 == 3 && rank2 == 2) || (rank1 == 2 && rank2 == 3))
                {
                    return "Full House";
                }
            }

            //for 3-1-1 and 2-2-1 combinations
            else if (ranks.Count == 3)
            {
                int rank1 = rankCount[ranks[0]];
                int rank2 = rankCount[ranks[1]];
                int rank3 = rankCount[ranks[2]];

                //any one of the rank count is three
                if (rank1 == 3 || rank2 == 3 || rank3 == 3)
                {
                    return "Three of a Kind";
                }
                //any two of the rank count is two each
                if ((rank1 == 2 && rank2 == 2) || (rank1 == 2 && rank3 == 2) || (rank2 == 2 && rank3 == 2))
                {
                    return "Two Pair";
                }
            }

            //for 2-1-1-1 combination
            else
            {
                //any one of the rank count is two
                foreach (int rank in rankCount.Keys)
                {
                    if (rankCount[rank] == 2)
                    {
                        return "Pair";
                    }
                }
            }

            //if nothing goes rightt
            return "High Card";

        }

    }
}
