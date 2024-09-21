using System.ComponentModel;
using System.Linq.Expressions;

namespace Task4
{
    class MyArrayList<T>{
        int size;
        public T[] elementData;
       
        public MyArrayList() {
            size = 0;
        }

        public MyArrayList(T[] a) {
            elementData = new T[a.Length * 2];
            for (int i = 0; i < a.Length; i++) {
                elementData[i] = a[i];
                size += 1;
            }
        
        }

        public MyArrayList(int cap)
        {
            elementData = new T[cap];
            size = 0;
        }

        public void add(T e) {
            if (size > elementData.Length) { 
                T [] NewArray = new T[elementData.Length * 2];
                for (int i = 0; i < elementData.Length; i++)
                    NewArray[i] = elementData[i];
            }
            elementData[size - 1] = e;
            size += 1;
        
        }


        public void Clear() {
            Array.Clear(elementData);
            size = 0;
        }


        public bool Contains(object o) {
            if (o.GetType() != elementData.GetType())
                return false;
            T oConverter = (T)o;
            foreach (T e in elementData) 
                if (oConverter.Equals(e)) 
                    return true;
                
            return false;
        }

        public bool ContainsAll(T[] a) {
            foreach (T e in a) { 
                foreach(T t in elementData)
                    if (t.Equals(e) == false)
                        return false;
            }
            return true;
        }


        public bool IsEmpty() => size == 0;


        public void Remove(object o)
        {
            T oConverter = (T)o;
            if (size > 0)
            {
                for (int i = 0; i < elementData.Length; i++)
                {
                    if (elementData[i].Equals(o))
                    {
                        if (i == elementData.Length - 1)
                        {
                            size -= 1;return;
                        }
                        for (int j = 0; j < elementData.Length - 1; j++)
                        {
                            if (j >= i)
                                elementData[j] = elementData[j + 1];
                        }
                        size -= 1;
                        return;
                    }
                }
            }
        }


        public void RemoveAll(T[] a) {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < elementData.Length; j++)
                    if (elementData[j].Equals(a[i]))
                        Deletion(elementData[j], j);
            }
        




            void Deletion(T element, int index) {
                if (index == elementData.Length - 1) { 
                    size -= 1;return;
                }
                for (int i = index; i < elementData.Length - 1; i++) {

                        elementData[index] = elementData[index + 1];
                }
                size -= 1;
                
            }
        }


        public void RetainAll(T[] a) {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < elementData.Length; j++)
                    if (elementData[j].Equals(a[i]) == false)
                        Deletion(elementData[j], j);
            }
            void Deletion(T element, int index)
            {
                if (index == elementData.Length - 1)
                {
                    size -= 1; return;
                }
                for (int i = index; i < elementData.Length - 1; i++)
                {

                    elementData[index] = elementData[index + 1];
                }
                size -= 1;

            }
        }

        public int Size() => size;

        public T[] ToArray()
        {
            T[] arrayToReturn = new T[size];
            for (int i = 0; i < elementData.Length; i++) {
                arrayToReturn[i] = elementData[i];
            }
            return arrayToReturn;
        }

        public T[] ToArray(T[] a) { 
            
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