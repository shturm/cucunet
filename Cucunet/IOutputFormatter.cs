using System;
using Gherkin.Ast;


namespace Cucunet
{
	public interface IOutputFormatter
	{
		void Log (Feature feature);
		void Log (Scenario scenario);
		void Log (Step step);
	}
}

