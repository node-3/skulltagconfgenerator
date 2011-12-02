using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkulltagConfGenerator.Enumerations.Utils {

	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	public class StringValueAttribute : Attribute {
		public string Value { get; set; }

		public StringValueAttribute(string value) {
			this.Value = value;
		}
	}
}
