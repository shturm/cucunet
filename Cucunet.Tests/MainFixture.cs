using NUnit.Framework;
using CuNS = Cucunet;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Gherkin;
using Gherkin.Ast;
using System.Linq;
using Moq;


namespace Cucunet.Tests
{
	[TestFixture ()]
	public class MainFixture
	{
		[Test ()]
		[Category("Unit")]
		public void GetFeatureFiles ()
		{
			var app = new App (new ConsoleFormatter ());
			var files = app.GetFeatureFiles(Directory.GetCurrentDirectory ());
			foreach (var file in files) {
				System.Console.WriteLine (file);
			}
			Assert.AreEqual (4, files.Length);
		}

		[Test ()]
		[Category("Unit")]
		public void GetStepMethods ()
		{
			var app = new App (new ConsoleFormatter ());
			var stepDefinitions = app.GetStepMethods(Directory.GetCurrentDirectory ());
			foreach (var stepDefinition in stepDefinitions) {
				System.Console.WriteLine (stepDefinition.Name);

			}
			Assert.AreEqual (4, stepDefinitions.Count); 
		}

		[Test]
		[Category ("Unit")]
		public void InvokeScenario ()
		{
			var app = new App (new ConsoleFormatter ());
			Scenario scenario = new Parser ()
								.Parse ("root.feature")
								.ScenarioDefinitions
								.ToArray ()[0]
								as Scenario;


			var expectedResult = @"I have entered 50 into the calculator
I have entered 70 into the calculator
I press Add
The result should be 120";

			var availableMethods = typeof(CucunetSpec).GetMethods ()
				.Where (m=>m.GetCustomAttributes <BaseStepAttribute>().Any ())
				.ToList ();

			app.InvokeScenario(scenario, availableMethods);
			var actualResult = string.Join("\n", CucunetSpec.ExecutedSteps);

			System.Console.WriteLine (expectedResult);
			System.Console.WriteLine (actualResult);

			Assert.AreEqual (expectedResult, actualResult);

		}

		[Test]
		[TestCase("GivenIHaveEntered50", "I have entered 50 into the calculator")]
		[TestCase("AndIHaveEntered70", "I have entered 70 into the calculator")]
		[TestCase("WhenIPressAdd", "I press Add")]
		[Category ("Unit")]
		public void GetStepMethod (string expectedMethodName, string stepText)
		{
			var app = new App (new ConsoleFormatter ());
			var step = CreateStep ("any keyword", stepText);
			var availableMethods = new List<MethodInfo> (){
				typeof(CucunetSpec).GetMethod (expectedMethodName)
			};

			var actualMethod = app.GetStepMethod (step, availableMethods);

			Assert.AreEqual (expectedMethodName, actualMethod.Name);
		}

		Step CreateStep (string keyword, string text)
		{
			var location = new Location (0, 0);
			var arg = new StepArgumentMock ();

			var step = new Step (location, keyword, text, arg);

			return step;
		}
	}

	class StepArgumentMock : StepArgument {
		
	}
}