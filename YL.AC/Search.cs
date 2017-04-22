using System;
using System.Collections.Generic;

namespace YL.AC
{
	public static class Search
	{
		public static IEnumerable<SearchResult> Find(string text, IEnumerable<string> patterns)
		{
			var pt = new PrefixTree(patterns);
			return pt.FindAll(text);
		}
	}
}