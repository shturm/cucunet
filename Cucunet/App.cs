using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using Gherkin;
using Gherkin.Ast;
using System.Linq;

namespace Cucunet
{
	public class App
	{

		delegate void StepProcessingStartedHandler(Step step, CucunetStatus status);
		event StepProcessingStartedHandler StepProcessingStartedEvent;

		IOutputFormatter _formatter;

		public App (IOutputFormatter formatter)
		{
			_formatter = formatter;
		}

		public void Start ()
		{
			string[] featureFilepaths = GetFeatureFiles (Directory.GetCurrentDirectory ());
			List<MethodInfo> stepMethods = GetStepMethods (Directory.GetCurrentDirectory ());

			var parser = new Parser ();
			foreach (var featureFilepath in featureFilepaths) {
				var feature = parser.Parse (featureFilepath);
				_formatter.Log (feature);

				foreach (Scenario scenario in feature.ScenarioDefinitions) {
					_formatter.Log (scenario);
					InvokeScenario (scenario, stepMethods);
				}
			}
		}

		public string[] GetFeatureFiles (string path)
		{
			var result = new List<string>();

			var files = Directory.GetFiles (path, "*.feature", SearchOption.AllDirectories);
			result.AddRange (files);

			return result.ToArray ();
		}

		public List<MethodInfo> GetStepMethods (string path)
		{
			var result = new List<MethodInfo>();
			var dllFilePaths = Directory.GetFiles (path, "*.dll", SearchOption.AllDirectories);

			foreach (var assemblyPath in dllFilePaths) {
				var assembly = Assembly.LoadFile (assemblyPath);
				var stepMethods = assembly.GetTypes ()
					.SelectMany (t => t.GetMethods ())
					.Where (m => m.GetCustomAttributes <BaseStepAttribute>().Any ());
				result.AddRange (stepMethods);
			}

			return result;
		}

		public void InvokeScenario (Scenario scenario, IEnumerable<MethodInfo> availableMethods)
		{

			foreach (var step in scenario.Steps) {
				_formatter.Log (step);

				MethodInfo stepMethod = GetStepMethod (step, availableMethods);
				// TODO steps should be global - create GetStepMethodDeclaringObject()
				if (stepMethod == null) {
					//					TODO notify the formatter of the step not having stepMethod
					continue;
				}
				var obj = Activator.CreateInstance(stepMethod.DeclaringType);
				stepMethod.Invoke (obj, null);
			}
		}

		public MethodInfo GetStepMethod (Step step, IEnumerable<MethodInfo> availableMethods)
		{
			MethodInfo result = null;
			foreach (var method in availableMethods) {
				var attrs = method.GetCustomAttributes <BaseStepAttribute> ();
				foreach (var a in attrs) {
					if (String.Compare(a.StepText, step.Text, true) == 0) {
						result = method;
					}
				}

			}

			return result;
		}
	}
}

