using BepInEx;
using System;
using UnityEditor;
using UnityEngine;
using BepInEx.Logging;
using GorillaLocomotion;
using GorillaNetworking;
using GorillaTag;
using GorillaTagScripts;
using GorillaGameModes;
using GorillaExtensions;
using Photon.Pun;
using UnityEngine.UI;
using HarmonyLib;



namespace ASTRA_CLIENT.MAIN_MENU_SCRIPT
{
    [HarmonyPatch(typeof(GorillaLocomotion.GTPlayer))]
    [HarmonyPatch("LateUpdate", MethodType.Normal)]
    [BepInPlugin(ASTRA_CLIENT.main.INFO2.GUID, ASTRA_CLIENT.main.INFO2.NAME, ASTRA_CLIENT.main.INFO2.VERSION)]
    public class MAIN : MonoBehaviour 
    {

    }
}