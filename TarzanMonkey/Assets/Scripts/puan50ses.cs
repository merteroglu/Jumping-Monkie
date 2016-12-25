using UnityEngine;
using System.Collections;

public class puan50ses : MonoBehaviour {

    public AudioClip puanSes;
    private AudioSource source;

    int acikMi;
	// Use this for initialization
	void Start () {
        acikMi = PlayerPrefs.GetInt("SFXBit");
        source = GetComponent<AudioSource>();

        if(acikMi == 1)
        source.PlayOneShot(puanSes, 1f);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
