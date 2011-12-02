using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using SkulltagConfGenerator.Domain.Model;
using System.Runtime.Remoting;
using SkulltagConfGenerator.Domain.Extensions;
using SkulltagConfGenerator.Enumerations;

namespace SkulltagConfGenerator.Domain.Parse {
	public class SkulltagConfigParser : IParser<SkulltagConfig, TextReader> {

		private const string Delimiter = @"(?<match>\w+)|\""(?<match>[\w\s]*)""";

		private IParserMetaData metaData;

		public SkulltagConfigParser(IParserMetaData metaData) {
			this.metaData = metaData;
		}

		public SkulltagConfig Parse(TextReader input) {

			SkulltagConfig config = new SkulltagConfig();

			string currentLine = null;

			while((currentLine = input.ReadLine()) != null) {
				currentLine = this.CleanLine(currentLine);

				KeyValuePair<string, string> kv = this.GetKeyValue(currentLine);

				Type keyType = this.metaData.GetDataType(kv.Key);

				this.HandleEntry(config, keyType, kv);
			}

			return config;
		}

		private void HandleEntry(SkulltagConfig config, Type keyType, KeyValuePair<string, string> kv) {
			if(keyType.IsEnum) {
				Enum flag = null;
				int enumValue = int.Parse(kv.Value);
				dynamic splitFlags = null;

				if(keyType == typeof(DMFlags)) {
					flag = (DMFlags)enumValue;
					splitFlags = flag.GetIndividualValues<DMFlags>();
					config.PopulateDMFlags();
				} else if(keyType == typeof(DMFlags2)) {
					flag = (DMFlags2)enumValue;
					splitFlags = flag.GetIndividualValues<DMFlags2>();
					config.PopulateDMFlags2();
				} else if(keyType == typeof(DMFlags3)) {
					flag = (DMFlags3)enumValue;
					splitFlags = flag.GetIndividualValues<DMFlags3>();
					config.PopulateDMFlags3();
				} else if(keyType == typeof(CompatFlags)) {
					flag = (CompatFlags)enumValue;
					splitFlags = flag.GetIndividualValues<CompatFlags>();
					config.PopulateCompatFlags();
				} else if(keyType == typeof(CompatFlags2)) {
					flag = (CompatFlags2)enumValue;
					splitFlags = flag.GetIndividualValues<CompatFlags2>();
					config.PopulateCompatFlags2();
				}

				foreach(var individualFlag in splitFlags) {
					config.SetValue(individualFlag, true);
				}

			} else {
				config.SetValue(kv.Key, kv.Value);
			}
		}

		private string CleanLine(string input) {
			return input.Trim();
		}

		private KeyValuePair<string, string> GetKeyValue(string input) {
			string[] keyValue = Regex.Matches(input, Delimiter).Cast<Match>().Select(x => x.Groups["match"].Value).ToArray();

			return new KeyValuePair<string, string>(keyValue.FirstOrDefault(), keyValue.Skip(1).FirstOrDefault());
		}
	}
}
