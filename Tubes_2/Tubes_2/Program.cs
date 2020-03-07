using System;

namespace Tubes_2
{
	class Program
	{
        public static void Main()
        {
            ReadFile Read = new ReadFile();
            Read.input_1("E:\\Learning\\semester_4\\stima\\tubes2\\ConsoleApp1\\ConsoleApp1\\input_1.txt");
            Read.input_2("E:\\Learning\\semester_4\\stima\\tubes2\\ConsoleApp1\\ConsoleApp1\\input_2.txt");

            Graph g = new Graph(Read.getCity(), Read.getPopulation());
            g.BatchEdge(Read.getCityParent(), Read.getCityChild(), Read.getTr());
            g.printNode();
        }
    }
}
