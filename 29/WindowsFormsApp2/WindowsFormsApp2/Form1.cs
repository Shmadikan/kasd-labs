using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new GViewer();
        
        StatusStrip statusStrip = new StatusStrip();
        ToolTip tt = new ToolTip();
        public Form1()
        {
            InitializeComponent();
           
            SuspendLayout();
            ToolStripItem toolStripLabel = new ToolStripStatusLabel();
            statusStrip.Items.Add(toolStripLabel);
            Controls.Add(statusStrip);
            ResumeLayout();

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Graph graph = new Graph();
            
        }

        private void gViewer1_Load(object sender, EventArgs e)
        {
            Graph graph = new Graph();
            graph.AddNode("1");
            graph.AddNode("2");
            graph.AddEdge("1", "2");
            viewer.Graph = graph;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
