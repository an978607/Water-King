using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Player
{
    public int currency;
    public int fuelAmount;
    public DateTime lastEnegeryUpdateTime;
    public int totalScore;
    [SerializeField] private string locationName;
    [SerializeField] private bool isUnlocked;
    [SerializeField] private int score;
    [System.NonSerialized] public List<Location> locations;

    // Score at each location
    [System.NonSerialized] public int scoreAtLocation1; // Temporary

    // TODO: Remove ********
    string locName = "Central Park,Time Square,Public Library,Empire State,5th Ave,High Line";
    string unlock = "1,0,0,0,0,0";
    string scor = "0,3143,23,0,0,0";
    string pric = "0,540,800,1300,2500,4000";
    public Player()
    {
        ParseLocations();
    }

    public void ParseLocations()
    {
        locations = new List<Location>();

        // Split Strings
        string[] locationString = locName.Split(','); // TODO: UPDATE to correct variable ********
        string[] unlockString = unlock.Split(',');
        string[] scoreString = scor.Split(',');
        string[] priceString = pric.Split(',');

        // Add locations to list
        for (int i = 0; i < locationString.Length; i++)
        {
            locations.Add(new Location(i, locationString[i], Convert.ToBoolean(int.Parse(unlockString[i])), int.Parse(scoreString[i]), int.Parse(priceString[i])));
        }
    }

}
