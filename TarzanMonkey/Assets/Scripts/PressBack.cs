using UnityEngine;
using System.Collections;

public class PressBack : MonoBehaviour {
    bool ilkbasismi = false;

    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape) && ilkbasismi == false) {
            ilkbasismi = true;
            Application.Quit();
        }
	
	}
}
