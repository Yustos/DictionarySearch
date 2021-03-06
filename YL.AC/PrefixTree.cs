using System;
using System.Collections.Generic;

namespace YL.AC
{
	internal class PrefixTree
	{
		private readonly Node _root;
		private readonly List<string> _patterns = new List<string>();

		internal PrefixTree(IEnumerable<string> patterns)
		{
			_root = new Node('_', null);
			foreach (var pattern in patterns)
			{
				_root.Add(pattern, _patterns.Count);
				_patterns.Add(pattern);
			}
		}

		internal IEnumerable<SearchResult> FindAll(string s)
		{
			var u = _root;
			for(int i = 0; i < s.Length; i++){
				u = GetMove(u, s[i]);
				foreach (var sr in Find(u, i+1))
				{
					yield return sr;
				}
			}
		}

		private IEnumerable<SearchResult> Find(Node v, int i)
		{
			for (var u = v; u != _root; u = GetSuffixMoveLink(u))
			{
				if (u.IsTerminal)
				{
					var match = _patterns[u.PatternIndex];
					yield return new SearchResult(i - match.Length, u.PatternIndex, match);
				}
			}
		}

		private Node GetSuffixLink(Node node)
		{
			if (node.SuffixLink == null)
			{
				if (node == _root || node.Parent == _root)
				{
					node.SuffixLink = _root;
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
			if (!node.Move.TryGetValue(c, out Node nextMove))
			{
				if (node.Childrens.TryGetValue(c, out Node nextNode))
				{
					nextMove = nextNode;
				}
				else
				{
					if (node == _root)
					{
						nextMove = _root;
					}
					else
					{
						nextMove = GetMove(GetSuffixLink(node), c);
					}
				}
			}
			node.Move[c] = nextMove;
			return nextMove;
		}

		private Node GetSuffixMoveLink(Node node)
		{
			if (node.SuffixMoveLink == null)
			{
				var u = GetSuffixLink(node);
				if (u == _root)
				{
					node.SuffixMoveLink = _root;
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