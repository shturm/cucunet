using NUnit.Framework;
using System;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Cucunet.Tests
{
	[TestFixture ()]
	public class SystemFixture
	{

		[Test]
		[Category("System")]
		[Description("It should at least locate and display processing of each")]
		public void HitsAllFeaturesAndScenariosAndSteps ()
		{
			var output = Run ();
			Console.WriteLine (output);

			var actualFeaturesCount = Regex.Matches (output, "\\s*Feature: ").Count;
			var actualScenariosCount = Regex.Matches (output, "\\s*Scenario: .*").Count;
			var actualStepsCount = Regex.Matches (output, "\\s*(Given|When|Then|And) .*").Count;

			Assert.AreEqual (4, actualFeaturesCount, "Feature count");
			Assert.AreEqual (6, actualScenariosCount, "Scenario count");
			Assert.AreEqual (23, actualStepsCount, "Step count");

		}
			
//		string Run(string arguments = null) {
//			var processInfo = new ProcessStartInfo ("mono", "Cucunet.exe "+arguments);
//			processInfo.UseShellExecute = false;
//			processInfo.RedirectStandardOutput = true;
//			processInfo.RedirectStandardError = true;
//
//			var process = Process.Start (processInfo);
//			var output = process.StandardOutput.ReadToEnd ();
//			output += process.StandardError.ReadToEnd ();
//
//			return output;
//		}

		string Run(string arguments = null) {
			var sb = new StringBuilder ();
			var writer = new StringWriter (sb);

			var oldOut = Console.Out;
			Console.SetOut (writer);

			Cucunet.Main (arguments == null ? new string[0] : arguments.Split (' '));

			var output = sb.ToString ();
			oldOut.Write (output);

			return output;
		}
	}
}

