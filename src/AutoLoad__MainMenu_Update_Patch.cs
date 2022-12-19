using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace AutoLoad
{
    [HarmonyPatch(typeof(MainMenu), "Update")]
    public static class AutoLoad__MainMenu_Update_Patch
    {
        private static Stopwatch Stopwatch = Stopwatch.StartNew();
        private static int AutoLoadDelayMilliseconds = Plugin.AutoLoadDelayMilliseconds.Value;

        public static void AbortAutoLoad()
        {
            Stopwatch.Stop();
        }

        public static void Postfix(MainMenu __instance)
        {
            if(Plugin.LastLoadedSlot.Value == 0)
            {
                Stopwatch.Stop();
            }
            else if (Stopwatch.IsRunning)
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    Stopwatch.Stop();
                }
                else if (Stopwatch.ElapsedMilliseconds > AutoLoadDelayMilliseconds)
                {
                    Stopwatch.Stop();
                    __instance.ClickOnSlot(Plugin.LastLoadedSlot.Value -1);
                }
            }

        }

    }
}
