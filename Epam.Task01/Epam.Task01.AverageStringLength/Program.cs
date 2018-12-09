using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task01.AverageStringLength
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string str = "\"woman, without her man, is nothing\" (emphasizing the importance of men), and \"woman: without her, man is nothing\" (emphasizing the importance of women) have very different meanings\"";

            Console.WriteLine("The initial string: {0}", str);
            char[] strToChar = str.ToCharArray();
            for (int i = 0; i < strToChar.Length; i++)
            {
                if (char.IsPunctuation(strToChar[i]))
                {
                    strToChar = strToChar.Where(x => x != strToChar[i]).ToArray(); 
                }
            }

            str = new string(strToChar);
            string[] words = str.Split(' ');
            int lettersQuantity = str.Length - (words.Length - 1);
            Console.WriteLine("The average word length in the sentence: {0}", lettersQuantity / words.Length);

            Console.WriteLine("press any key to continue");
            Console.ReadKey();
        }
    }
}
