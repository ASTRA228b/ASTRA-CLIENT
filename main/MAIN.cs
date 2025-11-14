
using BepInEx;
using HarmonyLib;
using Photon.Voice;
using UnityEngine;
using UnityEngine.UI;
using static Mono.Security.X509.X520;
using static System.Net.Mime.MediaTypeNames;


namespace ASTRA_CLIENT.main
{
    [HarmonyPatch(typeof(GorillaLocomotion.GTPlayer))]
    [HarmonyPatch("LateUpdate", MethodType.Normal)]
    public class MainMenu : MonoBehaviour
    {
        public static Font currentFont = Resources.GetBuiltinResource<Font>("Arial.ttf");
    }
    
   

    internal class PluginInfo
    {
        public const string GUID = "ASTRA.MODS.CLIENT";
        public const string Name = "ASTRA CLIENT";
        public const string Version = "1.0.2";
    }
    internal class INFO2
    {
        public const string VERSION = "1.0.2";
        public const string NAME = "idk.mod.Pathces";
        public const string GUID = "idk.mod.PATCH";
    }
}
