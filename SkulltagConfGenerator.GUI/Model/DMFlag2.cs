using SkulltagConfGenerator.Enumerations;
using SkulltagConfGenerator.Enumerations.Utils;

namespace SkulltagConfGenerator.GUI.Model {
	public class DMFlag2 : Flag {
		public DMFlag2(DMFlags2 flag) : base((int)flag, flag.GetFirstAlternateName(), flag.GetStringValue()) { }
	}
}
