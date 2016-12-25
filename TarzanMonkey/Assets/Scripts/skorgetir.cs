using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using UnityEngine.UI;

public class skorgetir : MonoBehaviour {
    public Text highscore;
    private string leaderboard = "CgkIq5SA9YUJEAIQAA";
	// Use this for initialization
	void Start () {
       
       
        highscore.text = PlayerPrefs.GetInt("HighScore").ToString();

	}
	
	// Update is called once per frame
	void Update () {
	    
	}   



   
}
