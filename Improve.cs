using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace Improve;

[BepInPlugin(PluginGuid, PluginName, PluginVersion)]
[BepInDependency("nickklmao.menulib", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("headclef.Relay", BepInDependency.DependencyFlags.HardDependency)]
public class Improve : BaseUnityPlugin
{
    private const string PluginGuid = "headclef.Improve";
    private const string PluginName = "R.E.P.O Awans";
    private const string PluginVersion = "1.2.2";

    internal static Improve Instance { get; private set; } = null!;
    internal new static ManualLogSource Logger => Instance._logger;
    private ManualLogSource _logger => base.Logger;
    internal Harmony? Harmony { get; set; }

    // ── Config ──
    internal static ConfigEntry<float> DifficultyMultiplier = null!;
    internal static ConfigEntry<int> BaseCost = null!;
    internal static ConfigEntry<KeyCode> OpenMenuKey = null!;

    private void Awake()
    {
        Instance = this;
        this.gameObject.transform.parent = null;
        this.gameObject.hideFlags = HideFlags.HideAndDontSave;

        BindConfiguration();
        SaveData.Initialize();
        ImproveMenu.Initialize();

        Harmony ??= new Harmony(Info.Metadata.GUID);
        Harmony.PatchAll();

        Logger.LogInfo($"{Info.Metadata.GUID} v{Info.Metadata.Version} has loaded!");
    }

    private void Update()
    {
        if (!Input.GetKeyDown(OpenMenuKey.Value)) return;
        try { ImproveMenu.TryOpenFromMainMenu(); }
        catch (System.Exception ex) { Logger.LogError($"Awans menu error: {ex}"); }
    }

    private void OnDestroy()
    {
        Harmony?.UnpatchSelf();
    }

    private void BindConfiguration()
    {
        OpenMenuKey = Config.Bind("Interface", "Open Menu Key", KeyCode.F5,
            "Open the Improve leveling menu from the main menu.");

        const string section = "Leveling";

        DifficultyMultiplier = Config.Bind(section, "Difficulty Multiplier", 0.5f,
            new ConfigDescription(
                "Difficulty multiplier for level-up cost. Easy=0.25, Standard=0.5, Hard=0.75, Hardest=1.0",
                new AcceptableValueRange<float>(0.1f, 2.0f)));

        BaseCost = Config.Bind(section, "Base Cost", 1000000,
            new ConfigDescription(
                "Base haul cost for level 1. Haul to reach level N is baseCost x difficulty x N^2.",
                new AcceptableValueRange<int>(100000, 10000000)));

    }
}
