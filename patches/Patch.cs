using BepInEx;
using HarmonyLib;


namespace ASTRA_CLIENT.patches
{
    
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
       
    }

}
