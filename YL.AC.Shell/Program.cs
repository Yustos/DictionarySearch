using System;
using System.IO;
using System.Collections.Generic;

namespace YL.AC.Shell
{
	class Program
	{
		static void Main(string[] args)
		{
			var stream = Console.In;
			Console.WriteLine("Start");
			Console.WriteLine("Patterns:");
			var patterns = new List<string>();
			string patternLine;
			while (!string.IsNullOrEmpty(patternLine = stream.ReadLine()))
			{
				patterns.Add(patternLine);
			}

			Console.WriteLine("String:");
			var line = stream.ReadLine();
			var result = Search.Find(line, patterns);
			foreach (var r in result)
			{
				Console.WriteLine("{0}: {1} [{2}]", r.Position, r.Match, r.PatternIndex);
			}
			Console.WriteLine("Finish");
		}
	}
}
