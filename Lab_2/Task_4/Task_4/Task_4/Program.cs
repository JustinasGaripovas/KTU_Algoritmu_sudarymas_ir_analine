using System;
using System.Threading.Tasks;
using System.Diagnostics;
namespace Task_4
{
    class MainClass
    {
        class CustomData
        {
            public int TNum;
            public int TResult;
        }

    public static void Main(string[] args)
        {
            Test(10,true);
            Console.WriteLine("Hello World!");
        }

        public static void Test(int times, bool testRecursive)
        {
            int[] S = { };
            int[] P = { };
            int w = 0;
            int n = 0;

            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;
            Random rand = new Random(0);

            for (int i = 3; i <= times + 3; i++)
            {
                n = (int)(Math.Pow(2, i * 2));

                S = GenerateRandomArray(n + 1, rand);
                P = GenerateRandomArray(n + 1, rand);
                w = rand.Next(70, 80);
                int answer;
                Stopwatch sw = new Stopwatch();
                sw.Start();
               
                answer = RecursivePar(n, w, S, P);

                sw.Stop();

                Console.WriteLine("PARALLEL Size of {0} in time {1}\nn={2}, w={3} G(n,w)={4}", n, sw.Elapsed, n, w, answer);
                sw.Reset();
                sw.Start();

                answer = Recursive(n, w, S, P);

                sw.Stop();

                Console.WriteLine("RECURSIVE Size of {0} in time {1}\nn={2}, w={3} G(n,w)={4}", n, sw.Elapsed, n, w, answer);

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

        public static int RecursivePar(int n, int w, int[] S, int[] P)
        {
            if (n == 0 || w == 0)
            {
                return 0;
            }
            else if (S[n - 1] > w)
            {
                int answer = 0;
                Parallel.Invoke(() => answer = Recursive(n - 1, w, S, P));
                return answer;
            }
            else
            {

                int countCPU = 1;
                Task[] tasks = new Task[countCPU];
                tasks[0] = Task.Factory.StartNew(
                (Object p) =>
                {
                    var data = p as CustomData; if (data == null) return;
                    data.TResult = Recursive(n - 1, w, S, P);
                }, new CustomData() { TNum = 0 });

                tasks[1] = Task.Factory.StartNew(
                (Object p) =>
                {
                    var data = p as CustomData; if (data == null) return;
                    data.TResult = Recursive(n - 1, w - S[n], S, P);
                },new CustomData() { TNum = 1 });

                Task.WaitAll(tasks);

                return Math.Max((tasks[0].AsyncState as CustomData).TResult, (tasks[1].AsyncState as CustomData).TResult + P[n]);

                int Rec1 = 0, Rec2 = 0;
                Parallel.Invoke(
                    () => Rec1 = Recursive(n - 1, w, S, P),
                    () => Rec2 = Recursive(n - 1, w - S[n], S, P)
                );

                return Math.Max(Rec1, Rec2 + P[n]);
            }
        }

        public static int Recursive(int n, int w, int[] s, int[] p)
        {
            if (w == 0 || n == 0)
            {
                return 0;
            }
            else if (s[n] > w)
            {
                return Recursive(n - 1, w, s, p);
            }
            else
            {
                return Math.Max(Recursive(n - 1, w, s, p), p[n] + Recursive(n - 1, w - s[n], s, p));
            }
        }
    }
}
