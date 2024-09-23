using ConsoleApp2;
namespace Task_8
{
    public class MyStack<T>: MyVector<T> { 
        public MyVector<T> stackArray = new MyVector<T>();
        int top;
        
        public MyStack() {
            top = -1;
        }

        public void Push(T item) {
            ++top;
            stackArray.Add(item);
            
            
        }


        public void Pop()
        {
            
            if (top < 0)
                throw new IndexOutOfRangeException(); 
            stackArray.RemoveElementAt(top);
            --top;
        }

        public T Peek() {
            if (top < 0)
                throw new IndexOutOfRangeException();
            return stackArray.get(top); 
        }


        public bool Empty()
        {
            if (top == -1)
                return true;
            return false;
        }

        public int Search(T item){
            int deep = 0;
            while (top - deep >= 0) {
                if (stackArray.get(top - deep).Equals(item))
                    return deep + 1;
                deep++;
            }
            return -1;
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> myStack = new MyStack<int>();
            Console.WriteLine(myStack.Empty());
            
            myStack.Push(0);
            
            
            myStack.stackArray.Print();
            Console.WriteLine();
            Console.WriteLine(myStack.Search(0));
            myStack.stackArray.Print();
        }
    }
}