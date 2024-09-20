using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using Task33;
using System.Diagnostics;
using System.Runtime;
using System.Threading;
using System.Collections.Concurrent;
using System.Timers;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        ConcurrentQueue<int> ints = new ConcurrentQueue<int>();
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
       
        


        int[] ArrayOfFunc = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
        Dictionary<int, string> sortName = new Dictionary<int, string> {
            {0, "Пузырь"},
            {1, "Вставка"},
            {2, "Выбором"},
            {3, "Шейкерная"},
            {4, "Гномья"},
            {5, "Битонная"},
            {6, "Шелла"},
            {7, "Дерево"},
            {8, "Расчёска"},
            {9, "Пирамида"},
            {10,"БЫСТРАЯ"},
            {11,"Слияние"},
            {12, "Подсчётом"},
            {13, "Поразрядная"}
        };
        Dictionary<int, Color> sortColor = new Dictionary<int, Color> {
            {0, Color.Tomato},
            {1, Color.LawnGreen},
            {2, Color.Magenta},
            {3, Color.OrangeRed},
            {4, Color.Silver},
            {5, Color.Brown},
            {6, Color.Chocolate},
            {7, Color.LightSeaGreen},
            {8, Color.Purple},
            {9, Color.Yellow},
            {10, Color.Red},
            {11, Color.RosyBrown},
            {12, Color.Thistle},
            {13, Color.Violet}
        };
        
        int start, end;
        List<int[]> AllArray = new List<int[]>();
        string answer;
        AllSortIsHere sortObj = new AllSortIsHere();
        Arrays MasGroup = new Arrays(10);
        
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            GraphPane p = zedGraphControl1.GraphPane;
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            answer = comboBox1.Text;
            progressBar1.Value = progressBar1.Minimum;
            timer.Tick += new EventHandler(Ticks);
            timer.Interval = 50;
            timer.Start();
        }

        public void Ticks(object sender, EventArgs e)
        {
            if (ints.IsEmpty == false)
            {
                int result;
                ints.TryDequeue(out result);
                if (progressBar1.Value < 100)
                progressBar1.Value += result;
            }
            
        }



        int flag = 0;
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string answer = comboBox2.Text;
            if (answer == "Первая")
            { flag = 1; start = 0;end = 5; }
            else if (answer == "Вторая") { flag = 2; start = 5; end = 8; }
            else if (answer == "Третья") { flag = 3; start = 8; end = 14; }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (answer == "Случайные числа")
            {
                
                AllArray.Clear();
                int size = 10;
                int[] mas = MasGroup.ar1;
                int power = FlagChecker(flag);

                while (size < Math.Pow(10, power))
                {

                    AllArray.Add(mas);
                    size *= 10;
                    mas = new int[size];
                }
                AllArray.Add(mas);
            }
            else if (answer == "Подмассивы")
            {
                AllArray.Clear();
                for (int i = 0; i < MasGroup.ar2.Length; i++)
                {
                    int size = 10;
                    int[] mas = MasGroup.ar2[i];
                    int power = FlagChecker(flag);
                    while (size < Math.Pow(10, power))
                    {
                        AllArray.Add(mas);
                        size *= 10;
                        mas = MasGroup.ReSize(size);
                    }
                }
            }

            else if (answer == "Сортировка с перестановкой")
            {
                AllArray.Clear();
                for (int i = 0; i < MasGroup.ar3.Length; i++)
                {
                    int size = 10;
                    int[] mas = MasGroup.ar3[i];
                    int power = FlagChecker(flag);
                    while (size < Math.Pow(10, power))
                    {
                        AllArray.Add(mas);
                        size *= 10;
                        mas = MasGroup.ReSize(size);
                    }
                }
            }
            else if (answer == "Повторение")
            {
                AllArray.Clear();
                for (int i = 0; i < MasGroup.ar4.Length; i++)
                {
                    int size = 10;
                    int[] mas = MasGroup.ar4[i];
                    int power = FlagChecker(flag);
                    while (size < Math.Pow(10, power))
                    {
                        AllArray.Add(mas);
                        size *= 10;
                        mas = mas = new int[size]; ;
                    }
                    AllArray.Add(mas);
                }
            }
        }


        

        private void button2_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(Para));
            thread.Start();
            void Para()
            {
                GraphPane pane = zedGraphControl1.GraphPane;
                pane.CurveList.Clear();

                int procent = 0;
                if (flag == 3) procent = 16;
                else if (flag == 2) procent = 33;
                else if (flag == 1) procent = 20;
                
                for (int st = start; st < end; st++)
                {
                    
                    PointPairList list = new PointPairList();
                    foreach (int[] i in AllArray)
                    {
                        
                        double x = 0;
                        x = i.Length;
                        double xmax = i.Length;
                        for (int j = 0; j < 20; j++)
                        {
                           
                            MasGroup.RandShuffle(i);
                            
                            list.Add(x, f(i, st));
                            
                        }
                        
                            
                            
                        


                    }
                    ints.Enqueue(procent);
                    LineItem my = pane.AddCurve(sortName[st], list, sortColor[st], SymbolType.None);

                    my.Line.Width = 5;
                    my.Line.Color = sortColor[st];
                    my.Color = sortColor[st];
                    zedGraphControl1.AxisChange();
                    zedGraphControl1.Invalidate();


                }
                AllArray.Clear();
            }
        }
        
        private int FlagChecker(int flag) {
            
            int power;
            if (flag == 1) power = 4;
            else if (flag == 2) power = 5;
            else power = 5;
            return power;

        }

        private double f(int[] mas, int st) { 
            Stopwatch clock= Stopwatch.StartNew();
            sortObj.SortChose(st, mas);
            
            clock.Stop();
            return clock.ElapsedMilliseconds;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
