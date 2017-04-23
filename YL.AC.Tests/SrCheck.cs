using System;

namespace YL.AC.Tests
{
	public class SrCheck
	{
		internal int Position { get; private set; }

		internal int PatternIndex { get; private set; }

		internal string Match { get; private set; }

		internal SrCheck(int position, int patternIndex, string match)
		{
			Position = position;
			PatternIndex = patternIndex;
			Match = match;
		}
	}
}