using System;
using System.Diagnostics;

namespace Task_2
{
    //Asmenine uzduotis
    /*
     *  Duota akcijų kainos svyravimo (per kiek punktų pakilo ar nukrito) seka, užrašyta sveikų skaičių
     *  eilute X: x 1 , x 2 , ... , x n (gali būti ir neigiamų skaičių). Reikia rasti nuoseklų posekį (negalima
     *  praleisti narių), kurio metu akcijų kaina nukrito daugiausiai.
     *  Tarkime, duota seka X: (1; −6; −3; −6; −5; 3; 1; −3; 4; −6 ). Tada kainų svyravimų posekis,
     *  atspindintis didžiausią kainos kritimą: (−6; −3; −6; −5). 
     * 
     */

     //  TODO:   Reikia iseiles eiti pro savo masyva
     //          Ir tikrinti


     //Reikia rasti nuoseklų posekį (negalima praleisti narių), kurio metu akcijų kaina nukrito daugiausiai
    class MainClass
    {
            static int currentSum = 0;
            static int minimumSum = 9999999;
            static int cX=0;
            static int mX=0, mY=0;

        public static int[] GenerateRandomArray(int size = 0, Random rand = null)
        {
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = rand.Next(1, 1000);
            }

            return array;
        }

        public static void Main(string[] args)
        {
            int[] array = { 1,10, -6, -3, -6, -5, 3, 1, -3, 4, -6 ,-18, 3, -10 };

            Random rand = new Random();

            Process(GenerateRandomArray(5000,rand));
            Process(GenerateRandomArray(50000, rand));
            Process(GenerateRandomArray(500000, rand));
            Process(GenerateRandomArray(5000000, rand));
            Process(GenerateRandomArray(50000000, rand));
            Process(GenerateRandomArray(500000000, rand));


            Console.WriteLine();
        }

        public static void Process(int[] array)
        {

            Stopwatch sw = new Stopwatch();

            sw.Start();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] + currentSum < currentSum)
                {
                    //Jei sekos kitas elementas toliau krenta pridedam prie jau esamos sumos
                    currentSum += array[i];
                }
                else
                {
                    //Console.WriteLine("dies");

                    //Patikrinam ar pasibaigusi seka yra maziausia
                    if (currentSum < minimumSum)
                    {
                        minimumSum = currentSum;
                        mX = cX;
                        mY = i;
                    }

                    cX = i;
                    //Jei sekos kitas elementas kyla jis pradeda nauja kritimo tarpa
                    currentSum = array[i];
                }

            }

            mX += 1;
            mY -= 1;

            sw.Stop();
            Console.WriteLine("PARALLEL Size of {0} in time {1}", array.Length, sw.Elapsed);
            sw.Reset();
        }
    }
}
