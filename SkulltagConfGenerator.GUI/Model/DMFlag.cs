using SkulltagConfGenerator.Enumerations;
using SkulltagConfGenerator.Enumerations.Utils;

namespace SkulltagConfGenerator.GUI.Model {
	public class DMFlag : Flag {
		public DMFlag(DMFlags flag) : base((int)flag, flag.GetFirstAlternateName(), flag.GetStringValue()) { }
	}
}
