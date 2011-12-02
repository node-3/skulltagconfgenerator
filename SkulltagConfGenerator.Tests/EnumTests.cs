using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkulltagConfGenerator.Enumerations.Utils;

namespace SkulltagConfGenerator.Tests {

	[TestClass]
	public class EnumTests {

		[TestMethod]
		public void AlternateNameAttribute_SingleAlternateName_GetsFirstAlternateName() {
			AlternateNameTestEnum testOne = AlternateNameTestEnum.Test1;

			IEnumerable<string> testOneAlternateNames = testOne.GetAlternateNames().OrderBy(x => x);

			Assert.IsTrue(testOneAlternateNames.Count() == 1);

			Assert.AreEqual(testOneAlternateNames.First(), "test1 is testworthy");
		}

		[TestMethod]
		public void AlternateNameAttribute_MultipleAlternateNames_GetsAllAlternateNames() {
			AlternateNameTestEnum testTwo = AlternateNameTestEnum.Test2;

			IEnumerable<string> testTwoAlternateNames = testTwo.GetAlternateNames().OrderBy(x => x);

			Assert.IsTrue(testTwoAlternateNames.Count() == 2);

			Assert.AreEqual(testTwoAlternateNames.First(), "test2 is not testworthy");
			Assert.AreEqual(testTwoAlternateNames.Last(), "test2's other alternate name");
		}

		[TestMethod]
		public void StringValueAttribute_PullFromEnum_GetsStringValueOffOfEnum() {
			StringValueTestEnum valueOne = StringValueTestEnum.Value1;
			StringValueTestEnum valueTwo = StringValueTestEnum.Value2;

			string testOneStringValue = valueOne.GetStringValue();
			string testTwoStringValue = valueTwo.GetStringValue();

			Assert.AreEqual(testOneStringValue, "Alternate Value One");
			Assert.AreEqual(testTwoStringValue, "Alternate Value Two!");
		}

		[TestMethod]
		public void StringValueAttribute_PullFromEnumWithoutStringValueAttribute_NullIsReturned() {
			PlainEnum plain = PlainEnum.Value1;

			string plainStringValueOne = plain.GetStringValue();

			Assert.IsNull(plainStringValueOne);
		}

		[TestMethod]
		public void AlternateNameAttribute_PullFromEnumWithoutAlternateNameAttribute_EmptyCollectionReturned() {
			PlainEnum plain = PlainEnum.Value1;

			IEnumerable<string> plainAlternateNames = plain.GetAlternateNames();

			Assert.IsTrue(plainAlternateNames.Count() == 0);
		}

		[TestMethod]
		public void AlternateNameAttribute_PullFromEnumWithFlagsAttributeAndSingleAlternateAttribute_SingleValuesReturned() {
			FlaggedAlternateNameTestEnum testOne = FlaggedAlternateNameTestEnum.Value2 | FlaggedAlternateNameTestEnum.Value5;

			FlaggedAlternateNameTestEnum value2 = testOne & FlaggedAlternateNameTestEnum.Value2;
			FlaggedAlternateNameTestEnum value5 = testOne & FlaggedAlternateNameTestEnum.Value5;

			IEnumerable<string> value2AlternateNames = value2.GetAlternateNames();
			IEnumerable<string> value5AlternateNames = value5.GetAlternateNames();

			Assert.IsTrue(value2AlternateNames.Count() == 1);
			Assert.IsTrue(value5AlternateNames.Count() == 1);

			Assert.AreEqual(value2AlternateNames.First(), "I hate pickles :(");
			Assert.AreEqual(value5AlternateNames.First(), "derp");
		}

		[TestMethod]
		public void AlternateNameAttribute_PullFromEnumWithFlagsAttributeAndMultipleAlternateAttributes_MultipleValuesReturned() {
			FlaggedAlternateNameTestEnum testOne = FlaggedAlternateNameTestEnum.Value4 | FlaggedAlternateNameTestEnum.Value3;

			FlaggedAlternateNameTestEnum value3 = testOne & FlaggedAlternateNameTestEnum.Value3;
			FlaggedAlternateNameTestEnum value4 = testOne & FlaggedAlternateNameTestEnum.Value4;

			IEnumerable<string> value3AlternateNames = value3.GetAlternateNames();
			IEnumerable<string> value4AlternateNames = value4.GetAlternateNames().OrderBy(x => x);

			Assert.IsTrue(value3AlternateNames.Count() == 1);
			Assert.IsTrue(value4AlternateNames.Count() == 3);

			Assert.AreEqual(value3AlternateNames.First(), "I LOVE PICKLES :D");
			Assert.AreEqual(value4AlternateNames.First(), "awesome, that's what are");
			Assert.AreEqual(value4AlternateNames.Last(), "what does pickles are?");
			Assert.AreEqual(value4AlternateNames.ElementAt(1), "wat....?");
		}

		[TestMethod]
		public void MixedCustomAttributes_PullEnumWithFlagsAlternateAndStringValueAttributes_MultpleValuesReturned() {
			FlaggedMixedCustomAttributesTestEnum testOne = 
				FlaggedMixedCustomAttributesTestEnum.Value1 | FlaggedMixedCustomAttributesTestEnum.Value2;

			FlaggedMixedCustomAttributesTestEnum value1 = testOne & FlaggedMixedCustomAttributesTestEnum.Value1;
			FlaggedMixedCustomAttributesTestEnum value2 = testOne & FlaggedMixedCustomAttributesTestEnum.Value2;

			IEnumerable<string> value1AlternateNames = value1.GetAlternateNames();
			string value1StringValue = value1.GetStringValue();
			
			IEnumerable<string> value2AlternateNames = value2.GetAlternateNames().OrderBy(x => x);
			string value2StringValue = value2.GetStringValue();

			Assert.IsTrue(value1AlternateNames.Count() == 1);
			Assert.IsTrue(value2AlternateNames.Count() == 3);

			Assert.AreEqual(value1AlternateNames.First(), "Value1 is awesome");

			Assert.AreEqual(value2AlternateNames.First(), "awesome, that's what are");
			Assert.AreEqual(value2AlternateNames.Last(), "what does pickles are?");
			Assert.AreEqual(value2AlternateNames.ElementAt(1), "wat....?");

			Assert.AreEqual(value1StringValue, "hello thar");
			Assert.AreEqual(value2StringValue, "why hello thar sir");
		}

		[TestMethod]
		public void AlternateNameAttribute_GetFirstAlternateNameWithSingleAlternateName_ReturnsAlternateName() {
			AlternateNameTestEnum testEnum = AlternateNameTestEnum.Test1;

			string alternateName = testEnum.GetFirstAlternateName();

			Assert.AreEqual(alternateName, "test1 is testworthy");
		}

		[TestMethod]
		public void AlternateNameAttribute_GetFirstAlternateNameWithMultipleAlternateNames_ReturnsFirstAlternateName() {
			AlternateNameTestEnum testEnum = AlternateNameTestEnum.Test2;

			string alternateName = testEnum.GetFirstAlternateName();

			Assert.AreEqual(alternateName, "test2 is not testworthy");
		}

		#region TestEnums
		
		private enum FlaggedMixedCustomAttributesTestEnum {
			[AlternateName("Value1 is awesome")]
			[StringValue("hello thar")]
			Value1 = 128,

			[AlternateName("what does pickles are?")]
			[AlternateName("awesome, that's what are")]
			[AlternateName("wat....?")]
			[StringValue("why hello thar sir")]
			Value2 = 65536,
		}

		[Flags]
		private enum FlaggedAlternateNameTestEnum {
			[AlternateName("Value1 is awesome")]
			Value1 = 1,

			[AlternateName("I hate pickles :(")]
			Value2 = 2,

			[AlternateName("I LOVE PICKLES :D")]
			Value3 = 4,

			[AlternateName("what does pickles are?")]
			[AlternateName("awesome, that's what are")]
			[AlternateName("wat....?")]
			Value4 = 8,

			[AlternateName("derp")]
			Value5 = 16,
		}

		private enum PlainEnum {
			Value1 = 1,
			Value2 = 2,
		}

		private enum StringValueTestEnum {
			[StringValue("Alternate Value One")]
			Value1 = 1,

			[StringValue("Alternate Value Two!")]
			Value2 = 2,
		}

		private enum AlternateNameTestEnum {

			[AlternateName("test1 is testworthy")]
			Test1 = 1,

			[AlternateName("test2 is not testworthy")]
			[AlternateName("test2's other alternate name")]
			Test2 = 2,
		}

		#endregion
	}
}
