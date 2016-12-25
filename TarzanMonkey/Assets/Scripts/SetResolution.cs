using UnityEngine;
using System.Collections;

public class SetResolution : MonoBehaviour {

	// Use this for initialization
	void Start () {

	Screen.SetResolution(480,320,true);
    Screen.sleepTimeout = SleepTimeout.NeverSleep;
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
