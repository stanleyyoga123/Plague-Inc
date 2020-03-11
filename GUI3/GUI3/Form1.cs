using System;
using System.IO;
using System.Collections;
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
            this.panel1.Controls.Add(viewer);

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

            Dictionary<string, int> h = c.run(Convert.ToInt32(numericUpDown1.Value), Read.getFirstCity());
            Dictionary<string, string> pre = c.getPre();
            string rute = "";
            foreach (var he in h)
            {
                if (pre.ContainsKey(he.Key))
                {
                    string ptr = he.Key;
                    ArrayList hasil = new ArrayList();
                    while (ptr != "-1")
                    {
                        hasil.Add(ptr);
                        ptr = pre[ptr];
                    }
                    hasil.Reverse();
                    string gg = "";
                    int si = hasil.Count;
                    for (int i = 0; i < si; i++)
                    {
                        if (i != si - 1)
                        {
                            gg += hasil[i];
                            gg += "->";
                        }
                        else
                        {
                            gg += hasil[i];
                            gg += "\n";
                        }
                    }
                    rute += gg;
                    if (he.Value >= 0 && he.Value <= 20)
                    {
                        this.graph.FindNode(he.Key.ToString()).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                    }
                    else
                    {
                        this.graph.FindNode(he.Key.ToString()).Attr.FillColor = Microsoft.Msagl.Drawing.Color.White;
                    }
                }
                this.label1.Text = rute;
                this.viewer.Graph = graph;
                this.viewer.Dock = System.Windows.Forms.DockStyle.Fill;
                this.panel1.Controls.Add(this.viewer);

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
