using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkulltagConfGenerator.Enumerations.Utils;

namespace SkulltagConfGenerator.Enumerations {

	[Flags]
	[AlternateName("compatflags2")]
	public enum CompatFlags2 {

		[StringValue("Client side scripts")]
		[AlternateName("compat_netscriptsareclientside")]
		ClientSideScripts = 1,

		[StringValue("Clients send full button info")]
		[AlternateName("compat_clientsendsfullbuttoninfo")]
		ClientsSendFullButtonInfo = 2,

		[StringValue("No land")]
		[AlternateName("compat_noland")]
		NoLand = 4,

		[StringValue("Use old random generator")]
		[AlternateName("compat_oldrandom")]
		UseOldRandomGenerator = 8,

		[StringValue("Add NOGRAVITY to some actors when spawned by the map")]
		[AlternateName("compat_nogravity_spheres")]
		AddNOGRAVITYToSomeActorsWhenSpawnedByMap = 16

	}
}
