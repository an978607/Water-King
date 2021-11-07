using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerDataManager : MonoBehaviour
{
    public static Player player;
    GameObject MapPinsLevelBanner;
    GameObject CurrentAmountObject;
    Text[] textComponentsInMapPin;
    GameObject unlockedGoButton;
    GameObject lockedGoButton;
    GameObject lockedItem;

    private void Awake()
    {
        // Set Initial Map Pin Level Banner High Score
        MapPinsLevelBanner = GameObject.FindGameObjectWithTag("CentralParkLevelBanner");
        if (MapPinsLevelBanner != null)
        {
            unlockedGoButton = MapPinsLevelBanner.transform.Find("Go Button (Unlocked)").gameObject;
            if (unlockedGoButton == null)
            {
                Debug.LogError("PlayerDataManager: Unable to find unlocked go button");
                return;
            }

            lockedGoButton = MapPinsLevelBanner.transform.Find("Go Button (locked)").gameObject;
            if (lockedGoButton == null)
            {
                Debug.LogError("PlayerDataManager: Unable to find locked go button");
                return;
            }


            lockedItem = MapPinsLevelBanner.transform.Find("Locked Item").gameObject;
            if (lockedItem == null)
            {
                Debug.LogError("PlayerDataManager: Unable to find locked item");
                return;
            }
            
            // Set Lock status of locations
            if (player.locations[0].isUnlocked)
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

            textComponentsInMapPin = MapPinsLevelBanner.GetComponentsInChildren<Text>();

            for (int i = 0; i < textComponentsInMapPin.Length; i++)
            {
                // TODO: Specify location ****************************
                if (textComponentsInMapPin[i].CompareTag("HighScore"))
                {
                    if (player.scoreAtLocation1 == 0)
                    {
                        textComponentsInMapPin[i].text = string.Empty;
                    }
                    else
                    {
                        textComponentsInMapPin[i].text = GetScoreAtLocation("Central Park").ToString();
                    }
                }
            }
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

    // Individual Location Scores
    public void UpdateScoreAtLocation(int updatedScore, string location)
    {
        player.scoreAtLocation1 = updatedScore;
    }
    public int GetScoreAtLocation(string location) // TODO
    {
        return player.scoreAtLocation1;
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
    public void SubtractFromCurrency(int subtractFromCurrencyAmount)
    {
        player.currency -= subtractFromCurrencyAmount;
    }
    public int GetCurrency()
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
        player.lastEnegeryUpdateTime = dateTime;
    }
    public DateTime GetLastEnergyUpdateTime()
    {
        return player.lastEnegeryUpdateTime;
    }
}
