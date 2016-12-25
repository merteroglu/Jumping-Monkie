using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;


public class GameOver : MonoBehaviour {
    public GameObject OyunSonuArkaPlan;
    LeaderBoard lBoard = new LeaderBoard();
    GoogleMobileAdsDemoScript Reklam;
   // Player myPlayer = new Player();
    
	// Use this for initialization
	void Start () {
        OyunSonuArkaPlan.SetActive(false);
        Reklam.HideBanner();
        
	}
	
    public void Retry(){
        Player.Skor = 0;
        Application.LoadLevel(1);
       
    }

    public void Back() {
        Player.Skor = 0;
        Application.LoadLevel(0);
    }

    public void Submit() {
        int score = Player.Skor;

        if (Social.localUser.authenticated)
        {
            Social.ReportScore(score, "CgkIq5SA9YUJEAIQAA", (bool success) =>
            {
                if (success)
                {
                    ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI("CgkIq5SA9YUJEAIQAA");
                }
                else
                {
                    //Debug.Log("Login failed for some reason");
                }
            });
        }

       
    }
}
