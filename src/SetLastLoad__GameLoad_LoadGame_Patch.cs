using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace AutoLoad
{
    internal class SetLastLoad__GameLoad_LoadGame_Patch
    {
        [HarmonyPatch(typeof(GameLoad), nameof(GameLoad.LoadGame))]
        internal static class SetLastLoadSlot_MainMenu_ClickOnSlot
        {
            public static void Prefix(int _Index)
            {
                Plugin.LastLoadedSlot.Value = _Index + 1;
            }
        }
    }
}
