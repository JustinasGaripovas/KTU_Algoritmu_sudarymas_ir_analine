using System;
using System.Diagnostics;
using System.IO;
using HeapSort;

namespace HeapSort
{
    class MainClass
    {

        const int n = 20;

        public static void Main(string[] args)
        {
            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;

            Test_D(seed);
        }

        public static void Test_OP(int seed)
        {
            Console.WriteLine("---------------------------------------------");

            Console.WriteLine("Test OP");

            Stopwatch sw = new Stopwatch();

            sw.Start();
            MyDataArray myarray = new MyDataArray(n, seed);
            sw.Stop();

            Console.WriteLine("Size of {0} count was initialized in => {1}", n, sw.Elapsed);

            Console.WriteLine("\nHeapsort started (timer on) \n");

            sw.Start();

            myarray.Print(n);
            Heapsort_OP.HeapSort(myarray, n);

            myarray.Print(n);

            sw.Stop();

            Console.WriteLine("Test OP success ");
            Console.WriteLine("Size of {0} count array was sorted in => {1}", n, sw.Elapsed);
            Console.WriteLine("---------------------------------------------");

        }


        public static void Test_D(int seed)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Test D");

            Stopwatch sw = new Stopwatch();

            string filename = @"/home/justin/Projects/HeapSort_OP/HeapSort_OP/mydataarray.dat";
            sw.Start();
            Console.WriteLine("Size of {0} count was initialized in => {1}", n, sw.Elapsed);
            MyFileArray myfilearray = new MyFileArray(filename, n, seed);
            sw.Stop();

            sw.Start();

            using (myfilearray.fs = new FileStream(filename, FileMode.Open,
            FileAccess.ReadWrite))
            {
                Console.WriteLine("\n FILE ARRAY \n");
                myfilearray.Print(n);
                Heapsort_D.HeapSort(myfilearray, n);

                myfilearray.PrintFromFile(n);

            }
            sw.Stop();

            Console.WriteLine("Test D success ");
            Console.WriteLine("Size of {0} count file was sorted in => {1}", n, sw.Elapsed);
            Console.WriteLine("---------------------------------------------");

        }
    }
}
