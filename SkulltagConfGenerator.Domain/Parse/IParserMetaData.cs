using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkulltagConfGenerator.Domain.Parse {
	public interface IParserMetaData {
		Type GetDataType(string propertyName); 
	}
}
