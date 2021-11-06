using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class PlayGamesController : MonoBehaviour {

    public void Start()
    {
        AuthenticateUser();
    }

    void AuthenticateUser()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) =>
        {
            if(success == true)
            {
                Debug.Log("Logged in to Google Play");
            }
            else 
            {
                Debug.Log("Unable to connect :(");
            }
        }
            );
    }

    public static void PostToLeaderboard(long newScore)
    {
        Social.ReportScore(newScore, GPGSIds.leaderboard_the_water_king, (bool success) =>
        {
            if (success)
            {
                Debug.Log("Posted new Score to leaderboard");
            }
            else
            {
                Debug.Log("Unable to post new score");
            }
        });
    }

    public static void ShowLeaderboardUI()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_the_water_king);
    }

}
