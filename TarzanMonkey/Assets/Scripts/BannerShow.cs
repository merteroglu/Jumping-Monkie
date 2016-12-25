using UnityEngine;
using System.Collections;

public class BannerShow : MonoBehaviour {
    public GoogleMobileAdsDemoScript adMob;

	// Use this for initialization
	void Start () {
        adMob.RequestBanner();
        adMob.BannerShows();
       
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
