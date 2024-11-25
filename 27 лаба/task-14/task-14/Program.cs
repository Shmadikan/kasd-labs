using System.Data.SqlTypes;
using System.Runtime.Intrinsics.X86;
using AllInterface;
namespace task_14
{
    internal class Program
    {
        public class MyArrayDeque<T> : MyList<T>, MyDeque<T> where T : IComparable
        {
            T[] elements;
            int head;
            int tail;


            public MyArrayDeque()
            {
                elements = new T[16];
                tail = -1;
                head = 0;
            }


            public MyArrayDeque(T[] a)
            {
                elements = new T[a.Length];
                for (int i = 0; i < a.Length; i++)
                    elements[i] = a[i];
                head = 0;
                tail = elements.Length - 1;
            }


            public MyArrayDeque(int cap)
            {
                elements = new T[cap];
                head = 0;
                tail = -1;
            }


            public void AddAll(int index, T[] el) {
                foreach (T t in el)
                    Add(index, t);

            }

            public T Get(int index) {
                if (index > tail)
                    throw new IndexOutOfRangeException();
                return elements[index];

            }

            public void Add(int index, T el) {
                if (index > tail - 1 || index < 0)
                    throw new IndexOutOfRangeException();

                if (tail + 1 > elements.Length)
                    ReSize();
                T saveElement = elements[index];
                elements[index] = el;
                for (int i = index + 1; i < tail; i++) {
                    T e = elements[i];
                    elements[i] = saveElement;
                    saveElement = e;
                }

            }

            public void Set(int index, T el) {
                if (index > tail || tail == -1)
                    throw new IndexOutOfRangeException();
                elements[index] = el;
            }

            public T[] SubList(int fromindex, int toindex){
                T[] a = new T[toindex - fromindex];
                int index = 0;
                for (int i = fromindex; i <= toindex; i++)
                {
                    a[index++] = elements[i];
                
                
                }
                return a;
                
            }

            public int IndexOf(object o) {
                if (tail == -1)
                    return -1;
                T el = (T)o;
                for (int i = 0; i < tail; i++)
                    if (elements[i].Equals(el))
                        return i;
                return -1;
            }

            public void Add(T value) {
                if (tail + 1 == elements.Length)
                {
                    T[] BiggerArray = new T[elements.Length * 2];
                    for (int i = 0; i <= tail; i++)
                        BiggerArray[i] = elements[i];
                    elements = BiggerArray;
                }
                elements[++tail] = value;
            }


            public void Clear()
            {
                tail = -1; head = 0;
                Array.Clear(elements);
            }


            public bool Contains(object o) {
                for (int i = 0; i <= tail; i++) 
                    if (elements[i].Equals(o))
                        return true;
                return false;
            }


            public bool ContainsAll(T[] a) {
                for (int i = 0; i <= tail; i++)
                    if (!Contains(a[i]))
                        return false;
                return true;
            }


            public bool IsEmpty() => tail == -1;


            public void Remove(object o) {
                for (int i = 0; i <= tail; i++) {
                    if (elements[i].Equals(o))
                    {
                        if (i == tail)
                        {
                            tail--;
                            return;
                        }
                        for (int j = i; j < tail; j++)
                            elements[j] = elements[j + 1];
                        tail--;
                        return;
                    }
                }
            
            }

            public int LastIndexOf(object o) { 
                
                   
                for (int i = tail; i >= 0; i--)
                    if (elements[i].Equals((T)o))
                        return i;
                return -1;
            
            
            }

            public T Remove(int index) {
                if (index > tail)
                    throw new ArgumentOutOfRangeException("index");
                T el = elements[index];
                if (index == tail || index == head)
                    tail--;
                else
                {
                    for (int i = index; i < tail; i++)
                    {
                        elements[i] = elements[i + 1];

                    }
                    tail--;
                }
                return el;
            
            }


            public void RemoveAll(T[] a) { 
                foreach (T t in a)
                        Remove(t);
            }

           
            public void RetainAll(T[] a) {
                for (int j = 0; j < elements.Length; j++)
                {
                    for (int i = 0; i <= tail; i++)
                    {
                        if (contains(elements[i]) == false)
                            Remove(elements[i]);
                    }
                }


                bool contains(T el) {
                    for (int i = 0; i < a.Length; i++)
                        if (el.Equals(a[i]))
                            return true;
                    return false;
                }
            }


            public int Size() { return tail + 1; }


            public T[] ToArray() {
                T[] RetArray = new T[tail + 1];
                for (int i = 0; i <= tail; i++) {
                    RetArray[i] = elements[i];
                }
                return RetArray;
            }


            public T[] ToArray(T[] a)
            {
                if (tail == -1)
                    throw new IndexOutOfRangeException();
                
                
                T[] RetArray = new T[a.Length + tail + 1];
                int i = 0;
                for (; i < a.Length; i++) {
                    RetArray[i] = a[i];
                }
                for (int j = 0; j <= tail; j++, i++) {
                    RetArray[i] = elements[j];
                
                }
                return RetArray;
            
            }


            public T Element() { 
                return elements[head];
            }


            public bool Offer(object b) {
                if (tail == elements.Length - 1)
                    return false;
                this.Add((T) b);
                return true;
            }


            public T? Peek() {
                if (tail == -1)
                    return default(T);
                return elements[head];
            }


            public T Pool() { 
                if (tail == -1)
                    return default(T);
                T el = elements[head];
                head++;
                return el;
            }


            public void AddFirst(T el) {
                if (tail + 1 == elements.Length)
                    ReSize();
                elements[tail + 1] = elements[tail];
                for (int i = tail; i >= 1; i--)
                {
                    elements[i] = elements[i - 1];
                    
                }
                elements[0] = el;
                tail++;
            }


            public void AddLast(T el)
            {
                this.Add(el);
            }


            public T GetFirst() {
                return elements[head];
                
            }

            public T GetLast() {
                return elements[tail];
            }


            public bool OfferFirst(T obj) {
                if (tail + 1 > elements.Length)
                    return false;
                Add(obj);
                return true;
            }


            public bool OfferLast(T obj)
            {
                if (tail + 1 > elements.Length)
                    return false;
                AddFirst(obj);
                return true;
            }


            public T Pop() { 
                T el = elements[head];
                for (int i = 0; i < tail; i++)
                    elements[i] = elements[i + 1];
                return el;
            }


            public void Push(T el) {
                AddFirst(el);
                
            }


            public T PeekFirst() {
                if (tail == -1)
                    return default(T);
                return elements[head];
            }


            public T PeekLast() {
                if (tail == -1)
                    return default(T);
                return elements[tail];
            }


            public T RemoveLast() {
                if (tail == -1)
                    throw new IndexOutOfRangeException();
                T el = elements[tail];
                tail--;
                return el;
            }


            public T RemoveFirst()
            {
                if (tail == -1)
                    throw new IndexOutOfRangeException();
                T el = elements[head];
                for (int i = 0; i < tail; i++)
                    elements[i] = elements[i + 1];
                return el;
            }


            public T PoolFirst() {
                T el = PeekFirst();
                RemoveFirst();
                return el;
            }


            public T PoolLast()
            {
                T el = PeekLast();
                RemoveLast();
                return el;
            }

            public bool RemoveLastOccurence(object obj) {
                T el = (T)obj;
                
                int? remIndex = null;
                for (int i = 0; i <= tail; i++) {
                    if (elements[i].Equals(el))
                        remIndex = i;
                }
                if (remIndex == null)
                    return false;
                if (remIndex == tail) {
                    tail--;
                    return true;
                }


                for (int j = (int) remIndex; j < tail; j++) {
                    elements[j] = elements[j + 1];
                
                }
                tail--;

                return true;
            }


            public bool RemoveFirstOccurence(object obj) {
                T el = (T)obj;
                for (int i = 0; i <= tail; i++)
                    if (el.Equals(elements[i])) {
                        if (i == tail) {
                            tail--;
                            return true;
                        }
                        for (int j = i; j < tail; j++)
                            elements[j] = elements[j + 1];
                        tail--;
                        return true;
                    }
                        
                return false;
            }


            public MyItr Iterator() { return new MyItr(this); }

            public class MyItr : MyIterator<T>
            {
                MyArrayDeque<T> copy;
                private T current = default(T);
                int size;
                int tail = 0;
                bool flagDel = false;
                internal MyItr(MyArrayDeque<T> Deq)
                {
                    copy = Deq;
                    size = Deq.Size();

                }


                public T Current { get => current; }

                public bool HasNext()
                {
                    if (tail >= copy.Size() || tail == -1)
                        return false;
                    return true;
                }

                public T Next()
                {
                    
                    current = copy.Get(tail);
                    tail++;
                    return current;
                }

                public void Remove()
                {
                    tail = copy.IndexOf(current);
                    copy.Remove(current);

                    flagDel = true;
                }
            }

            private void ReSize()
            {
                T[] values = new T[elements.Length * 2];
                for (int i = 0; i <= tail; i++)
                    values[i] = elements[i];
                elements = values;
            }


            public void Print() {
                for (int i = 0; i <= tail; i++)
                    Console.Write(elements[i].ToString()+ " ");
            }
        }


        static void Main(string[] args)
        {
            int[] a = {9, 1, 20, 3, 8, 7, 6, 5, 4, 3, 2, 1};
            int[] c = { 3, 5, 6 };
            MyArrayDeque<int> deque = new MyArrayDeque<int>(a);
            var iter = deque.Iterator();
            while (iter.HasNext()) {
                iter.Next();
                if (iter.Current == 1)
                    iter.Remove();
                else
                    Console.WriteLine(iter.Current);
            
            }
        }
    }
}