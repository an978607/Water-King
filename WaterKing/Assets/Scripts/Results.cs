using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Results : MonoBehaviour
{
    public Text coins;
    public Text finalScore;
    public Text originalScore;
    public string locationName;
    public Text multiplyer;
    private int finalscore;
    PlayerDataManager player;


    score Score;
    // Start is called before the first frame update
    void Awake()
    {
        //store the information 
        Score = GameObject.FindGameObjectWithTag("Score").GetComponent<score>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDataManager>();
    }

    // Update is called once per frame
    void Start()
    {
        //generate cash 
        Score.CalculateCashMultiplyer();
        Score.generateCash();
        finalscore = Score.getFinalScore();

        //post to UI
        coins.text = Score.getCash().ToString();
        finalScore.text = finalscore.ToString();
        originalScore.text = Score.getOriginalScore().ToString();
        multiplyer.text = Score.getMultiplyer().ToString();

        PlayerDataManager.AddToCurrency(Score.getCash());
        //add score to leader board 

        string scoreToPost = finalscore.ToString();
        //store string value in long and post 
        long scoreLong;
        if (long.TryParse(scoreToPost, out scoreLong))
        {
            PlayGamesController.PostToLeaderboard(scoreLong);
            Debug.Log("Score Posted!");
        }
        //update banner information
        if (player.GetScoreAtLocation(locationName) < finalscore)
        {
            Score.UpdateTotalScore();
            player.UpdateScoreAtLocation(finalscore, locationName);
        }
    }
}
