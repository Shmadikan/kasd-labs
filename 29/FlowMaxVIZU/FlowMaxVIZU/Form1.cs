using Microsoft.Msagl;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;

namespace FlowMaxVIZU
{
    public partial class Form1 : Form
    {
        int n;
        StreamReader reader = new StreamReader("input.txt");
        List<List<int>> c;
        GViewer viewer = new GViewer();
        Graph graph;
        public Form1()
        {

            InitializeComponent();
            Controls.Add(viewer);
        }

        private void gViewer1_Load(object sender, EventArgs e)
        {
            graph = new Graph();
            graph.Attr.LayerDirection = LayerDirection.LR;
            n = Convert.ToInt32(reader.ReadLine());
            c = new List<List<int>>(n);
            init(c, n);
            string line = reader.ReadLine();
            while (line != null && line != "")
            {
                string[] args = line.Split(" ");
                int ver1 = Convert.ToInt32(args[0]);
                int ver2 = Convert.ToInt32(args[1]);
                int Wes = Convert.ToInt32(args[2]);
                c[ver1][ver2] = Wes;
                graph.AddNode(ver1.ToString());
                graph.AddNode(ver2.ToString());
                var el = graph.AddEdge(ver1.ToString(), ver2.ToString());
                el.LabelText = Wes.ToString();
                line = reader.ReadLine();
            }
            viewer.Dock = DockStyle.Fill;

            viewer.Graph = graph;



        }


        void init(List<List<int>> lst, int n)
        {
            for (int i = 0; i < n; i++)
            {
                List<int> ints = new List<int>(n);
                for (int j = 0; j < n; j++)
                    ints.Add(0);
                lst.Add(ints);
            }
        }
        void initOther(List<int> lst, int n)
        {
            for (int i = 0; i < n; i++)
                lst.Add(0);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<List<int>> f = new List<List<int>>(n);
            init(f, n);
            for (int i = 1; i < n; i++)
            {
                f[0][i] = c[0][i];
                f[i][0] = -c[0][i];
            }
            List<int> h = new List<int>(n);
            initOther(h, n);
            h[0] = n;
            List<int> e1 = new List<int>(n);
            initOther(e1, n);
            for (int i = 1; i < n; i++)
                e1[i] = f[0][i];
            for (; ; )
            {
                int i;
                for (i = 1; i < n - 1; i++)
                {
                    if (e1[i] > 0)
                        break;

                }
                if (i == n - 1)
                    break;
                int j;
                for (j = 0; j < n; j++)
                    if (c[i][j] - f[i][j] > 0 && h[i] == h[j] + 1)
                        break;
                if (j < n)
                    Push(i, j, f, e1, c);
                else
                    Lift(i, h, f, c);
            }
            int flow = 0;
            for (int i = 0; i < n; i++)
                if (c[0][i] > 0)
                    flow += f[0][i];

            label1.Text = "Макс поток:" + flow.ToString();

            foreach (var el in graph.Edges) {
                el.LabelText = $"/{el.LabelText}";
            
            }

        }



        void Push(int u, int v, List<List<int>> f, List<int> e, List<List<int>> c)
        {
            int d = Math.Min(e[u], c[u][v] - f[u][v]);
            f[u][v] += d;
            f[v][u] = -f[u][v];
            e[u] -= d;
            e[v] += d;


        }

        void Lift(int u, List<int> h, List<List<int>> f, List<List<int>> c)
        {
            int d = int.MaxValue;
            for (int i = 0; i < f.Count; i++)
                if (c[u][i] - f[u][i] > 0)
                    d = Math.Min(d, h[i]);
            if (d == int.MaxValue)
                return;
            h[u] = d + 1;



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}