using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace SkulltagConfGenerator.Enumerations.Utils {
	public static class EnumExtensions {

		/// <summary>
		/// Gets the string value off of an enum.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetStringValue(this Enum value) {
			Type t = value.GetType();

			FieldInfo info = t.GetField(value.ToString());

			StringValueAttribute[] attributes = info.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];

			if(attributes != null) {
				StringValueAttribute first = attributes.FirstOrDefault();

				if(first != null) {
					return first.Value;
				}
			}

			return null;
		}

		/// <summary>
		/// Gets all alternate names on an enum.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static IEnumerable<string> GetAlternateNames(this Enum value) {

			Type t = value.GetType();

			FieldInfo info = t.GetField(value.ToString());

			AlternateNameAttribute[] alternateNames = info.GetCustomAttributes(typeof(AlternateNameAttribute), false) as AlternateNameAttribute[];

			if(alternateNames != null) {
				return alternateNames.Select(x => x.Name);
			}

			return null;
		}

		public static IEnumerable<string> GetAlternateNames(this Type type) {
			AlternateNameAttribute[] alternateNames = type.GetCustomAttributes(typeof(AlternateNameAttribute), false) as AlternateNameAttribute[];

			if(alternateNames != null) {
				return alternateNames.Select(x => x.Name);
			}

			return null;
		}

		/// <summary>
		/// Returns the alphabetically first alternate on the enum.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetFirstAlternateName(this Enum value) {
			return GetAlternateNames(value).OrderBy(x => x).FirstOrDefault();
		}

		public static string GetFirstAlternateName(this Type type) {
			return GetAlternateNames(type).OrderBy(x => x).FirstOrDefault();
		}
	}
}
