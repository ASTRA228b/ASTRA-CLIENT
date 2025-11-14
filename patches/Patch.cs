using BepInEx;
using HarmonyLib;


namespace ASTRA_CLIENT.patches
{
    [HarmonyPatch(typeof(GrowingSnowballThrowable), "SnowballThrowEventReceiver")]
    // creds to iidk for some patch code 
    // go downlod is menu at  https://github.com/iiDk-the-actual/iis.Stupid.Menu
    [HarmonyPatch(typeof(VRRig), "UpdateFriendshipBracelet")]
    [HarmonyPatch(typeof(VRRig), "DroppedByPlayer")]
    [HarmonyPatch(typeof(VRRig), "RequestCosmetics")]
    [HarmonyPatch(typeof(VRRig), "RequestMaterialColor")]
    [HarmonyPatch(typeof(DeployedChild), "Deploy")]
    [HarmonyPatch(typeof(LuauVm), "OnEvent")]
    [HarmonyPatch(typeof(VRRig), "PackCompetitiveData")]
    [BepInPlugin(ASTRA_CLIENT.main.INFO2.GUID, ASTRA_CLIENT.main.INFO2.GUID, ASTRA_CLIENT.main.INFO2.GUID)]
    public class pathcesA : BaseUnityPlugin
    {
        bool _patchforpach = false;
        bool _modpaches = false;

        void Start()
        {
            if (_patchforpach)
            {
                ApplyPatches();
                _patchforpach = true;
            }

            if (_modpaches)
            {
                ApplyModPatches();
                _modpaches = true;
            }
        }


        void ApplyPatches()
        {
            var harmony = new Harmony(ASTRA_CLIENT.main.PluginInfo.GUID);
            harmony.PatchAll();
        }

        void ApplyModPatches()
        {
            var harmony = new Harmony(ASTRA_CLIENT.main.INFO2.GUID);
            harmony.PatchAll();
        }
        [HarmonyPatch(typeof(GorillaGameManager), "ForceStopGame_DisconnectAndDestroy")]
        public class NoQuitOnBan
        {
            private static bool Prefix() =>
                false;
        }
        [HarmonyPatch(typeof(GorillaNot), "ShouldDisconnectFromRoom")]
        public class NoShouldDisconnectFromRoom
        {
            private static bool Prefix() =>
                false;
        }
        [HarmonyPatch(typeof(VRRig), "OnDisable")]
        public class RigPatch
        {
            public static bool Prefix(VRRig __instance) =>
                !__instance.isLocal;
        }

        [HarmonyPatch(typeof(VRRig), "Awake")]
        public class RigPatch2
        {
            public static bool Prefix(VRRig __instance) =>
                __instance.gameObject.name != "Local Gorilla Player(Clone)";
        }
    }
}