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
    public int multiplier = 3;
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
            finalScoreWin.text = multiplied_score.ToString();
            originalscoreWin.text = player_score.ToString();
            multiplierWin.text = multiplier.ToString();
            if (playerDataManager.GetScoreAtLocation("Central Park") < player_score)
            {
                playerDataManager.UpdateScoreAtLocation(player_score, "Central Park");
            }

        }
        if (failScreen.activeSelf == true)
        {
            finalScoreLose.text = multiplied_score.ToString();
            originalscoreLose.text = player_score.ToString();
            multiplierFail.text = multiplier.ToString();
            if (playerDataManager.GetScoreAtLocation("Central Park") < player_score)
            {
                playerDataManager.UpdateScoreAtLocation(player_score, "Central Park");
            }
        }
    }

    public void Enemy_Destroyed()
    {
        player_score = player_score + 1;
        multiplied_score = player_score * multiplier;
        Debug.Log(player_score);
        Debug.Log(multiplied_score);
    }
}
