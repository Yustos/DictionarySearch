using System;
using System.Collections.Generic;

namespace YL.AC.Tests
{
	public static class Helpers
	{
		public static bool SeqEqual(this IEnumerable<SearchResult> first, IEnumerable<SrCheck> second)
		{
			var fen = first.GetEnumerator();
			var sen = second.GetEnumerator();
			while (true)
			{
				var fn = fen.MoveNext();
				var sn = sen.MoveNext();
				if (!fn && !sn)
				{
					return true;
				}
				if (fn != sn)
				{
					return false;
				}
				var f = fen.Current;
				var s = sen.Current;
				if (f.Position != s.Position
					|| f.Match != s.Match
					|| f.PatternIndex != s.PatternIndex)
				{
					return false;
				}
			}
		}
	}
}