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
    string locName = "Central Park,Empire State,Times Square";
    string unlock = "1,0,0";
    string scor = "0,3143,23";

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

        // Add locations to list
        for (int i = 0; i < locationString.Length; i++)
        {
            locations.Add(new Location(locationString[i], Convert.ToBoolean(int.Parse(unlockString[i])), int.Parse(scoreString[i])));
        }
    }

}
