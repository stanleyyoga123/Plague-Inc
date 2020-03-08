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

		public void run(int t, char src)
		{
			Queue<char> q = new Queue<char>();
			Dictionary<char, int> T = new Dictionary<char, int>();
			Dictionary<char, int> vis = new Dictionary<char, int>(); 
			foreach(var item in this.g.graf)
			{
				if (item.Key == src)
				{
					T.Add(item.Key, 0);
					vis.Add(item.Key, 1);
				} else
				{
					T.Add(item.Key, 10000);
					vis.Add(item.Key, 0);
				}
			}

			q.Enqueue(src);

			while(q.Count != 0)
			{
				char front = q.Dequeue();
				int t_ = this.g.graf[front].getPopulation();

				foreach(var item in this.g.graf[front].getConnection())
				{
					if (vis[item.Item1] == 0)
					{
						vis[item.Item1] = 1;
						int ans = -1;
						for (int i = T[front]; i <= t; i++)
						{
							double cek = this.Calc(t_, i) * item.Item2;
							if(cek > 1.0)
							{
								ans = i;
								break;
							}
						}
						if(ans != -1)
						{
							T[item.Item1] = Math.Min(T[item.Item1], ans);
						}
						q.Enqueue(item.Item1);
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
