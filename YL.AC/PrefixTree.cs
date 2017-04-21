using System;

namespace YL.AC
{
	public class PrefixTree
	{
		private readonly Node Root;

		public PrefixTree(Node root)
		{
			Root = root;
		}

		public long CountAllPositions(string s)
		{
			var count = 0L;
			var u = Root;
			for(int i=0;i<s.Length;i++){
				u= GetMove(u, s[i]);
				count += Count(u, i+1);
			}
			return count;
		}

		private long Count(Node v, int i)
		{
			var count = 0L;
			for (var u = v; u != Root; u = GetSuffixMoveLink(u))
			{
				if (u.IsTerminal)
				{
					count++;
				}
			}
			return count;
		}

		private Node GetSuffixLink(Node node)
		{
			if (node.SuffixLink == null)
			{
				if (node == Root || node.Parent == Root)
				{
					node.SuffixLink = Root;
				}
				else
				{
					node.SuffixLink = GetMove(GetSuffixLink(node.Parent), node.C);
				}
			}
			return node.SuffixLink;
		}

		private Node GetMove(Node node, char c)
		{
			var idx = c - '0';
			if (node.Move[idx] == null)
			{
				if (node.Childrens[idx] != null)
				{
					node.Move[idx] = node.Childrens[idx];
				}
				else
				{
					if (node == Root)
					{
						node.Move[idx] = Root;
					}
					else
					{
						node.Move[idx] = GetMove(GetSuffixLink(node), c);
					}
				}
			}
			return node.Move[idx];
		}

		private Node GetSuffixMoveLink(Node node)
		{
			if (node.SuffixMoveLink == null)
			{
				var u = GetSuffixLink(node);
				if (u == Root)
				{
					node.SuffixMoveLink = Root;
				}
				else
				{
					node.SuffixMoveLink = u.IsTerminal ? u : GetSuffixMoveLink(u);
				}
			}
			return node.SuffixMoveLink;
		}


	}
}