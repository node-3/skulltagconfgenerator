using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkulltagConfGenerator.Domain.Model;
using SkulltagConfGenerator.Enumerations;

namespace SkulltagConfGenerator.Tests {
	[TestClass]
	public class SkulltagConfigTests {

		[TestMethod]
		public void SetValue_SetStringValue_ValueAddedToConfig() {
			SkulltagConfig config = new SkulltagConfig();

			string key = "hello pickles";
			string value = "why hello there";

			config.SetValue(key, value);

			string somevalue = config.StringValues[key];

			Assert.AreEqual(somevalue, value);
		}

		[TestMethod]
		public void SetValue_SetDMFlag_ValueAddedToConfig() {
			SkulltagConfig config = new SkulltagConfig();

			DMFlags key = DMFlags.AllowCrouching;
			bool value = true;

			config.SetValue(key, value);

			bool somevalue = config.DMFlags[key];

			Assert.IsTrue(somevalue);
		}

		[TestMethod]
		public void SetValue_SetCompatFlags_ValueAddedToConfig() {
			SkulltagConfig config = new SkulltagConfig();

			CompatFlags key = CompatFlags.DisableBoomDoorLightEffect;
			bool value = true;

			config.SetValue(key, value);

			bool somevalue = config.CompatFlags[key];

			Assert.IsTrue(somevalue);
		}
	}
}
