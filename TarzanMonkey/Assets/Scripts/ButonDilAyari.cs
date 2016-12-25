using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ButonDilAyari : MonoBehaviour {
    public Image imgSubmit, imgKaydet;
    public Image imgRetry, imgTekrar;
    public Image imgBack, imgGeri;

    int Kontrol;
	// Use this for initialization

	void Start () {
        Kontrol = string.Compare(PlayerPrefs.GetString("Dil"), "TR");

        if (Kontrol == 0)
        {
            imgSubmit.enabled = false;
            imgRetry.enabled = false;
            imgBack.enabled = false;
        }
        else {
            imgKaydet.enabled = false;
            imgTekrar.enabled = false;
            imgGeri.enabled = false;
        
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
