using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkulltagConfGenerator.Domain.Extensions {
	public static class DictionaryExtensions {

		/// <summary>
		/// Provides a simple way to add a flagged enum and value to a dictionary.
		/// </summary>
		/// <typeparam name="T">The key type of the dictionary</typeparam>
		/// <typeparam name="V">The value type of the dictionary</typeparam>
		/// <param name="dictionary"></param>
		/// <param name="flaggedEnum"></param>
		public static void SetFlaggedEnum<T, V>(this Dictionary<T, V> dictionary, T flaggedEnum, V value) where T : struct {
			Type valueType = flaggedEnum.GetType();

			object flagsAttribute = valueType.GetCustomAttributes(typeof(FlagsAttribute), false).FirstOrDefault();
			if(flagsAttribute != null && flagsAttribute is FlagsAttribute) {
				Enum enumValue = flaggedEnum as Enum;

				IEnumerable<T> values = enumValue.GetIndividualValues<T>();

				foreach(T eValue in values) {
					dictionary.AddOrSetValue(eValue, value);
				}
			} else {
				throw new ArgumentException("Key must be an enum with the flags attribute");
			}
		}

		/// <summary>
		/// Provides a simple way to add or set a value in a dictionary.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="V"></typeparam>
		/// <param name="dictionary"></param>
		/// <param name="key"></param>
		/// <param name="value"></param>
		public static void AddOrSetValue<T, V>(this Dictionary<T, V> dictionary, T key, V value) {
			if(dictionary.ContainsKey(key)) {
				dictionary[key] = value;
			} else {
				dictionary.Add(key, value);
			}
		}

		/// <summary>
		/// Assigns every value in a dictionary with the passed in value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="V"></typeparam>
		/// <param name="dictionary"></param>
		/// <param name="value"></param>
		public static void Reset<T, V>(this Dictionary<T, V> dictionary, V value) {
			foreach(var item in dictionary.Keys) {
				dictionary[item] = value;
			}
		}
	}
}
