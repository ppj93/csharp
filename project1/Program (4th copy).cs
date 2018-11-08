using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;

namespace project1
{
	[Synchronization]
	class MainClass122
	{
		static void Main (string[] args)
		{
			TimerCallback t = new TimerCallback (printTime);
			Timer timer = new Timer (t, null, 0, 10000);

			WaitCallback w = new WaitCallback (state => {
				Console.WriteLine ("state is: " + state);
			});

			for (int i = 0; i < 5; i++)
				ThreadPool.QueueUserWorkItem (w, i); //background thereads with normal priority .. cant change it..

			var list = new List<int> (){ 1, 2, 3, 3, 4 };

			Parallel.ForEach(list, i => Console.WriteLine(i));
			Thread.Sleep (100000);
		}

		static void printTime(object state){
			Console.WriteLine ("state is: " + state + " time is: " + DateTime.Now);
		}
	}

}
		