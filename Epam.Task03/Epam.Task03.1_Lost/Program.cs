using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task03._1_Lost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> people = new List<int> { };
            int qty = QuantityOfPeople();
            for (int i = 1; i <= qty; i++)
            {
                people.Add(i);
            }

            Console.Write("Current numbers of people in circle: ");
            ShowList(people);
            bool flag = false;
            int count = 0;
            while (true)
            {
                count++;
                if (people.Count == 1)
                {
                    break;
                }
                else
                {
                    for (int i = 0; i < people.Count; i++)
                    {
                        if (flag)
                        {
                            people.RemoveAt(i--);
                        }

                        flag = !flag;
                    }

                    Console.WriteLine();
                    Console.Write("After {0} striking out cycle: ", count);
                    ShowList(people);
                }
            }

            Console.WriteLine();
            Console.Write("Current number of the last person in the circle after striking out: ");
            ShowList(people);

            Console.WriteLine(Environment.NewLine + "Press any key to exit.");
            Console.ReadKey();
        }

        private static int QuantityOfPeople()
        {
            while (true)
            {
                Console.Write("Enter quantity of people in a circle: ");
                string str = Console.ReadLine();
                bool check = int.TryParse(str, out int result);
                if (check)
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("You entered not a number");
                }
            }
        }

        private static void ShowList(IEnumerable<int> people)
        {
            foreach (var item in people)
            {
                Console.Write("{0} ", item);
            }
        }
    }
}
