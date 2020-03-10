using System;
using System.Collections.Generic;

namespace Tubes_2
{
    class Graph
    {
        public Dictionary<string, City> graf;

        public Graph(string[] node, int[] population)
        {
            int i;
            graf = new Dictionary<string, City>();
            for (i = 0; i < node.Length; i++)
            {
                graf.Add(node[i], new City(population[i]));
            }
        }

        public void BatchEdge(string[] City1, string[] City2, double[] weight)
        {
            for (int i = 0; i < City1.Length; i++)
            {
                this.AddEdge(City1[i], City2[i], weight[i]);
            }
        }

        public void AddEdge(string City1, string City2, double weight)
        {
            if (graf.ContainsKey(City1))
            {
                graf[City1].addConnection(City2, weight);
            }
        }

        public void printNode()
        {
            foreach (string c in this.graf.Keys)
            {
                Console.Write(c);
                Console.Write(" ");
            }
            Console.WriteLine();
        }

        public void printConnection(string city)
        {
            this.graf[city].printConnection();
        }

        public List<Tuple<string, double>> getConnection(string city)
        {
            return this.graf[city].getConnection();
        }

        public double getWeight(string city1, string city2)
        {
            return this.graf[city1].getWeight(city2);
        }

    }
}