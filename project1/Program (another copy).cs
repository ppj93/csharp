using System;
using System.Runtime.Remoting.Messaging;

namespace project1
{
	class MainClass2
	{
		delegate int addMet(int x, int y);

		public static void Main1 (string[] args)
		{
			addMet x = (x1, y)=>x1+y;
			var asdfadf = x.BeginInvoke (12, 12, ass => {
				Console.Write ("adsfasdf " + ass.AsyncState);

				var u = ((AsyncResult)ass).AsyncDelegate;

				var originalDelegate = (addMet)u;


				Console.WriteLine("result is: " + originalDelegate.EndInvoke(ass));

			}, 333);

			while (!asdfadf.AsyncWaitHandle.WaitOne (1)) {
				Console.WriteLine ("asdfasdf not yet done");
			}
		}

	}
}
		