using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using Gherkin;
using Gherkin.Ast;
using System.Linq;

namespace Cucunet
{
	enum CucunetStatus
	{
		None, // not applicable or yet not assigned status
		Passed, // has step definition, no exceptions
		Pending, // has step definition, but still throws NotImplementedException
		Undefined, // no step definition
		Failed // has step definition, but throws an Exception
	}

}

