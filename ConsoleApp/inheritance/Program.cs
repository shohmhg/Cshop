using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritance
{
    class A
    {
        public A(int numb)
        {
            Console.WriteLine("Create A");
            Console.WriteLine(numb);
        }
        ~A()
        {
            Console.WriteLine("Delete A");
        }

        public void Print()
        {   Console.WriteLine("Print From A");
        }
    }
    class B : A
    {
        public B(int num):base(num)
        {
            Console.WriteLine("Create B");
            Console.WriteLine(num);
            base.Print();
        }
        ~B()
        {
            Console.WriteLine("Delete B");
        }
        public void Print()
        {
            Console.WriteLine("Print From B");
        }
    }
    class Programa
    {
        static void Main()
        {
            A a = new A(3);
            B b = new B(10);

            a.Print();
            Console.WriteLine("WW");
            b.Print();
        }
    }
}
