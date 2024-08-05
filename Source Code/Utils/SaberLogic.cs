using BepInEx;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace GSabersRemaster.Utils
{
    public class SaberLogic : MonoBehaviour
    {
        private bool canUse;
        private bool bladeStatus;
        public GameObject saber;
        private GameObject blade;
        private GameObject hilt;
        private AudioSource saberOn;
        private AudioSource saberOff;
        private AudioSource saberIdle;
        public static SaberLogic instance;


        //GetDownStuff
        private bool _lastFrame;
        private bool _currentFrame;


        private void Awake()
        {
            canUse = true;
            blade = GameObject.Find("Sabers(Clone)/Blades");
            hilt = GameObject.Find("Sabers(Clone)/Hilts");
            blade.transform.localScale = new Vector3(0.5f, 0, 0.5f);
            saberOn = GameObject.Find("Sabers(Clone)/SaberOn").GetComponent<AudioSource>();
            saberOff = GameObject.Find("Sabers(Clone)/SaberOff").GetComponent<AudioSource>();
            saberIdle = GameObject.Find("Sabers(Clone)/SaberIdle").GetComponent<AudioSource>();
            instance = this;
        }

        private void Update()
        {

            _lastFrame = _currentFrame;
            _currentFrame = ControllerInputPoller.instance.rightControllerPrimaryButton;

            //if the trigger is pressed then try blade
            if (GetButtonDown() || UnityInput.Current.GetKeyDown(KeyCode.E))
                TryBlade();
        }

        private void TryBlade()
        {
            if (!bladeStatus)
            {
                bladeStatus = true;
                blade.transform.localScale = new Vector3(1, 1, 1);
                saberOn.Play();
                saberIdle.Play();
            }
            else
            {
                bladeStatus = false;
                blade.transform.localScale = new Vector3(0.5f, 0, 0.5f);
                saberOff.Play();
                saberIdle.Stop();
            }

        }

        //Get key Down but for the controllers Yur
        public bool GetButtonDown()
        {
            return !_lastFrame && _currentFrame;
        }

        public void Hide(bool isHidden)
        {
            blade.SetActive(isHidden);
            hilt.SetActive(isHidden);
            Mute(!isHidden);
        }

        public void Mute(bool isMuted)
        {
            saberOn.mute = isMuted;
            saberOff.mute = isMuted;
            saberIdle.mute = isMuted;
        }

    }
}
