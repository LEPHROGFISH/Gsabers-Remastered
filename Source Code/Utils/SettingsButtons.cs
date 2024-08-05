using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace GSabersRemaster.Utils
{
    public class SettingsButtons : MonoBehaviour
    {
        public static bool isHilt;
        private static bool Pressed = false;

        //settings stuff
        private bool hidden;
        private bool muted;
        private bool locked;
        private bool rizzen;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out GorillaTriggerColliderHandIndicator component))
                StartCoroutine(Press(component.isLeftHand));
        }


        private void Awake()
        {
            gameObject.layer = 18;
        }

        private IEnumerator Press(bool isleft)
        {
            Pressed = true;
            GorillaTagger.Instance.StartVibration(isleft, GorillaTagger.Instance.tapHapticStrength / 2, GorillaTagger.Instance.tapHapticDuration);
            GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(211, isleft, 0.12f);
            PressEvent();
            yield return (object)new WaitForSeconds(1f);
            Pressed = false;
        }

        private void PressEvent()
        {
            if (gameObject.name.Contains("Rise"))
            {
                SelectorLogic.instance.Rise(rizzen);
                if (!rizzen)
                    rizzen = true;
                else
                    rizzen = false;
                
            }

            if (gameObject.name.Contains("H"))
            {
                SaberLogic.instance.Hide(hidden);

                if (hidden)
                    hidden = false;
                else
                    hidden = true;

            }
            if (gameObject.name.Contains("V"))
            {
                if (muted)
                    muted = false;
                else
                    muted = true;

                SaberLogic.instance.Mute(muted);
            }
            if (gameObject.name.Contains("L"))
            {
                
                if (SelectorLogic.instance.locked)
                    SelectorLogic.instance.locked = false;

                else
                    SelectorLogic.instance.locked = true;
                
            }

            if (gameObject.name.Contains("I"))
                System.Diagnostics.Process.Start("https://github.com/LEPHROGFISH/Gsabers-Remastered/wiki");

        }
    }
}
