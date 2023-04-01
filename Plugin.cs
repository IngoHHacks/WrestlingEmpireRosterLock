using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.IO;

namespace WrestlingEmpireRosterLock
{
    [BepInPlugin(PluginGuid, PluginName, PluginVer)]
    [HarmonyPatch]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "IngoH.WrestlingEmpire.WrestlingEmpireRosterLock";
        public const string PluginName = "WrestlingEmpireRosterLock";
        public const string PluginVer = "1.0.0";

        internal static ManualLogSource Log;
        internal readonly static Harmony Harmony = new(PluginGuid);

        internal static string PluginPath;
        

        private void Awake()
        {
            Plugin.Log = base.Logger;

            PluginPath = Path.GetDirectoryName(Info.Location);
        }

        private void OnEnable()
        {
            Harmony.PatchAll();
            Logger.LogInfo($"Loaded {PluginName}!");
        }

        private void OnDisable()
        {
            Harmony.UnpatchSelf();
            Logger.LogInfo($"Unloaded {PluginName}!");
        }
        
        [HarmonyPatch(typeof(EEOKBCJJILL), "DKPEGLFPLME")]
        [HarmonyPrefix]
        private static bool EEOKBCJJILL_DKPEGLFPLME_(int FCKDOPLEBIE)
        {
            if (FCKDOPLEBIE >= 23 && FCKDOPLEBIE <= 26)
            {
                return false;
            }
            return true;
        }
    }
}