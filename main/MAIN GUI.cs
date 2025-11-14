using ASTRA_CLIENT.main;
using ASTRA_CLIENT.Utilities;
using BepInEx;
using g3;
using GorillaExtensions;
using GorillaLocomotion;
using GorillaNetworking;
using HarmonyLib;
using Liv.NGFX;
using Meta.WitAi;
using Photon.Pun;
using Photon.Realtime;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Networking;
using static Mono.Security.X509.X509Stores;
using static Photon.Pun.UtilityScripts.TabViewManager;
using UIEventType = UnityEngine.EventType;


[BepInPlugin(ASTRA_CLIENT.main.PluginInfo.GUID, ASTRA_CLIENT.main.PluginInfo.Name, ASTRA_CLIENT.main.PluginInfo.Version)]
public class MAINGUI : BaseUnityPlugin
{
    Rect windowRect = new Rect(120, 120, 650, 500);
    Color color = Color.white;
    Color windowColor = new Color(0.1f, 0.1f, 0.1f, 1f);
    Color ButtonColor = new Color(0.2f, 0.2f, 0.2f, 1f);
    int currentTab = 0;
    Texture2D? solidTex;
    Texture2D? windowTex;
    GUIStyle? tabStyle;
    GUIStyle? tabPressedStyle;
    GUIStyle? windowStyle;
    GUIStyle? sliderStyle;
    GUIStyle? sliderThumbStyle;
    bool boxESP1 = false;
    bool boxESP2 = false; 
    bool boxESP3 = false;
    bool tracersESP = false;
    bool fivezfive = false;
    GUIStyle? buttons = null;
    bool ini = false;
    // bool showMessage = false; // SHOWING MESSAGE LABEL
    // float messageTimer = 0f; // MESSAGE LABEL TIMER
    Vector2 scrollPos = Vector2.zero;
    Color sliderTrackColor = new Color(0.15f, 0.15f, 0.15f, 1f);
    Color sliderThumbColor = new Color(0.0f, 0.6f, 1f, 1f);
    bool platss = false;
    private static GameObject? PlatsLeft, PlatsRight;
    private static bool PlatLSpawn, PlatRSpawn;
    bool mosa = false;
    float Mosaspeed = 10f;
    bool speed = false;
    float speedValue = 8.5f;
    float ArmAmount = 0f;
    bool isis = false;
    bool hidden = false;
    bool aspeed = false;
    float redValue = 0;
    float greenValue = 0f;
    float blueValue = 0f;
    float colorR = 0f;
    float colorG = 0f;
    float colorB = 0f;
    bool Mod1 = false;
    string NewName = "";
    string roomCode = "";
    bool skellyESP = false;
    bool sphereESP = false;
    struct Tab { public string Title; public Action Draw; public Tab(string t, Action d) { Title = t; Draw = d; } }
    List<Tab> tabs = new List<Tab>();
    bool gorillatime = false;
    Rect window = new Rect(100f, 100f, 200f, 200f);
    bool Moriningg = false;
    bool ten = false;
    bool day = false;
    bool evning = false;
    bool night = false;
    float fly = 111111f;
    bool cmet = false;
    Color windowColor2 = new Color(0.12f, 0.12f, 0.12f, 1f); 
    GUIStyle? toggels = null;
    string[] tabs2 = new string[] { "Main", "Settings", "Info" };
    bool h1 = false;
    Rect wini = new Rect(100, 100, 600, 400);
    static GameObject? lBall, rBall;
    // op mods trool
    bool Besp = false;
    bool invis = false;
    bool ghost = false;
    bool tahgun = false;
    bool noclipping = false;
    bool lowgravvity = false;
  
    void OnGUI()
    {
        if (!ini)
        {
            solidTex = new Texture2D(1, 1);
            solidTex.SetPixel(0, 0, new Color(0.15f, 0.15f, 0.15f, 1f));
            solidTex.Apply();
            windowTex = MakeTex(1, 1, windowColor2);
            tabStyle = new GUIStyle(GUI.skin.button);
            Texture2D tabTex = MakeTex(1, 1, ButtonColor);
            tabStyle.normal.background = tabTex;
            tabStyle.active.background = tabTex;
            tabStyle.hover.background = tabTex;
            tabStyle.focused.background = tabTex;
            tabStyle.onNormal.background = tabTex;
            tabStyle.onActive.background = tabTex;
            tabStyle.onHover.background = tabTex;
            tabStyle.onFocused.background = tabTex;
            tabStyle.normal.textColor = Color.white;
            tabStyle.hover.textColor = Color.blue;
            tabStyle.active.textColor = Color.red;
            tabStyle.focused.textColor = Color.white;
            tabStyle.onNormal.textColor = Color.blue;
            tabStyle.onHover.textColor = Color.blue;
            tabStyle.onActive.textColor = Color.blue;
            tabStyle.onFocused.textColor = Color.blue;
            tabStyle.fontStyle = FontStyle.Bold;
            tabStyle.padding = new RectOffset(8, 8, 4, 4);
            tabPressedStyle = new GUIStyle(tabStyle);
            Texture2D pressedTex = MakeTex(1, 1, new Color(0.2f, 0.6f, 1f, 1f)); 
            tabPressedStyle.normal.background = pressedTex;
            tabPressedStyle.active.background = pressedTex;
            tabPressedStyle.hover.background = pressedTex;
            tabPressedStyle.focused.background = pressedTex;
            tabPressedStyle.onNormal.background = pressedTex;
            tabPressedStyle.onActive.background = pressedTex;
            tabPressedStyle.onHover.background = pressedTex;
            tabPressedStyle.onFocused.background = pressedTex;
            windowStyle = new GUIStyle(GUI.skin.window);
            windowStyle.normal.background = windowTex;
            windowStyle.hover.background = windowTex;
            windowStyle.active.background = windowTex;
            windowStyle.focused.background = windowTex;
            windowStyle.onNormal.background = windowTex;
            windowStyle.onHover.background = windowTex;
            windowStyle.onActive.background = windowTex;
            windowStyle.onFocused.background = windowTex;
            windowStyle.normal.textColor = Color.white;
            windowStyle.fontStyle = FontStyle.Bold;
            sliderStyle = new GUIStyle(GUI.skin.horizontalSlider);
            sliderThumbStyle = new GUIStyle(GUI.skin.horizontalSliderThumb);
            sliderStyle.normal.background = MakeTex(1, 1, sliderTrackColor);
            sliderStyle.active.background = MakeTex(1, 1, sliderTrackColor);
            sliderStyle.hover.background = MakeTex(1, 1, sliderTrackColor);
            sliderThumbStyle.normal.background = MakeTex(1, 1, sliderThumbColor);
            sliderThumbStyle.active.background = MakeTex(1, 1, sliderThumbColor);
            sliderThumbStyle.hover.background = MakeTex(1, 1, sliderThumbColor);
            buttons = new GUIStyle(GUI.skin.button);
            Texture2D blackTex = MakeTex(1, 1, ButtonColor);
            buttons.normal.background = blackTex;
            buttons.active.background = blackTex;
            buttons.hover.background = blackTex;
            buttons.focused.background = blackTex;
            buttons.onNormal.background = blackTex;
            buttons.onActive.background = blackTex;
            buttons.onHover.background = blackTex;
            buttons.onFocused.background = blackTex;
            buttons.normal.textColor = Color.white;
            buttons.hover.textColor = Color.blue;
            buttons.active.textColor = Color.red;
            buttons.focused.textColor = Color.white;
            buttons.onNormal.textColor = Color.blue;
            buttons.onHover.textColor = Color.blue;
            buttons.onActive.textColor = Color.blue;
            buttons.onFocused.textColor = Color.blue;
            tabs.Clear();
            tabs.Add(new Tab("MAIN MODS", () => W(0)));
            tabs.Add(new Tab("SETTINGS", () => set(0)));
            tabs.Add(new Tab("SLIDERS/GOOFY", () => NN(1)));
            tabs.Add(new Tab("COLOR CHANGER", () => NAME(2)));
            tabs.Add(new Tab("NAME/ROOM", () => nameroom(4)));
            tabs.Add(new Tab("ESPS", () => espI(5)));
            tabs.Add(new Tab("CREDS", () => HH(3)));
            tabs.Add(new Tab("SoundBoard", () => soundb(6)));
            toggels = new GUIStyle(GUI.skin.toggle);
            Texture2D TOGGEL = MakeTex(1, 1, new Color(0.1f, 0.3f, 0.3f, 1f));
            toggels.normal.background = TOGGEL;
            toggels.active.background = TOGGEL;
            toggels.hover.background = TOGGEL;
            toggels.focused.background = TOGGEL;
            toggels.onNormal.background = TOGGEL;
            toggels.onActive.background = MakeTex(1, 1, new Color(0.1f, 0.1f, 0.1f, 1f));
            toggels.onHover.background = TOGGEL;
            toggels.onFocused.background = TOGGEL;
            GUI.skin.font = MainMenu.currentFont;
            tabStyle.font = GUI.skin.font;
            tabPressedStyle.font = GUI.skin.font;
            windowStyle.font = GUI.skin.font;
            sliderStyle.font = GUI.skin.font;
            sliderThumbStyle.font = GUI.skin.font;
            buttons.font = GUI.skin.font;
            toggels.font = GUI.skin.font;

            ini = true;
        }

        GUI.color = new Color(color.r, color.g, color.b, 1f);
        windowRect = GUILayout.Window(443, windowRect, ww, "", windowStyle);
        if (gorillatime)
        {
            window = GUILayout.Window(76, window, TimeUI, "GORILLA TIME");
        }
        if (h1)
        {
            wini = GUILayout.Window(00022, wini, win, "");
        }
    }


    void win(int id)
    {
        GUILayout.Label("idk");
        
    }


    void ww(int id)
    {
        Rect fullRect = new Rect(0, 0, windowRect.width, windowRect.height);
        GUI.DrawTexture(fullRect, MakeTex(1, 1, windowColor2));
        GUILayout.BeginHorizontal(GUI.skin.box);
        GUIStyle headerStyle = new GUIStyle(GUI.skin.label);
        headerStyle.fontStyle = FontStyle.Bold;
        headerStyle.normal.textColor = Color.white;
        GUILayout.Box("", GUILayout.Height(30), GUILayout.ExpandWidth(true));
        Rect headerRect = GUILayoutUtility.GetLastRect();
        GUI.DrawTexture(headerRect, MakeTex(1, 1, windowColor));
        GUI.Label(new Rect(headerRect.x + 10, headerRect.y + 5, 200, 20), "ASTRA CLIENT", headerStyle);
        GUI.Label(new Rect(headerRect.x + windowRect.width - 220, headerRect.y + 5, 210, 20),
        System.DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt"), headerStyle);
        GUILayout.EndHorizontal();
        GUILayout.Space(5);
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical(GUI.skin.box, GUILayout.Width(150), GUILayout.Height(300));
        for (int i = 0; i < tabs.Count; i++)
        {
            if (GUILayout.Button(tabs[i].Title, currentTab == i ? tabPressedStyle : tabStyle, GUILayout.Height(35)))
                currentTab = i;
        }
        GUILayout.EndVertical();
        GUILayout.Space(10);
        GUILayout.BeginVertical(GUI.skin.box, GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));
        GUILayout.Space(5);
        if (tabs.Count > 0)
        {
            if (currentTab < 0 || currentTab >= tabs.Count) currentTab = 0;
            tabs[currentTab].Draw();
        }
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();
        GUI.DragWindow();
    }






    void TimeUI(int windowID)
    {
        this.Morining();
        this.TENAM();
        this.dayy();
        this.Evning();
        this.Night();

        GUI.DragWindow();
    }
    void Morining()
    {
        this.Moriningg = GUILayout.Toggle(this.Moriningg, "Morning", Array.Empty<GUILayoutOption>());
        bool moriningg = this.Moriningg;
        if (moriningg)
        {
            BetterDayNightManager.instance.SetTimeOfDay(1);
        }
    }

    void TENAM()
    {
        this.ten = GUILayout.Toggle(this.ten, "10am", Array.Empty<GUILayoutOption>());
        bool flag = this.ten;
        if (flag)
        {
            BetterDayNightManager.instance.SetTimeOfDay(3);
        }
    }

    void dayy()
    {
        this.day = GUILayout.Toggle(this.day, "Day", Array.Empty<GUILayoutOption>());
        bool flag = this.day;
        if (flag)
        {
            BetterDayNightManager.instance.SetTimeOfDay(4);
        }
    }


    void Evning()
    {
        this.evning = GUILayout.Toggle(this.evning, "Evning", Array.Empty<GUILayoutOption>());
        bool flag = this.evning;
        if (flag)
        {
            BetterDayNightManager.instance.SetTimeOfDay(6);
        }
    }

    void Night()
    {
        this.night = GUILayout.Toggle(this.night, "Night", Array.Empty<GUILayoutOption>());
        bool flag = this.night;
        if (flag)
        {
            BetterDayNightManager.instance.SetTimeOfDay(0);
        }
    }


    
    void W(int id)
    {
        platss = GUILayout.Toggle(platss, "platfroms");
        mosa = GUILayout.Toggle(mosa, "Mosa Boost");
        speed = GUILayout.Toggle(speed, "Speed Boost");
        isis = GUILayout.Toggle(isis, "fly");
        hidden = GUILayout.Toggle(hidden, "Long Arms (A)");
        aspeed = GUILayout.Toggle(aspeed, "Speed Boost (A)");
        Mod1 = GUILayout.Toggle(Mod1, "Spazz Head");
        Besp = GUILayout.Toggle(Besp, "BOX ESP");
        invis = GUILayout.Toggle(invis, "Invis");
        ghost = GUILayout.Toggle(ghost, "Ghost monke");
        tahgun = GUILayout.Toggle(tahgun, "TagGun");
        noclipping = GUILayout.Toggle(noclipping, "Noclip");
        lowgravvity = GUILayout.Toggle(lowgravvity, "Low Gravity");
        GUILayout.Label("other guis");
        gorillatime = GUILayout.Toggle(gorillatime, "Gorilla Time");
        GUILayout.Label("broken dont turn on yet");
        cmet = GUILayout.Toggle(cmet, "Comet UI");
        if (Besp)
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig != GorillaTagger.Instance.offlineVRRig)
                {
                    UnityEngine.Color thecolor = vrrig.playerColor;
                    GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    box.transform.position = vrrig.transform.position;
                    UnityEngine.Object.Destroy(box.GetComponent<BoxCollider>());
                    box.transform.localScale = new Vector3(0.5f, 0.5f, 0f);
                    box.transform.LookAt(GorillaTagger.Instance.headCollider.transform.position);
                    box.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    box.GetComponent<Renderer>().material.color = thecolor;
                    UnityEngine.Object.Destroy(box, Time.deltaTime);
                }
            }
        }
        if (noclipping)
        {

            bool disablecolliders = ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f;
            MeshCollider[] colliders = Resources.FindObjectsOfTypeAll<MeshCollider>();

            foreach (MeshCollider collider in colliders)
            {
                collider.enabled = !disablecolliders;
            }
        }

        if (lowgravvity)
        {
            Physics.gravity = new Vector3(0, -3f, 0f);
        }
        else
        {
            Physics.gravity = new Vector3(0, -9.81f, 0);
        }


        if (invis)
        {
            if (ControllerInputPoller.instance.rightControllerSecondaryButton)
            {
                GorillaTagger.Instance.offlineVRRig.headBodyOffset.x = 180f;
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.headBodyOffset.x = 0f;
            }
        }

        if (ghost)
        {
            if (ControllerInputPoller.instance.rightControllerSecondaryButton)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }
        
        if(tahgun)
        {
            PlatL();
        }




        if (mosa)
        {
            GorillaLocomotion.GTPlayer.Instance.jumpMultiplier = 1.9f;
            GorillaLocomotion.GTPlayer.Instance.maxJumpSpeed = Mosaspeed;
        }
        if (speed)
        {
            GorillaLocomotion.GTPlayer.Instance.jumpMultiplier = 1.5f;
            GorillaLocomotion.GTPlayer.Instance.maxJumpSpeed = speedValue;
        }

        if (platss)
        {
            if (ControllerInputPoller.instance.leftControllerGripFloat > 0.1f && PlatsLeft == null)
            {
                PlatL();
            }
            if (ControllerInputPoller.instance.rightControllerGripFloat > 0.1f && PlatsRight == null)
            {
                PlatR();
            }

            if (ControllerInputPoller.instance.leftControllerGripFloat > 0.1f && PlatsLeft != null && !PlatLSpawn)
            {
               
                PlatsLeft.transform.position = GTPlayer.Instance.LeftHand.controllerTransform.position;
                PlatsLeft.transform.rotation = GTPlayer.Instance.LeftHand.controllerTransform.rotation;
                PlatLSpawn = true;
            }
            if (ControllerInputPoller.instance.rightControllerGripFloat > 0.1f && PlatsRight != null && !PlatRSpawn)
            {
                PlatsRight.transform.position = GTPlayer.Instance.RightHand.controllerTransform.position;
                PlatsRight.transform.rotation = GTPlayer.Instance.RightHand.controllerTransform.rotation;
                PlatRSpawn = true;
            }

            if (!ControllerInputPoller.instance.leftGrab && PlatsLeft != null)
            {
                GameObject.Destroy(PlatsLeft);
                PlatsLeft = null;
                PlatLSpawn = false;
            }
            if (!ControllerInputPoller.instance.rightGrab && PlatsRight != null)
            {
                GameObject.Destroy(PlatsRight);
                PlatsRight = null;
                PlatRSpawn = false;
            }

            if (isis)
            {
                if (ControllerInputPoller.instance.rightControllerPrimaryButton)
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaTagger.Instance.headCollider.transform.forward * Time.deltaTime * fly;
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
                }
            }

            if (hidden)
            {
                if (ControllerInputPoller.instance.rightControllerPrimaryButton)
                {
                    GTPlayer.Instance.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                }
            }
            if (aspeed)
            {
                if (ControllerInputPoller.instance.rightControllerPrimaryButton)
                {
                    GorillaLocomotion.GTPlayer.Instance.jumpMultiplier = 7.5f;
                    GorillaLocomotion.GTPlayer.Instance.maxJumpSpeed = 8f;
                }
            }
            if (Mod1)
            {
                var range = UnityEngine.Random.Range(0, 2000);
                VRRig.LocalRig.head.trackingRotationOffset.x = range;
                VRRig.LocalRig.head.trackingRotationOffset.y = range;
                VRRig.LocalRig.head.trackingRotationOffset.z = range;
            }

        }
    }

  

    void set(int id)
    {
        speedValue = GUILayout.HorizontalSlider(speedValue, 8.5f, 20f, sliderStyle, sliderThumbStyle);
        GUILayout.Label($"speedValue : [{speedValue:F2}]");
        Mosaspeed = GUILayout.HorizontalSlider(Mosaspeed, 8.5f, 20f, sliderStyle, sliderThumbStyle);
        GUILayout.Label($"Mosaspeed : [{Mosaspeed:F2}]");
        ArmAmount = GUILayout.HorizontalSlider(ArmAmount, 0f, 50f, sliderStyle, sliderThumbStyle);
        GUILayout.Label($"ARM : [{ArmAmount:F2}]");
        if (GUILayout.Button("Set Speed", buttons))
        {
            GorillaLocomotion.GTPlayer.Instance.jumpMultiplier = 1.5f;
            GorillaLocomotion.GTPlayer.Instance.maxJumpSpeed = speedValue;
        }
        if (GUILayout.Button("Set MSpeed", buttons))
        {
            GorillaLocomotion.GTPlayer.Instance.jumpMultiplier = 1.5f;
            GorillaLocomotion.GTPlayer.Instance.maxJumpSpeed = Mosaspeed;
        }
        if (GUILayout.Button("Set Arms", buttons))
        {
            GTPlayer.Instance.transform.localScale = new Vector3(ArmAmount, ArmAmount, ArmAmount);
        }
        if (GUILayout.Button("Reset Arms", buttons))
        {
            GTPlayer.Instance.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (GUILayout.Button("FixHead", buttons))
        {
            VRRig.LocalRig.head.trackingRotationOffset.x = 0f;
            VRRig.LocalRig.head.trackingRotationOffset.y = 0f;
            VRRig.LocalRig.head.trackingRotationOffset.z = 0f;
        }

    }
    public static void fixHead()
    {
        VRRig.LocalRig.head.trackingRotationOffset.x = 0f;
        VRRig.LocalRig.head.trackingRotationOffset.y = 0f;
        VRRig.LocalRig.head.trackingRotationOffset.z = 0f;
    }
    void NAME(int id)
    {
        GUILayout.Label("color settings");
        GUILayout.Label($" [{colorR:F2}]");
        colorR = GUILayout.HorizontalSlider(colorR, 0f, 9f, sliderStyle, sliderThumbStyle);
        GUILayout.Label("r");
        GUILayout.Label($"  [{colorG:F2}]");
        colorG = GUILayout.HorizontalSlider(colorG, 0f, 9f, sliderStyle, sliderThumbStyle);
        GUILayout.Label("g");
        GUILayout.Label($" [{colorB:F2}]");
        colorB = GUILayout.HorizontalSlider(colorB, 0f, 9f, sliderStyle, sliderThumbStyle);
        GUILayout.Label("b");
        if (GUILayout.Button("Set Color", buttons))
        {
            redValue = colorR;
            greenValue = colorG;
            blueValue = colorB;
            GorillaTagger.Instance.UpdateColor(redValue, greenValue, blueValue);
        }
    }

    void NN(int id)
    {
        if (GUILayout.Button("UpsideDownHead", buttons))
        {
            VRRig.LocalRig.head.trackingRotationOffset.z = 180f;
        }
        if (GUILayout.Button("BrokenNeck", buttons))
        {
            VRRig.LocalRig.head.trackingRotationOffset.z = 90f;
        }
        if (GUILayout.Button("BackwardsHead", buttons))
        {
            VRRig.LocalRig.head.trackingRotationOffset.y = 180f;
        }
        if (GUILayout.Button("SidewaysHead", buttons))
        {
            VRRig.LocalRig.head.trackingRotationOffset.y = 90f;
        }
        if (GUILayout.Button("Spazz Head", buttons))
        {
            var range = UnityEngine.Random.Range(0, 2000);
            VRRig.LocalRig.head.trackingRotationOffset.x = range;
            VRRig.LocalRig.head.trackingRotationOffset.y = range;
            VRRig.LocalRig.head.trackingRotationOffset.z = range;
        }
    }
   
    void nameroom(int id)
    {
        GUILayout.Label("Change Name");
        GUILayout.BeginHorizontal();
        GUILayout.Label("Name: ");
        NewName = GUILayout.TextField(NewName, 20);
        if (GUILayout.Button("Change Name"))
        {
            PhotonNetwork.LocalPlayer.NickName = NewName;
            GorillaComputer.instance.currentName = NewName;
            GorillaComputer.instance.savedName = NewName;
        }
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Room: ");
        roomCode = GUILayout.TextField(roomCode, 20);

        if (GUILayout.Button("Join Room"))
        {
            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom(roomCode, 0);
        }

        if (GUILayout.Button("Disconnect"))
        {
            PhotonNetwork.Disconnect();
        }
        GUILayout.EndHorizontal();
    }

   
    void PlatL()
    {
        PlatsLeft = GameObject.CreatePrimitive(PrimitiveType.Cube);
        UnityEngine.Object.Destroy(PlatsLeft.GetComponent<Rigidbody>());
        UnityEngine.Object.Destroy(PlatsLeft.GetComponent<BoxCollider>());
        UnityEngine.Object.Destroy(PlatsLeft.GetComponent<Renderer>());
        PlatsLeft.transform.localScale = new Vector3(0.25f, 0.3f, 0.25f);

        GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
        gameObject.transform.parent = PlatsLeft.transform;
        gameObject.transform.rotation = Quaternion.identity;
        gameObject.transform.localScale = new Vector3(0.1f, 1f, 1f);
        gameObject.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
        gameObject.GetComponent<Renderer>().material.color = GorillaTagger.Instance.offlineVRRig.playerColor;
        gameObject.transform.position = new Vector3(0.02f, 0f, 0f);
    }

    void PlatR()
    {
        PlatsRight = GameObject.CreatePrimitive(PrimitiveType.Cube);
        UnityEngine.Object.Destroy(PlatsRight.GetComponent<Rigidbody>());
        UnityEngine.Object.Destroy(PlatsRight.GetComponent<BoxCollider>());
        UnityEngine.Object.Destroy(PlatsRight.GetComponent<Renderer>());

        PlatsRight.transform.localScale = new Vector3(0.25f, 0.3f, 0.25f);
        GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
        gameObject.transform.parent = PlatsRight.transform;
        gameObject.transform.rotation = Quaternion.identity;
        gameObject.transform.localScale = new Vector3(0.1f, 1f, 1f);
        gameObject.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
        gameObject.GetComponent<Renderer>().material.color = GorillaTagger.Instance.offlineVRRig.playerColor;
        gameObject.transform.position = new Vector3(-0.02f, 0f, 0f);
    }

    void HH(int id)
    {
        GUIStyle centerLabel = new GUIStyle(GUI.skin.label);
        centerLabel.alignment = TextAnchor.MiddleCenter;
        centerLabel.normal.textColor = Color.white;
        centerLabel.fontSize = 12;
        GUILayout.FlexibleSpace();
        GUILayout.Label("ASTRA", centerLabel);
        GUILayout.Label("creds to rtf for tpgun and ghost monkey", centerLabel);
        GUILayout.Label("creds to CrysGT or coolgamerdube for the boxesp", centerLabel);
        GUILayout.Label("NOT-HACKERZ (HELPED WITH THE GUI)", centerLabel);
        GUILayout.Label("creds to Malachi for variables/extra code", centerLabel);
        GUILayout.Label("Creds TortiseWay2Cool for soundstuff script", centerLabel);
        GUILayout.FlexibleSpace();
    }
    void espI(int id)
    {
        GUILayout.Label("ESP'S");
        boxESP1 = GUILayout.Toggle(boxESP1, "Box ESP");
        boxESP2 = GUILayout.Toggle(boxESP2, "Box ESP V2");
        boxESP3 = GUILayout.Toggle(boxESP3, "Box ESP V3");
        skellyESP = GUILayout.Toggle(skellyESP, "Skeleton ESP");
        sphereESP = GUILayout.Toggle(sphereESP, "Sphere ESP");
        GUILayout.Label("Tracers");
        tracersESP = GUILayout.Toggle(tracersESP, "Tracers");
        if (boxESP1)
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig != GorillaTagger.Instance.offlineVRRig)
                {
                    Color thecolor = vrrig.playerColor;
                    GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                   UnityEngine.Object.Destroy(box.GetComponent<BoxCollider>());
                    box.transform.position = vrrig.transform.position;
                    box.transform.localScale = new Vector3(0.7f, 0.7f, 0f);
                    box.transform.LookAt(GorillaTagger.Instance.headCollider.transform.position);
                    box.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    box.GetComponent<Renderer>().material.color = thecolor;
                    UnityEngine.Object.Destroy(box, Time.deltaTime);
                }
            }
        }

        if (boxESP2)
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig != GorillaTagger.Instance.offlineVRRig)
                {
                    Shader shader = Shader.Find("GorillaTag/UberShader");
                    Color color = vrrig.playerColor;
                    GameObject parent = new GameObject("ESPOutline");
                    parent.transform.position = vrrig.transform.position;
                    GameObject top = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    UnityEngine.Object.Destroy(top.GetComponent<BoxCollider>());
                    top.transform.SetParent(parent.transform);
                    top.transform.localPosition = new Vector3(0f, 0.5f, 0f);
                    top.transform.localScale = new Vector3(1f, 0.02f, 0.02f);
                    top.GetComponent<Renderer>().material.shader = shader;
                    top.GetComponent<Renderer>().material.color = color;
                    GameObject bottom = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    UnityEngine.Object.Destroy(bottom.GetComponent<BoxCollider>());
                    bottom.transform.SetParent(parent.transform);
                    bottom.transform.localPosition = new Vector3(0f, -0.5f, 0f);
                    bottom.transform.localScale = new Vector3(1f, 0.02f, 0.02f);
                    bottom.GetComponent<Renderer>().material.shader = shader;
                    bottom.GetComponent<Renderer>().material.color = color;
                    GameObject left = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    UnityEngine.Object.Destroy(left.GetComponent<BoxCollider>());
                    left.transform.SetParent(parent.transform);
                    left.transform.localPosition = new Vector3(-0.5f, 0f, 0f);
                    left.transform.localScale = new Vector3(0.02f, 1f, 0.02f);
                    left.GetComponent<Renderer>().material.shader = shader;
                    left.GetComponent<Renderer>().material.color = color;
                    GameObject right = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    UnityEngine.Object.Destroy(right.GetComponent<BoxCollider>());
                    right.transform.SetParent(parent.transform);
                    right.transform.localPosition = new Vector3(0.5f, 0f, 0f);
                    right.transform.localScale = new Vector3(0.02f, 1f, 0.02f);
                    right.GetComponent<Renderer>().material.shader = shader;
                    right.GetComponent<Renderer>().material.color = color;
                    parent.transform.LookAt(GorillaTagger.Instance.headCollider.transform.position);
                    UnityEngine.Object.Destroy(parent, Time.deltaTime);
                }
            }
        }

        if (boxESP3)
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig != GorillaTagger.Instance.offlineVRRig)
                {
                    Shader shader = Shader.Find("GorillaTag/UberShader");
                    Color color = vrrig.playerColor;
                    GameObject parent = new GameObject("ESPCorners");
                    parent.transform.position = vrrig.transform.position;
                    GameObject cornerTLH = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    UnityEngine.Object.Destroy(cornerTLH.GetComponent<BoxCollider>());
                    cornerTLH.transform.SetParent(parent.transform);
                    cornerTLH.transform.localPosition = new Vector3(-0.42f, 0.49f, 0f);
                    cornerTLH.transform.localScale = new Vector3(0.15f, 0.02f, 0.02f);
                    cornerTLH.GetComponent<Renderer>().material.shader = shader;
                    cornerTLH.GetComponent<Renderer>().material.color = color;
                    GameObject cornerTLV = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    UnityEngine.Object.Destroy(cornerTLV.GetComponent<BoxCollider>());
                    cornerTLV.transform.SetParent(parent.transform);
                    cornerTLV.transform.localPosition = new Vector3(-0.49f, 0.42f, 0f);
                    cornerTLV.transform.localScale = new Vector3(0.02f, 0.15f, 0.02f);
                    cornerTLV.GetComponent<Renderer>().material.shader = shader;
                    cornerTLV.GetComponent<Renderer>().material.color = color;
                    GameObject cornerTRH = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    UnityEngine.Object.Destroy(cornerTRH.GetComponent<BoxCollider>());
                    cornerTRH.transform.SetParent(parent.transform);
                    cornerTRH.transform.localPosition = new Vector3(0.42f, 0.49f, 0f);
                    cornerTRH.transform.localScale = new Vector3(0.15f, 0.02f, 0.02f);
                    cornerTRH.GetComponent<Renderer>().material.shader = shader;
                    cornerTRH.GetComponent<Renderer>().material.color = color;
                    GameObject cornerTRV = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    UnityEngine.Object.Destroy(cornerTRV.GetComponent<BoxCollider>());
                    cornerTRV.transform.SetParent(parent.transform);
                    cornerTRV.transform.localPosition = new Vector3(0.49f, 0.42f, 0f);
                    cornerTRV.transform.localScale = new Vector3(0.02f, 0.15f, 0.02f);
                    cornerTRV.GetComponent<Renderer>().material.shader = shader;
                    cornerTRV.GetComponent<Renderer>().material.color = color;
                    GameObject cornerBLH = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    UnityEngine.Object.Destroy(cornerBLH.GetComponent<BoxCollider>());
                    cornerBLH.transform.SetParent(parent.transform);
                    cornerBLH.transform.localPosition = new Vector3(-0.42f, -0.49f, 0f);
                    cornerBLH.transform.localScale = new Vector3(0.15f, 0.02f, 0.02f);
                    cornerBLH.GetComponent<Renderer>().material.shader = shader;
                    cornerBLH.GetComponent<Renderer>().material.color = color;
                    GameObject cornerBLV = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    UnityEngine.Object.Destroy(cornerBLV.GetComponent<BoxCollider>());
                    cornerBLV.transform.SetParent(parent.transform);
                    cornerBLV.transform.localPosition = new Vector3(-0.49f, -0.42f, 0f);
                    cornerBLV.transform.localScale = new Vector3(0.02f, 0.15f, 0.02f);
                    cornerBLV.GetComponent<Renderer>().material.shader = shader;
                    cornerBLV.GetComponent<Renderer>().material.color = color;
                    GameObject cornerBRH = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    UnityEngine.Object.Destroy(cornerBRH.GetComponent<BoxCollider>());
                    cornerBRH.transform.SetParent(parent.transform);
                    cornerBRH.transform.localPosition = new Vector3(0.42f, -0.49f, 0f);
                    cornerBRH.transform.localScale = new Vector3(0.15f, 0.02f, 0.02f);
                    cornerBRH.GetComponent<Renderer>().material.shader = shader;
                    cornerBRH.GetComponent<Renderer>().material.color = color;
                    GameObject cornerBRV = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    UnityEngine.Object.Destroy(cornerBRV.GetComponent<BoxCollider>());
                    cornerBRV.transform.SetParent(parent.transform);
                    cornerBRV.transform.localPosition = new Vector3(0.49f, -0.42f, 0f);
                    cornerBRV.transform.localScale = new Vector3(0.02f, 0.15f, 0.02f);
                    cornerBRV.GetComponent<Renderer>().material.shader = shader;
                    cornerBRV.GetComponent<Renderer>().material.color = color;
                    parent.transform.LookAt(GorillaTagger.Instance.headCollider.transform.position);
                    UnityEngine.Object.Destroy(parent, Time.deltaTime);
                }
            }
        }
        if (skellyESP)
        {
            float width = 0.025f;
            Shader shader = Shader.Find("GUI/Text Shader");

            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig != GorillaTagger.Instance.offlineVRRig)
                {
                    Color color = vrrig.playerColor;
                    Transform[] bones = vrrig.mainSkin.bones;
                    int[] bonePairs = new int[]
 {
    8,
    12,
    27,
    15,
    33,
    41,
    19,
    5,
    48,
    22,
    7,
    13,
    29,
    36,
    18,
    24,
    40,
    11,
    21,
    9,
    14,
    6,
    31,
    44,
    28,
    39,
    3,
    20,
    26,
    16,
    10,
    4,
    37,
    42,
    2,
    30,
    1,
    23
 };

                    LineRenderer headLine = GTExt.GetOrAddComponent<LineRenderer>(vrrig.head.rigTarget.gameObject);
                    headLine.startWidth = headLine.endWidth = width;
                    headLine.material.shader = shader;
                    headLine.startColor = headLine.endColor = color;
                    headLine.SetPosition(0, vrrig.head.rigTarget.position + new Vector3(0f, 0.16f, 0f));
                    headLine.SetPosition(1, vrrig.head.rigTarget.position - new Vector3(0f, 0.4f, 0f));
                    for (int i = 0; i < bonePairs.Length; i += 2)
                    {
                        LineRenderer lr = GTExt.GetOrAddComponent<LineRenderer>(bones[bonePairs[i]].gameObject);
                        lr.startWidth = lr.endWidth = width;
                        lr.material.shader = shader;
                        lr.startColor = lr.endColor = color;
                        lr.SetPosition(0, bones[bonePairs[i]].position);
                        lr.SetPosition(1, bones[bonePairs[i + 1]].position);
                    }
                }
            }
        }

        if (sphereESP)
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig != GorillaTagger.Instance.offlineVRRig)
                {
                    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    UnityEngine.Object.Destroy(sphere.GetComponent<SphereCollider>());
                    sphere.transform.position = vrrig.transform.position;
                    sphere.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                    sphere.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    sphere.GetComponent<Renderer>().material.color = vrrig.playerColor;
                    UnityEngine.Object.Destroy(sphere, Time.deltaTime);
                }
            }
        }
        if (tracersESP)
        {
            if (PhotonNetwork.InRoom)
            {
                foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                {
                    if (vrrig != GorillaTagger.Instance.offlineVRRig)
                    {
                        Shader shader = Shader.Find("GorillaTag/UberShader");
                        Color color = vrrig.playerColor;
                        LineRenderer lr = GTExt.GetOrAddComponent<LineRenderer>(vrrig.gameObject);
                        lr.startWidth = 0.01f;
                        lr.endWidth = 0.01f;
                        lr.positionCount = 2;
                        lr.useWorldSpace = true;
                        lr.SetPosition(0, trace());
                        lr.SetPosition(1, vrrig.transform.position);
                        lr.material.shader = Shader.Find("GUI/Text Shader");
                        lr.startColor = color;
                        lr.endColor = color;
                        if (!new List<LineRenderer>().Contains(lr))
                            new List<LineRenderer>().Add(lr);
                    }
                }
            }
            else
            {
                if (new List<LineRenderer>().Count > 0)
                {
                    foreach (LineRenderer lineRenderer in new List<LineRenderer>())
                        UnityEngine.Object.Destroy(lineRenderer);
                    new List<LineRenderer>().Clear();
                }
            }
        }
        else
        {
            if (new List<LineRenderer>().Count > 0)
            {
                foreach (LineRenderer lineRenderer in new List<LineRenderer>())
                    UnityEngine.Object.Destroy(lineRenderer);
                new List<LineRenderer>().Clear();
            }
        }
    }
    static int system = 1;
    static Vector3 trace()
    {
        switch (system)
        {
            case 1:
                return GTPlayer.Instance.RightHand.controllerTransform.position;

            case 2:
                return GTPlayer.Instance.LeftHand.controllerTransform.position;

            case 3:
                return GTPlayer.Instance.bodyCollider.transform.position - new Vector3(0f, 0.3f, 0f);

            case 4:
                return GTPlayer.Instance.bodyCollider.transform.position + new Vector3(0f, 0.5f, 0f);

            default:
                return Vector3.zero;
        }
    }

    async void soundb(int id)
    {
        if (GUILayout.Button("Play Sound", buttons))
        {
            var clip = await SoundManager.LoadAudioFromFile("505.wav");
            if (clip != null)
            {
                await SoundManager.PalySoundOnMIC(clip, true);
            }
        }

        fivezfive = GUILayout.Toggle(fivezfive, "505");
        if (fivezfive)
        {
            var clip = await SoundManager.LoadAudioFromFile("505.wav");
            if (clip != null)
            {
                await SoundManager.PalySoundOnMIC(clip, true);
            }
        }
    }


    Texture2D MakeTex(int width, int height, Color col)
    {
        Texture2D result = new Texture2D(width, height);
        for (int y = 0; y < height; y++) for (int x = 0; x < width; x++) result.SetPixel(x, y, col);
        result.Apply();
        return result;
    }

}

