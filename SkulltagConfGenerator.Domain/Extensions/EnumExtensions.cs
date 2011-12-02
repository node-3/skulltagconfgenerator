using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkulltagConfGenerator.Domain.Extensions {
	public static class EnumExtensions {
		public static IEnumerable<T> GetIndividualValues<T>(this Enum enumValue) where T : struct {
			Type enumType = enumValue.GetType();

			FlagsAttribute flagsAttribute = enumType.GetCustomAttributes(typeof(FlagsAttribute), true).FirstOrDefault() as FlagsAttribute;

			if(flagsAttribute != null) {
				return enumValue.
					ToString().
					Split(new[] { ',' }).
					Select(x => (T)Enum.Parse(typeof(T), x.Trim())).
					GetFlagEnumValues();
			}

			throw new ArgumentException(string.Format("The enum {0} must have the Flags attribute", enumType.FullName));
		}
	}
}
