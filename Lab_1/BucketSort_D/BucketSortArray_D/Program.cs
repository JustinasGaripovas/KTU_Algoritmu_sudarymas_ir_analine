using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BucketSortArray_D
{
    class MainClass
    {
        const int n = 14;

        public static void Main(string[] args)
        {
            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;

            Test_Array_List(1);
        }

        public static void Test_Array_List(int seed)
        {
            Stopwatch sw = new Stopwatch();
            string filename = @"mydataarray.dat";

            sw.Start();
            MyFileArray myarray = new MyFileArray(filename,n, seed);
            sw.Stop();

            Console.WriteLine("Size of {0} count was initialized in => {1}", n, sw.Elapsed);

            Console.WriteLine("\nHeapsort started (timer on) \n");

            sw.Start();

            List<SortableObject> array = BucketSort_D.BucketSort(myarray, n);

            Console.WriteLine("yikes");
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("yikes");


            sw.Stop();
            Console.WriteLine("Heap sort took => {0}", sw.Elapsed);
        }
    }
}
