using BepInEx;
using GSabersRemaster.Objects;
using System;
using UnityEngine;
using Utilla;

namespace GSabersRemaster
{
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {



        void Start()
        {
            Utilla.Events.GameInitialized += OnGameInitialized;
        }

        void OnEnable()
        {
            HarmonyPatches.ApplyHarmonyPatches();
        }

        void OnDisable()
        {
            HarmonyPatches.RemoveHarmonyPatches();
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
            GameObject saber = new GameObject("SaberLoad");
            saber.AddComponent<Saber>();
            saber.GetComponent<Saber>().Load(saber);

            GameObject selector = new GameObject("SelectorLoad");
            saber.AddComponent<SSelector>();
            saber.GetComponent<SSelector>().Load(selector);
        }
    }
}
