using GSabersRemaster.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace GSabersRemaster.Objects
{
    public class SSelector : MonoBehaviour
    {
        public void Load(GameObject sselector)
        {
            var bundle = LoadAssetBundle("GSabersRemaster.Resources.sselector");
            var asset = bundle.LoadAsset<GameObject>("SSelector");

            sselector = Instantiate(asset);
            sselector.AddComponent<SelectorLogic>();
            sselector.GetComponent<SelectorLogic>().selector = sselector; 
        }
        public AssetBundle LoadAssetBundle(string path)
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
            AssetBundle bundle = AssetBundle.LoadFromStream(stream);
            stream.Close();
            return bundle;
        }
    }
}
