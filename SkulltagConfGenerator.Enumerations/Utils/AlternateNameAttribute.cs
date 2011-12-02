using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkulltagConfGenerator.Enumerations.Utils {

	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	public class AlternateNameAttribute : Attribute {

		public string Name { get; set; }

		public AlternateNameAttribute(string name) {
			this.Name = name;
		}
	}
}
