namespace Task_16
{
    internal class Program
    {
        public class MyLinkedList<T> {
            LinkedListElement<T>? first;
            LinkedListElement<T>? last;
            int size;

            public MyLinkedList() {
                first = null;
                last = null;
                size = 0;
            }

            public MyLinkedList(T[] a) {
                first = new LinkedListElement<T>();
                last = new LinkedListElement<T>();
                first.Value = a[0];
                last = first;
                size++;
                for (int i = 1; i < a.Length; i++) {
                    Add(a[i]);

                }
            }

            public void Add(T el) {
                if (first == null) {
                    first = new LinkedListElement<T>();
                    first.Value = el;
                    last = first;
                    return;
                }
                LinkedListElement<T> newEl = new LinkedListElement<T>();
                newEl.Value = el;

                newEl.prev = last;
                last.next = newEl;

                last = newEl;

                size++;
            }


            public void AddAll(T[] a) {
                foreach (T el in a)
                    Add(el);

            }

            public T Get(int index) {
                int curIndex = 0;
                if (index >= size)
                    throw new IndexOutOfRangeException();
                if (index == size - 1)
                    return last.Value;
                if (index == 0)
                    return first.Value;
                LinkedListElement<T>? iterator = first;
                while (curIndex != index) {
                    iterator = iterator.next;
                    curIndex++;
                }
                return iterator.Value;
            }


            public void Clear() {
                first = null;
                last = first;
            }


            public bool Contains(object o)
            {
                LinkedListElement<T>? iterator = first;
                while (iterator != null) {
                    if (iterator.Value.Equals((T)o))
                        return true;
                    iterator = iterator.next;

                }
                return false;
            }


            public bool ContainsAll(T[] a) {
                foreach (T el in a) {
                    if (Contains(el) == false)
                        return false;

                }
                return true;

            }


            public bool IsEmpty() => size == 0;


            public void Remove(object o) {
                LinkedListElement<T>? iterator = first;
                if (first.Value.Equals((T)o))
                {
                    first = first.next;
                    return;
                }
                if (last.Value.Equals((T)o)) {
                    last = last.prev;
                    return;
                
                }


                while (iterator.next != null) {
                    if (iterator.next.Value.Equals((T)o))
                    {
                        iterator.next = iterator.next.next;
                    }
                    else
                        iterator = iterator.next;
                }

            
            }


            public void RemoveAll(T[] a) {
                foreach (T el in a)
                    Remove(el);
            }


            public void RetainAll(T[] a) {
                int index = 0;
                for (int i = 0; i < size; i++) {
                    T el = Get(index);
                    if (Contains(el) == false)
                    {
                        Remove(el);
                    }
                    else
                        index++;
                }
                bool Contains(T el) {
                    for (int i = 0; i < a.Length; i++)
                    {
                        if (el.Equals(a[i]))
                            return true;
                    }
                    return false;
                }
            
            
            }


            public int Size() => size;


            public T[] ToArray()
            {
                T[] retArray = new T[size];
                for (int i = 0; i < size; i++)
                    retArray[i] = Get(i);
                return retArray;
            }


            public T[] ToArray(T[]? a)
            {
                if (a == null)
                    return ToArray();


                T[] retArray = new T[size + a.Length];
                int index = 0;
                for (;index < a.Length; index++)
                    retArray[index] = a[index];
                for (int i = 0; i < size; i++) {
                    retArray[index] = Get(i);
                    index++;
                
                }
                return retArray;

            }


            public void Add(int index, T el) {
                if (index == 0) { 
                    LinkedListElement<T> iter = new LinkedListElement<T>();
                    iter.Value = el;
                    iter.next = first;
                    first.prev = iter;
                    first = iter;
                    return;
                }
                if (index == size - 1) {
                    LinkedListElement<T> iter = new LinkedListElement<T>();
                    iter.Value = el;
                    iter.prev = last;
                    last.next = iter;
                    last = iter;
                    return;
                }
                int current = 0;
                LinkedListElement<T> iters = new LinkedListElement<T>();
                iters = first;
                while (current + 1 != index) {
                    iters = iters.next; current++;
                }
                if (current + 1 == index) {
                    LinkedListElement<T> nextEl = new LinkedListElement<T>();
                    nextEl.Value = el;
                    nextEl.prev = iters;
                    nextEl.next = iters.next;
                    
                    iters.next.prev = nextEl;
                    iters.next = nextEl;
                }
            }


            public void AddAll(int index, T[] a) {
                for (int i = a.Length - 1; i >= 0; i--) {
                    Add(index, a[i]);
                
                }
            
            
            }


            public int IndexOf(object o) { 
                T el = (T)o;
                int index = 0;
                

                LinkedListElement<T> iter = new LinkedListElement<T>();
                iter = first;
                while (iter != null) { 
                    if (iter.Value.Equals(el))
                        return index;
                    iter = iter.next;
                    index++;
                }
                return -1;
            }


            public int LastIndexOf(object o)
            {
                T el = (T)o;
                int index = size - 1;


                LinkedListElement<T> iter = new LinkedListElement<T>();
                iter = last;
                while (iter != null)
                {
                    if (iter.Value.Equals(el))
                        return index;
                    iter = iter.prev;
                    index--;
                }
                return -1;


            }


            public T Remove(int index) {
                int currentIndex = 0;
                if (index == 0)
                {
                    T el = first.Value;
                    first.next.prev = null;
                    first = first.next;
                    
                    return el;
                }


                if (index == size - 1)
                {
                    T el = last.Value;
                    last = last.prev;
                    return el;
                }


                LinkedListElement<T> iter = new LinkedListElement<T>();
                iter = first;
                while (currentIndex + 1 != index) {
                    iter = iter.next;
                    currentIndex++;
                
                
                }
                if (currentIndex + 1 == index) {
                    iter = iter.next;
                    iter.next.prev = iter.prev;
                    iter.prev.next = iter.next;
                }

                return default(T);
            }

            public void Print() {
                LinkedListElement<T>? iterator = first;
                while (iterator != null)
                {
                    Console.WriteLine($"{iterator.Value}");
                    iterator = iterator.next;
                
                }
            }

            


            class LinkedListElement<T> {
                public LinkedListElement<T>? next = null;
                public LinkedListElement<T>? prev = null;
                public T Value;
            }
        }


        static void Main(string[] args)
        {
            int[] a = { 1, 2, 5, 2};
            int[] b = { 3, 4, 5 };
            int[] c = {100,500};

            MyLinkedList<int> list = new MyLinkedList<int>(a);
            //list.Print();
            list.AddAll(b);
            list.Print();
            Console.WriteLine();
            Console.Write(list.Remove(0));
            Console.WriteLine();
            list.Print();
            //Console.WriteLine(list.ContainsAll(c));
            //           Console.WriteLine(list.Get(2));
        }
    }
}
