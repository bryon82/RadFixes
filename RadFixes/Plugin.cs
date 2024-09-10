using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;

namespace RadFixes
{
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public const string PLUGIN_GUID = "com.raddude82.radfixes";
        public const string PLUGIN_NAME = "RadFixes";
        public const string PLUGIN_VERSION = "1.0.1";

        internal static Plugin instance;
        internal static ManualLogSource logger;

        private void Awake()
        {
            instance = this;
            logger = Logger;

            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), PLUGIN_GUID);
        }
    }
}
