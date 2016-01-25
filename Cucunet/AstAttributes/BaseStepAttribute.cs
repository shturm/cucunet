using System;

namespace Cucunet
{
	public abstract class BaseStepAttribute : Attribute
	{
		public string StepText { get; private set;}
		public BaseStepAttribute (string stepText)
		{
			StepText = stepText;
		}
	}
}

