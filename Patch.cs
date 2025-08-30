using HarmonyLib;

public class HarmonyPatch1 
{
    public static void INTI()
    {
        var harmony = new Harmony(ASTRA_CLIENT.main.PluginInfo.GUID);
        harmony.PatchAll();
    }
}