using System;
using System.Collections.Generic;

namespace YL.AC
{
	internal class Node
	{
		internal readonly char C;

		internal readonly Dictionary<char, Node> Childrens = new Dictionary<char, Node>();

		internal bool IsTerminal;

		internal int PatternIndex;

		internal Node SuffixLink = null;

		internal Node Parent = null;

		internal Dictionary<char, Node> Move = new Dictionary<char, Node>();

		internal Node SuffixMoveLink;

		internal Node(char c, Node parent)
		{
			C = c;
			Parent = parent;
		}

		internal void Add(string s, int patternIndex)
		{
			var node = this;
			foreach (var c in s)
			{
				if (!node.Childrens.TryGetValue(c, out Node nextNode))
				{
					nextNode = new Node(c, node);
					node.Childrens[c] = nextNode;
				}
				node = nextNode;
			}
			node.IsTerminal = true;
			node.PatternIndex = patternIndex;
		}
	}
}
