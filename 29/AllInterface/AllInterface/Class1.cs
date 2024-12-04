using System.Collections;
using System.Runtime.CompilerServices;

namespace AllInterface
{
    public class MyCollectionException : Exception {

        public MyCollectionException(string message)
            :base(message) { }

        public void Ds() { }
    
    
    
    
    
    }
    public class IndexException : MyCollectionException
    {
        public IndexException(string message, int val) : base(message)
        {
        }
    }

    

    public interface MyCollection<T>
    {
        void Add(T item);
        
        void Clear();
        bool Contains(object o);
        bool ContainsAll(MyCollection<T> a);
        bool IsEmpty();
        void Remove(object o);
        void RemoveAll(MyCollection<T> a);
        void RetainAll(MyCollection<T> a);
        int Size();
        T[] ToArray();
        T[] ToArray(T[] a);

        MyIterator<T> Iterator();
        AnotherMyIterator<T>? ListIterator();
    }


    public interface MyList<T> : MyCollection<T>{
        void Add(int index, T e);
        void AddAll(int index, MyCollection<T> e);

        T Get(int index);
        int IndexOf(object o);
        int LastIndexOf(object o);
        void Set(int index, T e);
        T Remove(int index);

        T[] SubList(int fromIndex, int ToIndex);
    }


    public interface MyQueue<T> : MyCollection<T> where T : IComparable {
        T Element();
        bool Offer(T obj);

        T Peek();

        T Pool();
    
    }

    public interface MyDeque<T> : MyCollection<T> where T : IComparable {
        void AddFirst(T el);
        void AddLast(T el);
        T GetFirst();

        T GetLast();
        bool OfferFirst(T el);
        bool OfferLast(T el);
        T Pop();
        void Push(T el);
        T PeekFirst();
        T PeekLast();
        T PoolFirst();
        T PoolLast();

        T RemoveLast();

        T RemoveFirst();

        bool RemoveLastOccurence(object obj);


        bool RemoveFirstOccurence(object obj);
    }


    public interface MySet<T>:MyCollection<T> where T:IComparable
    {
        T First();
        T Last();

        MySet<T> SubSet(T fromElement, T Toelement);
        MySet<T> HeadSet(T fromElement);
        MySet<T> TailSet(T ToElement);


    }


    public interface MySortedSet<T> : MyCollection<T> where T : IComparable {

        MySortedSet<T> SubSet(T from, T To, bool incl, bool another);
        MySortedSet<T> HeadSet(T from, bool incl);
        MySortedSet<T> TailSet(T LowerBound, bool incl);

        T LowerEntry(T key);
        T FloorEntry(T key);
        T HigherEntry(T key);
        T CeilingEntry(T key);
        T LowerKey(T key);
        T FloorKey(T key);
        T HigherKey(T key);
        T CeilingKey(T key);

        T PollFirstEntry();
        T PollLastEntry();
        T FirstEntry();
        T LastEntry();
    }


    public interface MyMap<K,T> where T:IComparable {
        void Clear();
        bool ContainsKey(object value);
        Tuple<K, T>[] EntrySet();
        T Get(object Key);
        bool IsEmpty();
        K[] KeySet();
        void Put(K key, T value);
        void Remove(K key);
        int Size();

        void PutAll(MyMap<K, T> map);
        MyCollection<T> Values();
    
    }


    public interface MySortedMap<K, T>:MyMap<K,T> where T:IComparable
    {
        K FirstKey();
        K LastKey();
        MySortedMap<K, T> HeadMap(K end);
        MySortedMap<K, T> SubMap(K end, K start);
        MySortedMap<K, T> TailMap(K start);

        Tuple<K, T> LowerEntry(K key);
        Tuple<K, T> FloorEntry(K key);
        Tuple<K, T> HigherEntry(K key);
        Tuple<K, T> CeilingEntry(K key);
        K LowerKey(K key);
        K FloorKey(K key);
        K HigherKey(K key);
        K CeilingKey(K key);

        Tuple<K, T> PollFirstEntry();
        Tuple<K, T> PollLastEntry();
        Tuple<K, T> FirstEntry();
        Tuple<K, T> LastEntry();
    }


    public interface MyIterator<T> {
        bool HasNext();

        T Next();
        T Current { get; }
        void Remove();
    
    }


    public interface AnotherMyIterator<T>: MyIterator<T> {
        
        bool HasPrevious();
        T Previous();
        int NextIndex();
        int PreviousIndex();
        
        void Set(T element);

        void Add(T element);
    
    }

   
}