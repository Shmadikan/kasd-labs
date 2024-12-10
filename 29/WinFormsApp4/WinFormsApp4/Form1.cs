using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Media;
using ConsoleApp2;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;

namespace WinFormsApp4
{
    public partial class Form1 : Form
    {

        enum Colors
        {
            Gray,
            Black,
            White
        }
        static int n;
        static Colors[]? highs;
        static MyVector<MyVector<int>>? Graph;
        static bool Acycle = false;
        static string answer = "";
        static List<string> Nodes = new List<string>();
        Graph graph = new Graph();




        Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
        GViewer viewer2 = new GViewer();
        StatusStrip statusStrip = new StatusStrip();
        StreamReader Reader = new StreamReader("input.txt");
        public Form1()
        {
            InitializeComponent();

            Controls.Add(viewer);
            Controls.Add(viewer2);
        }









        private void gViewer1_Load_1(object sender, EventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = "Удачно";
            label3.BackColor = System.Drawing.Color.Green;
            int n = Convert.ToInt32(Reader.ReadLine());
            highs = new Colors[n];

            Graph = new MyVector<MyVector<int>>(n);
            for (int i = 0; i < n; i++)
            {
                Graph.Add(new MyVector<int>());
                highs[i] = Colors.White;
            }
            string line = Reader.ReadLine();
            while (line != "" && line != null)
            {
                string[] numbers = line.Split(" ");

                int num1 = Convert.ToInt32(numbers[0]);
                int num2 = Convert.ToInt32(numbers[1]);
                Graph[num1].Add(num2);
                line = Reader.ReadLine();
            }

            for (int i = 0; i < n; i++)
            {
                graph.AddNode(i.ToString());

            }
            for (int i = 0; i < n; i++)
            {
                var iter = Graph[i].Iterator();
                while (iter.HasNext())
                {
                    var ed = graph.AddEdge(i.ToString(), iter.Next().ToString());
                    
                }
            }
            Graph gr = new Graph();

            gr.Attr.LayerDirection = LayerDirection.LR;

            viewer2.Dock = DockStyle.Right;
            viewer.Graph = graph;
            viewer.Dock = DockStyle.Right;
            DFS(3);
            if (Acycle)
            {
                Console.WriteLine("CYCLE");
                label3.Text = "Неудача!";
                label3.ForeColor = label3.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                Console.WriteLine("NOT CYCLE");
                Console.WriteLine(answer);
                for (int i = 0; i < n; i++)
                    gr.AddNode(i.ToString());
                Nodes.Reverse();
                for (int i = 0; i < n - 1; i++)
                    gr.AddEdge(Nodes[i], Nodes[i + 1]);
                viewer2.Graph = gr;
            }

        }


        void DFS(int v)
        {
            if (highs[v] == Colors.Black)
                return;
            if (highs[v] == Colors.Gray)
            {
                Acycle = true;
                return;
            }
            highs[v] = Colors.Gray;
            for (int i = 0; i < Graph[v].Size(); i++)
                DFS(Graph[v][i]);

            answer = " " + v.ToString() + answer;
            Nodes.Add(v.ToString());
            highs[v] = Colors.Black;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}