using UnityEngine;
using System;
using System.Collections;

public class SFXOnOff : MonoBehaviour {

    GameObject goToggle;


	// Use this for initialization
    int sfxint;
	void Start () {
        sfxint = PlayerPrefs.GetInt("SFXBit");

	goToggle = GameObject.Find("SFX");
    if (sfxint == 1) {
        goToggle.GetComponent<UnityEngine.UI.Toggle>().isOn = true;

    }
    else if (sfxint == 0) {
        goToggle.GetComponent<UnityEngine.UI.Toggle>().isOn = false;
    }

    
    }

    public void Toggle_Changed(bool newValue) {
        int seTint;
        seTint = Convert.ToInt32(newValue);
        PlayerPrefs.SetInt("SFXBit", seTint);
    
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
