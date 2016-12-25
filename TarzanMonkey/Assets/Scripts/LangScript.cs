using UnityEngine;
using System.Collections;

public class LangScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

   public void TrDil() {
     //  if (string.Compare(PlayerPrefs.GetString("Dil"), "TR") != 1)   
       PlayerPrefs.SetString("Dil", "TR");

    }

   public void EngDil() {
       //if (string.Compare(PlayerPrefs.GetString("Dil"), "ENG") !=1) ;
       PlayerPrefs.SetString("Dil", "ENG");
   }


	
	// Update is called once per frame
	void Update () {
	
	}
}
