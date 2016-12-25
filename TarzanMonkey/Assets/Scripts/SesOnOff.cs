using UnityEngine;
using System.Collections;
using System;

public class SesOnOff : MonoBehaviour {
    GameObject goToggle;

    public AnaMuzikPlay sesAcKapa;

    int sesBas;
	// Use this for initialization
	void Start () {
        sesBas = PlayerPrefs.GetInt("AudioBit");

        goToggle = GameObject.Find("Toggle");
       

        if (sesBas == 1) {
            goToggle.GetComponent<UnityEngine.UI.Toggle>().isOn = true;
        }
        else if (sesBas == 0) {
            goToggle.GetComponent<UnityEngine.UI.Toggle>().isOn = false;
        }
        
	}

  public void Toggle_changed(bool newvalue) {
        int setint;
       setint = Convert.ToInt32(newvalue);

        PlayerPrefs.SetInt("AudioBit", setint);
        sesAcKapa.SesKontrol();

    }
	
}
