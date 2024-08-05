using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace GSabersRemaster.Utils
{
    public class SelectorLogic : MonoBehaviour
    {
        public GameObject selector;
        public static SelectorLogic instance;
        private int currentColor;
        private int currentHilt;
        private GameObject[] bColors;
        private Animator animator;
        //settings
        public bool locked;

        //All the names of each color🥰🥰
        private string[] bColorNames =
        {
            "Rainbow",//0
            "Red",//1
            "Green",//2
            "Blue",//3
            "Purple",//4
            "Orange",//5
            "Negative",//6
            "Gold"//7
        };
        private GameObject[] cButtons;
        private GameObject[] hModels;
        //All the names of each hilt model🥰🥰
        private string[] hModelNames =
        {
            "Frog",//0
            "Anakin",//1
            "Obi",//2
            "Mace"//3
        };
        private GameObject[] hButtons;

        private GameObject[] sButtons;
        private string[] settingButtons =
        {
            "H",
            "V",
            "L",
            "I"
        };

        private void Awake()
        {
            instance = this;
            bColors = new GameObject[bColorNames.Length];
            cButtons = new GameObject[bColorNames.Length];
            hModels = new GameObject[hModelNames.Length];
            hButtons = new GameObject[hModelNames.Length];
            sButtons = new GameObject[settingButtons.Length];

            animator = GameObject.Find("SSelector(Clone)/Selector").GetComponent<Animator>();

            GameObject.Find("SSelector(Clone)/Button/Rise").AddComponent<SettingsButtons>();

            //For every Name in the color name array set a gameobject the color array to that gameobject
            for (int i = 0; i < bColorNames.Length; i++)
            {
                bColors[i] = GameObject.Find("Sabers(Clone)/Blades/" + bColorNames[i]);
                cButtons[i] = GameObject.Find("SSelector(Clone)/Selector/Colors/C" + i);
                if (cButtons[i].GetComponent<CosButton>() == null)
                {
                    cButtons[i].AddComponent<CosButton>();
                }
                if (bColors[i]!=null)
                    Debug.Log("Loaded: " + bColorNames[i] + "(Blade Color)");
            }
            //Does what the other one does but for the hilts
            for (int i = 0;i < hModelNames.Length; i++)
            {
                hModels[i] = GameObject.Find("Sabers(Clone)/Hilts/" + hModelNames[i]);
                hButtons[i] = GameObject.Find("SSelector(Clone)/Selector/Hilts/H" + i);
                hButtons[i].AddComponent<CosButton>();
                if (hModels[i]!=null)
                    Debug.Log("Loaded: " + hModelNames[i] + "(Hilt Model");
            }

            //Giving Settings buttons their scripts
            for (int i = 0; i < settingButtons.Length; i++)
            {
                sButtons[i] = GameObject.Find("SSelector(Clone)/Selector/Settings/" + settingButtons[i]);
                sButtons[i].AddComponent<SettingsButtons>();
            }

        }

        //Turns current hilt model off then turns the desired one on
        public void ChangeHilt(int modelID)
        {
            if (locked)
                return;

            hModels[currentHilt].SetActive(false);
            hModels[modelID].SetActive(true);
            currentHilt = modelID;
            Debug.Log("Hilt ID: " + currentHilt);
        }
        //Turns current color off then turns the desired one on
        public void ChangeColor(int ColorID)
        {
            if (locked)
                return;

            bColors[currentColor].SetActive(false);
            bColors[ColorID].SetActive(true);
            currentColor = ColorID;
            Debug.Log("Color ID: " + currentColor);
        }

        public void Rise(bool isUp)
        {
            if (isUp)
                animator.SetTrigger("Fall");

            else
                animator.SetTrigger("Rise");
        }
    }
}
