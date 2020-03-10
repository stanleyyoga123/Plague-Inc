using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI3
{
    public partial class Form1 : Form
    {
        private Boolean sho = false;
        private Microsoft.Msagl.GraphViewerGdi.GViewer viewer;
        private Microsoft.Msagl.Drawing.Graph graph;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            //create a graph object 
            this.graph = new Microsoft.Msagl.Drawing.Graph("graph");
            //create the graph content 
            //bind the graph to the viewer 

            ReadFile Read = new ReadFile();
            string t = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            string cur_dir = Directory.GetParent(t).Parent.FullName;


            Read.input_1(cur_dir + "\\GUI3\\GUI3\\input_1.txt");
            Read.input_2(cur_dir + "\\GUI3\\GUI3\\input_2.txt");

            Graph g = new Graph(Read.getCity(), Read.getPopulation());
            g.BatchEdge(Read.getCityParent(), Read.getCityChild(), Read.getTr());
            foreach(var a in g.graf)
            {
                foreach (var b in a.Value.getConnection())
                {
                    this.graph.AddEdge(a.Key.ToString(), b.Item1.ToString());
                }
                this.graph.FindNode(a.Key.ToString()).Attr.FillColor = Microsoft.Msagl.Drawing.Color.White;
                    
            }
            this.viewer.Graph = graph;
            this.viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Controls.Add(viewer);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            ReadFile Read = new ReadFile();
            string t = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            string cur_dir = Directory.GetParent(t).Parent.FullName;


            Read.input_1(cur_dir + "\\GUI3\\GUI3\\input_1.txt");
            Read.input_2(cur_dir + "\\GUI3\\GUI3\\input_2.txt");

            Graph g = new Graph(Read.getCity(), Read.getPopulation());
            g.BatchEdge(Read.getCityParent(), Read.getCityChild(), Read.getTr());
            BFS c = new BFS(g);

            Dictionary<char, int> h = c.run(Convert.ToInt32(numericUpDown1.Value), 'A');
            foreach(var he in h)
            {
                if(he.Value >= 0 && he.Value <= 20)
                {
                    this.graph.FindNode(he.Key.ToString()).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                } else
                {
                    this.graph.FindNode(he.Key.ToString()).Attr.FillColor = Microsoft.Msagl.Drawing.Color.White;
                }
            }
            this.viewer.Graph = graph;
            this.viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Controls.Add(this.viewer);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
