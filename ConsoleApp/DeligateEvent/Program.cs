using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeligateEvent
{
    delegate void ExDel(string msg);

    class A
    {
        public event ExDel ExEve;

        public void Func(string msg)
        {
            Print pr = new Print();
            ExDel exd = new ExDel(pr.PrintA);
            exd += pr.PrintB;
            exd(msg);
            ExEve(msg);
        }
    }

    class Print
    {
        public void PrintA(string msg)
        {
            Console.WriteLine("A"+msg);
        }
        public void PrintB(string msg)
        {
            Console.WriteLine("B"+msg);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            Print print = new Print();

            ExDel exdel = print.PrintA;
            exdel += print.PrintB;
            exdel("yo");

            a.ExEve += new ExDel(print.PrintA);
            a.ExEve += new ExDel(print.PrintB);
            a.Func("FUck");
        }
    }
}
