using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkulltagConfGenerator.Enumerations;
using SkulltagConfGenerator.Domain.Extensions;

namespace SkulltagConfGenerator.Tests {

	[TestClass]
	public class ExtensionMethodsTests {

		#region Int Tests

		[TestMethod]
		public void IsPowerOfTwo_WithPowerOfTwoNumber_ResultIsTrue() {
			int value = 65536;

			bool result = value.IsPowerOfTwo();

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void IsPowerOfTwo_WithNonPowerOfTwoNumber_ResultIsFalse() {
			int value = 3;

			bool result = value.IsPowerOfTwo();

			Assert.IsFalse(result);
		}

		#endregion

		#region Enum Tests

		[TestMethod]
		public void GetIndividualValues_WithFlaggedEnum_EnumSplit() {
			FlaggedTestEnum flaggedEnum = FlaggedTestEnum.One | FlaggedTestEnum.Five | FlaggedTestEnum.Two;

			IEnumerable<FlaggedTestEnum> enums = flaggedEnum.GetIndividualValues<FlaggedTestEnum>();

			Assert.IsTrue(enums.Contains(FlaggedTestEnum.One));
			Assert.IsTrue(enums.Contains(FlaggedTestEnum.Two));
			Assert.IsTrue(enums.Contains(FlaggedTestEnum.Five));
		}

		[TestMethod]
		public void GetIndividualValues_WithoutFlaggedEnum_ExceptionThrown() {
			TestEnum flaggedEnum = TestEnum.One | TestEnum.Five | TestEnum.Two;

			try {
				IEnumerable<TestEnum> enums = flaggedEnum.GetIndividualValues<TestEnum>();
			} catch(Exception e) {
				Assert.IsTrue(e is ArgumentException);
				return;
			}

			Assert.Fail();
		}

		#endregion

		#region IEnumerable Tests

		[TestMethod]
		public void GetFlagEnumValues_WithFlaggedEnumAlreadyPowerOfTwoEnum_CollectionCountIsOne() {
			FlaggedTestEnum testEnum = FlaggedTestEnum.One;

			IEnumerable<FlaggedTestEnum> enums = testEnum.GetIndividualValues<FlaggedTestEnum>();

			Assert.IsTrue(enums.Count() == 1);
			Assert.IsTrue(testEnum == FlaggedTestEnum.One);
		}

		[TestMethod]
		public void GetFlagEnumValues_WithFlaggedEnumNonPowerOfTwoEnum_EnumSplitApart() {
			FlaggedTestEnum testEnum = FlaggedTestEnum.One | FlaggedTestEnum.Five;

			IEnumerable<FlaggedTestEnum> enums = testEnum.GetIndividualValues<FlaggedTestEnum>();

			Assert.IsTrue(enums.Count() == 2);
			Assert.IsTrue(enums.Contains(FlaggedTestEnum.One));
			Assert.IsTrue(enums.Contains(FlaggedTestEnum.Five));
		}

		#endregion

		#region Dictionary Tests

		[TestMethod]
		public void SetFlaggedEnum_ValuesNotAlreadyInDictionary_EnumPartsAddedToDictionary() {
			Dictionary<FlaggedTestEnum, bool> dict = new Dictionary<FlaggedTestEnum, bool>() {
				{ FlaggedTestEnum.One, false }
			};

			FlaggedTestEnum flaggedEnum =
				FlaggedTestEnum.Five |
				FlaggedTestEnum.Two |
				FlaggedTestEnum.Three |
				FlaggedTestEnum.Four;

			dict.SetFlaggedEnum(flaggedEnum, true);

			Assert.IsFalse(dict[FlaggedTestEnum.One]);
			Assert.IsTrue(dict[FlaggedTestEnum.Five]);
			Assert.IsTrue(dict[FlaggedTestEnum.Three]);
			Assert.IsTrue(dict[FlaggedTestEnum.Four]);
			Assert.IsTrue(dict[FlaggedTestEnum.Two]);
		}

		[TestMethod]
		public void SetFlaggedEnum_SomeValuesInDictionary_OnlyMissingValuesAreAdded() {
			Dictionary<FlaggedTestEnum, bool> dict = new Dictionary<FlaggedTestEnum, bool>() {
				{ FlaggedTestEnum.One, false }
			};

			FlaggedTestEnum flaggedEnum =
				FlaggedTestEnum.Five |
				FlaggedTestEnum.Two |
				FlaggedTestEnum.Three |
				FlaggedTestEnum.Four |
				FlaggedTestEnum.One;

			dict.SetFlaggedEnum(flaggedEnum, true);

			Assert.IsTrue(dict[FlaggedTestEnum.One]);
			Assert.IsTrue(dict[FlaggedTestEnum.Five]);
			Assert.IsTrue(dict[FlaggedTestEnum.Three]);
			Assert.IsTrue(dict[FlaggedTestEnum.Four]);
			Assert.IsTrue(dict[FlaggedTestEnum.Two]);
		}

		[TestMethod]
		public void SetFlaggedEnum_WithoutFlaggedEnum_ExceptionThrown() {
			Dictionary<TestEnum, bool> dict = new Dictionary<TestEnum, bool>() {
				{ TestEnum.Five, false },
				{ TestEnum.Four, true },
			};

			TestEnum tEnum = TestEnum.Three | TestEnum.Two | TestEnum.Five;

			try {
				dict.SetFlaggedEnum(tEnum, true);
			} catch(Exception e) {
				Assert.IsTrue(e is ArgumentException);
				return;
			}

			Assert.Fail();
		}

		#endregion

		#region Test Enums

		private enum TestEnum {
			One,
			Two,
			Three,
			Four,
			Five
		}

		[Flags]
		private enum FlaggedTestEnum {
			One = 1,
			Two = 2,
			Three = 4,
			Four = 8,
			Five = 16
		}

		#endregion
	}
}
