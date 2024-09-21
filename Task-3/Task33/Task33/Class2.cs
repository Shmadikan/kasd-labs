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



        public void RandShuffle(int[] array)
        {
            Random rand = new Random();
            int module = 1000;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(0, module);


            }


        }


        public void RandShuffle(int[] array, ref ConcurrentQueue<int> queue,int procent)
        {
            Random rand = new Random();
            int module = 1000;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(0, module);

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
                int[] currentArray = array[i];
                
                while (currentArray.Length - index >= module)
                {
                    int[] sub = new int[random.Next(0, module)];
                    Array.Copy(currentArray, index, sub, 0, sub.Length);
                    
                    Array.Sort(sub);
                    
                    Array.Copy(sub, 0, currentArray, index, sub.Length);
                    index += sub.Length;
                    module *= 2;
                }
            }

        }


        public void ItWasSorted(int[] array)
        {
            Random rand = new Random();
            int numOfRand = rand.Next(1, 10);
            
                
                Array.Sort(array);
            for (int j = 0; j < numOfRand; j++)
            {
                int it = rand.Next(0, array.Length - 1);
                int id = rand.Next(0, array.Length - 1);
                int tmp = array[it];
                array[it] = array[id];
                array[id] = tmp;
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
                int[] array = ar4[i];
                RandShuffle(array);
                int randNumber = array[rand.Next(0, ar4.Length - 1)];
                int counters = Counter(array, randNumber);

                if (counters < reqCount)
                {
                    for (int r = 0; r < reqCount; r++)
                    {
                        int rands = rand.Next(0, array.Length - 1);
                        array[rands] = randNumber;
                    }


                }
                index += 1;
            }
            int Counter(int[] array, int randNumber)
            {
                int counts = 0;
                foreach (int n in array)
                {
                    if (n == randNumber) counts += 1;
                }
                return counts;
            }
        }
        public int[] ReSize(int size) {
            int[] array = new int[size];
            return array;
        }

        
    }
    
}
