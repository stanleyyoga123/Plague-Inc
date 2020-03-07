using System;
using System.Collections.Generic;

namespace Tubes_2
{
    class Graph
    {
        Dictionary<char, City> graf;

        public Graph(char[] node, int[] population)
        {
            int i;
            graf = new Dictionary<char, City>();
            for (i = 0; i < node.Length; i++)
            {
                graf.Add(node[i], new City(population[i]));
            }
        }

        public void BatchEdge(char[] City1, char[] City2, float[] weight)
        {
            for (int i = 0; i < City1.Length; i++)
            {
                this.AddEdge(City1[i], City2[i], weight[i]);
            }
        }

        public void AddEdge(char City1, char City2, float weight)
        {
            if (graf.ContainsKey(City1))
            {
                graf[City1].addConnection(City2, weight);
            }
        }

        public void printNode()
        {
            foreach (char c in this.graf.Keys)
            {
                Console.Write(c);
                Console.Write(" ");
            }
            Console.WriteLine();
        }

        public void printConnection(char city)
        {
            this.graf[city].printConnection();
        }

        public List<char> getConnection(char city)
        {
            return this.graf[city].getConnection();
        }

        public float getWeight(char city1, char city2)
        {
            return this.graf[city1].getWeight(city2);
        }

    }
}