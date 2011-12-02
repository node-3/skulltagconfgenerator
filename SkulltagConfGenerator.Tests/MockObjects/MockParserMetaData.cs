using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using SkulltagConfGenerator.Domain.Parse;
using SkulltagConfGenerator.Enumerations;

namespace SkulltagConfGenerator.Tests.MockObjects {
	public static class MockParserMetaData {
		public static IParserMetaData StringMetaData {
			get {
				Mock<IParserMetaData> mockParser = new Mock<IParserMetaData>();
				mockParser.Setup(x => x.GetDataType(It.IsAny<string>())).Returns(typeof(string));

				return mockParser.Object;
			}
		}

		public static IParserMetaData DMFlagsMetaData {
			get {
				Mock<IParserMetaData> mockParser = new Mock<IParserMetaData>();
				mockParser.Setup(x => x.GetDataType(It.IsAny<string>())).Returns(typeof(DMFlags));

				return mockParser.Object;
			}
		}

		public static IParserMetaData FlagsMetaData {
			get {
				Mock<IParserMetaData> mockParser = new Mock<IParserMetaData>();
				mockParser.Setup(x => x.GetDataType(It.IsAny<string>())).Returns(delegate (string type) { 
					if(type == "dmflags") {
						return typeof(DMFlags);
					} else if(type == "dmflags2") {
						return typeof(DMFlags2);
					} else if(type == "dmflags3") {
						return typeof(DMFlags3);
					} else if(type == "compatflags") {
						return typeof(CompatFlags);
					} else {
						return typeof(CompatFlags2);
					}
				});

				return mockParser.Object;
			}
		}
	}
}
