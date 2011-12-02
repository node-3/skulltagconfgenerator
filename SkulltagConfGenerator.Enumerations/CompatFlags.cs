using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkulltagConfGenerator.Enumerations.Utils;

namespace SkulltagConfGenerator.Enumerations {

	[Flags]
	[AlternateName("compatflags")]
	public enum CompatFlags : int {

		[StringValue("Use Doom's shortest texture around behavior")]
		[AlternateName("compat_shorttex")]
		UseDoomsShortestTextureAroundBehavior = 1,

		[StringValue("Don't fix loop index for stair building")]
		[AlternateName("compat_stairs")]
		DoNotFixLoopIndexForStairBuilding = 2,

		[StringValue("Limit Pain Elemental to 20 lost souls")]
		[AlternateName("compat_limitpain")]
		PainElementalLimitSouls = 4,

		[StringValue("Pickups are only heard locally")]
		[AlternateName("compat_silentpickup")]
		PickupsHeardLocally = 8,

		[StringValue("Infinitely tall actors")]
		[AlternateName("compat_nopassover")]
		InfinitelyTallActors = 16,

		[StringValue("Limit actors to one sound at a time")]
		[AlternateName("compt_soundslots")]
		LimitActorsOneSoundAtATime = 32,

		[StringValue("Enable buggier wall clipping so players can wallrun")]
		[AlternateName("compat_wallrun")]
		BuggierWallClipping = 64,

		[StringValue("Spawn dropped items directly on the floor")]
		[AlternateName("compat_notossdrops")]
		SpawnDroppedItemsDirectlyOnFloor = 128,

		[StringValue("Any special line can block a use line")]
		[AlternateName("compat_useblocking")]
		AnySpecialLineCanBlockUseLine = 256,

		[StringValue("Disable Boom door light effect")]
		[AlternateName("compat_nodoorlight")]
		DisableBoomDoorLightEffect = 512,

		[StringValue("Raven's scrollers use original carrying speed")]
		[AlternateName("compat_ravenscroll")]
		RavenScrollersUseOriginalCarryingSpeed = 1024,

		[StringValue("Use sector based sound target code")]
		[AlternateName("compat_soundtarget")]
		UseSectorBasedSoundTargetCode = 2048,

		[StringValue("Limit dehacked max health value from the health bonus")]
		[AlternateName("compat_dehhealth")]
		LimitHealthBonusMaxValue = 4096,

		[StringValue("Trace ignores lines with the same sector on both sides")]
		[AlternateName("compat_trace")]
		TraceIgnoreLinesSameSectorBothSides = 8192,

		[StringValue("Monsters cannot move when hanging over a dropoff")]
		[AlternateName("compat_dropoff")]
		MonstersCannotMoveWhenOnDropoff = 16384,

		[StringValue("Scrolling sectors are additive")]
		[AlternateName("compat_boomscroll")]
		ScrollingSectorsAreAdditive  = 32768,

		[StringValue("Monsters can see semi-invisible players")]
		[AlternateName("compat_invisibility")]
		MonstersCanSeeSemiInvisiblePlayers = 65536,

		[StringValue("Limited movement in the air")]
		[AlternateName("compat_limited_airmovement")]
		LimitedMovementInAir = 131072,

		[StringValue("Allow the 'plasma bump' bug")]
		[AlternateName("compat_plasmabump")]
		AllowPlasmaBumpBug = 262144,

		[StringValue("Allow instant respawn")]
		[AlternateName("compat_instantrespawn")]
		AllowInstantRespawn = 524288,

		[StringValue("Disable taunting")]
		[AlternateName("compat_disabletaunts")]
		DisableTaunting = 1048576,

		[StringValue("Use original sound curve")]
		[AlternateName("compat_originalsoundcurve")]
		OriginalSoundCurve = 2097152,

		[StringValue("Use original intermission screens")]
		[AlternateName("compat_oldintermission")]
		OriginalIntermissionScreens = 4194304,

		[StringValue("Disable stealth monsters")]
		[AlternateName("compat_disablestealthmonsters")]
		DisableStealthMonsters = 8388608,

		[StringValue("Use old damage")]
		[AlternateName("compat_oldradiusdmg")]
		UseOldDamage = 16777216,

		[StringValue("Disable crosshair")]
		[AlternateName("compat_nocrosshair")]
		DisableCrosshair = 33554432,

		[StringValue("Use old weapon pickup behavior")]
		[AlternateName("compat_oldweaponswitch")]
		UseOldWeaponPickupBehavior = 67108864,

		[StringValue("Instant moving floors are not silent")]
		[AlternateName("compat_silentinstantfloors")]
		InstantMovingFloorsAreNotSilent = 134217728,

		[StringValue("Sector sounds use original method for origin")]
		[AlternateName("compat_sectorsounds")]
		SectorSoundsUseOriginalMethodForOrigin = 268435456,

		[StringValue("Use original heights for clipping against projectiles")]
		[AlternateName("compat_missileclip")]
		UseOriginalHeightsForProjectileClipping = 536870912,

		[StringValue("Monsters can't be pushed over dropoffs")]
		[AlternateName("compat_crossdropoff")]
		MonstersCannotBePushedOverDropoffs = 1073741824

	}
}
