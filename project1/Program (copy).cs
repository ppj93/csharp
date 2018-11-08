using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace project1
{
	class MainClass1
	{
		delegate int addMet(int x, int y);

		static AutoResetEvent autoResetEvent = new AutoResetEvent (false);

		public static void Main1 (string[] args)
		{
			Console.WriteLine (System.Threading.Thread.CurrentThread);
			Console.WriteLine (System.Threading.Thread.CurrentContext);
			Console.WriteLine (System.Threading.Thread.CurrentPrincipal);
			Console.WriteLine (Thread.GetDomainID());
			Thread.Sleep(200);

			var currentThread = Thread.CurrentThread;
			ext.WriteLineAll (currentThread.Name, 
				currentThread.Priority, currentThread.IsAlive, 
				currentThread.IsBackground, Thread.GetDomain().FriendlyName);

			var t = new Thread(new ThreadStart(printNums));
			t.IsBackground = true;
			t.Start ();


			var t1 = new Thread (new ParameterizedThreadStart(add));
			t1.IsBackground = true;
			t1.Start (12);


			var resetHandlerThread = new Thread (new ThreadStart (autoresetex));
			resetHandlerThread.IsBackground = true;
			resetHandlerThread.Start ();
			/* beterr then wait beause parallell 
			 * threasd can just notify this thread when serial tasks are 
			 * done and both can carry on... Simple Wait() waits for the complete 
			 * thread to compete... which is not what we want */
			autoResetEvent.WaitOne ();

			Thread.CurrentThread.IsBackground = true;

		}

		static void printNums(){
			for (var i = 0; i < 122; i++)
				Console.Write (i);
		}

		static void add(object o){
			Console.Write("\n" + (int)(o));
		}

		static void autoresetex(){
			//do blocking atsks
			autoResetEvent.Set();
		}
	}

	public static class ext {
		public static void WriteLineAll(params object[] objs){
			foreach (var x in objs)
				Console.WriteLine (x);
		}
	}
}
		