using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkulltagConfGenerator.Enumerations.Utils;

namespace SkulltagConfGenerator.Enumerations {

	[Flags]
	[AlternateName("dmflags2")]
	public enum DMFlags2 : int {

		[StringValue("Drop weapon on death")]
		[AlternateName("sv_weapondrop")]
		DropWeaponOnDeath = 2,

		[StringValue("Don't spawn runes")]
		[AlternateName("sv_norunes")]
		DoNoSpawnRunes = 4,

		[StringValue("Instant flag return")]
		[AlternateName("sv_instantreturn")]
		InstantFlagReturn = 8,

		[StringValue("Players can't switch teams in teamgames")]
		[AlternateName("sv_noteamswitch")]
		NoPlayerSwitching = 16,

		[StringValue("Automatic placement on teams")]
		[AlternateName("sv_noteamselect")]
		AutoTeamCreation = 32,

		[StringValue("Double ammo")]
		[AlternateName("sv_doubleammo")]
		DoubleAmmo = 64,

		[StringValue("Health over 100% drains slowly (quake style)")]
		[AlternateName("sv_degeneration")]
		HealthDrain = 128,

		[StringValue("BFG freelook in multiplayer games")]
		[AlternateName("sv_bfgfreeaim")]
		BFGFreelook = 256,

		[StringValue("Barrels respawn")]
		[AlternateName("sv_barrelrespawn")]
		BarrelsRespawn = 512,

		[StringValue("No respawn protection")]
		[AlternateName("sv_norespawninvul")]
		NoRespawnProtection = 1024,

		[StringValue("Start with shotgun")]
		[AlternateName("sv_shotgunstart")]
		StartWithShotgun = 2048,

		[StringValue("Respawn in same place after death (coop)")]
		[AlternateName("sv_samespawnspot")]
		RespawnInSamePlace = 4096,

		[StringValue("Keep team after map change")]
		[AlternateName("sv_keepteams")]
		KeepTeamAfterMapChange = 8192,

		[StringValue("Don't clear frags after each level")]
		[AlternateName("sv_keepfrags")]
		DoNotClearFragsAfterEachLevel = 16384,

		[StringValue("Players cannot respawn")]
		[AlternateName("sv_norespawn")]
		PlayerCannotRespawn = 32768,

		[StringValue("Lose frag when killed")]
		[AlternateName("sv_losefrag")]
		LoseFragWhenKilled = 65536,

		[StringValue("Infinite inventory")]
		[AlternateName("sv_infiniteinventory")]
		InfiniteInventory = 131072,

		[StringValue("Enforce OpenGL rendering options")]
		[AlternateName("sv_forcegldefaults")]
		EnforceOpenGLRenderingOptions = 262144,

		[StringValue("Disable rocket jumping")]
		[AlternateName("sv_norocketjumping")]
		DisableRocketJumping = 524288,

		[StringValue("Award damage dealt, not amount of kills")]
		[AlternateName("sv_awarddamageinsteadkills")]
		AwardDamage = 1048576,

		[StringValue("Enforce alpha rendering")]
		[AlternateName("sv_forcealpha")]
		EnforceAlphaOptions = 2097152,

		[StringValue("All monsters must be killed before level exit")]
		[AlternateName("sv_killallmonsters")]
		AllMonstersMustBeKilledBeforeExit = 4194304,

		[StringValue("Disable automap")]
		[AlternateName("sv_noautomap")]
		DisableAutomap = 8388608,

		[StringValue("Allies can't be seen on automap")]
		[AlternateName("sv_noautomapallies")]
		AlliesCannotBeSeenOnAutomap = 16777216,

		[StringValue("Players can't spy on other allies")]
		[AlternateName("sv_disallowspying")]
		NoSpyingOnAllies = 33554432,

		[StringValue("Players can't use the chasecam cheat")]
		[AlternateName("sv_chasecam")]
		DisableChasecamCheat = 67108864,

		[StringValue("Disallow suicide")]
		[AlternateName("sv_disallowsuicide")]
		DisallowSuicide = 134217728,

		[StringValue("Disable autoaim")]
		[AlternateName("sv_noautoaim")]
		DisableAutoaim = 268435456,

		[StringValue("Spawn singleplayer actors in coop games")]
		[AlternateName("sv_coop_spactorspawn")]
		SpawnSinglePlayerActors = 536870912,
	}
}
