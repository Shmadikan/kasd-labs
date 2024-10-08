using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task33
{
    public class StandartComparer<T> : Comparer<T> where T : IComparable
    {
        /// Второй кастомный компаратор, который сортирует все типы в порядке убывания.


        public override int Compare(T x, T y)
        {
            return x.CompareTo(y);
        }
    }


    public sealed class AllSortIsHere<T> where T: IComparable
    {
        /// <summary>
        /// Класс, содержащий методы сортировок, а также инкапсулирующий в себе, некоторые структуры и вспомогательные методы.
        /// </summary>
        /// <param name="array">Можно передать обобщённые данные.</param>
        protected IComparer<T> comparer = new StandartComparer<T>();
        public AllSortIsHere() { }
        public AllSortIsHere(IComparer<T> comp) { 
            comparer = comp;
        }
        
        
        public void BubbleSort(T[] array)
        {
            ///Пузырьковая сортировка
            for (int i = 0; i < array.Length; i++)
                for (int j = array.Length - 1; j > i; j--)
                    if (comparer.Compare(array[j - 1], array[j]) > 0)
                    {
                        T tmp = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = tmp;
                    }
        }


        public void ShakeSort(T[] array)
        {
            bool f = true;
            int right = array.Length - 1;
            int left = 0;
            while (left < right && f != false)
            {
                f = false;
                for (int i = right; i > left; i--)
                    if (comparer.Compare(array[i - 1], array[i]) > 0)
                    
                    {
                        T tmp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = tmp;
                        f = true;
                    }
                left += 1;
                for (int j = left; j < right; j++)
                    if (comparer.Compare(array[j], array[j + 1])> 0)
                    {
                        T tmp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tmp;
                        f = true;
                    }
                right -= 1;
            }
        }


        public void CombSort(T[] array)
        {
            double subFactor = 1.25;
            int currentDistanse = array.Length - 1;
            while (currentDistanse > 0)
            {
                for (int i = 0; i + currentDistanse < array.Length; i += 1)
                {
                    if (comparer.Compare(array[i], array[i + currentDistanse]) > 0)
                   
                    {
                        T tmp = array[i];
                        array[i] = array[i + currentDistanse];
                        array[i + currentDistanse] = tmp;
                    }
                }
                currentDistanse = (int)(currentDistanse / subFactor);
            }
        }


        public void InsertionSort(T[] array)
        {
            int i, j;
            T temp;
            for (i = 1; i < array.Length; i++)
            {
                temp = array[i];
                for (j = i - 1; j >= 0; j--)
                {
                    if (comparer.Compare(array[j], temp) < 0) break;
                    array[j + 1] = array[j];
                    array[j] = temp;
                }
            }
        }


        public void ShellSort(T[] array)
        {
            int step = array.Length / 2;
            while (step > 0)
            {
                for (int i = step; i < array.Length; i++)
                {
                    int j = i;
                    int stepBack = j - step;
                    
                    while (stepBack >= 0 && comparer.Compare(array[stepBack],array[j]) > 0)
                    {
                        swap(j, stepBack);
                        j = stepBack;
                        stepBack = j - step;
                    }
                }
                step /= 2;
            }
            void swap(int j, int stepBack)
            {
                T tmp = array[stepBack];
                array[stepBack] = array[j];
                array[j] = tmp;
            }
        }


        public void TreeSort(T[] array)
        {
            void CreateTree(Tree<T> rootk, T val)
            {
                if (rootk.val.CompareTo(val) > 0)
                {
                    if (rootk.left == null)
                    {
                        Tree<T> ntree = new Tree<T>();
                        ntree.val = val;
                        rootk.left = ntree;
                    }
                    else CreateTree(rootk.left, val);
                }
                else
                {
                    if (rootk.right == null)
                    {
                        Tree<T> ntree = new Tree<T>();
                        ntree.val = val;
                        rootk.right = ntree;
                    }
                    else CreateTree(rootk.right, val);
                }
            }
            Tree<T> root = new Tree<T>();
            root.val = array[0];
            // Создаём дерево.
            for (int index = 1; index < array.Length / 5; index++)
                CreateTree(root, array[index]);


            int i = 0;
            TreeWalking(root, array);
            void TreeWalking(Tree<T> roots,T[] mass)
            {
                if (roots == null) return;
                else
                {
                    TreeWalking(roots.left, mass);
                    mass[i] = roots.val; i++;
                    TreeWalking(roots.right, mass);
                }
            }
        }


        public void GnomeSort(T[] array)
        {
            int i = 0; int j = 1;
            while (j < array.Length)
            {
                if (comparer.Compare(array[i], array[i + 1])>0)
                
                {
                    T tmp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = tmp;
                    if (i > 0)
                        i -= 1;
                }
                else
                {
                    i = j; j++;
                }
            }
        }


        public void SelectionSort(T[] array)
        {
            int imin; T min;
            for (int i = 0; i < array.Length; i++)
            {
                imin = i; min = array[i];
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (comparer.Compare(array[j], min) < 0)
                    {
                        min = array[j];
                        imin = j;
                    }
                }
                T tmp = array[i];
                array[i] = min;
                array[imin] = tmp;
            }
        }


        public void HeapSort(T[] array)
        {
            Heap s = new Heap(array, comparer);
            s.ExactlySort(array);
        }


        public void QuickSort(T[] array, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex];

            while (i <= j)
            {
                while (comparer.Compare(array[i], pivot) < 0)
                {
                    i++;
                }
                while (comparer.Compare(array[j], pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    T temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
                QuickSort(array, leftIndex, j);

            if (i < rightIndex)
                QuickSort(array, i, rightIndex);

            
        }


        public void CountSort<T>(T[] array)
        {
            
            int min = int.MaxValue;
            int max = int.MinValue;

            foreach (T item in array)
            {
                int value = Convert.ToInt32(item);
                if (value < min) min = value;
                if (value > max) max = value;
            }

            
            int[] helpMas = new int[max - min + 1];

            
            for (int i = 0; i < array.Length; i++)
            {
                int el = Convert.ToInt32(array[i]);
                helpMas[el - min]++;
            }

            
            int k = 0;
            for (int i = 0; i < helpMas.Length; i++)
            {
                for (int j = 0; j < helpMas[i]; j++)
                {
                    array[k] = (T)Convert.ChangeType(i + min, typeof(T));  // Преобразование обратно к типу T
                    k++;
                }
            }
        }



        public T[] mergeSort(T[] array)
        {
            T[] left;
            T[] right;
            T[] result = new T[array.Length];
            if (array.Length <= 1)
                return array;

            int midPoint = array.Length / 2;

            left = new T[midPoint];


            if (array.Length % 2 == 0)
                right = new T[midPoint];

            else
                right = new T[midPoint + 1];

            for (int i = 0; i < midPoint; i++)
                left[i] = array[i];

            int x = 0;

            for (int i = midPoint; i < array.Length; i++)
            {
                right[x] = array[i];
                x++;
            }

            left = mergeSort(left);

            right = mergeSort(right);

            result = merge(left, right);
            return result;

        }
        public T[] merge(T[] left, T[] right)
        {
            /// Вспомогательный метод для сортировки слиянием. Также объединяет их.
            int resultLength = right.Length + left.Length;
            T[] result = new T[resultLength];

            int indexLeft = 0, indexRight = 0, indexResult = 0;

            while (indexLeft < left.Length || indexRight < right.Length)
            {

                if (indexLeft < left.Length && indexRight < right.Length)
                {

                    if (comparer.Compare(left[indexLeft],right[indexRight]) <= 0)
                    {
                        result[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }

                    else
                    {
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }

                else if (indexLeft < left.Length)
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                else if (indexRight < right.Length)
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }
            return result;


        }


        public void RadixSort(int[] array)
        {
            //Вспомогательный массив.
            int[] t = new int[array.Length];

            // Количество рассматриваемых битов. 
            int r = 4;
            
            // Всего битов в int.
            int b = 32;

            // count массив, который мы используем для сортировки битов по индексу.
            // Получаем 4 бита и увеличиваем значение по индексу, соответствующему 4 битам.


            // Префиксную сумму используем для того, чтобы поставить число на нужное место в массив.
            int[] count = new int[1 << r];
            int[] pref = new int[1 << r];

            // Количество итераций. 
            int groups = 8;

            // Маска для отделения 4 битов. 
            int mask = (1 << r) - 1;

            for (int c = 0, shift = 0; c < groups; c++, shift += r)
            {
                // Сброс значений.
                for (int j = 0; j < count.Length; j++)
                    count[j] = 0;


                for (int i = 0; i < array.Length; i++)
                {
                    int test = array[i];
                    var first = array[i] >> shift;
                    var num = first & mask;
                    count[num]++;
                }

                // Составляем префиксную сумму. 
                pref[0] = 0;
                for (int i = 1; i < count.Length; i++)
                    pref[i] = pref[i - 1] + count[i - 1];


                for (int i = 0; i < array.Length; i++)
                {
                    var first = array[i] >> shift;
                    var num = first & mask;
                    t[pref[num]++] = array[i];
                }

                t.CopyTo(array, 0);
                ///Пояснения насчёт префиксной суммы:
                ///Префиксная сумма это вспомогательный массив.
                ///Каждый индекс в этом массиве соответствует sum(0, b) массива, где b
                ///Индекс исходного массива.
                ///Пример:
                ///[0, 1, 0, 1, 0] - Исходный массив
                ///[0, 0, 1, 1, 2] - Его префиксная сумма
                ///Так, например, sum(0,4), на 4 позиции префиксного массива будет сумма от 0 до b (2).
                ///Фактически сумма на этой позиции означает, что до этого мы встретили 2 числа.
                ///Если предположить, что они уже стоят по своим индексам, мы можем поставить число
                ///На эту позицию. В случае с повторяющимися числами, достаточно после постановки числа
                ///на позицию, увеличить индекс. В таком случае мы поставим одинаковое число на следующую позицию.
            }
        }



        class Tree<T> where T: IComparable
        {
            /// Вспомогательный класс для построения дерева.

            public T val;
            public Tree<T> left = null;
            public Tree<T> right = null;
        }


        class Heap
        {
            /// Вспомогательный класс для пирамидальной сортировки.
            /// Содержит методы для: упорядочивания, извлечения минимального и сортировки.
            
            
            List<T> heap;
            int sizeofheap;
            IComparer<T> comparer;
            public Heap(T[] array, IComparer<T> comparer)
            {
                this.comparer = comparer;
                this.heap = array.ToList();
                this.sizeofheap = array.Length;
                for (int i = sizeofheap / 2; i >= 0; i--)
                {
                    OrderingHeap(i);
                }
                foreach (T i in heap) Console.Write($"{i} ");
                Console.WriteLine();
            }


            public void OrderingHeap(int i)
            {
                /// Метод, реализующий упорядочивание кучи.
                int rightHeap, leftHeap, rootHeap;
                
                while (true)
                {
                    leftHeap = 2 * i + 1;
                    rightHeap = 2 * i + 2;
                    rootHeap = i;
                    
                    if (leftHeap < sizeofheap && comparer.Compare(heap[leftHeap],heap[rootHeap]) < 0)
                    {
                        rootHeap = leftHeap;
                    }
                    if (rightHeap < sizeofheap && comparer.Compare(heap[rightHeap], heap[rootHeap]) < 0)
                    {
                        rootHeap = rightHeap;
                    }
                    if (rootHeap == i) break;
                    Swap(i, rootHeap);
                    i = rootHeap;
                }



                void Swap(int firstSwap, int secondSwap)
                {
                    T tmp = heap[firstSwap];
                    heap[firstSwap] = heap[secondSwap];
                    heap[secondSwap] = tmp;
                }
            }
            public T Min()
            {
                ///Метод, извлекающий минимальный элемент из кучи.


                T result = heap[0];
                heap[0] = heap[sizeofheap - 1];
                --sizeofheap;
                return result;
            }
            public void ExactlySort(T[] array)
            {
                ///Метод, в котором осуществляется непосредственно сортировка массива.

                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = this.Min();
                    this.OrderingHeap(0);
                }

            }

        }
        public T[] BitonicSort(ref T[] array)
        {
            
            
                int n = array.Length;
                int k, j, l, i;
                T temp;
                int cond = n & (n - 1);
                if (cond != 0)
                {
                    int pow = 1;
                    int sn = n;
                    while (sn != 0)
                    {
                        sn /= 2;
                        pow *= 2;
                    }
                    n = pow;
                }
                T[] newArray = new T[n];

                for (int it = 0; it < newArray.Length; it++)
                {
                    if (it < array.Length)
                    {
                        newArray[it] = array[it];

                    }
                    else newArray[it] = default(T);
                }
                for (k = 2; k <= n; k *= 2)
                {
                    for (j = k / 2; j > 0; j /= 2)
                    {
                        for (i = 0; i < n; i++)
                        {
                            l = i ^ j;
                            if (l > i)
                            {
                                if (((i & k) == 0) && (comparer.Compare(newArray[i], newArray[l])) > 1 || (((i & k) != 0) && comparer.Compare(newArray[i],newArray[l]) < 0))
                                {
                                    temp = newArray[i];
                                    newArray[i] = newArray[l];
                                    newArray[l] = temp;
                                }
                            }
                        }
                    }
                }

                return newArray;
            
        }
        public void SortChose(int st, T[] array)
        {
            switch (st)
            {
                case 0: { this.BubbleSort(array); break; }
                case 1: { this.InsertionSort(array); break; }
                case 2: { this.SelectionSort(array); break; }
                case 3: { this.ShakeSort(array); break; }
                case 4: { this.GnomeSort(array); break; }
                case 5: { this.BitonicSort(ref array);break; }
                case 6: { this.ShellSort(array);break; }
                case 7: { this.TreeSort(array);break; }
                case 8: { this.CombSort(array);break; }
                case 9: { this.HeapSort(array); break; }
                case 10: { this.QuickSort(array, 0, array.Length - 1);break; }
                case 11: { this.mergeSort(array);break; }
                case 12: { this.CountSort(array);break; }
                case 13: { break; }
            }

        }

    }
}
