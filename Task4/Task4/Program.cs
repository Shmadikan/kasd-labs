using System;
using System.ComponentModel;
using System.Linq.Expressions;
using Task4.Task4;
namespace Task4
{
    

    namespace Task4
    {
        class MyArrayList<T>
        {
            int size;
            public T[] elementData = null;

            public MyArrayList()
            {
                size = 0;
            }

            public MyArrayList(T[] a)
            {
                if (a.Length == 0)
                    
                    return;
                elementData = new T[a.Length * 2];
                for (int i = 0; i < a.Length; i++)
                {
                    elementData[i] = a[i];
                    ++size;
                }

            }

            public MyArrayList(int cap)
            {
                elementData = new T[cap];
                size = 0;
            }

            public void AddElement(T e)
            {
                /// Добавление элемента в конец.

                if (elementData == null) return;
                size += 1;
                if (size > elementData.Length)
                {
                    ReSize();
                }
                elementData[size - 1] = e;
            }


            public void Clear()
            {
                Array.Clear(elementData);
                size = 0;
            }


            public bool Contains(object o)
            {
                ///Проверка на содержание элемента.
                
                T oConverter = (T)o;
                foreach (T e in elementData)
                    if (oConverter.Equals(e))
                        return true;

                return false;
            }

            public bool ContainsAll(T[] a)
            {
                /// Метод, проверяющий наличие всех элементов
                /// Из передаваемого массива в динамическом.
                


                foreach (T e in a)
                {
                    bool flag = false;
                    foreach (T t in elementData)
                        if (t.Equals(e) == true)
                            flag = true;
                    if (!flag) return false;
                }
                return true;
            }


            public bool IsEmpty() => size == 0;


            public void Remove(object o)
            {
                /// Метод, удаляющий первое включение объекта о.


                T oConverter = (T)o;
                if (size > 0)
                {
                    for (int i = 0; i < elementData.Length; i++)
                    {
                        if (elementData[i].Equals(o))
                        {
                            if (i == elementData.Length - 1)
                            {
                                size -= 1; return;
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


            public void RemoveAll(T[] a)
            {
                /// Метод, удаляющий все элементы из динамического массива,
                /// При условии, что этот элемент есть в передаваемом массиве.

                if (size > 0)
                {
                    foreach (T o in a) 
                    for (int i = 0; i < elementData.Length; i++)
                    {
                        if (elementData[i].Equals(o))
                        {
                            if (i == elementData.Length - 1)
                            {
                                size -= 1; return;
                            }
                            for (int j = 0; j < elementData.Length - 1; j++)
                            {
                                if (j >= i)
                                    elementData[j] = elementData[j + 1];
                            }
                            size -= 1;
                            
                        }
                    }
                }





                
            }


            public void RetainAll(T[] a)
            {
                /// Метод, который оставляет в дин. массиве элементы из а.



                if (size > 0) {
                    for (int i = 0; i < size;) {
                        if (ElInArray(elementData[i]) == false)
                        {
                            if (i == size - 1)
                                size -= 1;
                            else
                            {
                                for (int index = i; index < size; index++)
                                {
                                    elementData[index] = elementData[index + 1];
                                }
                                size -= 1;
                            }

                        }
                        else i++;
                    
                    } 
                    





                }

                bool ElInArray(T el) 
                {
                    /// Вспомогательный метод, для проверки наличия элемента.

                    bool flag = false;
                    for (int i = 0; i < a.Length; i++)
                        if (a[i].Equals(el))
                            flag = true;
                    return flag;

                }
            }


            public int Size() => size;

            public T[] ToArray()
            {
                /// Метод возвращает массив из элементов дин. массива.

                T[] arrayToReturn = new T[size];
                for (int i = 0; i < size; i++)
                {
                    arrayToReturn[i] = elementData[i];
                }
                return arrayToReturn;
            }

            public T[] ToArray(T[] a = null)
            {
                /// Метод, который добавляет в массив а, все элементы из дин. массива.
                /// Если передаваемый массив пустой, то возвращает все элементы дин массива.

                if (a == null) {
                    T[] Ret = new T[size];
                    for (int i = 0; i < size; i++)
                        Ret[i] = elementData[i];
                    return Ret;
                }


                T[] RetArray = new T[a.Length + size];
                int index = 0;
                for (;index < a.Length;index++ )
                    RetArray[index] = a[index];

                for (int j = 0; j < size; j++) {
                    RetArray[index] = elementData[j];
                    index += 1;
                }
                return RetArray;
            }


            public void Add(int index, T e0)
            {
                /// Добавление элемента по индексу.
                if (index > size - 1 || index < 0)
                    throw new IndexOutOfRangeException();

                if (size + 1 > elementData.Length)
                    ReSize();

                T saveIndex = elementData[index];
                elementData[index] = e0;
                for (int i = index + 1; i < elementData.Length; i++)
                {
                    T saveEl = elementData[i];
                    elementData[i] = saveIndex;
                    saveIndex = saveEl;
                }
                ++size;
            }

            public void Add(int index, T[] elt)
            {
                /// Вставка элементов массива, начиная с индекса.

                if (index > size - 1 || index < 0)
                    throw new IndexOutOfRangeException();

                while (size + elt.Length > elementData.Length)
                    ReSize();
                
                T[] newArray = new T[size - index];
                for (int i = index, j = 0; j < size - index; i++, j++)
                    newArray[j] = elementData[i];
                int it = index;
                for (int j = 0; j < elt.Length; j++) {
                    elementData[it] = elt[j];
                    it++;
                }
                size = size + elt.Length;
                for (int k = 0; k < newArray.Length; it++, k++)
                
                    elementData[it] = newArray[k];
                    
                


                


            }



            public T get(int index) {
                if (index > size - 1 || index < 0)
                   throw new IndexOutOfRangeException();
               
                return elementData[index]; 
            
            }

            public int IndexOf(object o)
            {
                /// Возвращает индекс первого включения объекта о.

                T el = (T)o;
                for (int i = 0; i < elementData.Length; i++)
                    if (elementData[i].Equals(el))
                        return i;
                return -1;
            }


            public int LastIndex(object o)
            {
                /// Возвращает индекс последнего включения объекта о.

                T el = (T)o;
                for (int i = size - 1; i >= 0; i--)
                {
                    if (elementData[i].Equals(el))
                        return i;
                }
                return -1;
            }


            public T ReturnRemove(int index)
            {
                /// Метод удаляет элемент, и возвращает его значение пользователю.
                if (index > size - 1 || index < 0)
                    throw new IndexOutOfRangeException();

                if (index == size - 1)
                {
                    T retEl = elementData[size - 1];
                    size -= 1;
                    return retEl;
                }
                T el = elementData[index];
                for (int i = index; i < size; i++)
                    elementData[i] = elementData[i + 1];
                size -= 1;


                return el;
            }


            public void Set(int index, T e)
            {
                /// Замена по индексу.

                if (index > size - 1 || index < 0)
                    throw new IndexOutOfRangeException();
                elementData[index] = e;
            }


            public T[] SubList(int fromindex, int toindex)
            {
                if (fromindex > toindex || fromindex < 0 || toindex >= size)
                    throw new IndexOutOfRangeException();
                /// Возвращение подмассива с элементами, начиная с первого
                /// переданного индекса, до последнего.

                T[] arr = new T[toindex - fromindex + 1];
                int k = 0;
                for (int i = fromindex; i <= toindex; i++)
                {
                    arr[k] = elementData[i];
                    k++;
                }
                return arr;
            }

            public void ReSize()
            {
                /// Вспомогательный метод для перевыделения памяти.

                if (size > elementData.Length)
                {
                    
                    T[] NewArray = new T[elementData.Length * 2];
                    for (int i = 0; i < elementData.Length; i++)
                        NewArray[i] = elementData[i];
                    elementData = NewArray;
                }
            }

            public void Print() {
                /// Отладочный метод для просмотра элементов массива.

                if (elementData != null)
                {
                    for (int i = 0; i < size; i++)
                        Console.Write($"{elementData[i]} ");
                }
            }
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            /// Пустота.
        }
    }
}