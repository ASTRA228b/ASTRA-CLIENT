
using BepInEx;
using HarmonyLib;
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
        public static GameObject? menu;
        public static GameObject? menuBackground;
        public static GameObject? reference;
        public static GameObject? canvasObject;
        public static Font currentFont = Resources.GetBuiltinResource<Font>("Arial.ttf");

        public void Prefix()
        {
            try
            {
                bool openmenun = ControllerInputPoller.instance.leftControllerSecondaryButton;
                if (openmenun)
                {
                    CreateMenu();
                }
            }
            catch (Exception exc)
            {
                Debug.LogError($"[ASTRA CLIENT] Error in MainMenu Prefix: {exc.Message}");
            }
        }



        public static void CreateMenu()
        {
            menu = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(menu.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(menu.GetComponent<BoxCollider>());
            UnityEngine.Object.Destroy(menu.GetComponent<Renderer>());
            menu.transform.localScale = new Vector3(0.1f, 0.3f, 0.3825f);
            menuBackground = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(menuBackground.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(menuBackground.GetComponent<BoxCollider>());
            menuBackground.transform.parent = menu.transform;
            menuBackground.transform.rotation = Quaternion.identity;
            menuBackground.transform.localScale = menu.transform.localScale;
            menuBackground.transform.position = new Vector3(0.05f, 0f, 0f);
            menuBackground.GetComponent<Renderer>().material.color = Color.blue;
            canvasObject = new GameObject();
            canvasObject.transform.parent = menu.transform;
            Canvas canvas = canvasObject.AddComponent<Canvas>();
            CanvasScaler canvasScaler = canvasObject.AddComponent<CanvasScaler>();
            canvasObject.AddComponent<GraphicRaycaster>();
            canvas.renderMode = RenderMode.WorldSpace;
            canvasScaler.dynamicPixelsPerUnit = 1000f;
            menu.transform.position = GorillaTagger.Instance.rightHandTransform.position;
            menu.transform.rotation = GorillaTagger.Instance.rightHandTransform.rotation;
            UnityEngine.UI.Text text = new GameObject
            {
                transform =
                {
                    parent = canvasObject.transform
                }
            }.AddComponent<UnityEngine.UI.Text>();
            text.font = currentFont;
            text.text = "Astra menu";
            text.fontSize = 1;
            text.color = Color.white;
            text.supportRichText = true;
            text.fontStyle = FontStyle.Italic;
            text.alignment = TextAnchor.MiddleCenter;
            text.resizeTextForBestFit = true;
            text.resizeTextMinSize = 0;
            RectTransform component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(0.28f, 0.05f);
            component.position = new Vector3(0.06f, 0f, 0.165f);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
        }

        

    }

    internal class PluginInfo
    {
        public const string GUID = "ASTRA.MODS.CLIENT";
        public const string Name = "ASTRA CLIENT";
        public const string Version = "1.0.2";
    }
}
