using System.Windows.Forms;
using System.Windows.Media.Media3D;
using Microsoft.Msagl;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;

namespace VisualIZO
{
    public partial class Form1 : Form
    {
        class CustomCompare : Comparer<List<int>>
        {
            public override int Compare(List<int>? x, List<int>? y)
            {
                int n = Math.Min(x.Count, y.Count);
                for (int i = 0; i < n; i++)
                {
                    if (x[i] > y[i])
                        return 1;
                    else if (x[i] < y[i])
                        return -1;
                }
                return 0;
            }
        }



        int n;
        int[][] GraphMatrix;
        int[][] SecondGraph;
        GViewer viewer1 = new GViewer();
        GViewer viewer2 = new GViewer();
        StreamReader ReaderGr1 = new StreamReader("input1.txt");
        StreamReader ReaderGr2 = new StreamReader("input2.txt");
        public Form1()
        {
            InitializeComponent();
            Controls.Add(viewer1);
            Controls.Add(viewer2);
        }

        private void gViewer1_Load(object sender, EventArgs e)
        {
            int n1 = Convert.ToInt32(ReaderGr1.ReadLine());
            n = n1;
            ReaderGr2.ReadLine();

            GraphMatrix = new int[n1][];
            SecondGraph = new int[n1][];
            for (int i = 0; i < n1; i++)
            {
                SecondGraph[i] = new int[n1];
                GraphMatrix[i] = new int[n1];
            }
            string line1;
            string line2;

            for (int i = 0; i < n1; i++)
            {

                line1 = ReaderGr1.ReadLine();
                line2 = ReaderGr2.ReadLine();
                string[] fromline1 = line1.Split(" ");
                string[] fromline2 = line2.Split(" ");
                for (int j = 0; j < n1; j++)
                {
                    GraphMatrix[i][j] = Convert.ToInt32(fromline1[j]);
                    SecondGraph[i][j] = Convert.ToInt32(fromline2[j]);
                }
            }
            Graph gr1 = new Graph();
            Graph gr2 = new Graph();
            for (int i = 0; i < n1; i++)
            {
                gr1.AddNode(i.ToString());
                gr2.AddNode(i.ToString());
            }
            for (int i = 0; i < n1; i++)
                for (int j = 0; j < n1; j++)
                {
                    if (GraphMatrix[i][j] != 0)
                    {
                        var el = gr1.AddEdge(i.ToString(), j.ToString());
                        el.Attr.ArrowheadAtTarget = ArrowStyle.None;
                    }
                    if (SecondGraph[i][j] != 0)
                    {
                        var el = gr2.AddEdge(i.ToString(), j.ToString());
                        el.Attr.ArrowheadAtTarget = ArrowStyle.None;
                    }
                }
            viewer1.Graph = gr1;
            viewer2.Graph = gr2;
            viewer2.Dock = DockStyle.Right;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[][] Multiply(int[][] Matrix, int[][] SecondMatrix)
            {
                label1.Text = "";
                int n = SecondMatrix.Length;
                int index1 = 0; int index2 = 0;
                int[][] NewMatrix = new int[n][];
                for (int i = 0; i < n; i++)
                    NewMatrix[i] = new int[n];
                int sum;
                for (int s = 0; s < n; s++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        sum = 0;
                        for (int i = 0; i < n; i++)
                        {
                            sum += Matrix[s][i] * SecondMatrix[i][j];

                        }
                        NewMatrix[index1][index2] = sum;
                        index2++;
                    }
                    index2 = 0; index1++;
                }
                return NewMatrix;

            }



            int[][] Copy = new int[n][];
            int[][] SecondCopy = new int[n][];
            for (int i = 0; i < n; i++)
            {
                Copy[i] = new int[n];
                SecondCopy[i] = new int[n];
            }
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Copy[i][j] = GraphMatrix[i][j];
                    SecondCopy[i][j] = SecondGraph[i][j];
                }




            List<List<int>> UniqueVer1 = new List<List<int>>(n);
            List<List<int>> UniqueVer2 = new List<List<int>>(n);
            for (int i = 0; i < n; i++)
            {
                UniqueVer1.Add(new List<int>(n));
                UniqueVer2.Add(new List<int>(n));
            }
            for (int k = 0; k < n; k++)
            {
                Copy = Multiply(GraphMatrix, Copy);
                SecondCopy = Multiply(SecondGraph, SecondCopy);

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        UniqueVer1[i].Add(Copy[i][j]);
                        UniqueVer2[i].Add(SecondCopy[i][j]);

                    }
                    UniqueVer1[i].Sort();
                    UniqueVer2[i].Sort();
                }
            }

            var CompObj = new CustomCompare();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n - 1; j++)
                {
                    if (CompObj.Compare(UniqueVer1[j], UniqueVer1[j + 1]) > 0)
                    {
                        var tmp = UniqueVer1[j];
                        UniqueVer1[j] = UniqueVer1[j + 1];
                        UniqueVer1[j + 1] = tmp;
                    }
                    if (CompObj.Compare(UniqueVer2[j], UniqueVer2[j + 1]) > 0)
                    {
                        var tmp = UniqueVer2[j];
                        UniqueVer2[j] = UniqueVer2[j + 1];
                        UniqueVer2[j + 1] = tmp;
                    }

                }
            for (int i = 0; i < n; i++)
                if (CompObj.Compare(UniqueVer1[i], UniqueVer2[i]) != 0)
                {
                    label1.Text = "NO >:(";
                    label1.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            label1.Text = "YES!";
            label1.ForeColor = System.Drawing.Color.Green;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}