using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;


public class LeaderBoard : MonoBehaviour {
    private string leaderboard = "CgkIq5SA9YUJEAIQAA";
	// Use this for initialization
	void Start () {
        Confugire();
        Signin();
	}

    public void StartGame() {
        Application.LoadLevel(1);
    }



    public void Confugire() { 
     PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
    
       
        .RequireGooglePlus()
        .Build();

    PlayGamesPlatform.InitializeInstance(config);

         // Activate the Google Play Games platform
    PlayGamesPlatform.Activate();
    
    }

    public void Signin() {
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                Debug.Log("Sign in success");
            }
            else {
            Debug.Log("Sign in fail");
         
            }
            
        });


    
    }


    public void SendScore(int Score)
    {
        Social.ReportScore(Score, "CgkIq5SA9YUJEAIQAA", (bool success) =>
        {
            if (success)
            {
                Debug.Log("Score kaydedildi");
            }
            else {
                Debug.Log("Score kayit edilemedi");
            
            }

        });

    }

    public void ShowLeaderBoard()
    {
        /*Debug.Log("showleaderboard");
        if(Social.localUser.authenticated)
        Social.ShowLeaderboardUI();*/
        ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(leaderboard);
     

    }

    public void SignOut() {
        PlayGamesPlatform.Instance.SignOut();
    }
	
}
