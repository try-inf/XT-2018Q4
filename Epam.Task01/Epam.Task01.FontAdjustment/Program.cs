using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task01.FontAdjustment
{
    class Program
    {
       
        enum FontStyles
        {
            None = 0,
            Bold = 1,
            Italic = 2,
            Underline = 4
        }

        static void SetFontProp(FontStyles fs)
        {
            switch (fs)
            {
                case FontStyles.None:
                    Console.WriteLine("Параметры надписи: {0}", FontStyles.None.ToString());
                    break;
                case FontStyles.Bold:
                    Console.WriteLine("Параметры надписи: {0}", FontStyles.Bold.ToString());
                    break;
                case FontStyles.Italic:
                    Console.WriteLine("Параметры надписи: {0}", FontStyles.Italic.ToString());
                    break;
                case FontStyles.Underline:
                    Console.WriteLine("Параметры надписи: {0}", FontStyles.Underline.ToString());
                    break;
            }
        }


        static void Main(string[] args)
        {
            
            Console.WriteLine("Введите: \n\r 1: bold \n\r 2: italic \n\r 3: underline");
            int n = int.Parse(Console.ReadLine());

            SetFontProp((FontStyles)n);

            Console.WriteLine(Environment.NewLine + "Press any key to exit.");
            Console.ReadKey();
            

        }
    }
}
