using System;

namespace YL.AC
{
	internal class Node
	{
		internal readonly char C;

		internal readonly Node[] Childrens = new Node[10];

		internal bool IsTerminal;

		internal int PatternIndex;

		internal Node SuffixLink = null;

		internal Node Parent = null;

		internal Node[] Move = new Node[10];

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
				var idx = c - '0';
				var nextNode = node.Childrens[idx];
				if (nextNode == null)
				{
					nextNode = new Node(c, node);
					node.Childrens[idx] = nextNode;
				}
				node = nextNode;
			}
			node.IsTerminal = true;
			node.PatternIndex = patternIndex;
		}

		internal bool IsString(string s)
		{
			var node = this;
			foreach (var c in s)
			{
				var idx = c - '0';
				var nextNode = node.Childrens[idx];
				if (nextNode != null)
				{
					node = nextNode;
				}
				else
				{
					return false;
				}
			}
			return node.IsTerminal;
		}
	}
}
