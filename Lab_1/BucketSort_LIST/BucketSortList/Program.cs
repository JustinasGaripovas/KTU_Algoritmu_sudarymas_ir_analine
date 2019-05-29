using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using BucketSort;
using BucketSortList;

namespace BucketSortList
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;

            TestArrayList(3);
        }


        public static void TestArrayList(int seed)
        {
            int n = 10000;
            ListObject data = new ListObject();

            Console.WriteLine("---------------------------------------------");
            Stopwatch sw = new Stopwatch();
            sw.Start();

            Random rand = new Random(seed);
            for (int i = 0; i < n; i++)
            {
                SortableObject temp = new SortableObject();
                temp.Number = rand.Next(1, 100);
                //temp.Number = i;

                for (int j = 0; j < 8; j++)
                {
                    temp.Text += (char)rand.Next(65, 90);
                }

                data.Insert(temp, i);
            }


            sw.Stop();
            Console.WriteLine("Size of {0} count was initialized in => {1}", n, sw.Elapsed);
            Console.WriteLine("\nHeapsort started (timer on) \n");

            sw.Start();


            List<SortableObject> SortableList = BucketSortMyFileList.BucketSort(data, n);
            Console.WriteLine("---------------------------------------------");

            foreach(SortableObject s in SortableList)
            {
                Console.WriteLine(s.ToString());
            }

            sw.Stop();

            Console.WriteLine("Test OP success ");
            Console.WriteLine("Size of {0} count array was sorted in => {1}", n, sw.Elapsed);
            Console.WriteLine("---------------------------------------------");

        }
    }
}
