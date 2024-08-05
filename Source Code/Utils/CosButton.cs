using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace GSabersRemaster.Utils
{
    public class CosButton : MonoBehaviour
    {
        public static bool isHilt;
        private static bool Pressed = false;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out GorillaTriggerColliderHandIndicator component))
            {
                StartCoroutine(Press(component.isLeftHand));
            }
            
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
            yield return (object)new WaitForSeconds(0.25f);
            Pressed = false;
        }

        private void PressEvent()
        {
            if (gameObject.name.Contains("H"))
            {
                SelectorLogic.instance.ChangeHilt(int.Parse(gameObject.name.Replace("H", "")));
            }
            else
            {
                SelectorLogic.instance.ChangeColor(int.Parse(gameObject.name.Replace("C", "")));
            }
        }
    }
}
