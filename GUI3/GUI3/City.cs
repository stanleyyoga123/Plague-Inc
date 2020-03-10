using System;
using System.Collections.Generic;

namespace GUI3
{
	public class City
	{
		int population;
		List<Tuple<string, double>> connection;

		public City()
		{
			this.population = 0;
			connection = new List<Tuple<string, double>>();
		}
		public City(int population)
		{
			this.population = population;
			connection = new List<Tuple<string, double>>();
		}

		public int getPopulation()
		{
			return this.population;
		}

		public void addConnection(string city, double weight)
		{
			this.connection.Add(new Tuple<string, double>(city, weight));
		}

		public void printConnection()
		{
			foreach (var c in connection)
			{
				Console.Write(c.Item1);
				Console.Write(" ");
			}
			Console.WriteLine();
		}

		public void printWeight()
		{
			foreach (var c in connection)
			{
				Console.Write(c.Item2);
				Console.Write(" ");
			}
			Console.WriteLine();
		}

		public double getWeight(string city)
		{
			foreach (var c in this.connection)
			{
				if (c.Item1 == city)
				{
					return c.Item2;
				}
			}
			return -999;
		}

		public List<Tuple<string, double>> getConnection()
		{
			/*List<char> ret = new List<char>();
			foreach (var c in connection)
			{
				ret.Add(c.Item1);
			}
			return ret;*/
			return this.connection;
		}
	}

}