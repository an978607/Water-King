using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    //public InputField scoreInputField;
    //public Text errorText;
    // Start is called before the first frame update
    void Start()
    {
        //errorText.text = "";
    }

    public void OnButtonPostToLeaderboard()
    {
        Debug.Log("Posting score to leaderboard");
        // errorText.text = "";

        //if(string.IsNullOrEmpty(scoreInputField.text))
        //{
        // errorText.text = "Error: please enter a value";
        // return;
        //}
        // else 
        // {
        // long scoreToPost;
        // if(long.TryParse(scoreInputField.text, out scoreToPost))
        // {
        // PlayGamesController.PostToLeaderboard(scoreToPost);
        // }
        //  else 
        //  {
        //  errorText.text = "Error! :(";
        // }
        //  }
    }

    public void OnButtonShowLeaderboard()
    {
        Debug.Log("Showing Leaderboard");
       // PlayGamesController.ShowLeaderboardUI();
    }
}