using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Arrays
    {
        AllSortIsHere SortObject = new AllSortIsHere();
        public int[] ar1;
        public int[][] ar2 = new int[3][];
        public int[][] ar3 = new int[3][];
        public int[][] ar4 = new int[8][];
        public Arrays(int size) { 
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



        private void RandShuffle(int[] mas) { 
            Random rand = new Random();
            int module = 1000;
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = rand.Next(0, module);
                
               
            }
            
            
        }


        public void RandUnArrayShuffle() {
            /// Метод для второй группы массивов.
            Random random = new Random();
            int module = 10;
            int index = 0;
            
            for (int i = 0; i < this.ar2.Length; i++)
            {
                module = 10;
                index = 0;
                int[] mas = this.ar2[i];
                RandShuffle(mas);
                while (mas.Length - index >= module)
                {
                    int[] sub = new int[random.Next(0, module)];
                    Array.Copy(mas, index, sub, 0, sub.Length);
                    Console.WriteLine($"OLD{i}:{string.Join(' ', sub)}");
                    Array.Sort(sub);
                    Console.WriteLine(string.Join(' ', sub));
                    Array.Copy(sub, 0, mas, index, sub.Length);
                    index += sub.Length;
                    module *= 2;
                }
            }
        
        }


        public void ItWasSorted() { 
            Random rand = new Random();
            int numOfRand = rand.Next(1, 10);
            for (int i = 0; i < this.ar3.Length; i++)
            {
                int[] mas = this.ar3[i];
                RandShuffle(mas);
                Array.Sort(mas);
                for (int j = 0; j < numOfRand; j++) {
                    int it = rand.Next(0, mas.Length - 1);
                    int id = rand.Next(0, mas.Length - 1);
                    int tmp = mas[it];
                    mas[it] = mas[id];
                    mas[id] = tmp;
                }
            }
        }

        public void ManyArray() {
            Random rand = new Random();
            RandShuffle(this.ar4[0]);
            Array.Sort(this.ar4[0]);
            this.ar4[0].CopyTo(this.ar4[1], 0);
            Array.Reverse(this.ar4[1]);

            for (int i = 2; i < 4; i++) {
                RandShuffle(this.ar4[i]);
                int count = rand.Next(0, ar4.Length - 1);
                for (int j = 0; j < count; j++) {
                    this.ar4[i][j] = rand.Next(0, int.MaxValue);
                }
            }


            double[] proc = { 0.1, 0.25, 0.5, 0.75, 0.9};
            int index = 0;
            for (int i = 4; i < ar4.Length; i++) {
                double s = ar4[i].Length * proc[index];
                int reqCount = (int) s; 
                int[] mas = ar4[i];
                RandShuffle(mas);
                int randNumber = mas[rand.Next(0, ar4.Length - 1)];
                int count = Counter(mas, randNumber);
                
                if (count < reqCount) {
                    for (int r = 0; r < reqCount; r++) { 
                        int rands = rand.Next(0, mas.Length - 1);
                        mas[rands] = randNumber;
                    } 

                
                }
                index += 1;
            }
            int Counter(int[] mas, int randNumber) { 
                int count = 0;
                foreach (int n in mas)
                {
                    if (n == randNumber) count += 1;
                }
                return count;
            }
        }
        
    }
    internal class ArrayTypes
    {
        static void Main(string[] args)
        {
            Arrays obj = new Arrays(100);
            obj.ManyArray();
            for (int i = 0; i < obj.ar4.Length;i++)
            {
                Console.WriteLine(string.Join(' ', obj.ar4[i]));

            }
        }
    }
}
