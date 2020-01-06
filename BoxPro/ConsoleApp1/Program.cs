using System;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            int[,] a =
            {
                {1,2,3,4 },
                {5,6,7,8 },
                {9,10,11,12 }
            };
            for(int i=0;i<a.GetLength(1) - 1;i++)
            {
                Console.WriteLine("hi");
            }
            Console.WriteLine(a.GetLength(1));
        }
    }
}
