
using System.Reflection.Metadata.Ecma335;
using ConsoleApp2;
using System.Xml.Schema;
using System.Collections;
using System.Security.Cryptography;
using System;
using System.Data.SqlTypes;

namespace ConsoleApp3
{

    internal class Program
    {
        

        public class MyComparer2<T> : Comparer<T> where T : IComparable<T>
        {
            /// Второй кастомный компаратор, который сортирует все типы в порядке убывания.


            public override int Compare(T? x, T? y)
            {


                return y.CompareTo(x) * -1;
            }
        }




        public class MyComparer<T> : Comparer<T> where T : IComparable
        {
            /// <summary>
            /// Кастомный компаратор, сортирующий все типы, кроме int в порядке убывания.
            /// В типе int чётные числа, считаются большими, чем все остальные.
            /// </summary>
            



            public override int Compare(T? x, T? y)
            {
                //x - родитель
                //y - наследник

                //el1 - элемент родителя
                //el2 - элемент наследника

                if (x == null && y == null)
                    return 0;


                if (x.GetType() != y.GetType())
                    throw new NotImplementedException();
                if (x is int)
                {
                    int el1 = (int)(object)x;
                    int el2 = (int)(object)y;
                    if (el1 % 2 == 0 && el2 % 2 != 0) // Если наследник чётный, родитель нет.
                        return 1;
                    if (el2 % 2 != 0 && el1 % 2 != 0) // Если оба нечётные 
                    {
                        if (el2 < el1)
                            return -1;
                        if (el2 == el1)
                            return 0;
                        return 1;

                    }
                    if (el2 % 2 == 0 && el1 % 2 != 0) // Если наследник чётный, родитель нет.
                        return -1;

                    else // Если оба чётные.
                    {

                        if (el2 < el1)
                            return -1;
                        if (el2 > el1)
                            return 1;
                        if (el2 == el1)
                            return 0;
                    }
                }


                return y.CompareTo(x) * -1;


            }
        }

        public class MyPriorityQueue<T> where T : IComparable
        {
            public MyVector<T> queue;
            private int size;
            private IComparer<T> comparer = new MyComparer<T>();
            //private MyComparer<T> comparer = new MyComparer<T>();
            public MyPriorityQueue()
            {
                queue = new MyVector<T>();
                size = 0;
            }


            public MyPriorityQueue(T[] a)
            {
                queue = new MyVector<T>(a);
                size = queue.Size();
                for (int index = size / 2; index >= 0; index--)
                    OrderInHeap(index);
            }


            public MyPriorityQueue(int capacity)
            {
                queue = new MyVector<T>(capacity);
                size = 0;
            }


            public MyPriorityQueue(int capacity, IComparer<T> comp)
            {
                queue = new MyVector<T>(capacity);
                size = 0;
                comparer = comp;
            }


            public MyPriorityQueue(MyPriorityQueue<T> c)
            {
                queue = new MyVector<T>();
                T[] a = c.ToArray();
                for (int i = 0; i < a.Length; i++)
                    queue.Add(a[i]);
                size = queue.Size();
            }

            public void Add(T e)
            {

                queue.Add(e);
                size++;
                for (int index = size / 2; index >= 0; index--)
                    OrderInHeap(index);


            }


            public void Clear()
            {
                size = 0; queue.Clear();

            }


            public bool Contains(object o)
            {
                return queue.Contains(o);

            }

            public bool ContainsAll(T[] a)
            {
                return queue.ContainsAll(a);
            }

            public bool IsEmpty() => size == 0;

            public void Remove(object o)
            {
                queue.Remove(o);
                size--;
                for (int index = size / 2; index >= 0; index--)
                    OrderInHeap(index);
            }


            public void RemoveAll(T[] a)
            {
                queue.RemoveAll(a);
                size = queue.Size();
            }


            public void RetainAll(T[] a)
            {
                queue.RetainAll(a);
                size = queue.Size();
                for (int index = size / 2; index >= 0; index--)
                    OrderInHeap(index);
            }


            public int Size() => size;


            public T[] ToArray() { return queue.ToArray(); }


            public T[] ToArray(T[] a) { return queue.ToArray(a); }


            public T Element() => queue.firstElement();


            public T? Peek()
            {
                if (size == 0) return default(T);
                return queue.firstElement();
            }


            public T Pool()
            {
                if (size == 0)
                    throw new InvalidOperationException();
                size -= 1;
                T el = queue.firstElement();

                queue.RemoveElementAt(0);
                for (int index = size / 2; index >= 0; index--)
                    OrderInHeap(index);
                return el;
            }

            private void OrderInHeap(int index)
            {



                int left, right, root;
                while (true)
                {
                    left = index * 2 + 1;
                    right = index * 2 + 2;
                    root = index;







                    if (left < size)
                    {
                        if (this.comparer.Compare(queue.get(root), queue.get(left)) < 0)
                            root = left;

                    }

                    if (right < size)
                    {
                        if (this.comparer.Compare(queue.get(root), queue.get(right)) < 0)
                            root = right;

                    }
                    if (root == index)
                        break;

                    T tmp = queue.get(root);
                    queue.Set(root, queue.get(index));
                    queue.Set(index, tmp);
                    index = root;


                }


            }


        }

        static void Main() {
            int[] mas = { 4, 3, 1,7 , 5};
            char[] mas2 = { 'a', 'b', 'c' };
            MyPriorityQueue<char> Mpq = new MyPriorityQueue<char>(mas2);
            MyPriorityQueue<int> Mp = new MyPriorityQueue<int>(mas);
            while (Mpq.Size() > 0) {
                Console.Write(Mpq.Peek() + " ");
                Mpq.Pool();
            }
            Console.WriteLine();

            

            while (Mp.Size() > 0) { 
                Console.Write(Mp.Peek() + " ");
                Mp.Pool();
            }
        
        }



    }

        





       
    
}