using System;
using System.Threading;
using System.Threading.Tasks;

using System.Net;

namespace AsyncAwaitDemo
{
	class MainClass
	{
		private static WebClient WebWorker { get; set; }
		private static Worker worker { get; set; }


		public static void Main (string[] args)
		{
//			Console.WriteLine ("1");
			worker = new Worker();
			WebWorker = new WebClient ();
//			var worker = new Worker ();
			worker.StringReaded += (object sender, StringReadedEventArgs e) => {
				Console.WriteLine("1");
				Console.WriteLine(e.RemoteResult);
			};

			//string html = WebWorker.DownloadString (@"http://www.google.com");
			//Console.WriteLine (html);

			//Task.Run (() => Method ()).Wait ();
			Task.Run (() => Method ());
			//Method();
			Console.WriteLine ("2");
			//Console.WriteLine ();

		}
		public async static Task<string> Method()
		{
			Task.Delay (2000);
			Console.WriteLine ("3");
//			var worker = new Worker ();
			/*
			Task<string> tsk = worker.DoSomething ();
			string result = await tsk;
			Console.WriteLine (result);
			return result;
			*/

//			worker.StringReaded += (object sender, StringReadedEventArgs e) => {
//				Console.WriteLine(e.RemoteResult);
//			};

			await worker.DoSomething ();

			return "";
		}
	}

	public class Worker
	{
		public async Task<string> DoSomething()
		{
			Task.Delay (2000);
			Console.WriteLine ("4");
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
//			RemoteResult = "HeHe this is RemoteResultString";
			//Console.WriteLine("StringReaderEventArgs");
		}
	}
}
