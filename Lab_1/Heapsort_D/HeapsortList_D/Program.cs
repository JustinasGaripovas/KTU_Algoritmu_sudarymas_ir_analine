using System;
using System.Diagnostics;

namespace HeapsortList_D
{
    class MainClass
    {

        const int n = 100000;

        public static void Main(string[] args)
        {
            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;

            Test_OP(0);
        }

        public static void Test_OP(int seed)
        {
            int n = 11;
            string filename = @"mydataarray.dat";

            ListObject data = new ListObject(filename,n,seed);
            data.Print();

            Console.WriteLine("\n\nPRINTA DATRA\n\n");
            data.Swap(0, 1);
            data.Print();






            Console.WriteLine("---------------------------------------------");
            Stopwatch sw = new Stopwatch();

            sw.Start();

            data.Print();

            HeapSort_list_D.HeapSort(data, n);
            Console.WriteLine("---------------------------------------------");

            data.Print();

            sw.Stop();

            Console.WriteLine("Test OP success ");
            Console.WriteLine("Size of {0} count array was sorted in => {1}", n, sw.Elapsed);
            Console.WriteLine("---------------------------------------------");

        }
    }
}
