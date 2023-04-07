using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Hands_On
{
    /*In Nico Cipher, encoding is done by creating a numeric key and assigning each letter position 
     of the message with the provided key.Create a function that takes two arguments, key and message, 
    and returns the encoded message.

    There are some variations on the rules of encipherment.One version of the cipher rules are outlined below:

    message = "mubashirhassan"
    key = "crazy"

    nicoCipher(message, key) ➞ "bmusarhiahass n"
    Step 1: Assign numbers to sorted letters from the key:

    "crazy" = 23154
    Step 2: Assign numbers to the letters of the given message:

    2 3 1 5 4
    ---------
    m u b a s
    h i r h a
    s s a n
    Step 3: Sort columns as per assigned numbers:

    1 2 3 4 5
    ---------
    eMessage = "bmusarhiahass n"
    Examples
    NicoCipher("mubashirhassan", "crazy") ➞ "bmusarhiahass n"

    NicoCipher("edabitisamazing", "matt") ➞ "deabtiismaaznig "

    NicoCipher("iloveher", "612345") ➞ "lovehir    e"
    Notes
    Keys will have alphabets or numbers only.*/
    public class NicoCipher
    {
        public static void NicoCipherMain()
        {
            Console.WriteLine("Enter the message :");
            string message = Console.ReadLine();
            Console.WriteLine("Enter the Key :");
            string key = Console.ReadLine();

            NicoCipher nicoCipher = new NicoCipher();
            Console.WriteLine(nicoCipher.Encryption(message, key));
        }
        public string Encryption(string message,string key)
        {
            //Get all the character in key as list and sort 
            List<char> keysChar = new List<char>();
            foreach (char character in key)
            {
                keysChar.Add(character);
            }

            keysChar.Sort();

            //Create a List of List and Initialize
            List<List<char>> lettersMatrix = new List<List<char>>();

            foreach (char character in keysChar)
            {
                lettersMatrix.Add(new List<char>());
            }


            //Place the character of message 
            int messageIndex = 0;
            int range = (int)Math.Ceiling((double)message.Length / key.Length);

            for (int positionIndex = 0; positionIndex < range; positionIndex++)
            {

                for (int keyIndex = 0; keyIndex < keysChar.Count; keyIndex++)
                {
                    if (messageIndex < message.Length)
                    {
                        lettersMatrix[keyIndex].Add(message[messageIndex]);
                    }
                    else
                    {
                        lettersMatrix[keyIndex].Add(' ');
                    }

                    messageIndex++;
                }
            }

            //Get the sorting order
            int[] mapping = new int[key.Length];
            char[] existingChar = new char[key.Length];
            for (int i = 0; i < key.Length; i++)
            {
                if (existingChar.Contains(key[i]))
                {
                    int countChar = existingChar.Count(character => character == keysChar[i]);
                    for (int j = 0;j < key.Length;j++)
                    {
                        if (key[j] == keysChar[i])
                        {
                            if(countChar == 0)
                            {
                                mapping[i] = j; 
                                break;
                            }
                            else
                            {
                                countChar--;
                            }
                        }
                    }
                }
                else
                {
                    mapping[i] = keysChar.IndexOf(key[i]);
                }
                existingChar[i] = key[i];
            }
            

            //Extract the cipher text based on the sorting order
            string cipherText = "";

            for(int i = 0; i < range; i++)
            {
                for(int mapIndex = 0;mapIndex < mapping.Length; mapIndex++)
                {
                    
                    int index = Array.IndexOf(mapping, mapIndex);
                    Console.WriteLine(i + " " + index);
                    cipherText += lettersMatrix[index][i];
                    
                }
            }

            return cipherText;
        }
    }
}
