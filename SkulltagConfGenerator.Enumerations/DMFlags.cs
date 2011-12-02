using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkulltagConfGenerator.Enumerations.Utils;

namespace SkulltagConfGenerator.Enumerations {
	[Flags]
	[AlternateName("dmflags")]
	public enum DMFlags : int {
		[StringValue("Do not spawn health items")]
		[AlternateName("sv_nohealth")]
		DoNotSpawnHealthItems = 1,

		[StringValue("Do not spawn powerups")]
		[AlternateName("sv_noitems")]
		DoNotSpawnPowerups = 2,

		[StringValue("Weapons remain after pickup")]
		[AlternateName("sv_weaponstay")]
		WeaponsRemainAfterPickup = 4,

		[StringValue("Players sustain falling damage")]
		[AlternateName("sv_oldfalldamage")]
		PlayersSustainFallingDamage = 8,

		[StringValue("Players sustain falling damage (Hexen style)")]
		[AlternateName("sv_falldamage")]
		PlayersSustainFallingDamageHexenStyle = 16,

		[StringValue("Stay on same map when someone exits")]
		[AlternateName("sv_samelevel")]
		StayOnSameMap = 64,

		[StringValue("Spawn players as far away from each other as possible")]
		[AlternateName("sv_spawnfarthest")]
		SpawnPlayersFarAway = 128,

		[StringValue("Automatically respawn dead players")]
		[AlternateName("sv_forcerespawn")]
		RespawnDeadPlayers = 256,

		[StringValue("Do not spawn armor")]
		[AlternateName("sv_noarmor")]
		DoNotSpawnArmor = 512,

		[StringValue("Kill anyone who tries to exit the level")]
		[AlternateName("sv_noexit")]
		KillOnExit = 1024,

		[StringValue("Infinite ammo")]
		[AlternateName("sv_infiniteammo")]
		InfiniteAmmo = 2048,

		[StringValue("No monsters")]
		[AlternateName("sv_nomonsters")]
		NoMonsters = 4096,

		[StringValue("Monsters respawn")]
		[AlternateName("sv_monstersrespawn")]
		MonstersRespawn = 8192,

		[StringValue("Other powerups respawn")]
		[AlternateName("sv_itemsrespawn")]
		OtherPowerupsRespawn = 16384,

		[StringValue("Fast monsters")]
		[AlternateName("sv_fastmonsters")]
		FastMonsters = 32768,

		[StringValue("Don't allow jumping (overrides map's settings)")]
		[AlternateName("sv_nojump")]
		NoJumping = 65536,

		[StringValue("Don't allow freelook")]
		[AlternateName("sv_nofreelook")]
		NoFreelook = 131072,

		[StringValue("Invulnerability and invisibility respawn")]
		[AlternateName("sv_respawnsuper")]
		MegaPowerupsRespawn = 262144,

		[StringValue("Only admin can set FOV (for all players)")]
		[AlternateName("sv_nofov")]
		AdminSetFOV = 524288,

		[StringValue("Don't spawn multiplayer weapons in coop games")]
		[AlternateName("sv_noweaponspawn")]
		NoMultiplayerWeaponsInCoopGames = 1048576,

		[StringValue("Don't allow crouching (overrides map's settings)")]
		[AlternateName("sv_nocrouch")]
		NoCrouching = 2097152,

		[StringValue("Lose inventory on death (coop)")]
		[AlternateName("sv_coop_loseinventory")]
		LoseInventoryOnDeath = 4194304,

		[StringValue("Lose keys on death (coop)")]
		[AlternateName("sv_coop_losekeys")]
		LoseKeysOnDeath = 8388608,

		[StringValue("Lose weapons on death (coop)")]
		[AlternateName("sv_coop_loseweapons")]
		LoseWeaponsOnDeath = 16777216,

		[StringValue("Lose armor on death (coop)")]
		[AlternateName("sv_coop_losearmor")]
		LoseArmorOnDeath = 33554432,

		[StringValue("Lose powerups on death (coop)")]
		[AlternateName("sv_coop_losepowerups")]
		LosePowerupsOnDeath = 67108864,

		[StringValue("Lose ammo on death (coop)")]
		[AlternateName("sv_coop_loseammo")]
		LoseAmmoOnDeath = 134217728,

		[StringValue("Lose half ammo on death (coop)")]
		[AlternateName("sv_coop_halveammo")]
		LoseHalfAmmoOnDeath = 268435456,

		[StringValue("Allow jumping (overrides map's settings)")]
		[AlternateName("sv_allowjump")]
		AllowJumping = 536870912,

		[StringValue("Allow crouching (overrides map's settings)")]
		[AlternateName("sv_allowcrouch")]
		AllowCrouching = 1073741824,
	}
}
