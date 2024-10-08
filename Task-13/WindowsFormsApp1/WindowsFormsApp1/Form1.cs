﻿using System;
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
using System.Drawing.Text;
using System.Collections;

namespace WindowsFormsApp1
{
    public partial class Form1: Form
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
       
        IList AllArray;
        
        object sortObj;
        object MasGroup;
        
        string answer;
        string typeArray;
  
        //List<int[]> AllArray = new List<int[]>();
        //string answer;
        //AllSortIsHere<int> sortObj = new AllSortIsHere<int>();
        //Arrays<int> MasGroup = new Arrays<int>(10);

        public Form1()
        {
            InitializeComponent();
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.XAxis.Title.Text = "Размер массива";
            pane.YAxis.Title.Text = "Время выполнения мс.";
            pane.Title.Text = "Зависимость времени выполнения сортировок от размера массива";
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
            // Кнопка, генерирующая массив.


            if (answer == "Случайные числа")
            {
                switch (typeArray) {
                    case "INT": { PartGeneration<int>();break; }
                    case "CHAR": { PartGeneration<char>();break; }
                    case "STRING": { PartGeneration<string>();break; }
                    case "DOUBLE": { PartGeneration<double>();break; }
                }
            }
            else if (answer == "Подмассивы")
            {
                switch (typeArray)
                {
                    case "INT": { PartGenerationForSub<int>(); break; }
                    case "CHAR": { PartGenerationForSub<char>(); break; }
                    case "STRING": { PartGenerationForSub<string>(); break; }
                    case "DOUBLE": { PartGenerationForSub<double>(); break; }
                }
            }

            else if (answer == "Сортировка с перестановкой")
            {
                switch (typeArray)
                {
                    case "INT": { PartGenerationWithPer<int>(); break; }
                    case "CHAR": { PartGenerationWithPer<char>(); break; }
                    case "STRING": { PartGenerationWithPer<string>(); break; }
                    case "DOUBLE": { PartGenerationWithPer<double>(); break; }
                }
            }
            else if (answer == "Повторение")
            {
                switch (typeArray)
                {
                    case "INT": { SortWithPer<int>(); break; }
                    case "CHAR": { SortWithPer<char>(); break; }
                    case "STRING": { SortWithPer<string>(); break; }
                    case "DOUBLE": { SortWithPer<double>(); break; }
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

                switch (typeArray) {
                    case "INT": {
                            DoStuff<int>();
                            break;
                    }
                    case "CHAR":
                        {
                            DoStuff<char>();
                            break;
                        }
                    case "STRING":
                        {
                            DoStuff<string>();
                            break;
                        }
                    case "DOUBLE":
                        {
                            DoStuff<double>();
                            break;
                        }

                }








                void DoStuff<T>() where T : IComparable, IConvertible 
                {
                    
                    AllSortIsHere<T> sortObj = new AllSortIsHere<T>();
                    Arrays<T> MasGroup = new Arrays<T>(10);
                    for (int st = start; st < end; st++)
                    {
                        this.AllArray = (List<T[]>) this.AllArray;
                        Dictionary<double, double> saving = new Dictionary<double, double>();
                        PointPairList list = new PointPairList();
                        
                        foreach (T[] i in this.AllArray)
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
                                    MasGroup.RandUnArrayShuffle((List<T[]>)this.AllArray);
                                    milliSecondsSum += f(i, st);
                                }
                                else if (answer == "Сортировка с перестановкой")
                                {
                                    MasGroup.ItWasSorted(i);
                                    milliSecondsSum += f(i, st);
                                }
                                else if (answer == "Повторение")
                                {
                                    List<T[]> CurrentArray = new List<T[]>();
                                    for (int k = 0; k < 7; k++)
                                    {
                                        T[] Nmas = new T[i.Length];
                                        i.CopyTo(Nmas, 0);
                                        CurrentArray.Add(Nmas);
                                    }
                                    MasGroup.ManyArray(CurrentArray);
                                    foreach (T[] ar in CurrentArray)
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

                    double f(T[] array, int st)
                    {
                        Stopwatch clock = Stopwatch.StartNew();
                        sortObj.SortChose(st, array);

                        clock.Stop();
                        return clock.ElapsedMilliseconds;
                    }
                }
            }
        }

        private int FlagChecker(int flag)
        {

            int power;
            if (flag == 1) power = 4;
            else if (flag == 2) power = 6;
            else power = 6;
            return power;

        }

        //private double f<T>(T[] array, int st) where T: IComparable
        //{
        //    Stopwatch clock = Stopwatch.StartNew();
        //    sortObj.SortChose(st, array);
            
        //    clock.Stop();
        //    return clock.ElapsedMilliseconds;
        //}

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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            typeArray = comboBox3.Text;
            
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            
        }



        private void PartGeneration<T>() where T : IComparable, IConvertible {

            this.AllArray = new List<T[]>();

            string answer;
            AllSortIsHere<T>sortObj = new AllSortIsHere<T>();
            Arrays<T>MasGroup = new Arrays<T>(10);
            for (int i = 0; i < MasGroup.ar3.Length; i++)
            {
                int size = 10;
                T[] array = MasGroup.ar3[i];
                int power = FlagChecker(flag);
                while (size < Math.Pow(10, power))
                {
                    this.AllArray.Add(array);
                    size *= 10;
                    MasGroup.ar3[i] = new T[size];
                    array = MasGroup.ar3[i];
                }
                this.AllArray.Add(array);
            }

        }


        private void PartGenerationForSub<T>() where T : IComparable, IConvertible {
            
            this.AllArray = new List<T[]>();
            
            AllSortIsHere<T> sortObj = new AllSortIsHere<T>();
            Arrays<T> MasGroup = new Arrays<T>(10);
            


            for (int i = 0; i < MasGroup.ar2.Length; i++)
            {
                int size = 10;
                T[] array = new T[size];
                int power = FlagChecker(flag);
                while (size < Math.Pow(10, power))
                {
                    AllArray.Add(array);
                    size *= 10;
                    MasGroup.ar2[i] = new T[size];
                    array = MasGroup.ar2[i];
                }

                AllArray.Add(array);
            }
        }


        private void PartGenerationWithPer<T>() where T : IComparable, IConvertible
        {
            this.AllArray = new List<T[]>();

            AllSortIsHere<T> sortObj = new AllSortIsHere<T>();
            Arrays<T> MasGroup = new Arrays<T>(10);
            for (int i = 0; i < MasGroup.ar3.Length; i++)
            {
                int size = 10;
                T[] array = MasGroup.ar3[i];
                int power = FlagChecker(flag);
                while (size < Math.Pow(10, power))
                {
                    AllArray.Add(array);
                    size *= 10;
                    MasGroup.ar3[i] = new T[size];
                    array = MasGroup.ar3[i];
                }
                AllArray.Add(array);
            }
        }

        private void SortWithPer<T>() where T : IComparable, IConvertible {
            this.AllArray = new List<T[]>();

            AllSortIsHere<T> sortObj = new AllSortIsHere<T>();
            Arrays<T> MasGroup = new Arrays<T>(10);
            for (int i = 0; i < MasGroup.ar4.Length; i++)
            {
                int size = 10;
                T[] array = MasGroup.ar4[i];
                int power = FlagChecker(flag);
                while (size < Math.Pow(10, power))
                {
                    AllArray.Add(array);
                    size *= 10;
                    MasGroup.ar4[i] = new T[size];
                    array = MasGroup.ar4[i];
                }
                AllArray.Add(array);
            }


        }

        
    }
}