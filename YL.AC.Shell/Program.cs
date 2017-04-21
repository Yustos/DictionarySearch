using System;
using System.IO;

namespace YL.AC.Shell
{
	class Program
	{
		static void Main(string[] args)
		{
			var stream = Console.In;
			Console.WriteLine("Start");
			Console.WriteLine("Patterns:");
			var root = new Node('_', null);
			string patternLine;
			while (!string.IsNullOrEmpty(patternLine = stream.ReadLine()))
			{
				root.Add(patternLine);
			}

			Console.WriteLine("String:");
			var line = stream.ReadLine();
			var pt = new PrefixTree(root);
			var count = pt.CountAllPositions(line);
			Console.WriteLine(count);
			Console.WriteLine("Finish");
		}
	}
}
