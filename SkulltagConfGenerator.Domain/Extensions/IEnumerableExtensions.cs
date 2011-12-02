using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkulltagConfGenerator.Domain.Extensions {
	public static class IEnumerableExtensions {

		/// <summary>
		/// Credit goes to Bob Page at http://paceyourself.net
		/// http://paceyourself.net/2010/09/13/breaking-down-c-flags-enums-into-individual-values-for-comparison/
		/// </summary>
		public static IEnumerable<T> GetFlagEnumValues<T>(this IEnumerable<T> values) where T : struct {

			foreach(T item in values) {
				int intValue = Convert.ToInt32(item);

				if(intValue.IsPowerOfTwo()) {
					yield return item;
				} else {
					string binaryVersion = Convert.ToString(intValue, 2);

					char[] bits = new string('0', binaryVersion.Length).ToCharArray();

					IEnumerable<T> individualFlags = binaryVersion.Select((character, idx) => {
						char[] template = (char[])bits.Clone();
						template[idx] = character;
						return new string(template);
					}).Where(x => {
						return !x.All(c => c == '0');
					}).Select(x => {
						int bitValue = Convert.ToInt32(x, 2);
						return (T)Enum.ToObject(typeof(T), bitValue);
					});

					foreach(T value in individualFlags) {
						yield return value;
					}
				}
			}
		}
	}
}
