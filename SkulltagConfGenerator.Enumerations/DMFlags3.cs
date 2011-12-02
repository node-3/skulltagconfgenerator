using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkulltagConfGenerator.Enumerations.Utils;

namespace SkulltagConfGenerator.Enumerations {

	[Flags]
	[AlternateName("dmflags3")]
	public enum DMFlags3 : int {

		[StringValue("Enforces client not to identify players")]
		[AlternateName("sv_noidentifytarget")]
		EnforcesClientNotToIdentifyPlayers = 1,

		[StringValue("Apply LMS spectator settings in all game modes")]
		[AlternateName("sv_applylmsspectatorsettings")]
		ApplyLMSSpectatorSettingsInallGameModes = 2,

		[StringValue("Don't draw coop info")]
		[AlternateName("sv_nocoopinfo")]
		DoNotDrawCoopInfo = 4,

		[StringValue("Disable unlagged")]
		[AlternateName("sv_nounlagged")]
		DisableUnlagged = 8,
	}
}
