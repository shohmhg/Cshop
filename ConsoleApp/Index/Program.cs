using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Index
{
    class ExIndex
    {
        private int[] numb = new int[5];

        public int this[int index]
        {
            get 
            { 
                return this.numb[index]; 
            }
            set 
            {
                this.numb[index] = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ExIndex exIndex = new ExIndex();
            Console.WriteLine(exIndex[2] = 1112);

           
        }
    }
}
