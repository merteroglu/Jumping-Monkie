using UnityEngine;
using System.Collections;

public class PressEsc : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Player.Skor = 0;
            Application.LoadLevel(0);
        }
	}
}
