using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Linq;

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

			Task.Factory.StartNew (() => Console.WriteLine ("task starterd"));

			Parallel.Invoke (()=>{}, ()=>{});

			var filter = from i in list.AsParallel() where i > 90 group i by i;

			Console.WriteLine (filter.ToList());

			var asyncResult = asyncCaller ();

			voidasync ();

			Thread.Sleep (100000);
		}

		static void printTime(object state){
			Console.WriteLine ("state is: " + state + " time is: " + DateTime.Now);
		}

		static async Task<int> asyncCaller(){
			var asyncresult = await asyncMet();
			return 23;
		}

		static Task<int> asyncMet(){
			Console.WriteLine ("async manner called");
			return new Task<int>(()=>{return 1;});
		}

		static async void voidasync(){
			Console.WriteLine ("void async");
			await asyncMet ();
		}
	}

}
		