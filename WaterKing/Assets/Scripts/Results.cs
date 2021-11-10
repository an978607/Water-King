using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Results : MonoBehaviour
{
    public Text coins;
    public Text finalScore;
    public Text originalScore;
    public Text multiplyer;

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

        //post to UI
        coins.text = Score.getCash().ToString();
        finalScore.text = Score.getFinalScore().ToString();
        originalScore.text = Score.getOriginalScore().ToString();
        multiplyer.text = Score.getMultiplyer().ToString();

        player.AddToCurrency(Score.getCash());

        if (player.GetScoreAtLocation("Central Park") < Score.getFinalScore())
        {
            Score.UpdateTotalScore();
            player.UpdateScoreAtLocation(Score.getFinalScore(), "Central Park");
        }
    }
}
