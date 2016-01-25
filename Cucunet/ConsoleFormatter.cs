using System;
using Gherkin.Ast;

namespace Cucunet
{
	public class ConsoleFormatter: IOutputFormatter
	{
		#region IOutputFormatter implementation

		public void Log (Feature feature)
		{
			Console.WriteLine ("Feature: {0}", feature.Name);
		}

		public void Log (Scenario scenario)
		{
			Console.WriteLine ("  Scenario: {0}", scenario.Name);
		}

		public void Log (Step step)
		{
			Console.WriteLine ("    {0}{1}", step.Keyword, step.Text);
		}

		#endregion

	}
}
