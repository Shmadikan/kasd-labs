using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task33
{
    public sealed class AllSortIsHere
    {
        /// <summary>
        /// Класс, содержащий методы сортировок, а также инкапсулирующий в себе, некоторые структуры и вспомогательные методы.
        /// </summary>
        /// <param name="mas">Необходимо передавать массив целых чисел.</param>
        public void BubbleSort(int[] mas)
        {
            ///Пузырьковая сортировка
            for (int i = 0; i < mas.Length; i++)
                for (int j = mas.Length - 1; j > i; j--)
                    if (mas[j] < mas[j - 1])
                    {
                        int tmp = mas[j];
                        mas[j] = mas[j - 1];
                        mas[j - 1] = tmp;
                    }
        }


        public void ShakeSort(int[] mas)
        {
            bool f = true;
            int right = mas.Length - 1;
            int left = 0;
            while (left < right && f != false)
            {
                f = false;
                for (int i = right; i > left; i--)
                    if (mas[i] < mas[i - 1])
                    {
                        int tmp = mas[i];
                        mas[i] = mas[i - 1];
                        mas[i - 1] = tmp;
                        f = true;
                    }
                left += 1;
                for (int j = left; j < right; j++)
                    if (mas[j] > mas[j + 1])
                    {
                        int tmp = mas[j];
                        mas[j] = mas[j + 1];
                        mas[j + 1] = tmp;
                        f = true;
                    }
                right -= 1;
            }
        }


        public void CombSort(int[] mas)
        {
            double subFactor = 1.25;
            int currentDistanse = mas.Length - 1;
            while (currentDistanse > 0)
            {
                for (int i = 0; i + currentDistanse < mas.Length; i += 1)
                {
                    if (mas[i] > mas[i + currentDistanse])
                    {
                        int tmp = mas[i];
                        mas[i] = mas[i + currentDistanse];
                        mas[i + currentDistanse] = tmp;
                    }
                }
                currentDistanse = (int)(currentDistanse / subFactor);
            }
        }


        public void InsertionSort(int[] mas)
        {
            int i, j, temp;
            for (i = 1; i < mas.Length; i++)
            {
                temp = mas[i];
                for (j = i - 1; j >= 0; j--)
                {
                    if (mas[j] < temp) break;
                    mas[j + 1] = mas[j];
                    mas[j] = temp;
                }
            }
        }


        public void ShellSort(int[] mas)
        {
            int step = mas.Length / 2;
            while (step > 0)
            {
                for (int i = step; i < mas.Length; i++)
                {
                    int j = i;
                    int stepBack = j - step;
                    while (stepBack >= 0 && mas[stepBack] > mas[j])
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
                int tmp = mas[stepBack];
                mas[stepBack] = mas[j];
                mas[j] = tmp;
            }
        }


        public void TreeSort(int[] mas)
        {
            void CreateTree(Tree rootk, int val)
            {
                if (rootk.val > val)
                {
                    if (rootk.left == null)
                    {
                        Tree ntree = new Tree();
                        ntree.val = val;
                        rootk.left = ntree;
                    }
                    else CreateTree(rootk.left, val);
                }
                else
                {
                    if (rootk.right == null)
                    {
                        Tree ntree = new Tree();
                        ntree.val = val;
                        rootk.right = ntree;
                    }
                    else CreateTree(rootk.right, val);
                }
            }
            Tree root = new Tree();
            root.val = mas[0];
            // Создаём дерево.
            for (int index = 1; index < mas.Length / 5; index++)
                CreateTree(root, mas[index]);


            int i = 0;
            TreeWalking(root, mas);
            void TreeWalking(Tree roots,int[] mass)
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


        public void GnomeSort(int[] mas)
        {
            int i = 0; int j = 1;
            while (j < mas.Length)
            {
                if (mas[i] > mas[i + 1])
                {
                    int tmp = mas[i];
                    mas[i] = mas[i + 1];
                    mas[i + 1] = tmp;
                    if (i > 0)
                        i -= 1;
                }
                else
                {
                    i = j; j++;
                }
            }
        }


        public void SelectionSort(int[] mas)
        {
            int imin, min;
            for (int i = 0; i < mas.Length; i++)
            {
                imin = i; min = mas[i];
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[j] < min)
                    {
                        min = mas[j];
                        imin = j;
                    }
                }
                int tmp = mas[i];
                mas[i] = min;
                mas[imin] = tmp;
            }
        }


        public void HeapSort(int[] mas)
        {
            Heap s = new Heap(mas);
            s.ExactlySort(mas);
        }


        public void QuickSort(int[] array, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex];

            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }

                while (array[j] > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    int temp = array[i];
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


        public void CountSort(int[] mas)
        {
            int[] helpMas = new int[mas.Max() + 20];
            for (int i = 0; i < mas.Length; i++)
            {
                helpMas[mas[i]] += 1;
            }
            int k = 0;
            for (int i = 0; i < helpMas.Length; i++)
            {
                for (int j = 0; j < helpMas[i]; j++)
                { mas[k] = i; ++k; }
            }
        }


        public int[] mergeSort(int[] array)
        {
            int[] left;
            int[] right;
            int[] result = new int[array.Length];
            if (array.Length <= 1)
                return array;

            int midPoint = array.Length / 2;

            left = new int[midPoint];


            if (array.Length % 2 == 0)
                right = new int[midPoint];

            else
                right = new int[midPoint + 1];

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
        public int[] merge(int[] left, int[] right)
        {
            /// Вспомогательный метод для сортировки слиянием. Также объединяет их.
            int resultLength = right.Length + left.Length;
            int[] result = new int[resultLength];

            int indexLeft = 0, indexRight = 0, indexResult = 0;

            while (indexLeft < left.Length || indexRight < right.Length)
            {

                if (indexLeft < left.Length && indexRight < right.Length)
                {

                    if (left[indexLeft] <= right[indexRight])
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


        public void RadixSort(int[] mas)
        {
            //Вспомогательный массив.
            int[] t = new int[mas.Length];

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


                for (int i = 0; i < mas.Length; i++)
                {
                    int test = mas[i];
                    var first = mas[i] >> shift;
                    var num = first & mask;
                    count[num]++;
                }

                // Составляем префиксную сумму. 
                pref[0] = 0;
                for (int i = 1; i < count.Length; i++)
                    pref[i] = pref[i - 1] + count[i - 1];


                for (int i = 0; i < mas.Length; i++)
                {
                    var first = mas[i] >> shift;
                    var num = first & mask;
                    t[pref[num]++] = mas[i];
                }

                t.CopyTo(mas, 0);
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



        class Tree
        {
            /// Вспомогательный класс для построения дерева.

            public int val;
            public Tree left = null;
            public Tree right = null;
        }


        class Heap
        {
            /// Вспомогательный класс для пирамидальной сортировки.
            /// Содержит методы для: упорядочивания, извлечения минимального и сортировки.


            List<int> heap;
            int sizeofheap;
            public Heap(int[] mas)
            {
                this.heap = mas.ToList();
                this.sizeofheap = mas.Length;
                for (int i = sizeofheap / 2; i >= 0; i--)
                {
                    OrderingHeap(i);
                }
                foreach (int i in heap) Console.Write($"{i} ");
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
                    if (leftHeap < sizeofheap && heap[leftHeap] < heap[rootHeap])
                    {
                        rootHeap = leftHeap;
                    }
                    if (rightHeap < sizeofheap && heap[rightHeap] < heap[rootHeap])
                    {
                        rootHeap = rightHeap;
                    }
                    if (rootHeap == i) break;
                    Swap(i, rootHeap);
                    i = rootHeap;
                }



                void Swap(int firstSwap, int secondSwap)
                {
                    int tmp = heap[firstSwap];
                    heap[firstSwap] = heap[secondSwap];
                    heap[secondSwap] = tmp;
                }
            }
            public int Min()
            {
                ///Метод, извлекающий минимальный элемент из кучи.


                int result = heap[0];
                heap[0] = heap[sizeofheap - 1];
                --sizeofheap;
                return result;
            }
            public void ExactlySort(int[] mas)
            {
                ///Метод, в котором осуществляется непосредственно сортировка массива.

                for (int i = 0; i < mas.Length; i++)
                {
                    mas[i] = this.Min();
                    this.OrderingHeap(0);
                }

            }

        }
        public int[] BitonicSort(ref int[] mas)
        {
            
            
                int n = mas.Length;
                int k, j, l, i, temp;
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
                int[] nmas = new int[n];

                for (int it = 0; it < nmas.Length; it++)
                {
                    if (it < mas.Length)
                    {
                        nmas[it] = mas[it];

                    }
                    else nmas[it] = -1;
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
                                if (((i & k) == 0) && (nmas[i] > nmas[l]) || (((i & k) != 0) && (nmas[i] < nmas[l])))
                                {
                                    temp = nmas[i];
                                    nmas[i] = nmas[l];
                                    nmas[l] = temp;
                                }
                            }
                        }
                    }
                }

                return nmas;
            
        }
        public void SortChose(int st, int[] mas)
        {
            switch (st)
            {
                case 0: { this.BubbleSort(mas); break; }
                case 1: { this.InsertionSort(mas); break; }
                case 2: { this.SelectionSort(mas); break; }
                case 3: { this.ShakeSort(mas); break; }
                case 4: { this.GnomeSort(mas); break; }
                case 5: { this.BitonicSort(ref mas);break; }
                case 6: { this.ShellSort(mas);break; }
                case 7: { this.TreeSort(mas);break; }
                case 8: { this.CombSort(mas);break; }
                case 9: { this.HeapSort(mas); break; }
                case 10: { this.QuickSort(mas, 0, mas.Length - 1);break; }
                case 11: { this.mergeSort(mas);break; }
                case 12: { this.CountSort(mas);break; }
                case 13: { this.RadixSort(mas);break; }
            }

        }

    }
}
