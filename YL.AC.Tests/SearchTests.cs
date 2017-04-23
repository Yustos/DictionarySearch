using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;

namespace YL.AC.Tests
{
	[TestClass]
	public class SearchTests
	{
		[TestMethod]
		public void SearchTest()
		{
			var result = Search.Find("input", new [] { "inp", "ut" });
			Assert.IsTrue(result.SeqEqual(new SrCheck [] {
				new SrCheck(0, 0, "inp"),
				new SrCheck(3, 1, "ut")
			}));
			Assert.IsFalse(result.SeqEqual(new SrCheck [] {
				new SrCheck(0, 0, "fail")
			}));
		}

		[TestMethod]
		public void SearchEmptyTest()
		{
			var result = Search.Find("input", new [] { string.Empty });
			Assert.IsTrue(result.SeqEqual(new SrCheck [] {}));
		}

		[TestMethod]
		public void SearchNullTest()
		{
			var result = Search.Find("input", new string[] { null });
			Assert.IsTrue(result.SeqEqual(new SrCheck [] {}));
		}

		[TestMethod]
		public void SearchNullPatternTest()
		{
			var result = Search.Find("input", new [] { "inp", null, "ut" });
			Assert.IsTrue(result.SeqEqual(new SrCheck [] {
				new SrCheck(0, 0, "inp"),
				new SrCheck(3, 2, "ut")
			}));
		}
	}
}
