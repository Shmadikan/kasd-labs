using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task4;
using Task_16;
using ZedGraph;
using System.Threading;

namespace Task_17
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string answer;
        MyArrayList<int> lst = new MyArrayList<int>();
        MyLinkedList<int> ls = new MyLinkedList<int>();
        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        


        

        



        private void button1_Click(object sender, EventArgs e)
        {
            LineItem my;
            GraphPane pane = zedGraphControl1.GraphPane;
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            pane.CurveList.Clear();
            pane.XAxis.Scale.Min = 0;
            pane.XAxis.Scale.Max = Math.Pow(10, 5);
            answer = comboBox1.Text;
            Thread thread = new Thread(new ThreadStart(Para));
            Thread thread2 = new Thread(new ThreadStart(Para2));
            thread.Start();
            thread2.Start();
            void Para()
            {
                int power = 2;
                while (power <= 5)
                {
                    int size = (int)Math.Pow(10, power);
                    list1.Add(size, DoArray(size));
                    power += 1;
                }



                my = pane.AddCurve("Массив", list1, Color.Chocolate, SymbolType.None);
                my.Line.Width = 5;
                my.Line.Color = Color.Chocolate;
                my.Color = Color.Chocolate;
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
            }
            void Para2()
            {
                int power = 2;
                while (power <= 5)
                {
                    int size = (int)Math.Pow(10, power);
                    list2.Add(size, DoList(size));
                    power += 1;

                }

                my = pane.AddCurve("Список", list2, Color.DeepPink, SymbolType.None);
                my.Line.Width = 5;
                my.Line.Color = Color.DeepPink;
                my.Color = Color.DeepPink;
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
            }
        }


        public double DoArray(int size) {
            

            double milliseconds = 0;
            for (int i = 0; i < 3; i++) {
               
                milliseconds += FuncForArray(size);
            }

            return milliseconds;
        }

        public double DoList(int size)
        {
            double milliseconds = 0;
            for (int i = 0; i < 3; i++)
            {
                milliseconds += FuncForList(size);
            }
            return milliseconds;
        }


        public double FuncForArray(int size)
        {
            Random random = new Random();
            MyArrayList<int> dynArray;
           

            Stopwatch clock = new Stopwatch();
            switch (answer) {
                case "add": {
                        dynArray = new MyArrayList<int>();
                        clock.Start();
                        for (int i = 0; i < size; i++)
                        {
                            
                            dynArray.AddElement(i);
                        }
                        break;
                }
                case "get":
                {     
                        int[] array = ArrayGeneration(size);
                        dynArray = new MyArrayList<int>(array);
                        clock.Start();
                        for (int i = 0; i < size; i++)
                        {
                            int index = random.Next(0, dynArray.Size() - 1);
                            dynArray.get(index);
                        }
                        break;  
                }

                case "set":
                {
                        int[] array = ArrayGeneration(size);
                        dynArray = new MyArrayList<int>(array);
                        clock.Start();
                        for (int i = 0; i < size; i++)
                        {
                            int index = random.Next(0, dynArray.Size() - 1);
                            int number = random.Next(0, 100000);
                            dynArray.Set(index, number);
                        }
                        break;
                }
                case "remove":
                    {
                        int[] array = ArrayGeneration(size);
                        dynArray = new MyArrayList<int>(array);
                        clock.Start();
                        for (int i = 0; i < size; i++)
                        {
                            int number = random.Next(1, 10000);
                            dynArray.Remove(number);
                        }
                        break;
                    }

                case "indexAdd": {
                        int[] array = ArrayGeneration(size);
                        dynArray = new MyArrayList<int>(array);
                        clock.Start();
                        for (int i = 0; i < size; i++)
                        {
                            int index = random.Next(0, dynArray.Size() - 1);
                            int ranNumber = random.Next(0, 10000);
                            dynArray.Add(index, ranNumber);
                        }
                        break;
                }
            }



            clock.Stop();
            return clock.ElapsedMilliseconds;
        }


        public double FuncForList(int size)
        {
            Random random = new Random();
            MyLinkedList<int> linkedList;
            Stopwatch clock = new Stopwatch();

            switch (answer) {
                case "add": {
                        linkedList = new MyLinkedList<int>();
                        clock.Start();
                        for (int i = 0; i < size; i++) {
                            linkedList.Add(i);
                        }
                        break;
                }
                case "get": {
                        int[] array = ArrayGeneration(size);
                        linkedList = new MyLinkedList<int>(array);
                        clock.Start();
                        for (int i = 0; i < size; i++)
                        {
                            int index = random.Next(0, linkedList.Size() - 1);
                            linkedList.Get(index);
                        }
                        break;
                }
                case "set": {
                        int[] array = ArrayGeneration(size);
                        linkedList = new MyLinkedList<int>(array);
                        clock.Start();
                        for (int i = 0; i < size; i++)
                        {
                            int index = random.Next(0, linkedList.Size() - 1);

                            linkedList.Set(index, i);
                        }
                        break;
                }

                case "remove": {
                        int[] array = ArrayGeneration(size);
                        linkedList = new MyLinkedList<int>(array);
                        clock.Start();
                        for (int i = 0; i < size; i++)
                        {
                            int number = random.Next(1, 10000);
                            linkedList.RemoveEl(number);
                        }
                        break;
                }
                case "indexAdd":
                    {
                        int[] array = ArrayGeneration(size);
                        linkedList = new MyLinkedList<int>(array);
                        clock.Start();
                        for (int i = 0; i < size; i++)
                        {
                            int index = random.Next(0, linkedList.Size() - 1);
                            int ranNumber = random.Next(0, 10000);
                            linkedList.Add(index, ranNumber);
                        }
                        break;
                    }

            }

            clock.Stop();
            return clock.ElapsedMilliseconds;
        }

        public int[] ArrayGeneration(int size)
        {
            Random rand = new Random();
            int[] Arrays = new int[size];
            for (int i = 0; i < size; i++)
                Arrays[i] = rand.Next(1, 100000);
            return Arrays;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
