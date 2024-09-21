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
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        StreamWriter writer = new StreamWriter("sort.txt");
        ConcurrentQueue<int> ints = new ConcurrentQueue<int>();
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        List<int[]> ListToTxt = new List<int[]>();

        

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
            {3, Color.DarkBlue},
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
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.XAxis.Title.Text = "Размер массива";
            pane.YAxis.Title.Text = "Время выполнения мс.";
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


        }

        public void Ticks(object sender, EventArgs e)
        {
            if (ints.IsEmpty == false)
            {
                int result;
                ints.TryDequeue(out result);
                if (progressBar1.Value + result < 100)
                    progressBar1.Value += result;
            }

        }



        int flag = 0;
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string answer = comboBox2.Text;
            if (answer == "Первая")
            { flag = 1; start = 0; end = 5; }
            else if (answer == "Вторая") { flag = 2; start = 5; end = 8; }
            else if (answer == "Третья") { flag = 3; start = 8; end = 14; }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (answer == "Случайные числа")
            {

                AllArray.Clear();
                int size = 10;
                int[] array = new int[size];
                int power = FlagChecker(flag);

                while (size < Math.Pow(10, power))
                {

                    AllArray.Add(array);
                    size *= 10;
                    array = new int[size];
                }
                AllArray.Add(array);
            }
            else if (answer == "Подмассивы")
            {
                AllArray.Clear();
                for (int i = 0; i < MasGroup.ar2.Length; i++)
                {
                    int size = 10;
                    int[] array = new int[size];
                    int power = FlagChecker(flag);
                    while (size < Math.Pow(10, power))
                    {
                        AllArray.Add(array);
                        size *= 10;
                        MasGroup.ar2[i] = new int[size];
                        array = MasGroup.ar2[i];
                    }

                    AllArray.Add(array);
                }
            }

            else if (answer == "Сортировка с перестановкой")
            {
                AllArray.Clear();
                for (int i = 0; i < MasGroup.ar3.Length; i++)
                {
                    int size = 10;
                    int[] array = MasGroup.ar3[i];
                    int power = FlagChecker(flag);
                    while (size < Math.Pow(10, power))
                    {
                        AllArray.Add(array);
                        size *= 10;
                        MasGroup.ar3[i] = new int[size];
                        array = MasGroup.ar3[i];
                    }
                    AllArray.Add(array);
                }
            }
            else if (answer == "Повторение")
            {
                AllArray.Clear();
                for (int i = 0; i < MasGroup.ar4.Length; i++)
                {
                    int size = 10;
                    int[] array = MasGroup.ar4[i];
                    int power = FlagChecker(flag);
                    while (size < Math.Pow(10, power))
                    {
                        AllArray.Add(array);
                        size *= 10;
                        MasGroup.ar4[i] = new int[size];
                        array = MasGroup.ar4[i];
                    }
                    AllArray.Add(array);
                }
            }
        }




        private void button2_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            timer.Tick += new EventHandler(Ticks);
            timer.Interval = 50;
            timer.Start();
            progressBar1.Value += 1;
            Thread thread = new Thread(new ThreadStart(Para));
            thread.Start();
            void Para()
            {
                GraphPane pane = zedGraphControl1.GraphPane;
                pane.CurveList.Clear();
                double power = FlagChecker(flag);
                double x = 0;
                int procent = 0;
                if (flag == 3) { procent = 18;
                    pane.XAxis.Scale.Min = 0;
                    pane.XAxis.Scale.Max = Math.Pow(10, power); 
                }
                else if (flag == 2) { procent = 30;
                    pane.XAxis.Scale.Min = 0;
                    pane.XAxis.Scale.Max = Math.Pow(10, power);
                }// pane.XAxis.Scale.Max = 10000; }
                else if (flag == 1) { procent = 20;
                    pane.XAxis.Scale.Min = 0;
                    pane.XAxis.Scale.Max = Math.Pow(10, power);
                }// pane.XAxis.Scale.Max = 1000000; }

                for (int st = start; st < end; st++)
                {
                    Dictionary<double, double> saving = new Dictionary<double, double>();
                    PointPairList list = new PointPairList();

                    foreach (int[] i in AllArray)
                    {


                        x = i.Length;
                        double milliSecondsSum = 0;
                        for (int j = 0; j < 20; j++)
                        {




                            if (answer == "Случайные числа")
                            {
                                MasGroup.RandShuffle(i);
                                milliSecondsSum += f(i, st);
                            }
                            if (answer == "Подмассивы")
                            {
                                MasGroup.RandUnArrayShuffle(AllArray);
                                milliSecondsSum += f(i, st);
                            }
                            else if (answer == "Сортировка с перестановкой")
                            {
                                MasGroup.ItWasSorted(i);
                                milliSecondsSum += f(i, st);
                            }
                            else if (answer == "Повторение")
                            {
                                List<int[]> CurrentArray = new List<int[]>();
                                for (int k = 0; k < 7; k++)
                                {
                                    int[] Nmas = new int[i.Length];
                                    i.CopyTo(Nmas, 0);
                                    CurrentArray.Add(Nmas);
                                }
                                MasGroup.ManyArray(CurrentArray);
                                foreach (int[] ar in CurrentArray)
                                    milliSecondsSum += f(ar, st);


                            }




                        }

                        if (saving.ContainsKey(x) == false)
                        {
                            saving[x] = milliSecondsSum / 20;

                        }
                        else
                        {
                            if (saving[x] < milliSecondsSum / 20)
                            {
                                saving[x] = milliSecondsSum / 20;
                            }

                        }

                    }
                    foreach (double x2 in saving.Keys)
                    {
                        list.Add(x2, saving[x2]);
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
                timer.Stop();
                ints = new ConcurrentQueue<int>();
            }
        }

        private int FlagChecker(int flag)
        {

            int power;
            if (flag == 1) power = 4;
            else if (flag == 2) power = 5;
            else power = 6;
            return power;

        }

        private double f(int[] array, int st)
        {
            Stopwatch clock = Stopwatch.StartNew();
            sortObj.SortChose(st, array);
            ListToTxt.Add(array);
            clock.Stop();
            return clock.ElapsedMilliseconds;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                foreach (int[] txt in ListToTxt)
                {
                    writer.WriteLine(string.Join(" ", txt));
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("Здесь Какая то ошибка");

            }
        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {
            
        }
        

        private void progressBar1_Click(object sender, EventArgs e)
        {
            
        }
    }
}