using UnityEngine;

using System.Collections;

public class AnaMuzikPlay : MonoBehaviour {
    public AudioClip anaMuzik;
  

    private AudioSource source;

    int sesOnOff;

    

	// Use this for initialization
	void Start () {
        SesKontrol();
	}


    public void SesKontrol() {
        sesOnOff = PlayerPrefs.GetInt("AudioBit");

        source = GetComponent<AudioSource>();
        source.clip = anaMuzik;

        if (sesOnOff == 1)
        {
            source.Play();
        }
        else
        {
            source.Stop();
        }
    
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
