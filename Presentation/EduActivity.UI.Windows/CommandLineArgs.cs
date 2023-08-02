using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFramework.Windows.Forms.CommandLine;

namespace KMU.EduActivity.UI.Windows
{
	public class CommandLineArgs
	{
		private static volatile CommandLineArgs _current;
		public static CommandLineArgs Current
		{
			get
			{
				if ( _current == null )
				{
					if (_current == null)
					{
						_current = new CommandLineArgs();
					}
				}
				return _current;
			}
		}

		[ValueList(typeof(List<string>), MaximumElements = 20)]
		public IList<string> Items { get; set; }

	}
}