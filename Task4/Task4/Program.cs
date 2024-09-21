using System.ComponentModel;
using System.Linq.Expressions;

namespace Task4
{
    class MyArrayList<T>{
        int size;
        public T[] array;
        public MyArrayList() {
            size = 0;
        }

        public MyArrayList(T[] a) {
            array = new T[a.Length * 2];
            for (int i = 0; i < a.Length; i++) {
                array[i] = a[i];
                size += 1;
            }
        
        }

        public MyArrayList(int cap)
        {
            array = new T[cap];
            size = 0;
        }

        public void add(T e) {
            if (size > array.Length) { 
                T [] NewArray = new T[array.Length * 2];
                
            }
            array[size - 1] = e;
            size += 1;
        
        } 

    }



    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}