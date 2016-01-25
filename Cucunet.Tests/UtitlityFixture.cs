using NUnit.Framework;
using CuNS = Cucunet;
using System.Text.RegularExpressions;
using System.Linq;
using System.Reflection;

namespace Cucunet.Tests
{
	public class UtitlityFixture
	{
		[Test]
		[Category ("Utilities")]
		public void CanNotInvokeDecoupledMethods ()
		{
			var t = GetType ().GetMethod ("InvokeMe");
			t.Invoke ( this, new object[0]);


			Assert.Throws<TargetException>(() => {
				t.Invoke (new object(), new object[0]);
			});

		}

		public void InvokeMe() {
			System.Console.WriteLine ("Invoking InvokeMe");
		}

		[Test]
		[Category ("Utilities")]
		public void Arrays()
		{
			string[] a = {"a", "b", "c"};
			string[] b = {"d"};
			string[] c = new string[a.Length+b.Length];

			a.CopyTo (c, 0);
			b.CopyTo (c, a.Length);

			Assert.AreEqual (4, c.Length);
		}

		[Test]
		[Category ("Utility")]
		public void IterateOverAttributes ()
		{
			var method = typeof(CucunetSpec).GetMethods ().First ();
			System.Console.WriteLine (method.Name);

			var attrs = method.GetCustomAttributes <BaseStepAttribute>();
			System.Console.WriteLine (attrs.Count ());

			foreach (var a in attrs) {
				System.Console.WriteLine (a.StepText);
			}
		}

		[Test]
		[Category ("Utility")]
		public void CountStringOccurences ()
		{
			string sut = "Bo Bob Bobby";
			int expectedCount = 3; // Bo
			int actualCount = Regex.Matches (sut, "Bo").Count;

			Assert.AreEqual (expectedCount, actualCount);
		}

		[Test]
		[Category ("Utility")]
		public void RegexWhitespace()
		{
			string str = "   preceded with whitespace";
			var count = Regex.Matches (str, "^\\s+preceded").Count;
			Assert.AreEqual (1, count);
		}
	}
}

