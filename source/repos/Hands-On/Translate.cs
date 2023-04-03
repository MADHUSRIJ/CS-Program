using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

/*Question:
English to Pig Latin Translator



Pig latin has two very simple rules:

If a word starts with a consonant move the first letter(s) of the word, till you reach a vowel, to the end of the word and add "ay" to the end.
have ➞ avehay
cram ➞ amcray
take ➞ aketay
cat ➞ atcay
shrimp ➞ impshray
trebuchet ➞ ebuchettray
If a word starts with a vowel add "yay" to the end of the word.
ate ➞ ateyay
apple ➞ appleyay
oaken ➞ oakenyay
eagle ➞ eagleyay
Write two functions to make an English to pig latin translator. The first function TranslateWord(word) takes a single word and returns that word translated into pig latin. The second function TranslateSentence(sentence) takes an English sentence and returns that sentence translated into pig latin.

Examples
TranslateWord("flag") ➞ "agflay"

TranslateWord("Apple") ➞ "Appleyay"

TranslateWord("button") ➞ "uttonbay"

TranslateWord("") ➞ ""

TranslateSentence("I like to eat honey waffles.") ➞ "Iyay ikelay otay eatyay oneyhay afflesway."
TranslateSentence("Do you think it is going to rain today?") ➞ "Oday ouyay inkthay ityay isyay oinggay otay ainray odaytay?"
Notes
Regular expressions will help you not mess up the punctuation in the sentence.
If the original word or sentence starts with a capital letter, the translation should preserve its case (see examples #2, #5 and #6).*/

namespace Hands_On
{
    public interface TranslateInterface
    {
        abstract public string TranslateWord(string word);
        abstract public string TranslateSentence(string sentence);
    }
    public class Translate : TranslateInterface
    {
        bool CheckVowelOrNot(char letter)
        {
            if(letter == 'a' || letter == 'e'|| letter == 'i'|| letter == 'o'|| letter == 'u')
            {
                return true;
            }
            return false;
        }
        public string TranslateWord(string word)
        {
            if(word.Length == 0)
            {
                return "";
            }
            bool upperCase = false;
            if (char.IsUpper(word[0]))
            {
                upperCase = true;
            }
            if (CheckVowelOrNot(word.ToLower()[0]))
            {
                return word + "yay";
            }
            else
            {
                int index = 0;
                foreach(char letter in word)
                {
                    if (CheckVowelOrNot(letter))
                    {
                        break;
                    }
                    index++;
                }
                if (upperCase)
                {
                    word = word.ToLower();
                    return char.ToUpper(word[index]) + word.Substring(index + 1)  + word.Substring(0, index) + "ay";
  
                }
            
                return word.Substring(index) + word.Substring(0, index) + "ay";
            }
        }
        public string TranslateSentence(string sentence)
        {
            string[] words = sentence.Split(" ");
            string translatedSentence = "";
            
            foreach (string wordBefore in words)
            {
                string word = wordBefore;
                String spl = "";
                if (word.Contains(".") || word.Contains(",") || word.Contains("?"))
                {
                    spl = word[word.Length-1].ToString();
                 
                    word = word.Substring(0,word.Length-1);
                    
                }
                translatedSentence += TranslateWord(word);
                translatedSentence += spl;
                translatedSentence += " ";
            }
            return translatedSentence.TrimEnd();
        }

        public static void TranslateMain()
        {
            Console.WriteLine("Enter the sentence");
            string sentence = Console.ReadLine();

            Translate translate = new Translate();
            Console.WriteLine(translate.TranslateSentence(sentence));
        }
    }
}
