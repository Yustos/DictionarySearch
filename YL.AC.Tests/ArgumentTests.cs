using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YL.AC.Tests
{
	[TestClass]
	public class ArgumentTests
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ArgumentTextCheckTest()
		{
			Search.Find(null, new string[]{});
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ArgumentPatternsCheckTest()
		{
			Search.Find("input", null);
		}
	}
}