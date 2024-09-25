using ConsoleApp2;
using System.ComponentModel;
using System.Drawing;

namespace ConsoleApp2
{
    public class MyVector<T>
    {
        T[] elementData;
        int elementCount;
        int capacityIncrement;
        public MyVector(int initialCapacity, int CapIncr) {
            elementCount = initialCapacity;
            capacityIncrement = CapIncr;
            elementData = new T[elementCount];
        }
 

        public MyVector(int initialCapacity) {
            elementCount = initialCapacity;
            capacityIncrement = 0;
            elementData = new T[elementCount];
        }


        public MyVector() {
            elementCount = 0;
            capacityIncrement = 0;
            elementData = new T[elementCount];
        }


        public MyVector(T[] a) {
            elementCount = a.Length;
            elementData = new T[elementCount];
            capacityIncrement = 0;
            for (int i = 0; i < a.Length; i++)
                elementData[i] = a[i];
        }

        public void Add(T e) {
            if (elementData == null) return;
            elementCount += 1;
            if (elementCount > elementData.Length)
            {
                ReSize();
            }
            elementData[elementCount - 1] = e;
        }


        public void AddAll(T[] a) {
            for (int i = 0; i < a.Length; i++)
                this.Add(a[i]);

        }


        public void Clear()
        {
            Array.Clear(elementData);
            elementCount = 0;
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


        public bool IsEmpty() => elementCount == 0;


        public void Remove(object o)
        {
            /// Метод, удаляющий первое включение объекта о.


            T oConverter = (T)o;
            if (elementCount > 0)
                for (int i = 0; i < elementData.Length; i++)
                    if (elementData[i].Equals(o))
                    {
                        if (i == elementData.Length - 1)
                        {
                            elementCount -= 1; return;
                        }
                        for (int j = 0; j < elementData.Length - 1; j++)
                        {
                            if (j >= i)
                                elementData[j] = elementData[j + 1];
                        }
                        elementCount -= 1;
                        return;
                    }
        }

        public void RemoveAll(T[] a)
        {
            /// Метод, удаляющий все элементы из динамического массива,
            /// При условии, что этот элемент есть в передаваемом массиве.

            if (elementCount > 0)
            {
                foreach (T o in a)
                    for (int i = 0; i < elementData.Length; i++)
                    {
                        if (elementData[i].Equals(o))
                        {
                            if (i == elementData.Length - 1)
                            {
                                elementCount -= 1; return;
                            }
                            for (int j = 0; j < elementData.Length - 1; j++)
                            {
                                if (j >= i)
                                    elementData[j] = elementData[j + 1];
                            }
                            elementCount -= 1;

                        }
                    }
            }






        }


        public void RetainAll(T[] a)
        {
            /// Метод, который оставляет в дин. массиве элементы из а.



            if (elementCount > 0)
            {
                for (int i = 0; i < elementCount;)
                {
                    if (ElInArray(elementData[i]) == false)
                    {
                        if (i == elementCount - 1)
                            elementCount -= 1;
                        else
                        {
                            for (int index = i; index < elementCount; index++)
                            {
                                elementData[index] = elementData[index + 1];
                            }
                            elementCount -= 1;
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


        public int Size() => elementCount;

        public T[] ToArray()
        {
            /// Метод возвращает массив из элементов дин. массива.

            T[] arrayToReturn = new T[elementCount];
            for (int i = 0; i < elementCount; i++)
            {
                arrayToReturn[i] = elementData[i];
            }
            return arrayToReturn;
        }

        public T[] ToArray(T[] a = null)
        {
            /// Метод, который добавляет в массив а, все элементы из дин. массива.
            /// Если передаваемый массив пустой, то возвращает все элементы дин массива.

            if (a == null)
            {
                T[] Ret = new T[elementCount];
                for (int i = 0; i < elementCount; i++)
                    Ret[i] = elementData[i];
                return Ret;
            }


            T[] RetArray = new T[a.Length + elementCount];
            int index = 0;
            for (; index < a.Length; index++)
                RetArray[index] = a[index];

            for (int j = 0; j < elementCount; j++)
            {
                RetArray[index] = elementData[j];
                index += 1;
            }
            return RetArray;
        }


        public void Add(int index, T e0)
        {
            /// Добавление элемента по индексу.
            if (index > elementCount - 1 || index < 0)
                throw new IndexOutOfRangeException();

            if (elementCount + 1 > elementData.Length)
                ReSize();

            T saveIndex = elementData[index];
            elementData[index] = e0;
            for (int i = index + 1; i < elementData.Length; i++)
            {
                T saveEl = elementData[i];
                elementData[i] = saveIndex;
                saveIndex = saveEl;
            }
            ++elementCount;
        }

        public void Add(int index, T[] elt)
        {
            /// Вставка элементов массива, начиная с индекса.

            if (index > elementCount - 1 || index < 0)
                throw new IndexOutOfRangeException();

            while (elementCount + elt.Length > elementData.Length)
                ReSize();

            T[] newArray = new T[elementCount - index];
            for (int i = index, j = 0; j < elementCount - index; i++, j++)
                newArray[j] = elementData[i];
            int it = index;
            for (int j = 0; j < elt.Length; j++)
            {
                elementData[it] = elt[j];
                it++;
            }
            elementCount = elementCount + elt.Length;
            for (int k = 0; k < newArray.Length; it++, k++)

                elementData[it] = newArray[k];







        }



        public T get(int index)
        {
            if (index > elementCount - 1 || index < 0)
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
            for (int i = elementCount - 1; i >= 0; i--)
            {
                if (elementData[i].Equals(el))
                    return i;
            }
            return -1;
        }


        public T ReturnRemove(int index)
        {
            /// Метод удаляет элемент, и возвращает его значение пользователю.
            if (index > elementCount - 1 || index < 0)
                throw new IndexOutOfRangeException();

            if (index == elementCount - 1)
            {
                T retEl = elementData[elementCount - 1];
                elementCount -= 1;
                return retEl;
            }
            T el = elementData[index];
            for (int i = index; i < elementCount; i++)
                elementData[i] = elementData[i + 1];
            elementCount -= 1;


            return el;
        }


        public void Set(int index, T e)
        {
            /// Замена по индексу.

            if (index > elementCount - 1 || index < 0)
                throw new IndexOutOfRangeException();
            elementData[index] = e;
        }


        public T[] SubList(int fromindex, int toindex)
        {
            if (fromindex > toindex || fromindex < 0 || toindex >= elementCount)
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

        private void ReSize()
        {
            T[] newArray;
            if (capacityIncrement > 0)
                newArray = new T[capacityIncrement];
            else
                newArray = new T[elementCount * 2];
            for (int i = 0; i < elementData.Length; i++)
                newArray[i] = elementData[i];
            elementData = newArray;
        }


        public T firstElement()
        {
            if (elementCount == 0)
                throw new ArgumentOutOfRangeException();
            return elementData[0];
        }


        public T lastElement() {
            if (elementCount == 0)
                throw new ArgumentOutOfRangeException();
            return elementData[(elementCount - 1)];
        }


        public void RemoveElementAt(int position) {
            if (position > elementCount - 1 || position < 0)
                throw new IndexOutOfRangeException();
            if (position == elementCount - 1)
                elementCount--;

            for (int i = position; i < elementCount - 1; i++)
                elementData[i] = elementData[(i + 1)];
            elementCount--;
        }

        public void RemoveRange(int begin, int end)
        {
            if (begin < 0 || begin > end || end > elementCount)
                throw new ArgumentOutOfRangeException();

            for (int i = begin; i < end; i++)
            {
                for (int j = begin; j < elementCount - 1; j++)
                    elementData[j] = elementData[j + 1];
                elementCount--;
            }
        }


        public void Print()
        {
            /// Отладочный метод для просмотра элементов массива.

            if (elementData != null)
            {
                for (int i = 0; i < elementCount; i++)
                    Console.Write($"{elementData[i]} ");
            }
        }
    }







   
}
