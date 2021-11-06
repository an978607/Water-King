using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Text scoreText;
    public Text originalscoreWin;
    public Text originalscoreLose;
    public Text finalScoreWin;
    public Text finalScoreLose;
    public Text multiplierWin;
    public Text multiplierFail;
    public GameObject winScreen;
    public GameObject failScreen;
    public int player_score = 1;
    public int multiplied_score = 0;
    public int multiplier = 1;
    GameObject playerObject;
    PlayerDataManager playerDataManager;

    private void Awake()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            playerDataManager = playerObject.GetComponent<PlayerDataManager>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = player_score.ToString();

        if (winScreen.activeSelf == true)
        {
            finalScoreWin.text = player_score.ToString();
            originalscoreWin.text = player_score.ToString();
            multiplierWin.text = multiplier.ToString();
            if (playerDataManager.GetScoreAtLocation("Central Park") < player_score)
            {
                playerDataManager.UpdateScoreAtLocation(player_score, "Central Park");
                UpdateTotalScore();
            }
           
        }
        if(failScreen.activeSelf == true)
        {
            finalScoreLose.text = player_score.ToString();
            originalscoreLose.text = player_score.ToString();
            multiplierFail.text = multiplier.ToString();
            if (playerDataManager.GetScoreAtLocation("Central Park") < player_score)
            {
                playerDataManager.UpdateScoreAtLocation(player_score, "Central Park");
                UpdateTotalScore();
            }
        }
    }

    private void UpdateTotalScore()
    {
        int scoreAtLocation = playerDataManager.GetScoreAtLocation("Central Park");
        if (scoreAtLocation < player_score)
        {
            int scoreOffset = player_score - scoreAtLocation;
            playerDataManager.AddToTotalScore(scoreOffset);
        }
    }

    public void Enemy_Destroyed()
    {
        player_score = player_score + multiplier * 1;
        multiplier = multiplier + 1;
    }
}
