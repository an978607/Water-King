using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerDataManager : MonoBehaviour
{
    public static Player player;
    GameObject CurrentAmountObject;
    Text[] textComponentsInMapPin;
    GameObject unlockedGoButton;
    GameObject lockedGoButton;
    GameObject lockedItem;
    [SerializeField] private GameObject shopItemPrefab;
    [SerializeField] private bool isShop;
    private GameObject locationsUIContent;
    public static string PRICE_ZERO_TEXT = "UNLOCKED";

    private void Awake()
    {

        if (isShop)
        {
            locationsUIContent = GameObject.FindGameObjectWithTag("LocationsUIContent");
            if (locationsUIContent == null)
            {
                Debug.LogError("PlayerDataManager: Unable to find UpgradesUIContent object");
                return;
            }

            CreateLocationShopItemList();
        }

        // Set Initial Currency Amount in Shop UI
        CurrentAmountObject = GameObject.FindGameObjectWithTag("Currency");
        if (CurrentAmountObject != null)
        {
            CurrentAmountObject.GetComponent<Text>().text = GetCurrency().ToString();
        }
    }

    void Update()
    {
        
    }

    public void UpdateMapLevelBanners()
    {
        // Set Initial Map Pin Level Banner status
        if(gameObject.name == "Level Banner")
        {
            string parentName = gameObject.transform.parent.name;
            unlockedGoButton = gameObject.transform.Find("Go Button (Unlocked)").gameObject;
            if (unlockedGoButton == null)
            {
                Debug.LogError("PlayerDataManager: Unable to find unlocked go button");
                return;
            }

            lockedGoButton = gameObject.transform.Find("Go Button (locked)").gameObject;
            if (lockedGoButton == null)
            {
                Debug.LogError("PlayerDataManager: Unable to find locked go button");
                return;
            }


            lockedItem = gameObject.transform.Find("Locked Item").gameObject;
            if (lockedItem == null)
            {
                Debug.LogError("PlayerDataManager: Unable to find locked item");
                return;
            }

            // Set Lock status of locations
            if (player.locations[parentName].isUnlocked)
            {
                unlockedGoButton.SetActive(true);
                lockedGoButton.SetActive(false);
                lockedItem.SetActive(false);
            }
            else
            {
                unlockedGoButton.SetActive(false);
                lockedGoButton.SetActive(true);
                lockedItem.SetActive(true);
            }

            textComponentsInMapPin = gameObject.GetComponentsInChildren<Text>();

            for (int i = 0; i < textComponentsInMapPin.Length; i++)
            {
                // TODO: Specify location ****************************
                if (textComponentsInMapPin[i].CompareTag("HighScore"))
                {
                    if (player.locations[parentName].score == 0)
                    {
                        textComponentsInMapPin[i].text = string.Empty;
                    }
                    else
                    {
                        textComponentsInMapPin[i].text = GetScoreAtLocation(parentName).ToString();
                    }
                }
            }
        }
    }

    void CreateLocationShopItemList()
    {
        foreach (KeyValuePair<string, Location> location in player.locations)
        {
            Text[] textArray;
            Image[] imageArray;
            GameObject prefabInstance;
            int price = location.Value.price;

            prefabInstance = Instantiate(shopItemPrefab);
            textArray = prefabInstance.GetComponentsInChildren<Text>();
            textArray[0].text = location.Value.name;
            textArray[1].text = string.Empty;

            imageArray = prefabInstance.GetComponentsInChildren<Image>();
            if (imageArray.Length > 1)
            {
                imageArray[1].sprite = Resources.Load<Sprite>("ShopSprites/" + location.Value.name);
            }

            if (location.Value.isUnlocked)
            {
                textArray[2].text = PRICE_ZERO_TEXT;
                prefabInstance.GetComponentInChildren<Button>().interactable = false;
            }
            else
            {
                if (price > GetCurrency())
                {
                    prefabInstance.GetComponentInChildren<Button>().interactable = false;
                }

                textArray[2].text = price.ToString();
            }

            prefabInstance.transform.SetParent(locationsUIContent.transform, false);
        }   
    }

    // Individual Location Scores
    public void UpdateScoreAtLocation(int updatedScore, string location)
    {
        player.locations[location].score = updatedScore;
        SavePlayerData(player.locations[location]);
    }
    public int GetScoreAtLocation(string location) // TODO
    {
        return player.locations[location].score;
    }

    // Total Score
    public void AddToTotalScore(int addToScoreAmount)
    {
        Debug.Log("sending Score to post");
        player.totalScore += addToScoreAmount;

        //convert int to string 
        string scoreToPost = player.totalScore.ToString();
        //store string value in long and post 
        long scoreLong;
        if (long.TryParse(scoreToPost, out scoreLong))
        {
            PlayGamesController.PostToLeaderboard(scoreLong);
            Debug.Log("Score Posted!");
        }
        else
        {
            Debug.Log( "Error! :(");
        }
    }

    public int GetTotalScore()
    {
        return player.totalScore;
    }
   
    // Currency
    public void AddToCurrency(int addToCurrencyAmount)
    {
        player.currency += addToCurrencyAmount;
    }
    public static void SubtractFromCurrency(int subtractFromCurrencyAmount)
    {
        player.currency -= subtractFromCurrencyAmount;
    }
    public static int GetCurrency()
    {
        return player.currency;
    }
    
    // Fuel Amount
    public void AddToFuel(int addToFuelAmount)
    {
        player.fuelAmount += addToFuelAmount;
    }
    public int GetFuelAmount()
    {
        return player.fuelAmount;
    }
    public void SetFuelAmount(int fuelAmount)
    {
        player.fuelAmount = fuelAmount;
    }

    // Energy Update Time
    public void SetLastEnergyUpdateTime(DateTime dateTime)
    {
        player.lastEnergyUpdateTime = dateTime;
    }
    public DateTime GetLastEnergyUpdateTime()
    {
        return player.lastEnergyUpdateTime;
    }

    public static void SavePlayer()
    {
        Serialization.Serialize(player);
    }

    public static void SavePlayerData(Vehicle vehicle)
    {
        Serialization.Serialize(vehicle);
    }

    public static void SavePlayerData(Item item)
    {
        Serialization.Serialize(item);
    }

    public static void SavePlayerData(Event eventObj)
    {
        Serialization.Serialize(eventObj);
    }

    public static void SavePlayerData(Location location)
    {
       Serialization.Serialize(location);
    }
}
