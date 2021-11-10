using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Text scoreText;

    public int player_score = 0;
    public int multiplied_score = 0;
    private int cash;

    //variables that go into finding score multiplyer
    private float score_multiplyer;
    private float locationScore;
    private float brandScore = 0;

    //variables for finding cash multiplyer
    private float vehicleCash;
    private float locationCash;
    private float brandCash = 0;
    private float cashMultiplyer;

    //get storage
    private int storage;
    private int storageBonus;
    private int storageVehicle;


    GameObject playerObject;
    PlayerDataManager playerDataManager;
    VehicleInfo vehicle;
    LocationInfo location;
    Bonus upgrades;

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
        locationCash = location.getCashBonus();

        //vehicle information
        vehicle = GameObject.FindGameObjectWithTag("VehicleInfo").GetComponent<VehicleInfo>();
        vehicleCash = vehicle.getCashBonus();
        storageVehicle = vehicle.getStorage();

        //upgrades from shop
        upgrades = GameObject.FindGameObjectWithTag("UpgradesInfo").GetComponent<Bonus>();
        storageBonus = upgrades.getstorageBonus();

        //new player storage
        storage = storageVehicle + storageBonus;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = player_score.ToString();
    }

    public void setBrandScore(float Set)
    {
        brandScore = Set;
    }

    public void setBrandCash(float Cash)
    {
        brandCash = Cash;
    }

    public void CalculateMultiplyer()
    {
        score_multiplyer = brandScore + locationScore;
    }

    public void CalculateCashMultiplyer()
    {
        cashMultiplyer = vehicleCash + locationCash + brandCash;
        Debug.Log(cashMultiplyer);
    }

    public void UpdateTotalScore()
    {
        int scoreAtLocation = playerDataManager.GetScoreAtLocation("Central Park");
        if (scoreAtLocation < player_score)
        {
            int scoreOffset = player_score - scoreAtLocation;
            playerDataManager.AddToTotalScore(scoreOffset);
        }
    }

    public void generateCash()
    {
        cash = (int)(player_score* cashMultiplyer * storage);
    }

    public void Enemy_Destroyed()
    {
        //calcuate multiplyer 
        CalculateMultiplyer();

        //apply it to score
        player_score = player_score + 1;
        multiplied_score = (int)(player_score * score_multiplyer);
    }

    public int getOriginalScore()
    {
        return player_score;
    }

    public int getFinalScore()
    {
        return multiplied_score;
    }

    public float getMultiplyer()
    {
        return score_multiplyer;
    }

    public int getCash()
    {
        return cash;
    }

}
