using AllInterface;
namespace Task_16
{
    internal class Program
    {
        public class MyLinkedList<T> : MyList<T> where T : IComparable
        {
            LinkedListElement<T>? first;
            LinkedListElement<T>? last;
            int size;

            public MyLinkedList()
            {
                first = null;
                last = null;
                size = 0;
            }

            public MyLinkedList(MyCollection<T> a)
            {
                first = new LinkedListElement<T>();
                last = new LinkedListElement<T>();
                var iter = a.Iterator();
                first.Value = iter.Next();
                last = first;
                size++;
                while (iter.HasNext())
                    Add(iter.Next());
                
            }

            public void Add(T el)
            {
                if (first == null)
                {
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


            public void AddAll(MyCollection<T> a)
            {
                var iter = a.Iterator();
                while (iter.HasNext()) { 
                    T el = iter.Next();
                    Add(el);
                }
            }

            public T Get(int index)
            {
                int curIndex = 0;
                if (index >= size)
                    throw new IndexOutOfRangeException();
                if (index == size - 1)
                    return last.Value;
                if (index == 0)
                    return first.Value;
                LinkedListElement<T>? iterator = first;
                while (curIndex != index)
                {
                    iterator = iterator.next;
                    curIndex++;
                }
                return iterator.Value;
            }


            public void Clear()
            {
                first = null;
                last = first;
            }


            public bool Contains(object o)
            {
                LinkedListElement<T>? iterator = first;
                while (iterator != null)
                {
                    if (iterator.Value.Equals((T)o))
                        return true;
                    iterator = iterator.next;

                }
                return false;
            }


            public bool ContainsAll(MyCollection<T> a)
            {
                var iter = a.Iterator();
                while (iter.HasNext())
                {
                    T el = iter.Next();
                    if (Contains(el) == false)
                        return false;
                }
                return true;
                

            }


            public bool IsEmpty() => size == 0;


            public void Remove(object o)
            {
                LinkedListElement<T>? iterator = first;
                if (first.Value.Equals((T)o))
                {
                    first = first.next;
                    return;
                }
                if (last.Value.Equals((T)o))
                {
                    last = last.prev;
                    return;

                }


                while (iterator.next != null)
                {
                    if (iterator.next.Value.Equals((T)o))
                    {
                        iterator.next = iterator.next.next;
                    }
                    else
                        iterator = iterator.next;
                }


            }


            public void RemoveAll(MyCollection<T> a)
            {
                var iter = a.Iterator();
                while (iter.HasNext())
                {
                    T el = iter.Next();
                    Remove(el);
                }
            }


            public void RetainAll(MyCollection<T> a)
            {
                int index = 0;
                for (int i = 0; i < size; i++)
                {
                    T el = Get(index);
                    if (Contains(el) == false)
                    {
                        Remove(el);
                    }
                    else
                        index++;
                }
                bool Contains(T el)
                {
                    var iter = a.Iterator();
                    while (iter.HasNext())
                    {
                        if (el.Equals(iter.Next()))
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
                for (; index < a.Length; index++)
                    retArray[index] = a[index];
                for (int i = 0; i < size; i++)
                {
                    retArray[index] = Get(i);
                    index++;

                }
                return retArray;

            }


            public void Add(int index, T el)
            {
                if (index == 0)
                {
                    LinkedListElement<T> iter = new LinkedListElement<T>();
                    iter.Value = el;
                    iter.next = first;
                    first.prev = iter;
                    first = iter;
                    return;
                }
                if (index == size - 1)
                {
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
                while (current + 1 != index)
                {
                    iters = iters.next; current++;
                }
                if (current + 1 == index)
                {
                    LinkedListElement<T> nextEl = new LinkedListElement<T>();
                    nextEl.Value = el;
                    nextEl.prev = iters;
                    nextEl.next = iters.next;

                    iters.next.prev = nextEl;
                    iters.next = nextEl;
                }
            }


            public void AddAll(int index, MyCollection<T> a)
            {
                var iter = a.Iterator();
                
                while (iter.HasNext())
                {
                    T el = iter.Next();
                    Add(index,el);
                }
                


            }


            public int IndexOf(object o)
            {
                T el = (T)o;
                int index = 0;


                LinkedListElement<T> iter = new LinkedListElement<T>();
                iter = first;
                while (iter != null)
                {
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


            public T Remove(int index)
            {
                if (index >= size)
                    throw new IndexOutOfRangeException();
                int currentIndex = 0;
                if (index == 0)
                {
                    T el = first.Value;

                    first = first.next;
                    first.prev = null;
                    size -= 1;
                    return el;
                }


                if (index == size - 1)
                {
                    T el = last.Value;
                    last = last.prev;
                    last.next = null;
                    size -= 1;
                    return el;
                }


                LinkedListElement<T> iter = new LinkedListElement<T>();
                iter = first;
                while (currentIndex != index)
                {
                    iter = iter.next;
                    currentIndex++;
                }
                if (currentIndex == index)
                {
                    iter.prev.next = iter.next;
                    iter.next.prev = iter.prev;
                    size -= 1;
                    return iter.Value;
                }

                return default(T);
            }


            public void Set(int index, T e)
            {
                if (index >= size)
                    throw new IndexOutOfRangeException();
                if (index == 0)
                {
                    first.Value = e;
                    return;
                }
                if (index == size - 1)
                {
                    last.Value = e;
                    return;
                }
                int id = 0;
                LinkedListElement<T> iter = new LinkedListElement<T>();
                iter = first;
                while (id != index)
                {
                    iter = iter.next;
                    id++;
                }
                iter.Value = e;
            }


            public T[] SubList(int fromindex, int toindex)
            {
                if (fromindex > toindex || fromindex < 0 || toindex >= size)
                    throw new IndexOutOfRangeException();
                T[] RetArray = new T[toindex - fromindex + 1];
                int currentIndex = 0;
                LinkedListElement<T> iter = new LinkedListElement<T>();
                iter = first;
                while (currentIndex != fromindex)
                {
                    iter = iter.next;
                    currentIndex++;
                }
                int retIndex = 0;
                while (currentIndex <= toindex)
                {
                    RetArray[retIndex] = iter.Value;
                    retIndex++;
                    currentIndex++;
                    iter = iter.next;
                }
                return RetArray;
            }


            public T Element()
            {
                if (first == null)
                    throw new IndexOutOfRangeException();
                return first.Value;
            }




            public void Print()
            {
                LinkedListElement<T>? iterator = first;
                while (iterator != null)
                {
                    Console.WriteLine($"{iterator.Value}");
                    iterator = iterator.next;

                }
            }


            public T Peek()
            {
                if (first == null)
                    return default(T);
                return first.Value;
            }


            public void AddFirst(T el)
            {
                Add(0, el);
            }

            public void AddLast(T el)
            {
                Add(size - 1, el);
            }
            public T Pool()
            {
                if (first == null)
                    throw new IndexOutOfRangeException();
                T el = first.Value;
                first = first.next;
                first.prev = null;
                size -= 1;
                return el;
            }

            public T GetFirst()
            {
                if (first == null)
                    throw new IndexOutOfRangeException();
                return first.Value;

            }


            public T GetLast()
            {
                if (last == null)
                    throw new IndexOutOfRangeException();
                return last.Value;

            }

            public bool OfferFirst(T obj)
            {

                LinkedListElement<T>? iterator = new LinkedListElement<T>();
                iterator.Value = obj;
                iterator.next = first;
                iterator.prev = null;
                first.prev = iterator;
                first = iterator;
                return true;
            }


            public bool OfferLast(T obj)
            {

                LinkedListElement<T>? iterator = new LinkedListElement<T>();
                iterator.Value = obj;
                iterator.next = null;
                iterator.prev = last;
                last.next = iterator;
                last = iterator;
                return true;
            }


            public void Push(T obj)
            {
                AddFirst(obj);
            }


            public T PeekFirst()
            {
                if (size == 0)
                    return default(T);
                return first.Value;

            }


            public T PeekLast()
            {
                if (size == 0)
                    return default(T);
                return first.Value;
            }


            public T PollFirst()
            {
                if (size == 1)
                {
                    first = null;
                    last = null;
                    size = 0;
                }
                if (size == 0)
                    return default(T);
                T el = first.Value;
                first = first.next;
                first.prev = null;
                size--;
                return el;
            }


            public T PollLast()
            {
                if (size == 1)
                {
                    first = null;
                    last = null;
                    size = 0;
                }
                if (size == 0)
                    return default(T);
                T el = last.Value;
                last = last.prev;
                last.next = null;
                size--;
                return el;
            }

            public T Pop()
            {
                if (size == 1)
                {
                    first = null;
                    size = 0;
                }
                if (first == null)
                    throw new IndexOutOfRangeException();
                T el = first.Value;

                first = first.next;
                first.prev = null;
                size -= 1;
                return el;
            }


            public T RemoveLast()
            {
                T el = last.Value;
                last = last.prev;
                last.next = null; size--;
                return el;
            }


            public T RemoveFirst()
            {
                if (size == 1)
                {
                    first = null;
                    size = 0;
                }
                T el = first.Value;
                first = first.next;
                last.prev = null; size--;
                return el;
            }


            public bool RemoveLastOccurence(object obj)
            {
                T el = (T)obj;
                if (size == 1 && first.Value.Equals(el))
                {
                    first = null;
                    size--;
                    return true;
                }
                if (last.Value.Equals(el))
                {
                    last = last.prev;
                    last.next = null;
                    size--;
                    return true;
                }

                LinkedListElement<T>? iterator = last;
                while (iterator != null)
                {
                    if (iterator.Value.Equals(el))
                    {
                        if (iterator != first)
                        {
                            iterator.prev.next = iterator.next;
                            iterator.next.prev = iterator.prev;

                        }
                        else
                        {
                            first = first.next;
                            first.prev = null;
                        }
                        size--;
                        return true;
                    }
                    iterator = iterator.prev;

                }
                return false;
            }


            public bool RemoveFirstOccurence(object obj)
            {
                if (size == 1 && first.Value.Equals((T)obj))
                {
                    size--; return true;
                }
                if (first.Value.Equals(obj))
                {
                    first = first.next;
                    first.prev = null;
                    return true;
                }
                T el = (T)obj;
                LinkedListElement<T>? iterator = first;
                while (iterator != null)
                {
                    if (iterator.Value.Equals(el))
                    {
                        if (iterator != last)
                        {
                            iterator.prev.next = iterator.next;
                            iterator.next.prev = iterator.prev;

                        }
                        else
                        {
                            last = last.prev;
                            last.next = null;
                        }
                        size--;
                        return true;
                    }
                    iterator = iterator.next;

                }
                return false;



            }

            class LinkedListElement<T>
            {
                public LinkedListElement<T>? next = null;
                public LinkedListElement<T>? prev = null;
                public T Value;
            }


            public MyIterator<T> Iterator() => new MyItr(this);

            public AnotherMyIterator<T> ListIterator() => new MyItr(this);
            public MyItr IndexIterator(int index) => new MyItr(this, index);

            public class MyItr : AnotherMyIterator<T>
            {
                T retElement;
                int index = 0;
                LinkedListElement<T> element = null;
                MyLinkedList<T> Copy;
                MyLinkedList<T> nil;
                public T Current
                {
                    get
                    {

                        return retElement;




                    }


                }
                internal MyItr(MyLinkedList<T> Copy, int index = 0)
                {
                    this.Copy = Copy;
                    this.index = index;
                    if (index != 0)
                    {
                        element = Copy.first;
                        for (int i = 0; i < index; i++)
                        {
                            element = element.next;

                        }
                    }

                }



                public void Add(T element)
                {
                    LinkedListElement<T> newEl = new LinkedListElement<T>();
                    newEl.Value = element;
                    LinkedListElement<T> NextEl = this.element.next;
                    this.element.next = newEl;
                    NextEl.prev = newEl;
                    newEl.next = NextEl;
                    newEl.prev = this.element;
                    Copy.size++;

                }

                public bool HasNext()
                {
                    if (element == null && index == 0 && Copy.size > 0)
                        return true;
                    if (element == null && index == 0 && Copy.size == 0)
                        return false;
                    if (element.next == null)
                        return false;
                    return true;
                }

                public bool HasPrevious()
                {
                    if (element != null && element.prev == null)
                        return false;
                    return true;

                }

                public T Next()
                {
                    if (element == null && Copy.size > 0)
                    {
                        element = Copy.first;
                        retElement = element.Value;
                        return element.Value;

                    }

                    element = element.next;
                    retElement = element.Value;
                    index++;
                    if (element == null)
                        return Current;
                    return element.Value;
                }

                public int NextIndex()
                {
                    return index + 1;
                }

                public T Previous()
                {
                    if (element.prev != null)
                        element = element.prev;
                    index--;
                    return element.Value;
                    throw new NotImplementedException();
                }

                public int PreviousIndex()
                {
                    return index - 1;
                    throw new NotImplementedException();
                }

                public void Remove()
                {
                    if (element == null)
                        return;
                    LinkedListElement<T> NextEl = element.next;
                    LinkedListElement<T> PrevEl = element.prev;
                    if (NextEl != null && PrevEl != null)
                    {
                        NextEl.prev = PrevEl;
                        PrevEl.next = NextEl;

                    }
                    else if (NextEl == null && PrevEl != null)
                        PrevEl.next = null;

                    else if (NextEl != null && PrevEl == null)
                        NextEl.prev = null;

                    else if (NextEl == null && PrevEl == null)
                    {
                        retElement = element.Value;
                        element = null;


                    }
                    Copy.size--;
                    if (index != 0)
                        index--;
                }

                public void Set(T element)
                {
                    this.element.Value = element;


                }
            }
        }


        static void Main(string[] args)
        {
            int[] a = { 1, 2, 5, 2, 3, 4, 5 };
            MyLinkedList<int> lst = new MyLinkedList<int>();
            lst.Add(5);
            MyLinkedList<int> list = new MyLinkedList<int>(lst);
            var iter = list.Iterator();
            while (iter.HasNext())
            {
                iter.Next();
                

                Console.WriteLine(iter.Current.ToString());
            }
            var iter2 = list.Iterator();
            while (iter2.HasNext())
            {
                iter2.Next();


                Console.WriteLine(iter2.Current.ToString());
            }
            //Console.WriteLine(list.ContainsAll(c));
            //           Console.WriteLine(list.Get(2));
        }
    }
}