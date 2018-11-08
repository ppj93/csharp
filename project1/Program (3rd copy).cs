using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;

namespace project1
{
	[Synchronization]
	class MainClass12
	{
		class Flag {
			public bool k { get; set;}
		}

		static Flag l = new Flag(){k= false};
		static void Main (string[] args)
		{
			var x = new List<Thread> ();
				
			for (int i = 0; i < 4; i++) {
				var t = new Thread (new ThreadStart (printNumLock));
				t.Start ();
				x.Add (t);
			}


			foreach (Thread a in x)
				a.Join ();

			x.Clear ();

			Console.WriteLine ("\n");

			for (int i = 0; i < 4; i++) {
				var t = new Thread (new ThreadStart (printNum));
				t.Start ();
				x.Add (t);
			}	

			foreach (Thread a in x)
				a.Join ();

			x.Clear ();

			Console.WriteLine ("\n");


			for (int i = 0; i < 2; i++) {
				var t = new Thread (new ParameterizedThreadStart (printMonitorComplex));
				t.Name = i.ToString ();
				t.Start (i);
				x.Add (t);
			}	

			foreach (Thread a in x)
				a.Join ();

			x.Clear ();

			Console.WriteLine ("\n");

			int operated = 1;
			Interlocked.Decrement (ref operated);

			Interlocked.Increment (ref operated);

			Interlocked.CompareExchange (ref operated, 122, 1);

			Interlocked.Exchange (ref operated, 11);


		}

		public static void printNum ()
		{
			for (int i = 0; i < 10; i++)
				Console.Write (i);
		}

		public static void printNumLock ()
		{
			lock (l) {
				for (int i = 0; i < 10; i++)
					Console.Write (i);
			}
		}

		static void printMonitor ()
		{
			Monitor.Enter (l);

			try {
				for (int i = 0; i < 10; i++)
					Console.Write (i);
			} catch (Exception e) {
				
			} finally {
				Monitor.Exit (l);
			}
		}

		static void printMonitorComplex (object t)
		{
			int type = (int)t;

			Monitor.Enter (l);

			if (type == 1 && !l.k) {
				Monitor.Wait (l);
			}
			else
			{
				l.k = true;
			}


			for (int i = 0; i < 10; i++) {
					
				if (i % 2 == type) {
					Console.WriteLine (Thread.CurrentThread.Name + "-->" + i);
				}

				Monitor.Pulse (l);
				Monitor.Wait (l);
			}

			Monitor.PulseAll (l);
			Monitor.Exit (l);

		}
	}
}
		