using System;
using System.Collections.Generic;

namespace Tubes_2
{
	class BFS
	{
		private Graph g;
		public BFS(Graph g)
		{
			this.g = g;
		}

		public void run(int t, string src)
		{
			Queue<string> q = new Queue<string>();
			Dictionary<string, int> T = new Dictionary<string, int>();
			foreach(var item in this.g.graf)
			{
				if (item.Key == src)
				{
					T.Add(item.Key, 0);
				} else
				{
					T.Add(item.Key, 10000);
				}
			}

			q.Enqueue(src);

			while(q.Count != 0)
			{
				string front = q.Dequeue();
				int t_ = this.g.graf[front].getPopulation();

				foreach(var item in this.g.graf[front].getConnection())
				{
					
					int ans = -1;
					/*Console.WriteLine("Parent: ");
					Console.WriteLine(front);
					Console.WriteLine("Child: ");
					Console.WriteLine(item.Item1);*/
					for (int i = T[front]; i <= t; i++)
					{
						double cek = this.Calc(t_, i - T[front]) * item.Item2;
						/*Console.WriteLine(i);
						Console.WriteLine(cek);*/
						if(cek > 1.0)
						{
							ans = i;
							break;
						}
					}
					if(ans != -1)
					{
						if(ans <= T[item.Item1])
						{
							T[item.Item1] = ans;
							q.Enqueue(item.Item1);
						}
					}				
				}
			}

			foreach(var item in T)
			{
				if(item.Value >= 0 && item.Value <= t)
				{
					Console.WriteLine(item.Key);
				}
				//Console.WriteLine(item.Value);
			}

		}

		private double Calc(int pop, int time)
		{
			double popd = pop;
			double timed = time;

			double denom = 1.0 + (popd - 1.0) * Math.Exp(-0.25 * timed);
			double ans = popd / denom;
			return ans;
		}
	}
}
