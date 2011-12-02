using System.IO;

namespace SkulltagConfGenerator.Domain.Parse {
	public interface IParser<ReturnType, InputType> where ReturnType : class
													where InputType : TextReader {

		ReturnType Parse(InputType input);
	}
}
