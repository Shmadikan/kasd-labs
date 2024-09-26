using Task4;
using Task4.Task4;

namespace Task_10
{
    internal class Program
    {
        


            





        public class Heap<T> where T: IComparable<T>{
            MyArrayList<T> array = new MyArrayList<T>(10);
            int size;
            public Heap(T[] array) {
                this.array.AddAll(array);
                size = array.Length;
                for (int i = size / 2; i >= 0; i--)
                    HeapOrder(i);
                this.array.Print();
            }



            void HeapOrder(int index) {
                int rightChild, leftChild, currentParent;
                while (true) {
                    leftChild = index * 2 + 1;
                    rightChild = index * 2 + 2;
                    currentParent = index;

                    


                    if (leftChild < size ) 
                    {
                        if (array.get(leftChild).CompareTo(array.get(currentParent)) < 0)
                            currentParent = leftChild;
                    }

                    if (rightChild < size)
                    {
                        if (array.get(rightChild).CompareTo(array.get(currentParent)) < 0)
                            currentParent = rightChild;
                    }

                    if (currentParent == index)
                        break;

                    T tmp = array.get(currentParent);
                    array.Set(currentParent, array.get(index));
                    array.Set(index, tmp);
                    index = currentParent;
                }
            
            }

            public T Min() => array.get(0);

            public T RetMin() {
                if (array.Size() > 1)
                {
                    T e = array.get(0);
                    array.Set(0, array.get(array.Size() - 1));
                    --size;
                    HeapOrder(0);
                    return e;
                }
                else
                {
                    size = 0;
                    return array.get(0);
                }
            }

            public void AddToHeap(T e) {
                array.AddElement(e);
                size++;
                for (int i = size / 2; i >= 0; i++)
                    HeapOrder(i);
            }

            public void HeapMerge(Heap<T> newHeap)
            {
                while (newHeap.size > 0)
                {
                    T e = newHeap.RetMin();
                    array.AddElement(e);
                    size++;
                }
                for (int i = size / 2; i >= 0; i++)
                    HeapOrder(i);
            }


            public void KeyIncr(int index, T e) {
                if (index > array.Size() - 1)
                    throw new IndexOutOfRangeException();
                array.Set(index, e);
                for (int i = size / 2; i >= 0; i--)
                {
                    array.Print();
                    Console.WriteLine();
                    HeapOrder(i);
                }
            }
            public void Print() {
                array.Print();
            
            }
        }




        static void Main(string[] args)
        {

            int[] mas = { 10, 2, 3,7,6,5,1 };
            Heap<int> hp = new Heap<int>(mas);
            hp.KeyIncr(2, 20);
            hp.Print();
        }
    }
}