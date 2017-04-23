using System;
using System.Collections.Generic;

namespace YL.AC
{
	public static class Search
	{
		public static IEnumerable<SearchResult> Find(string text, IEnumerable<string> patterns)
		{
			if (text == null)
			{
				throw new ArgumentNullException("text");
			}
			if (patterns == null)
			{
				throw new ArgumentNullException("patterns");
			}
			var pt = new PrefixTree(patterns);
			return pt.FindAll(text);
		}
	}
}