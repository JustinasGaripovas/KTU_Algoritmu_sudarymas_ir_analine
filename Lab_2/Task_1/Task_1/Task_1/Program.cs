using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Task_1
{
    class MainClass
    {
        /*  
         *                  0                               jei     w=0||n=0
         *      G(n, w) =   G(n-1,w)                        jei     sk > w
         *                  max{G(n-1),r)pk + G(n-1,r-sk)}  jei     kiti atvejai
         */
        public static void Main(string[] args)
        {
            int[] S = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 50 };
            int[] P = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 40 };

            Test(12,false);
            Console.WriteLine("\n\nDynamic test end\n\n");
        

            //Console.WriteLine("Final result recursive {0} ", Recursive(10, 10, S, P));
            //Console.WriteLine("Final result dynamic {0} ", Dynamic(10, 10, S, P));
        }


        public static void Test(int times, bool testRecursive)
        {
            int[] S = { };
            int[] P = { };
            int w = 0;
            int n = 0;

            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;
            Random rand = new Random(0);

            for (int i = 3; i <= times+3; i++)
            {
                n = (int)(Math.Pow(2, i*2));

                S = GenerateRandomArray(n+1, rand);
                P = GenerateRandomArray(n+1, rand);
                w = rand.Next(70, 80);
                int answer;
                Stopwatch sw = new Stopwatch();
                sw.Start();
                if(testRecursive)
                {
                    answer = Recursive(n, w, S, P);
                }
                else
                {
                    answer = Dynamic(n, w, S, P);
                }
                sw.Stop();

                Console.WriteLine("Size of {0} in time {1}\nn={2}, w={3} G(n,w)={4}", n, sw.Elapsed,n,w,answer);


            }

        }

        public static int[] GenerateRandomArray(int size = 0, Random rand = null)
        {
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = rand.Next(1, 1000);
            }

            return array;
        }

        public static int Recursive(int n, int w, int[] s, int[] p)
        {
            if (w == 0 || n == 0)
            {
                return 0;
            }
            else if (s[n] > w)
            {
                return Recursive(n - 1, w,s,p);
            }
            else
            {
                return Math.Max(Recursive(n - 1, w,s,p), p[n] + Recursive(n - 1, w - s[n],s,p));
            }
        }

        public static int Dynamic(int n, int w, int[] s, int[] p)
        {
            int[,] G = new int[n + 1, w + 1];

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= w; j++)
                {
                    if (i == 0 || j == 0)
                        G[i, j] = 0;
                    else if (s[i - 1] > j)
                        G[i, j] = G[i - 1, j];
                    else
                        G[i, j] = Math.Max(G[i - 1, j], p[i - 1] + G[i - 1, j - s[i - 1]]);
                }
            }
            return G[n, w];
        }
    }
}