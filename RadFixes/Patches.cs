using HarmonyLib;
using UnityEngine;
using System.Linq;

namespace RadFixes
{
    internal class Patches
    {
        [HarmonyPatch(typeof(ShipItemFishingRod))]
        private class ShipItemFisingRodPatches
        {
            [HarmonyPostfix]
            [HarmonyPatch("OnLoad")]
            public static void OnLoadSetReverseSpinner(ref float ___spinnerSpeed)
            {
                ___spinnerSpeed = -40f;
            }

            [HarmonyPostfix]
            [HarmonyPatch("OnBuy")]
            public static void OnBuySetReverseSpinner(ref float ___spinnerSpeed)
            {
                ___spinnerSpeed = -40f;
            }
        }

        [HarmonyPatch(typeof(StartMenu))]
        private class StartMenuPatches
        {
            [HarmonyPostfix]
            [HarmonyPatch("Awake")]
            public static void DestroyDeco(GameObject ___settingsUI)
            {
                var deco = ___settingsUI.GetComponentsInChildren<Transform>().FirstOrDefault(k => k.name == "deco (1)");
                Object.Destroy(deco.gameObject);
            }
        }

        [HarmonyPatch(typeof(BackupSavesListUI))]
        private class BackupSavesListUIPatches
        {
            [HarmonyPostfix]
            [HarmonyPatch("Awake")]
            public static void SetShowingListFor(ref int ___showingListFor)
            {
                ___showingListFor = -1;
            }
        }

        [HarmonyPatch(typeof(MouseButtonPointer))]
        private class MouseButtonPointerPatches
        {
            [HarmonyPrefix]
            [HarmonyPatch("LateUpdate")]
            public static bool DisableMouseInputLostFocus()
            {
                if (!Application.isFocused)
                    return false;
                return true;
            }
        }
    }
}
