/*

using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitDemo
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("1");
			Task.Run (() => Method ()).Wait ();
			//Task.Run (() => Method ());
			//Method();
			Console.WriteLine ("2");
			Console.WriteLine ();

		}
		public async static Task<string> Method()
		{
			Console.WriteLine ("Here is Method");
			var worker = new Worker ();

//			Task<string> tsk = worker.DoSomething ();
//			string result = await tsk;
//			Console.WriteLine (result);
//			return result;


			worker.StringReaded += (object sender, StringReadedEventArgs e) => {
				Console.WriteLine(e.RemoteResult);
			};

			await worker.DoSomething ();

			return "";
		}
	}

	public class Worker
	{
		public async Task<string> DoSomething()
		{
			await Task.Delay (2000);

			var resultString = @"Test";

			EventHandler<StringReadedEventArgs> handler = StringReaded;
			var args = new StringReadedEventArgs{ RemoteResult = resultString };
			if(null != handler)
			{
				handler (this, args);
			}


			return await Task.Run (() => resultString);
		}

		public event EventHandler<StringReadedEventArgs> StringReaded;
	}

	public class StringReadedEventArgs : EventArgs
	{
		public string RemoteResult { get; set; }

		public StringReadedEventArgs()
		{
			RemoteResult = "HeHe this is RemoteResultString";
		}
	}
}
*/