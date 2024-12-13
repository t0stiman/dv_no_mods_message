using System;
using System.Reflection;
using UnityModManagerNet;
using HarmonyLib;

namespace no_mods_message
{
	[EnableReloading]
	static class Main
	{
		private static UnityModManager.ModEntry myModEntry;
		private static Harmony myHarmony;

		//===========================================

		private static bool Load(UnityModManager.ModEntry modEntry)
		{
			try
			{
				myModEntry = modEntry;
				myModEntry.OnUnload = OnUnload;
				
				myHarmony = new Harmony(myModEntry.Info.Id);
				myHarmony.PatchAll(Assembly.GetExecutingAssembly());
			}
			catch (Exception ex)
			{
				myModEntry.Logger.LogException($"Failed to load {myModEntry.Info.DisplayName}:", ex);
				myHarmony?.UnpatchAll(myModEntry.Info.Id);
				return false;
			}

			myModEntry.Logger.Log("loaded");
			return true;
		}

		private static bool OnUnload(UnityModManager.ModEntry modEntry)
		{
			myHarmony?.UnpatchAll(myModEntry.Info.Id);
			return true;
		}
	}
}