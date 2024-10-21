using System;
using System.Collections;
using System.ComponentModel.Design;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using Task_16;
namespace ConsoleApp1
{
    internal class Program
    {
        public class MyHashMap<K, T> {
           
            MyLinkedList<Tuple<K, T>>[] Entry;
            K s;
            
            BitArray chosen;
            int size;
            double loadFactor;
            public MyHashMap() { 
                Entry = new MyLinkedList<Tuple<K, T>>[16];
                chosen = new BitArray(16);
                size = 0;
                loadFactor = 0.75;
            }

            public MyHashMap(int cap)
            {
                Entry = new MyLinkedList<Tuple<K, T>>[cap]; 
                chosen = new BitArray(cap);
                size = 0;
                loadFactor = 0.75;
            }


            public MyHashMap(int cap, float load)
            {
                Entry = new MyLinkedList<Tuple<K, T>>[cap];
                size = 0;
                if (load > 1.0)
                    throw new Exception();
                loadFactor = load;
            }


            public T Get(K key) {
                var el = Entry[Math.Abs((key.GetHashCode()) % Entry.Length)];

                for (int i = 0; i < el.Size(); i++)
                {
                    Tuple<K, T> tup = el.Get(i);
                    if (tup.Item1.Equals(key))
                        return tup.Item2;
                }
                return default(T);
            }


            public void Clear() { 
                Array.Clear(Entry);
            }
            public bool ContainsKey(object Key) { 
                K key = (K)Key;
                if (Entry[Math.Abs((key.GetHashCode()) % Entry.Length)] == null)
                    return false;
                else
                {
                    MyLinkedList<Tuple<K, T>> list = Entry[Math.Abs((key.GetHashCode()) % Entry.Length)];
                    for (int i = 0; i < list.Size(); i++)
                    {
                        if (list.Get(i).Item1.Equals(key))
                            return true;
                    }
                }
                return false;
            }


            public bool IsEmpty() => size == 0;


            public K[] KeySet()
            {
                int s = size;
                K[] RetArray = new K[size];
                int index = 0;
                for (int i = 0; i < Entry.Length; i++) {
                    if (Entry[i] != null) {
                        var List = Entry[i];
                        for (int e = 0; e < List.Size(); e++)
                        {
                            RetArray[index] = List.Get(e).Item1;
                            index++;
                        }
                    }

                }
                return RetArray;
            }


            public bool ContainsValue(object Value) { 
                T el = (T)Value;
                for (int i = 0; i < Entry.Length; i++) {
                    if (Entry[i] != null) { 
                        var List = Entry[i];
                        for (int e = 0; e < List.Size(); e++) { 
                            if (List.Get(e).Item2.Equals(Value))
                                return true;
                        }
                    }
                
                }

                return false;
            }

            public void Put(K key, T value) {
                double count = (double)(size + 1) / (double)Entry.Length;
                if (count >= loadFactor) {
                    ReSize();
                }
                
                int index = Math.Abs(key.GetHashCode()) % Entry.Length;
                CheckPut(index, Entry, key, value);
            }


            public Tuple<K, T>[] EntrySet() {
                
                Tuple<K, T>[] retArray = new Tuple<K, T>[size];
                int index = 0;
                for (int i = 0; i < Entry.Length; i++) {
                    if (Entry[i] != null) {
                        var List = Entry[i];
                        for (int e = 0; e < List.Size(); e++)
                        {
                            
                            retArray[index] = List.Get(e);
                            
                            index ++;
                            
                        }
                    }
                }
                
                return retArray;
            }


            public void Remove(K key) {
                int index = Math.Abs(key.GetHashCode()) % Entry.Length;
                if (index > Entry.Length)
                    throw new IndexOutOfRangeException();

                if (Entry[index] != null) {
                    var List = Entry[index];
                    for (int e = 0; e < List.Size(); e++)
                    {
                        if (List.Get(e).Item1.Equals(key))
                        {
                            List.Remove(e);
                            size--;
                        }
                    }
                }
            }


            public int Size() => size;


            public void ReSize()
            {
                MyLinkedList<Tuple<K, T>>[] newArray = new MyLinkedList<Tuple<K, T>>[Entry.Length * 3];
                size = 0;
                for (int i = 0; i < Entry.Length; i++) {
                    if (Entry[i] != null) {
                        MyLinkedList<Tuple<K, T>> val = Entry[i];
                        while (val.Size() > 0) {
                             Tuple<K, T> pair = val.PollFirst();
                             int index = Math.Abs(pair.Item1.GetHashCode()) % newArray.Length;
                             CheckPut(index, newArray, pair.Item1, pair.Item2);
                        
                        }

                    }
                
                }
                Entry = newArray;   
            }







            void CheckPut(int index, MyLinkedList<Tuple<K,T>>[] Entry, K key, T value)
            {
                if (Entry[index] == null)
                {
                    Tuple<K, T> valToAdd = new Tuple<K, T>(key, value);
                    MyLinkedList<Tuple<K, T>> newKey = new MyLinkedList<Tuple<K, T>>();
                    newKey.Add(valToAdd);
                    Entry[index] = newKey;
                }
                else
                {
                    var Element = Entry[index];
                    K ListKey;
                    var s = Element.Size();
                    for (int i = 0; i < Element.Size(); i++)
                    {
                        ListKey = Element.Get(i).Item1;
                        if (ListKey.GetHashCode() == key.GetHashCode())
                        {
                            if (ListKey.Equals(key))
                            {
                                Element.Set(i, new Tuple<K, T>(ListKey, value));
                                return;
                            }
                        }
                    }
                    Element.AddLast(new Tuple<K, T>(key, value));

                }
                size += 1;
            }





        }


        static void Main(string[] args)
        {
            Random rand = new Random();
            MyHashMap<int, int> dict = new MyHashMap<int, int>();
            for (int i = 0; i < 100; i++) {
                dict.Put(i,rand.Next(1, 10000));
            }
            Console.WriteLine(dict.Size());
            for (int i = 0; i < 100; i++)
            
                Console.WriteLine(dict.Get(i));
            
        }
    }
}