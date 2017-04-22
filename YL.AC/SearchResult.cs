using System;

namespace YL.AC
{
	public class SearchResult
	{
		public int Position { get; private set; }

		public int PatternIndex { get; private set; }

		public string Match { get; private set; }

		internal SearchResult(int position, int patternIndex, string match)
		{
			Position = position;
			PatternIndex = patternIndex;
			Match = match;
		}
	}
}