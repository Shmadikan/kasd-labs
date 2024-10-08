using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task33
{
    public class Arrays<T> where T: IComparable, IConvertible
    {
        AllSortIsHere<T> SortObject = new AllSortIsHere<T>();
        public T[] ar1;
        public T[][] ar2 = new T[3][];
        public T[][] ar3 = new T[3][];
        public T[][] ar4 = new T[8][];
        public Arrays(int size)
        {
            this.ar1 = new T[size];
            for (int i = 0; i < ar2.Length; i++)
            {
                this.ar2[i] = new T[size];

            }

            for (int i = 0; i < ar3.Length; i++)
                this.ar3[i] = new T[size];

            for (int i = 0; i < ar4.Length; i++)
                ar4[i] = new T[size];




        }



        public void RandShuffle(T[] array) 
        {
            Random rand = new Random();
            int module = 1000;
            for (int i = 0; i < array.Length; i++)
            {
                int el = rand.Next(0, module);
                object el2 = (object)el;
                T eln = (T)Convert.ChangeType(el2, typeof(T));  // Приведение с использованием Convert
                array[i] = eln;


            }


        }


        public void RandShuffle(T[] array, ref ConcurrentQueue<int> queue,int procent)
        {
            Random rand = new Random();
            int module = 1000;
            for (int i = 0; i < array.Length; i++)
            {
                int el = rand.Next(0, module);
                object el2 = (object)el;
                T eln = (T) el2;
                array[i] = eln;

            }
            queue.Enqueue(procent);

        }


        public void RandUnArrayShuffle(List<T[]> array)
        {
            
            /// Метод для второй группы массивов.
            Random random = new Random();
            int module = 10;
            int index = 0;

            for (int i = 0; i < array.Count; i++)
            {
                module = 10;
                index = 0;
                T[] currentArray = array[i];
                
                while (currentArray.Length - index >= module)
                {
                    T[] sub = new T[random.Next(0, module)];
                    Array.Copy(currentArray, index, sub, 0, sub.Length);
                    
                    Array.Sort(sub);
                    
                    Array.Copy(sub, 0, currentArray, index, sub.Length);
                    index += sub.Length;
                    module *= 2;
                }
            }

        }


        public void ItWasSorted(T[] array)
        {
            Random rand = new Random();
            int numOfRand = rand.Next(1, 10);
            
                
                Array.Sort(array);
            for (int j = 0; j < numOfRand; j++)
            {
                int it = rand.Next(0, array.Length - 1);
                int id = rand.Next(0, array.Length - 1);
                T tmp = array[it];
                array[it] = array[id];
                array[id] = tmp;
            }
        }

        public void ManyArray(List<T[]> Arrayss)
        {
            Random rand = new Random();
            
            Array.Sort(Arrayss[0]);
            
            Array.Reverse(Arrayss[1]);

            
                int count = rand.Next(0, ar4.Length - 1);
                for (int j = 0; j < count; j++)
                {
                object el = rand.Next(0, int.MaxValue);
                T eln = (T)el;
                Arrayss[3][j] = eln;
                }
            


            double[] proc = { 0.1, 0.25, 0.5, 0.75, 0.9 };
            int index = 0;
            for (int i = 4; i < Arrayss.Count; i++)
            {
                double s = ar4[i].Length * proc[index];
                int reqCount = (int)s;
                T[] array = ar4[i];
                RandShuffle(array);
                
                T randNumber = array[rand.Next(0, ar4.Length - 1)];
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
            int Counter(T[] array, T randNumber)
            {
                int counts = 0;
                foreach (T n in array)
                {
                    if (n.Equals(randNumber)) counts += 1;
                }
                return counts;
            }
        }
        public T[] ReSize(int size) {
            T[] array = new T[size];
            return array;
        }

        
    }
    
}
