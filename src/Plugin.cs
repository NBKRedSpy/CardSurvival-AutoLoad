using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace AutoLoad
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public static ManualLogSource Log { get; set; }
        public static ConfigEntry<int> LastLoadedSlot;
        public static ConfigEntry<int> AutoLoadDelayMilliseconds;


        private void Awake()
        {

            Log = Logger;

            Config.SaveOnConfigSet = true;

            LastLoadedSlot = Config.Bind("General", nameof(LastLoadedSlot), 0, "The last save slot that was loaded or created.");
            AutoLoadDelayMilliseconds = Config.Bind("General", nameof(AutoLoadDelayMilliseconds), 2000, "The number of milliseconds to wait for the shift key to abort the auto load.  Set to zero to immediately load.");

            Harmony harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
            harmony.PatchAll();

        }

        public static void LogInfo(string text)
        {
            Plugin.Log.LogInfo(text);
        }

        public static string GetGameObjectPath(GameObject obj)
        {
            GameObject searchObject = obj;

            string path = "/" + searchObject.name;
            while (searchObject.transform.parent != null)
            {
                searchObject = searchObject.transform.parent.gameObject;
                path = "/" + searchObject.name + path;
            }
            return path;
        }

    }
}