using System;

namespace YL.AC
{
	public class Node
	{
		public readonly char C;

		public readonly Node[] Childrens = new Node[10];

		public bool IsTerminal;

		public Node SuffixLink = null;

		public Node Parent = null;

		public Node[] Move = new Node[10];

		public Node SuffixMoveLink;

		public Node(char c, Node parent)
		{
			C = c;
			Parent = parent;
		}

		public void Add(string s)
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
		}

		public bool IsString(string s)
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
