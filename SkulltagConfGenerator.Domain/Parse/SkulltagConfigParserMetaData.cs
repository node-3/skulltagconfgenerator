using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using SkulltagConfGenerator.Enumerations.Utils;

namespace SkulltagConfGenerator.Domain.Parse {
	public class SkulltagConfigParserMetaData : IParserMetaData {
		#region Fields

		private Dictionary<string, Type> enumTypes;

		#endregion

		public SkulltagConfigParserMetaData(Assembly assemblyToScan, string namespaceToScan) {
			this.enumTypes = new Dictionary<string, Type>();

			IEnumerable<Type> specialTypes = assemblyToScan.GetTypes().Where(x => x.Namespace == namespaceToScan).Where(x => x.IsEnum == true);

			foreach(Type enumType in specialTypes) {
				IEnumerable<string> enumAlternateNames = enumType.GetAlternateNames();

				foreach(var alternateName in enumAlternateNames) {
					this.enumTypes.Add(alternateName, enumType);
				}
			}
		}

		public Type GetDataType(string propertyName) {
			Type returnType = typeof(string);

			if(enumTypes.ContainsKey(propertyName)) {
				returnType = enumTypes[propertyName];
			}

			return returnType;
		}
	}
}
