﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task01._2dArray
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[,] arr = new int[4,2] { { 2, 4 }, { 5, 6 }, { 7, 2 }, { 4, 8 } };
            int[,] arr = new int[4, 2];
            arr[0, 0] = 2;
            arr[0, 1] = 4;
            arr[1, 0] = 5;
            arr[1, 1] = 6;
            arr[2, 0] = 7;
            arr[2, 1] = 2;
            arr[3, 0] = 4;
            arr[3, 1] = 8;

            int SumEvens=0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 0) SumEvens += arr[i,j];
                    //SumEvens += arr[i,j];
                    Console.Write("|" + arr[i,j]);
                }
                Console.WriteLine("|");
            }

            Console.WriteLine($"The sum of the elements standing on even positions: {SumEvens}");

            Console.WriteLine(Environment.NewLine + "Press any key to exit.");
            Console.ReadKey();

        }
    }
}