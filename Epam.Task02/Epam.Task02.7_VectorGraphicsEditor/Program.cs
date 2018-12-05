using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02._7_VectorGraphicsEditor
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("You can draw any of the figures below:");
            Console.WriteLine("\t 1: Line");
            Console.WriteLine("\t 2: Circle");
            Console.WriteLine("\t 3: Rectangle");
            Console.WriteLine("\t 4: Round");
            Console.WriteLine("\t 5: Ring");
            Console.WriteLine();
            Console.WriteLine("If you want to exit then press \"9\"");
            Console.WriteLine();

            Random r = new Random();
            Figure[] Figures = new Figure[5];
            int count = 0;
            while (true)
            {
                if (count >= Figures.Length)
                {
                    Array.Resize(ref Figures, Figures.Length + 5);

                }

                Console.Write("Please choose the figure you wanted to draw or" +
                    " press \"8\" to start drawing selected figures: ");

                bool check = int.TryParse(Console.ReadLine(), out int n);
                if (check)
                {
                    switch (n)
                    {
                        case 1:
                            Figures[count] = new Line(r.Next(1, 99), r.Next(1, 99), r.Next(1, 99), r.Next(1, 99));
                            break;
                        case 2:
                            Figures[count] = new Circle(r.Next(1, 99), r.Next(1, 99), r.Next(1, 99));
                            break;
                        case 3:
                            Figures[count] = new Rectangle(r.Next(1, 99), r.Next(1, 99), r.Next(1, 99), r.Next(1, 99));
                            break;
                        case 4:
                            Figures[count] = new Round(r.Next(1, 99), r.Next(1, 99), r.Next(1, 99));
                            break;
                        case 5:
                            Figures[count] = new Ring(r.Next(1, 99), r.Next(1, 99), r.Next(1, 99), r.Next(1, 99));
                            break;
                        case 8:
                            for (int i = 0; i < count; i++)
                            {
                                Console.WriteLine();
                                Figures[i].Draw();
                                Console.WriteLine();
                            }
                            goto Exit;
                        case 9:
                            goto Exit;
                        default:
                            Console.WriteLine("You should choose the number of figures (from 1 to 5) " +
                                "or press \"8\" to draw your figures or press \"9\" to exit");
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("Wrong input");
                }

                count++;
            }

            Exit:

            Console.WriteLine(Environment.NewLine + "Press any key to exit.");
            Console.ReadKey();

        }
    }
}
