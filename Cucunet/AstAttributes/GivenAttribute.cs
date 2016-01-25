using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Gherkin;
using Gherkin.Ast;
using System.Reflection;

namespace Cucunet
{
	public class GivenAttribute : BaseStepAttribute
	{
		public GivenAttribute (string stepText) : base(stepText) 
		{

		}
	}

}
