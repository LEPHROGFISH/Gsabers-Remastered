using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using UnityEngine;
using GSabersRemaster.Utils;

namespace GSabersRemaster.Objects
{
    public class Saber : MonoBehaviour
    {
        public void Load(GameObject saber)
        {
            var bundle = LoadAssetBundle("GSabersRemaster.Resources.gsabers");
            var asset = bundle.LoadAsset<GameObject>("Sabers");

            saber = Instantiate(asset, GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/RigAnchor/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R").transform);
            saber.transform.localPosition = new Vector3(0.05052872f, 0.07158074f, 0.008802317f);
            saber.transform.localRotation = Quaternion.Euler(16.652f, -81.292f, -80.824f);

            saber.AddComponent<SaberLogic>();
            saber.GetComponent<SaberLogic>().saber = saber;
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
