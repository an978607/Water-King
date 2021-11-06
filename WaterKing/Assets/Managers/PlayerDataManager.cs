using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerDataManager : MonoBehaviour
{
    static Player player;
    GameObject MapPinsLevelBanner;
    GameObject CurrentAmountObject;
    Text[] textComponentsInMapPin;

    private void Awake()
    {
        if (player == null)
        {
            player = new Player();
            player.currency = 25;
            player.fuelAmount = 3;
            player.lastEnegeryUpdateTime = DateTime.Now;
            player.scoreAtLocation1 = 0;
        }

        // Set Initial Map Pin Level Banner High Score
        MapPinsLevelBanner = GameObject.FindGameObjectWithTag("CentralParkLevelBanner");
        if (MapPinsLevelBanner != null)
        {
            textComponentsInMapPin = MapPinsLevelBanner.GetComponentsInChildren<Text>();

            for (int i = 0; i < textComponentsInMapPin.Length; i++)
            {
                // TODO: Specify location
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
        player.totalScore += addToScoreAmount;
        PlayGamesController.PostToLeaderboard(player.totalScore);
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
