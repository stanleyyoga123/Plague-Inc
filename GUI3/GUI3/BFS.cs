using System;
using System.Collections.Generic;

namespace GUI3
{
	class BFS
	{
		/* pre digunakan untuk menyimpan previous city yang berhasil menginfeksi city yang dipilih */
		private Dictionary<string, string> pre;

		/* g merupakan variabel Graph yg akan ditelusuri menggunakan BFS */
		private Graph g;
		
		/* Konstruktor class BFS */
		public BFS(Graph g)
		{
			this.g = g;
		}

		/* method utility untuk menjalankan BFS dari source -> src */
		public Dictionary<string, int> run(int t, string src)
		{
			this.pre = new Dictionary<string, string>();
			Queue<string> q = new Queue<string>();
			Dictionary<string, int> T = new Dictionary<string, int>();

			/* Inisialisasi nilai T dengan nilai yang besar, kecuali source dimana T[src] = 0 */
			foreach (var item in this.g.graf)
			{
				if (item.Key == src)
				{
					T.Add(item.Key, 0);
				}
				else
				{
					T.Add(item.Key, 10000);
				}
			}

			/* Previous dari source adalah -1 */
			this.pre[src] = "-1";

			q.Enqueue(src);

			/* Algoritma BFS */
			while (q.Count != 0)
			{
				string front = q.Dequeue();
				int t_ = this.g.graf[front].getPopulation();

				foreach (var item in this.g.graf[front].getConnection())
				{

					int ans = -1;
					for (int i = T[front]; i <= t; i++)
					{
						double cek = this.Calc(t_, i - T[front]) * item.Item2;
						if (cek > 1.0)
						{
							ans = i;
							break;
						}
					}
					if (ans != -1)
					{
						if (ans <= T[item.Item1])
						{
							T[item.Item1] = ans;
							this.pre[item.Item1] = front;
							q.Enqueue(item.Item1);
						}
					}
				}
			}

			return T;
		}

		/* method utility untuk mengembalikan previous */
		public Dictionary<string, string> getPre()
		{
			return this.pre;
		}

		/* method untuk menghitung fungsi logistik */
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
