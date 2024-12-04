using ConsoleApp2;
using System.ComponentModel;
using System.Drawing;
using AllInterface;
using System.Runtime.CompilerServices;

namespace ConsoleApp2
{
    public class MyVector<T>:MyList<T>
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
            elementCount = 0;
            capacityIncrement = 0;
            elementData = new T[initialCapacity];
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

        public T this[int index] {
            get => Get(index);
        
        }
        public void AddAll(MyCollection<T> a) {
            var iter = a.Iterator();
            while (iter.HasNext())
                Add(iter.Next());
            

        }

        public void AddAll(int index, MyCollection<T> a)
        {
            var iter = a.Iterator();
            while (iter.HasNext())
                Add(index,iter.Next());
            

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

        public bool ContainsAll(MyCollection<T> a)
        {
            /// Метод, проверяющий наличие всех элементов
            /// Из передаваемого массива в динамическом.


            var iter = a.Iterator();
            while (iter.HasNext())
            {
                T e = iter.Next();


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

        public void RemoveAll(MyCollection<T> a)
        {
            /// Метод, удаляющий все элементы из динамического массива,
            /// При условии, что этот элемент есть в передаваемом массиве.

            if (elementCount > 0)
            {
                var iter = a.Iterator();
                while (iter.HasNext())
                {
                    T o = iter.Next();

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






        }


        public void RetainAll(MyCollection<T> a)
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
                var iter = a.Iterator();
                while (iter.HasNext())
                    if (iter.Next().Equals(el))
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



        public T Get(int index)
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


        public int LastIndexOf(object o)
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


        public T Remove(int index)
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


        public MyIterator<T> Iterator() => new MyItr(this);

        public AnotherMyIterator<T> ListIterator() => new MyItr(this);
        public MyItr IndexIterator(int index) => new MyItr(this, index);
        public class MyItr : AnotherMyIterator<T>
        {

            MyVector<T> copy;
            T currentElement;
            int index = -1;
            bool delete = false;


            public T Current { get {
                    if (index == -1 && !delete)
                        return default(T);
                    return currentElement;
                } 
            }
            internal MyItr(MyVector<T> Orig, int index = -1) {

                copy = Orig;
                this.index = index;
            }


            public void Add(T element)
            {
                if (copy.Size() + 1 == copy.elementCount)
                    copy.ReSize();
                if (index + 1 == copy.Size())
                {
                    copy.elementData[++index] = element;
                    return;
                }
                T rel = copy.elementData[index + 1];
                copy.elementData[index + 1] = rel;
                for (int i = index + 2; i < copy.Size(); i++) {
                    T el = copy.elementData[i];
                    copy.elementData[i] = rel;
                    rel = el;
                }

            }

            public bool HasNext()
            {
                if (index + 1 == copy.Size())
                {
                    currentElement = default(T);
                    return false;
                }
                return true;
            }

            public bool HasPrevious()
            {
                if (index > 0)
                    return true;
                return false;
                
            }

            public T Next()
            {
                currentElement = copy.elementData[++index];
                return currentElement;
            }

            public int NextIndex()
            {
                return index + 1;
                
            }

            public T Previous()
            {
                if (index > 0 && index != -1) { 
                    return currentElement = copy.elementData[--index];
                
                }
                throw new Exception();    
            }

            public int PreviousIndex()
            {
                return index - 1;
            }

            public void Remove()
            {
                if (copy.Contains(currentElement))
                {
                    copy.Remove(currentElement);
                    index--;
                    delete = true;
                }
            }

            public void Set(T element)
            {
                copy.elementData[index] = element;
            }
        }


        
        
    }

    





   
}
