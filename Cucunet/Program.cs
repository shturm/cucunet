using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Gherkin;
using Gherkin.Ast;
using System.Reflection;
using System.Globalization;

namespace Cucunet
{
	public class Cucunet
	{
		public static void Main (string[] args)
		{
			var app = new App (new ConsoleFormatter ());
			app.Start ();
		}
	}
}
