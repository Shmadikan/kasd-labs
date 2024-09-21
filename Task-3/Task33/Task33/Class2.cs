using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task33
{
    public class Arrays
    {
        AllSortIsHere SortObject = new AllSortIsHere();
        public int[] ar1;
        public int[][] ar2 = new int[3][];
        public int[][] ar3 = new int[3][];
        public int[][] ar4 = new int[8][];
        public Arrays(int size)
        {
            this.ar1 = new int[size];
            for (int i = 0; i < ar2.Length; i++)
            {
                this.ar2[i] = new int[size];

            }

            for (int i = 0; i < ar3.Length; i++)
                this.ar3[i] = new int[size];

            for (int i = 0; i < ar4.Length; i++)
                ar4[i] = new int[size];




        }



        public void RandShuffle(int[] mas)
        {
            Random rand = new Random();
            int module = 1000;
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = rand.Next(0, module);


            }


        }


        public void RandShuffle(int[] mas, ref ConcurrentQueue<int> queue,int procent)
        {
            Random rand = new Random();
            int module = 1000;
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = rand.Next(0, module);

            }
            queue.Enqueue(procent);

        }


        public void RandUnArrayShuffle(List<int[]> array)
        {
            /// Метод для второй группы массивов.
            Random random = new Random();
            int module = 10;
            int index = 0;

            for (int i = 0; i < array.Count; i++)
            {
                module = 10;
                index = 0;
                int[] mas = array[i];
                
                while (mas.Length - index >= module)
                {
                    int[] sub = new int[random.Next(0, module)];
                    Array.Copy(mas, index, sub, 0, sub.Length);
                    
                    Array.Sort(sub);
                    
                    Array.Copy(sub, 0, mas, index, sub.Length);
                    index += sub.Length;
                    module *= 2;
                }
            }

        }


        public void ItWasSorted(int[] mas)
        {
            Random rand = new Random();
            int numOfRand = rand.Next(1, 10);
            
                
                Array.Sort(mas);
            for (int j = 0; j < numOfRand; j++)
            {
                int it = rand.Next(0, mas.Length - 1);
                int id = rand.Next(0, mas.Length - 1);
                int tmp = mas[it];
                mas[it] = mas[id];
                mas[id] = tmp;
            }
        }

        public void ManyArray(List<int[]> Arrayss)
        {
            Random rand = new Random();
            
            Array.Sort(Arrayss[0]);
            
            Array.Reverse(Arrayss[1]);

            
                int count = rand.Next(0, ar4.Length - 1);
                for (int j = 0; j < count; j++)
                {
                Arrayss[3][j] = rand.Next(0, int.MaxValue);
                }
            


            double[] proc = { 0.1, 0.25, 0.5, 0.75, 0.9 };
            int index = 0;
            for (int i = 4; i < Arrayss.Count; i++)
            {
                double s = ar4[i].Length * proc[index];
                int reqCount = (int)s;
                int[] mas = ar4[i];
                RandShuffle(mas);
                int randNumber = mas[rand.Next(0, ar4.Length - 1)];
                int counters = Counter(mas, randNumber);

                if (counters < reqCount)
                {
                    for (int r = 0; r < reqCount; r++)
                    {
                        int rands = rand.Next(0, mas.Length - 1);
                        mas[rands] = randNumber;
                    }


                }
                index += 1;
            }
            int Counter(int[] mas, int randNumber)
            {
                int counts = 0;
                foreach (int n in mas)
                {
                    if (n == randNumber) counts += 1;
                }
                return counts;
            }
        }
        public int[] ReSize(int size) {
            int[] mas = new int[size];
            return mas;
        }

        
    }
    
}
