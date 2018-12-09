using System;

namespace project1
{
	class MainClass5
	{
		public double this[int index] {
			get{ return new Random().NextDouble(); }
		}

		delegate int addMet(int x, int y);
		static event addMet kl;

		public static void Main1(string[] args)
		{
			Console.WriteLine (new MainClass5 () [11]);
			addMet n = new addMet(delegate(int x, int y) {
				return x+y;
			});

			addMet x11 = (u, y)=>{return u-y;};
			Console.WriteLine(n.Invoke (1,2));
			Console.WriteLine (x11.Invoke (1, 2));

			Action<int> uu = u => {Console.WriteLine(u);};

			uu (122);

			Func<int, int, string> jjj = (u, s) => {
				return s.ToString();
			};

			foreach (var d in n.GetInvocationList()) {
				Console.WriteLine (d.Method);
				Console.WriteLine (d.Target);
			}

			kl += (x, y) => x+y;

			kl.Invoke (00, 99);
		}

	}
}
		