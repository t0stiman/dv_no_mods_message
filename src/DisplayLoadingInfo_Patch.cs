using HarmonyLib;

namespace no_mods_message;

[HarmonyPatch(typeof(DisplayLoadingInfo))]
[HarmonyPatch(nameof(DisplayLoadingInfo.OnLoadingStatusChanged))]
public class DisplayLoadingInfo_OnLoadingStatusChanged_Patch 
{
	private static void Postfix(ref DisplayLoadingInfo __instance)
	{
		__instance.modsNoticeTMP.text = "";
	}
}