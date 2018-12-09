using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task03._2_WordFrequency
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Please enter some text: ");
            string str = Console.ReadLine();
            string[] array = str.ToLower().Split(' ', '.');
            Dictionary<string, List<int>> words = new Dictionary<string, List<int>>();

            for (int i = 0; i < array.Length; i++)
            {
                foreach (var item in array)
                {
                    if (words.ContainsKey(item))
                    {
                        words[item].Add(1);
                    }
                    else
                    {
                        words.Add(item, new List<int> { 1 });
                    }
                }
            }

            foreach (var item in words)
            {
                int n = item.Value.Count / words.Count;
                Console.WriteLine("Слово \"{0}\" - встречается в тексте {1} {2}.", item.Key, n, ((n > 1) && (n < 5)) ? "раза" : "раз");
            }

            Console.WriteLine(Environment.NewLine + "Press any key to exit.");
            Console.ReadKey();
        }
    }
}
