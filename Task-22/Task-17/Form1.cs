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
using Task_21;
using Task_16;
using ConsoleApp1;
using ZedGraph;
using System.Threading;
using System.Collections.Concurrent;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Task_17
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            
            InitializeComponent();
        }
        string answer;
        
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        ConcurrentQueue<Tuple<int, int>> queue = new ConcurrentQueue<Tuple<int, int>>();
        int countMap = 0;
        int countTree = 0;
        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public void Ticks(object sender, EventArgs e)
        {
            if (queue.IsEmpty == false)
            {
                Tuple<int, int> result;
                queue.TryDequeue(out result);
                if (result.Item2 == 1)
                    label5.Text = $"{result.Item1} / 2222080";
                else
                    label2.Text = $"{result.Item1} / 2222080";
            }

        }








        private void button1_Click(object sender, EventArgs e)
        {
            countMap = 0;
            countTree = 0;
            label2.Text = "0 / 2222080";
            label5.Text = "0 / 2222080";
            LineItem my;
            GraphPane pane = zedGraphControl1.GraphPane;
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            pane.CurveList.Clear();
            pane.XAxis.Scale.Min = 0;
            pane.XAxis.Scale.Max = Math.Pow(10, 6);
            answer = comboBox1.Text;
            timer.Tick += new EventHandler(Ticks);
            timer.Interval = 1;
            timer.Start();
            Thread thread = new Thread(new ThreadStart(Para));
            Thread thread2 = new Thread(new ThreadStart(Para2));
            thread.Start();
            thread2.Start();
            void Para()
            {
                int power = 2;
                while (power <= 6)
                {
                    int size = (int)Math.Pow(10, power);
                    list1.Add(size, DoArray(size));
                    power += 1;
                }
                


                my = pane.AddCurve("Хэш-таблица", list1, Color.DarkSeaGreen, SymbolType.None);
                my.Line.Width = 5;
                my.Line.Color = Color.DarkSeaGreen;
                my.Color = Color.DarkSeaGreen;
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
                Console.WriteLine(countMap);
            }
            void Para2()
            {
                int power = 2;
                while (power <= 6)
                {
                    int size = (int)Math.Pow(10, power);
                    list2.Add(size, DoList(size));
                    power += 1;

                }

                my = pane.AddCurve("Дерево", list2, Color.Gold, SymbolType.None);
                my.Line.Width = 5;
                my.Line.Color = Color.Gold;
                my.Color = Color.Gold;
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
            }
        }


        public double DoArray(int size) {
            

            double milliseconds = 0;
            for (int i = 0; i < 20; i++) {
                countMap += 1;   
                milliseconds += FuncForArray(size);
            
            }
            
            return milliseconds;
        }

        public double DoList(int size)
        {
            double milliseconds = 0;
            for (int i = 0; i < 20; i++)
            {
                countTree += 1;
                milliseconds += FuncForList(size);
            }
            return milliseconds;
        }


        public double FuncForArray(int size) // Map
        {
            Random random = new Random();
            MyHashMap<int, int> map;
           

            Stopwatch clock = new Stopwatch();
            switch (answer) {
                case "add": {
                        map = new MyHashMap<int, int>();
                        clock.Start();
                        for (int i = 0; i < size; i++)
                        {
                            
                            map.Put(i,random.Next(1,1000));
                            
                        }
                        
                        queue.Enqueue(new Tuple<int, int>(countMap += size, 1));
                        break;
                }
                case "get":
                {     
                        
                        map = new MyHashMap<int, int>(1000);
                        for (int i = 0; i < size; i++)
                            map.Put(i, 1);
                        clock.Start();
                        int k = map.Size();
                        var t = size;
                        for (int i = 0; i < size; i++)
                        {
                            
                            int key = random.Next(0, map.Size() - 1);
                            map.Get(i);
                        }
                        queue.Enqueue(new Tuple<int, int>(countMap += size, 1));
                        break;  
                }

                
                case "remove":
                    {
                        map = new MyHashMap<int, int>();
                        for (int i = 0; i < size; i++)
                            map.Put(i, random.Next(0, 1000));
                        clock.Start();
                        for (int i = 0; i < size; i++)
                        {

                            int key = random.Next(0, map.Size() - 1);
                            map.Remove(key);
                        }
                        queue.Enqueue(new Tuple<int, int>(countMap += size, 1));
                        break;
                    }

                
            }



            clock.Stop();
            return clock.ElapsedMilliseconds;
        }


        public double FuncForList(int size) // Tree
        {
            Random random = new Random();
            MyTreeMap<int, int> treeMap;
            Stopwatch clock = new Stopwatch();
            int[] array = ArrayGeneration(size);
            Shuffle(array);
            switch (answer) {
                case "add": {
                        treeMap = new MyTreeMap<int, int>();
                        clock.Start();
                        for (int i = 0; i < size; i++) {
                            treeMap.Put(array[i], random.Next(0, 1000));
                            
                        }
                        queue.Enqueue(new Tuple<int, int>(countTree += size, 2));
                        break;
                }
                case "get": {
                        
                        treeMap = new MyTreeMap<int, int>();
                        for (int i = 0; i < size; i++)
                        {
                            treeMap.Put(array[i], random.Next(0, 1000));
                        }
                        int k = treeMap.Size();
                        clock.Start();
                        for (int i = 0; i < size; i++)
                        {
                            int index = random.Next(0, treeMap.Size() - 1);
                            treeMap.Get(index);
                            
                        }
                        queue.Enqueue(new Tuple<int, int>(countTree += size, 2));
                        break;
                }
                

                case "remove": {
                        treeMap = new MyTreeMap<int, int>();
                        for (int i = 0; i < size; i++)
                        {
                            treeMap.Put(array[i], random.Next(0, 1000));
                        }
                        clock.Start();
                        for (int i = 0; i < size; i++)
                        {
                            
                            int index = random.Next(0, treeMap.Size() - 1);
                            treeMap.Remove(index);

                        }
                        queue.Enqueue(new Tuple<int, int>(countTree += size, 2));
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
            HashSet<int> set = new HashSet<int>();
            
            
            for (int i = 0; i < size; i++)
                Arrays[i] = rand.Next(1, 100000);
            return Arrays;
        }

        public void Shuffle(int[] array) {
            Random rand = new Random();
            for (int i = array.Length - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
                // обменять значения data[j] и data[i]
                var temp = array[j];
                array[j] = array[i];
                array[i] = temp;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
