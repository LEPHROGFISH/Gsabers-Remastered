using BepInEx;
using GSabersRemaster.Objects;
using System;
using UnityEngine;

namespace GSabersRemaster
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {



        void Start()
        {
            GorillaTagger.OnPlayerSpawned(Init);
        }

        void Init()
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
