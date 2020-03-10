using System;
using System.IO;

namespace Tubes_2
{
	class Program
	{
        public static void Main()
        {
            ReadFile Read = new ReadFile();
            string t = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            string cur_dir = Directory.GetParent(t).Parent.FullName;
 

            Read.input_1(cur_dir + "\\tubes_2\\input_1.txt");
            Read.input_2(cur_dir + "\\tubes_2\\input_2.txt");

            Graph g = new Graph(Read.getCity(), Read.getPopulation());
            g.BatchEdge(Read.getCityParent(), Read.getCityChild(), Read.getTr());
            g.printNode();
            g.printConnection("AA");
            BFS b = new BFS(g);

            b.run(10, Read.getFirstCity());

        }
    }
}
