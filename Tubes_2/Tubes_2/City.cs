using System;
using System.Collections.Generic;

namespace Tubes_2
{
	public class City
	{
		int population;
		List<Tuple<char, float>> connection;

		public City()
		{
			this.population = 0;
			connection = new List<Tuple<char, float>>();
		}
		public City(int population)
		{
			this.population = population;
			connection = new List<Tuple<char, float>>();
		}

		public void addConnection(char city, float weight)
		{
			this.connection.Add(new Tuple<char, float>(city, weight));
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

		public float getWeight(char city)
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

		public List<char> getConnection()
		{
			List<char> ret = new List<char>();
			foreach (var c in connection)
			{
				ret.Add(c.Item1);
			}
			return ret;
		}
	}

}