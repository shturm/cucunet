using System;
using Cucunet;
using System.Collections.Generic;

namespace Cucunet.Tests
{
	public class CucunetSpec
	{
		public static List<string> ExecutedSteps = new List<string>();

		[Given("I have entered 50 into the calculator")]
		[And("Blah blah blah")]
		public void GivenIHaveEntered50 ()
		{
			ExecutedSteps.Add ("I have entered 50 into the calculator");
		}

		[And("I have entered 70 into the calculator")]
		public void AndIHaveEntered70 ()
		{
			ExecutedSteps.Add ("I have entered 70 into the calculator");
		}

		[When("I press Add")]
		public void WhenIPressAdd ()
		{
			ExecutedSteps.Add ("I press Add");
		}

		[Then("The result should be 120")]
		public void ThenTheResultShouldBe120 ()
		{
			ExecutedSteps.Add("The result should be 120");
		}


	}
}

