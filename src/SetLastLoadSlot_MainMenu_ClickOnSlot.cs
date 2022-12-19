using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace AutoLoad
{
    [HarmonyPatch(typeof(MainMenu), nameof(MainMenu.ClickOnSlot))]
    internal static class SetLastLoadSlot_MainMenu_ClickOnSlot
    {
        public static void Prefix(int _Index)
        {
            AutoLoad__MainMenu_Update_Patch.AbortAutoLoad();
            Plugin.LastLoadedSlot.Value = _Index + 1;
        }
    }
}
