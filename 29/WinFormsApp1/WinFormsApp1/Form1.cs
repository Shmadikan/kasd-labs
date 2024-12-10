using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        GViewer viewer = new GViewer();
        public Form1()
        {
            
            InitializeComponent();
            ResumeLayout();
        }

        private void gViewer1_Load(object sender, EventArgs e)
        {
            Graph graph = new Graph();
            graph.AddNode("A");
            graph.AddNode("B");
            viewer.Graph = graph;
        }
    }
}