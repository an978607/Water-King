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
    public int player_score = 0;
    public int multiplied_score = 0;


    //variables that go into finding score multiplyer
    public float score_multiplyer;
    private float locationScore;
    private float brandScore;
    private int storage = 0;

    GameObject playerObject;
    PlayerDataManager playerDataManager;
    VehicleInfo vehicle;
    LocationInfo location;
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
        //find level information 
        location = GameObject.FindGameObjectWithTag("LocationInfo").GetComponent<LocationInfo>();
        locationScore = location.getScoreBonus();
        Debug.Log("Location score on start is " + locationScore);
    }


    // Update is called once per frame
    void Update()
    {
        scoreText.text = player_score.ToString();

        if (winScreen.activeSelf == true)
        {
            finalScoreWin.text = multiplied_score.ToString();
            originalscoreWin.text = player_score.ToString();
            multiplierWin.text = score_multiplyer.ToString();
            if (playerDataManager.GetScoreAtLocation("Central Park") < player_score)
            {
                UpdateTotalScore();
                playerDataManager.UpdateScoreAtLocation(player_score, "Central Park");
            }

        }
        if (failScreen.activeSelf == true)
        {
            finalScoreLose.text = multiplied_score.ToString();
            originalscoreLose.text = player_score.ToString();
            multiplierFail.text = score_multiplyer.ToString();
            if (playerDataManager.GetScoreAtLocation("Central Park") < player_score)
            {
                UpdateTotalScore();
                playerDataManager.UpdateScoreAtLocation(player_score, "Central Park");  
            }
        }
    }

    public void setBrandScore(float Set)
    {
        brandScore = Set;
        Debug.Log("Brand Score has been set to " + brandScore);
    }

    public void CalculateMultiplyer()
    {
        score_multiplyer = brandScore + locationScore;
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
        //calcuate multiplyer 
        CalculateMultiplyer();

        //apply it to score
        player_score = player_score + 1;
        multiplied_score = (int)(player_score * score_multiplyer);
    }
}
