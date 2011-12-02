using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkulltagConfGenerator.Domain.Parse;
using SkulltagConfGenerator.Domain.Model;
using SkulltagConfGenerator.Enumerations;
using System.Reflection;
using System.Configuration;
using Moq;
using SkulltagConfGenerator.Tests.MockObjects;

namespace SkulltagConfGenerator.Tests {

	[TestClass]
	public class ParserTests {

		[TestMethod]
		public void Parse_ValidStringInputSingleLine_PropertyInConfigSet() {
			string validInput = "sv_hostname \"test server\"";

			StringReader reader = new StringReader(validInput);

			SkulltagConfig conf = new SkulltagConfig();

			IParserMetaData fakeParser = MockParserMetaData.StringMetaData;

			IParser<SkulltagConfig, TextReader> parser = new SkulltagConfigParser(fakeParser);

			SkulltagConfig config = parser.Parse(reader);

			Assert.AreEqual(config.StringValues["sv_hostname"], "test server");
		}

		[TestMethod]
		public void Parse_ValidStringInputMultipleLines_PropertiesInConfigSet() {
			string validInput = "sv_hostname \"test server\"\nsv_maxplayers 24\nsv_maxclients 32";

			StringReader reader = new StringReader(validInput);

			SkulltagConfig conf = new SkulltagConfig();

			IParserMetaData fakeParser = MockParserMetaData.StringMetaData;

			IParser<SkulltagConfig, TextReader> parser = new SkulltagConfigParser(fakeParser);

			SkulltagConfig config = parser.Parse(reader);

			Assert.AreEqual(config.StringValues["sv_hostname"], "test server");
			Assert.AreEqual(config.StringValues["sv_maxplayers"], "24");
			Assert.AreEqual(config.StringValues["sv_maxclients"], "32");
		}

		[TestMethod]
		public void Parse_ValidSpecialInputSingleLine_PropertyInConfigSet() {
			string validInput = "dmflags 1024";

			StringReader reader = new StringReader(validInput);

			SkulltagConfig conf = new SkulltagConfig();

			IParserMetaData fakeParser = MockParserMetaData.DMFlagsMetaData;

			IParser<SkulltagConfig, TextReader> parser = new SkulltagConfigParser(fakeParser);

			SkulltagConfig config = parser.Parse(reader);

			Assert.IsTrue(config.DMFlags[DMFlags.KillOnExit]);
		}

		[TestMethod]
		public void Parse_ValidSpecialInputMultipleLines_PropertiesInConfigSet() {
			string validInput = "dmflags 516\ndmflags2 = 8704";

			StringReader reader = new StringReader(validInput);

			SkulltagConfig conf = new SkulltagConfig();

			IParserMetaData fakeParser = MockParserMetaData.FlagsMetaData;

			IParser<SkulltagConfig, TextReader> parser = new SkulltagConfigParser(fakeParser);

			SkulltagConfig config = parser.Parse(reader);

			Assert.IsTrue(config.DMFlags[DMFlags.WeaponsRemainAfterPickup]);
			Assert.IsTrue(config.DMFlags[DMFlags.DoNotSpawnArmor]);

			Assert.IsTrue(config.DMFlags2[DMFlags2.BarrelsRespawn]);
			Assert.IsTrue(config.DMFlags2[DMFlags2.KeepTeamAfterMapChange]);
		}
	}
}
