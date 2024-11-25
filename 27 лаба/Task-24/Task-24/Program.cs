using System.Collections;
using AllInterface;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;

namespace Task_24
{
    public class MyComparator<T> : Comparer<T> where T : IComparable
    {
        public override int Compare(T? x, T? y)
        {
            return x.CompareTo(y);
            throw new NotImplementedException();

        }
    }


    public class MyReverseComparator<T> : Comparer<T> where T : IComparable
    {
        public override int Compare(T? x, T? y)
        {
            return x.CompareTo(y) * (-1);
            throw new NotImplementedException();

        }
    }


    public class MyTreeSet<K>:MySortedSet<K>, IEnumerable where K : IComparable
    {
        IComparer comparer = new MyComparator<K>();

        private protected TreeElement root = null;
        private TreeElement nil = new TreeElement();

        private int size;

        public MyTreeSet()
        {


            size = 0;
        }


        public MyTreeSet(IComparer comp)
        {
            comparer = comp;
        }

        public MyTreeSet(K[] a)
        {
            foreach (var el in a)
                Add(el);

        }


        public MyTreeSet(SortedSet<K> a)
        {
            foreach (var el in a)
                Add(el);
        }


        public void AddAll(K[] a)
        {
            foreach (var el in a)
                Add(el);
        }


        public void Clear()
        {
            root = null;
            size = 0;

        }

        public bool Contains(object o)
        {
            
            TreeElement copy = root;
            while (copy != nil)
            {
                if (comparer.Compare((K)o, copy.Key) < 0)
                    copy = copy.left;
                else if (comparer.Compare((K)o, copy.Key) > 0)
                    copy = copy.right;
                else if (comparer.Compare((K)o, copy.Key) == 0)
                    return true;
            }
            return false;
        }



        public bool IsEmpty() => size == 0;


        public void RemoveAll(K[] a)
        {
            foreach (var el in a)
                Remove(el);
        }


        public void RetainAll(K[] a)
        {
            K[] array = new K[size];
            int index = 0;
            foreach (K key in BFS())
            {

                array[index++] = key;
            }

            foreach (K key in array)
            {
                if (!a.Contains<K>(key))
                    Remove(key);
            }



        }


        public bool ContainsAll(K[] a)
        {
            foreach (var el in a)
            {
                if (!Contains(el))
                    return false;

            }
            return true;

        }



        public int Size() => size;


        public K[] ToArray()
        {
            K[] array = new K[size];
            int index = 0;
            foreach (K key in BFS())
            {

                array[index++] = key;
            }
            return array;
        }


        public K[] ToArray(K[] a)
        {
            K[] array;
            int index = 0;
            if (a == null)
            {
                array = new K[size];
            }
            else
            {
                array = new K[size + a.Length];
                for (int i = 0; i < a.Length; i++)
                    array[index++] = a[i];
            }

            foreach (K key in BFS())
            {

                array[index++] = key;
            }
            return array;
        }



        public K FirstEntry()
        {
            TreeElement copy = root;
            while (copy.left != nil)
                copy = copy.left;
            return copy.Key;

        }


        public K LastEntry()
        {
            TreeElement copy = root;
            while (copy.right != nil)
                copy = copy.right;
            return copy.Key;

        }



        public K LowerEntry(K key) {
            return LowerKey(key);
        
        }

        public K FloorEntry(K key)
        {
            return FloorKey(key);

        }

        public K CeilingEntry(K key)
        {
            return CeilingKey(key);

        }


        public K HigherEntry(K key)
        {
            return HigherKey(key);

        }

        public MyTreeSet<K> SubSet(K FromElement, K ToElement)
        {
            MyTreeSet<K> Sub = new MyTreeSet<K>();
            foreach (K el in BFS())
                if (el.CompareTo(FromElement) >= 0 && el.CompareTo(ToElement) <= 0)
                    Sub.Add(el);

            return Sub;
        }


        public MyTreeSet<K> HeadSet(K ToElement)
        {
            MyTreeSet<K> Sub = new MyTreeSet<K>();
            foreach (K el in OrdesrPrint()) {
                if (el.CompareTo(ToElement) <= 0)
                    Sub.Add(el);
            
            }
            return Sub;
        }


        public MyTreeSet<K> TailSet(K FromElement)
        {
            MyTreeSet<K> Sub = new MyTreeSet<K>();
            foreach (K el in OrdesrPrint())
            {
                if (el.CompareTo(FromElement) >= 0)
                    Sub.Add(el);

            }
            return Sub;
        }


        public K CeilingKey(K obj) {
            foreach (K el in OrdesrPrint()) {
                if (el.CompareTo(obj) >= 0)
                    return el;
            }
            return default(K);
        }

        public K FloorKey(K obj) {
            foreach (K el in OrdesrPrint())
            {
                if (el.CompareTo(obj) <= 0)
                    return el;
            }
            return default(K);

        }


        public K HigherKey(K obj)
        {
            foreach (K el in OrdesrPrint())
            {
                if (el.CompareTo(obj) > 0)
                    return el;
            }
            return default(K);
        }


        public K LowerKey(K obj)
        {
            foreach (K el in OrdesrPrint())
            {
                if (el.CompareTo(obj) < 0)
                    return el;
            }
            return default(K);

        }



        public K PollLastEntry() {
            if (size == 0)
                return default(K);

            TreeElement copy = root;
            while (copy.right != nil)
                copy = copy.right;
            Remove(copy.Key);
            return copy.Key;
        }


        public K PollFirstEntry()
        {
            if (size == 0)
                return default(K);

            TreeElement copy = root;
            while (copy.left != nil)
                copy = copy.left;
            Remove(copy.Key);
            return copy.Key;
        }





        



        public virtual void Add(K key)
        {
            if (root == null)
            {

                root = new TreeElement();
                root.Key = key;

                root.color = Color.Black;
                root.left = nil;
                root.right = nil;

                size++;
                return;
            }
            TreeElement el = new TreeElement();
            el.Key = key;

            while (root.prev != null)
                root = root.prev;
            TreeAdd(root, el);
            while (root.prev != null)
                root = root.prev;



            void TreeAdd(TreeElement root, TreeElement AddVal)
            {
                int result = comparer.Compare(AddVal.Key, root.Key);
                while (true)
                {
                    if (comparer.Compare(AddVal.Key, root.Key) < 0)
                    {
                        if (root.left == nil)
                        {
                            AddVal.prev = root;
                            root.left = AddVal;
                            AddVal.color = Color.Red;
                            AddVal.right = nil;
                            AddVal.left = nil;
                            BalanceTree(AddVal);
                            size++;
                            break;

                        }
                        else root = root.left;
                    }
                    else if (comparer.Compare(AddVal.Key, root.Key) > 0)
                    {
                        if (root.right == nil)
                        {
                            AddVal.prev = root;
                            root.right = AddVal;
                            AddVal.color = Color.Red;
                            AddVal.right = nil;
                            AddVal.left = nil;
                            BalanceTree(AddVal);
                            size++;
                            break;

                        }
                        else root = root.right;
                    }
                    else if (root.Key.Equals(AddVal.Key))
                    {
                        root.Key = AddVal.Key;
                        return;
                    }
                }
            }
        }




        public virtual void Remove(object AddVal)
        {
            
            while (root.prev != null)
                root = root.prev;
            TreeElement copy = root;
            while (true)
            {
                if (comparer.Compare((K)AddVal, copy.Key) < 0)
                {
                    if (copy.left == nil)
                    {
                        return;

                    }
                    else copy = copy.left;
                }
                else if (comparer.Compare((K)AddVal, copy.Key) > 0)
                {
                    if (copy.right == nil)
                    {
                        return;

                    }
                    else copy = copy.right;
                }
                else if (copy.Key.Equals((K)AddVal))
                {
                    Delete(copy);
                    size--;
                    while (root.prev != null)
                        root = root.prev;
                    break;
                }
            }





        }
        private void Delete(TreeElement NodeDel)
        {
            if (NodeDel == null)
                return;
            if (size == 1)
            {
                root = null;

                return;
            }
            TreeElement Parent = NodeDel.prev;
            if (NodeDel.color == Color.Red && NodeDel.right == nil && NodeDel.left == nil)
            {
                if (Parent.left == NodeDel)
                    Parent.left = nil;
                else if (Parent.right == NodeDel)
                    Parent.right = nil;
            }

            else if (NodeDel.left != nil && NodeDel.right != nil)
            {
                TreeElement MaxLeft = NodeDel.left;
                TreeElement MinRight = NodeDel.right;
                TreeElement ChosenCand = new TreeElement();
                while (MaxLeft.right != nil)
                    MaxLeft = MaxLeft.right;
                while (MinRight.left != nil)
                    MinRight = MinRight.left;
                if (MaxLeft.color == Color.Red && MinRight.color == Color.Red)
                    ChosenCand = MaxLeft;
                else if (MaxLeft.color == Color.Black && MinRight.color == Color.Red)
                    ChosenCand = MinRight;
                else if (MaxLeft.color == Color.Red && MinRight.color == Color.Black)
                    ChosenCand = MaxLeft;
                else if (MaxLeft.color == Color.Black && MinRight.color == Color.Black)
                    ChosenCand = MaxLeft;
                if (ChosenCand.color == Color.Red)
                {
                    K tmp = NodeDel.Key;
                    NodeDel.Key = ChosenCand.Key;
                    ChosenCand.Key = tmp;

                    NodeDel = ChosenCand;
                    TreeElement Par = NodeDel.prev;
                    if (NodeDel.color == Color.Red && NodeDel.right == nil && NodeDel.left == nil)
                    {
                        if (Par.left == NodeDel)
                            Par.left = nil;
                        else if (Par.right == NodeDel)
                            Par.right = nil;
                    }
                }
                else if (ChosenCand.color == Color.Black && ChosenCand.left != nil || ChosenCand.right != nil)
                {
                    K tmp = NodeDel.Key;
                    NodeDel.Key = ChosenCand.Key;
                    ChosenCand.Key = tmp;

                    NodeDel = ChosenCand;
                    if (NodeDel.left != nil)
                    {
                        NodeDel.Key = NodeDel.left.Key;
                        NodeDel.left = nil;

                    }
                    else if (NodeDel.right != nil)
                    {
                        NodeDel.Key = NodeDel.right.Key;
                        NodeDel.right = nil;
                    }
                }

                else if (ChosenCand.color == Color.Black && ChosenCand.left == nil && ChosenCand.right == nil)
                {
                    NodeDel.Key = ChosenCand.Key;
                    NodeDel = ChosenCand;
                    if (NodeDel.prev.left == NodeDel)
                    {
                        NodeDel.prev.left = nil;
                        DelBalance(NodeDel);

                    }
                    else if (NodeDel.prev.right == NodeDel)
                    {
                        NodeDel.prev.right = nil;
                        DelBalanceRight(NodeDel);
                    }

                }




            }

            else if (NodeDel.color == Color.Black && NodeDel.right == nil && NodeDel.left != nil || NodeDel.left == nil && NodeDel.right != nil)
            {
                if (NodeDel.left != nil)
                {
                    NodeDel.Key = NodeDel.left.Key;
                    NodeDel.left = nil;

                }
                else if (NodeDel.right != nil)
                {
                    NodeDel.Key = NodeDel.right.Key;
                    NodeDel.right = nil;
                }
            }

            else if (NodeDel.color == Color.Black && NodeDel.left == nil && NodeDel.right == nil)
            {
                if (NodeDel.prev.left == NodeDel)
                {
                    NodeDel.prev.left = nil;
                    DelBalance(NodeDel);
                }
                else if (NodeDel.prev.right == NodeDel)
                {
                    NodeDel.prev.right = nil;
                    DelBalanceRight(NodeDel);
                }




            }


            void DelBalance(TreeElement NodeD)
            {
                TreeElement Parent = NodeD.prev;
                if (Parent == null)
                {
                    root = new TreeElement();
                    return;
                }
                TreeElement Brother = Parent.right;



                if (Brother.color == Color.Black && Brother.right.color == Color.Red)
                {
                    Brother.color = Parent.color;
                    Parent.color = Color.Black;
                    Brother.right.color = Color.Black;
                    LeftRotate(Brother);
                }
                else if (Brother.color == Color.Black && Brother.left.color == Color.Red && Brother.right.color == Color.Black)
                {
                    Brother.left.color = Brother.color;
                    Brother.color = Color.Red;
                    TreeElement BrotherLeft = Brother.left;
                    RightRotate(BrotherLeft);
                    DelBalance(NodeD);
                    return;
                }

                else if (Brother.color == Color.Black && Brother.right.color == Color.Black && Brother.left.color == Color.Black)
                {
                    Brother.color = Color.Red;
                    if (Parent.color == Color.Red)
                        Parent.color = Color.Black;
                    else
                    {
                        Parent.color = Color.Black;
                        if (Parent.prev != null)
                        {
                            if (Parent.prev.left == Parent)
                                DelBalance(Parent);
                            else if (Parent.prev.right == Parent)
                                DelBalanceRight(Parent);
                        }
                    }
                }


                else if (Brother.color == Color.Red && Parent.color == Color.Black)
                {
                    Brother.color = Color.Black;
                    Parent.color = Color.Red;
                    LeftRotate(Brother);
                }
            }


            void DelBalanceRight(TreeElement NodeD)
            {
                TreeElement Parent = NodeD.prev;
                if (Parent == null)
                {
                    root = new TreeElement();
                    return;
                }
                TreeElement Brother = Parent.left;
                if (Brother.color == Color.Black && Brother.left.color == Color.Red)
                {
                    Brother.color = Parent.color;
                    Parent.color = Color.Black;
                    Brother.left.color = Color.Black;
                    RightRotate(Brother);
                }


                else if (Brother.color == Color.Black && Brother.left.color == Color.Black && Brother.right.color == Color.Red)
                {
                    Brother.right.color = Brother.color;
                    Brother.color = Color.Red;
                    TreeElement BrotherRight = Brother.right;
                    LeftRotate(BrotherRight);
                    DelBalanceRight(NodeD);
                    return;
                }


                else if (Brother.color == Color.Black && Brother.right.color == Color.Black && Brother.left.color == Color.Black)
                {
                    Brother.color = Color.Red;
                    if (Parent.color == Color.Red)
                        Parent.color = Color.Black;
                    else
                    {
                        Parent.color = Color.Black;
                        if (Parent.prev != null)
                        {
                            if (Parent.prev.left == Parent)
                                DelBalance(Parent);
                            else if (Parent.prev.right == Parent)
                                DelBalanceRight(Parent);
                        }
                    }
                }


                else if (Brother.color == Color.Red && Parent.color == Color.Black)
                {
                    Brother.color = Color.Black;
                    Parent.color = Color.Red;
                    LeftRotate(Brother);
                }


            }
        }








        private void BalanceTree(TreeElement Node)
        {
            if (Node.prev == null)
                Case1(Node);
            else if (Node.prev.color == Color.Red && Node.color == Color.Red)
            {
                Case1(Node);
                Case2(Node);
                Case3(Node);





            }




            void Case1(TreeElement BalanceNode)
            {
                if (BalanceNode.prev == null && BalanceNode.color == Color.Red)
                {
                    BalanceNode.color = Color.Black;
                    return;
                }
                if (BalanceNode.prev == null)
                    return;
                if (BalanceNode.prev.color == Color.Black && BalanceNode.color == Color.Red)
                    return;


                TreeElement Uncle;
                if (BalanceNode.prev.prev.right == BalanceNode.prev)
                {
                    Uncle = BalanceNode.prev.prev.left;
                }
                else
                {
                    Uncle = BalanceNode.prev.prev.right;
                }
                if (Uncle.color == Color.Red && BalanceNode.prev.color == Color.Red)
                {
                    Uncle.color = Color.Black;
                    BalanceNode.prev.color = Color.Black;
                    BalanceNode.prev.prev.color = Color.Red;
                    BalanceTree(BalanceNode.prev.prev);
                }
                else
                    return;
            }


            void Case2(TreeElement BalanceNode)
            {
                if (BalanceNode.prev == null && BalanceNode.color == Color.Red)
                {
                    BalanceNode.color = Color.Black;
                    return;
                }
                TreeElement Uncle;
                if (BalanceNode.prev.prev.right == BalanceNode.prev)
                {
                    Uncle = BalanceNode.prev.prev.left;
                }
                else
                {
                    Uncle = BalanceNode.prev.prev.right;
                }
                TreeElement Parent = BalanceNode.prev;
                TreeElement Grand = BalanceNode.prev.prev;
                if (Parent.color == Color.Red && BalanceNode.color == Color.Red)
                {
                    if (Uncle.color == Color.Black && Parent.right == BalanceNode && Grand.left == Parent)
                    {
                        Grand.left = BalanceNode;
                        Parent.right = BalanceNode.left;
                        BalanceNode.left.prev = Parent;
                        BalanceNode.left = Parent;
                        BalanceNode.prev = Grand;
                        Parent.prev = BalanceNode;

                        BalanceTree(Parent);
                        return;
                    }
                    if (Uncle.color == Color.Black && Parent.left == BalanceNode && Grand.right == Parent)
                    {
                        Grand.right = BalanceNode;
                        Parent.left = BalanceNode.right;
                        BalanceNode.right.prev = Parent;
                        BalanceNode.right = Parent;
                        Parent.prev = BalanceNode;

                        BalanceNode.prev = Grand;
                        BalanceTree(Parent);
                        return;
                    }
                }


            }



            void Case3(TreeElement BalanceNode)
            {
                if (BalanceNode.prev == null && BalanceNode.color == Color.Red)
                {
                    BalanceNode.color = Color.Black;
                    return;
                }
                if (BalanceNode.prev == null || BalanceNode.prev.prev == null)
                    return;
                TreeElement Uncle;
                if (BalanceNode.prev.prev.right == BalanceNode.prev)
                {
                    Uncle = BalanceNode.prev.prev.left;
                }
                else
                {
                    Uncle = BalanceNode.prev.prev.right;
                }
                TreeElement Parent = BalanceNode.prev;
                TreeElement Grand = BalanceNode.prev.prev;
                if (Parent.color == Color.Red && BalanceNode.color == Color.Red)
                {
                    if (Parent.left == BalanceNode && Grand.left == Parent && Uncle.color == Color.Black)
                    {
                        Grand.left = Parent.right;
                        Parent.right.prev = Grand;

                        Parent.right = Grand;
                        Parent.prev = Grand.prev;
                        if (Grand.prev != null && Grand.prev.right == Grand)
                            Grand.prev.right = Parent;
                        if (Grand.prev != null && Grand.prev.left == Grand)
                            Grand.prev.left = Parent;
                        Grand.prev = Parent;

                        Grand.color = Color.Red;
                        Parent.color = Color.Black;
                        BalanceTree(Parent);
                        return;
                    }

                    if (Parent.right == BalanceNode && Grand.right == Parent && Uncle.color == Color.Black)
                    {
                        Grand.right = Parent.left;
                        Parent.left.prev = Grand;

                        Parent.left = Grand;
                        Parent.prev = Grand.prev;
                        if (Grand.prev != null && Grand.prev.right == Grand)
                            Grand.prev.right = Parent;
                        if (Grand.prev != null && Grand.prev.left == Grand)
                            Grand.prev.left = Parent;
                        Grand.prev = Parent;
                        Grand.color = Color.Red;
                        Parent.color = Color.Black;
                        BalanceTree(Parent);
                        return;
                    }
                }

            }
        }



        


        private void LeftRotate(TreeElement RotateNode)
        {
            TreeElement Parent = RotateNode.prev;
            if (Parent == null)
                return;
            TreeElement Grand = Parent.prev;

            TreeElement tmp = RotateNode.left;

            RotateNode.left = Parent;
            Parent.right = tmp;
            RotateNode.prev = Parent.prev;
            Parent.prev = RotateNode;
            tmp.prev = Parent;
            if (Grand != null && Grand.left == Parent)
                Grand.left = RotateNode;
            else if (Grand != null && Grand.right == Parent)
                Grand.right = RotateNode;

        }


        private void RightRotate(TreeElement RotateNode)
        {
            TreeElement Parent = RotateNode.prev;
            if (Parent == null)
                return;


            TreeElement Grand = Parent.prev;

            TreeElement tmp = RotateNode.right;

            RotateNode.right = Parent;
            Parent.left = tmp;
            RotateNode.prev = Parent.prev;
            Parent.prev = RotateNode;
            tmp.prev = Parent;
            if (Grand != null && Grand.left == Parent)
                Grand.left = RotateNode;
            else if (Grand != null && Grand.right == Parent)
                Grand.right = RotateNode;





        }







        public void Print()
        {
            if (size == 0)
                return;
            while (root.prev != null)
                root = root.prev;
            Pprint(root);
            void Pprint(TreeElement roo)
            {
                if (roo == nil)
                    return;
                else
                {

                    Console.WriteLine(roo.color.ToString() + " " + roo.Key.ToString());
                    Pprint(roo.left);
                    Pprint(roo.right);
                }
            }


        }


        public void OrderPrint()
        {
            if (size == 0)
                return;
            while (root.prev != null)
                root = root.prev;
            Pprint(root);
            void Pprint(TreeElement roo)
            {
                if (roo == nil)
                    return;
                else
                {


                    Pprint(roo.left);
                    Console.WriteLine(roo.color.ToString() + " " + roo.Key.ToString());
                    Pprint(roo.right);
                }
            }


        }







        internal enum Color
        {
            Black,
            Red
        }



        internal class TreeElement
        {
            public TreeElement left = null;
            public TreeElement right = null;
            public TreeElement prev = null;

            public K Key;
            public Color color = Color.Black;
        }




        private IEnumerable<K> OrdesrPrint()
        {
            if (size == 0)
                yield break;
            while (root.prev != null)
                root = root.prev;

            Stack<TreeElement> stack = new Stack<TreeElement>();
            TreeElement copy = root;

            while (copy != nil || stack.Count != 0)
            {
                while (copy != nil)
                {
                    stack.Push(copy);
                    copy = copy.left;
                }
                copy = stack.Pop();
                yield return copy.Key;
                copy = copy.right;
            }


        }


        public virtual TreeIter DescendingIterator() {
            
            
            return new TreeIter(root, nil); 
            
        
        }



        public MySortedSet<K> HeadSet(K upperbound, bool incl) {
            return new TreeSubSet(this, upperbound, incl);
        }


        public MySortedSet<K> SubSet(K lowerBound, K upperbound, bool highincl, bool lowincl)
        {
            return new TreeSubSet(this, upperbound, lowerBound, highincl, lowincl);
        }


        public MySortedSet<K> TailSet(K lowerbound, bool incl) {
            return new TreeSubSet(lowerbound, this, incl);
        }


        public MyTreeSet<K> DescendingSet() {
            IComparer cmp = new MyReverseComparator<K>(); 
            MyTreeSet <K> ReverseSet = new MyTreeSet<K>(cmp);
            foreach (var el in BFS())
                ReverseSet.Add(el);
            return ReverseSet;
        }

        public class TreeIter : IEnumerator
        {
            private TreeElement Copy = new TreeElement();
            private TreeElement Nil = new TreeElement();
            private K WriteElement = default(K);
            private Stack<TreeElement> stack = new Stack<TreeElement>();
            internal TreeIter(TreeElement copy, TreeElement nil)
            {
                
                Copy = copy;
                Nil = nil;
                
            }

            public object Current { get => WriteElement; }

            public bool MoveNext()
            {
                if (Copy == Nil && stack.Count == 0)
                    return false;
                while (Copy != Nil)
                {
                    stack.Push(Copy);
                    Copy = Copy.right;
                }
                Copy = stack.Pop();
                WriteElement = Copy.Key;
                Copy = Copy.left;
                return true;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }


        public class MyItr : MyIterator<K>
        {
            TreeElement? current = null;
            int IteratedElements = 0;
            MyTreeSet<K> CopySet;
            List<TreeElement> CompletedNode = new List<TreeElement>();

            K keyCur;
            private Stack<TreeElement> stack = new Stack<TreeElement>();
            public K Current { get => keyCur; }


            internal MyItr(MyTreeSet<K> TreeSet) {
                CopySet = TreeSet;
                
                
            
            }

            public bool HasNext()
            {
                if (IteratedElements == CopySet.size)
                    return false;
                return true;
            }

            public K Next()
            {
                if (current == null) 
                    current = CopySet.root;
                    
                
                while (current != CopySet.nil)
                {
                    stack.Push(current);
                    current = current.right;
                }
                current = stack.Pop();
                keyCur =current.Key;
                


                current = current.left;
                IteratedElements++;
                
                return keyCur;
            }

            public void Remove()
            {
                CopySet.Remove(current.Key);
                IteratedElements--;
                stack = new Stack<TreeElement>();
                current = null;
            }
        }




        private IEnumerable<K> BFS()
        {
            
            TreeElement copy = root;
            Queue<TreeElement> queue = new Queue<TreeElement>();
            queue.Enqueue(copy);
            while (queue.Count > 0)
            {
                copy = queue.Dequeue();
                K pair = copy.Key;
                yield return pair;
                if (copy.left != nil)
                    queue.Enqueue(copy.left);
                if (copy.right != nil)
                    queue.Enqueue(copy.right);
            }
        }

        public virtual IEnumerator GetEnumerator()
        {
            return new TreeIter(root, nil);
        }

        public sealed class TreeSubSet:MyTreeSet<K> {

            MyTreeSet<K> IncludedSet;
            K upperBound;
            K lowerBound;
            bool? incl = null;
            bool? high = null;
            bool? low = null;
            bool? inclusive = null;
            
            public TreeSubSet(MyTreeSet<K> Set, K upperBound, K HigherBound, bool high, bool low) {
                this.IncludedSet = Set;
                this.upperBound = upperBound;
                this.lowerBound = HigherBound;
                this.high = high;
                this.low = low;
                IncludeInRange();
                
            }


            public TreeSubSet(MyTreeSet<K> Set, K upperBound, bool incl)
            {
                IncludedSet = Set;
                this.upperBound = upperBound;
                this.incl = incl;
                IncludeInRange();
            }


            public TreeSubSet(K lowerBound, MyTreeSet<K> Set, bool inclusive)
            {
                IncludedSet = Set;
                this.lowerBound = lowerBound;
                this.inclusive = inclusive;
                IncludeInRange();
            }

            public override void Add(K key)
            {
                if (this.WithinRange(key))
                {
                    base.Add(key);
                    IncludedSet.Add(key);
                }
            }


            public override void Remove(object key) {
                if (this.WithinRange((K)key))
                {
                    base.Remove(key);
                    IncludedSet.Remove(key);
                }
            }

            private void IncludedInSet() {
                foreach (K el in IncludedSet)
                    if (WithinRange(el) && base.Contains(el) == false)
                        base.Add(el);
            }
            



            private bool WithinRange(K key) {
                if (inclusive != null)
                {
                    if (comparer.Compare(lowerBound, key) > 0)
                        return true;
                    else if (comparer.Compare(lowerBound, key) == 0 && inclusive == true)
                        return true;
                }


                else if (incl != null)
                {
                    if (comparer.Compare(upperBound, key) < 0)
                        return true;
                    else if (comparer.Compare(upperBound, key) == 0 && incl == true)
                        return true;
                }


                else if (high != null && low != null)
                {
                    if (comparer.Compare(upperBound, key) > 0 && comparer.Compare(lowerBound, key) < 0)
                        return true;
                    else if (comparer.Compare(upperBound, key) == 0 && high == true || comparer.Compare(lowerBound, key) == 0 && low == true)
                        return true;
                }


                return false;


            }
            public override TreeIter DescendingIterator()
            {
                IncludedInSet();
                return base.DescendingIterator();
            }

            public override IEnumerator GetEnumerator()
            {
                IncludedInSet();
                return base.GetEnumerator();
            }

            private void IncludeInRange() {
                foreach (K key in IncludedSet) {
                    this.Add(key);
                }
            }
        
        
        
        }
        public MyItr Iterator() => new MyItr(this);
        
    }



    internal class Program
    {
        
        static void Main(string[] args)
        {
           

            List<int> lst = new List<int>();
            int[] a = { 10, 15, 2, 76, 18, 20, 1, 3, 9, 17, 12, 4, 22, 13 };
            MyTreeSet<int> tree = new MyTreeSet<int>(a);

            var iter = tree.Iterator();
            while (iter.HasNext()) {
                iter.Next();
                iter.Remove();
                Console.WriteLine(iter.Current);
            
            }



            //var set = new SortedSet<int>(a);
            //SortedSet<int> newset = set.GetViewBetween(4, 15);
            //foreach (var el in set)
            //    Console.Write(el + " ");
            //Console.WriteLine();
            //foreach (var el in newset)
            //    Console.Write(el + " ");
            //Console.WriteLine();
            //newset.Add(146565);

            //foreach (var el in set)

            //    Console.Write(el + " ");
            //Console.WriteLine();
            //foreach (var el in newset)
            //    Console.Write(el + " ");
            //Console.WriteLine();
            ////MyTreeSet<int> Sub = tree.HeadSet(12);
            ////Console.WriteLine(tree.Ceiling(11));



        }
    }
}