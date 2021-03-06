using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[System.Serializable]
public class Player
{
    public int player_id;
    public int currency;
    public int fuelAmount;
    public DateTime lastEnergyUpdateTime;
    public int totalScore;
    public int protection;
    public int upgrade;
    public float time;
    public string selectedVehicle;

    [SerializeField] private string locationName;
    [SerializeField] private string isUnlocked;
    [SerializeField] private string score;
    [SerializeField] private string price;
    [System.NonSerialized] public Dictionary<string, Location> locations;
    [System.NonSerialized] public Dictionary<string, Location> vehicles;
    [System.NonSerialized] public Dictionary<string, Location> items;
    [System.NonSerialized] public Dictionary<string, Location> events;

    // Score at each location
    //[System.NonSerialized] public int scoreAtLocation1; // Temporary

    // TODO: Remove ********
    //string locName = "Central Park,Time Square,Public Library,Empire State,Fifth Avenue,High Line";
    //string unlock = "1,0,0,0,0,0";
    //string scor = "0,3143,23,45,55,63";
    //string pric = "0,5,5,10,2500,4000";
    public void ParseData(string json)
    {
        ParseLocations();
        ParseVehicles(json);
        ParseItems(json);
        ParseEvents(json);
    }

    private void ParseLocations()
    {
        locations = new Dictionary<string, Location>();

        // Split Strings
        string[] locationString = locationName.Split(','); // TODO: UPDATE to correct variable ********
        string[] unlockString = isUnlocked.Split(',');
        string[] scoreString = score.Split(',');
        string[] priceString = price.Split(',');

        // Add locations to list
        for (int i = 0; i < locationString.Length; i++)
        {
            if (locations.ContainsKey(locationString[i]))
            {
                Debug.LogError("Player: Unable to add duplicate location, check remote database");
                continue;
            }
            locations.Add(locationString[i], new Location(i, locationString[i], Convert.ToBoolean(int.Parse(unlockString[i])), int.Parse(scoreString[i]), int.Parse(priceString[i])));
        }

        locations.OrderBy(key => key.Value.price);
    }
    
    private void ParseVehicles(string strJSONInput)
    {
        string json = GetAPIDatabase.GetPlayerVehicles(strJSONInput);
        PlayerVehicles playerVehicles = Deserialization.DeserializePlayerVehicles(json);
        playerVehicles.ParseData();
    }

    private void ParseItems(string strJSONInput)
    {
        string json = GetAPIDatabase.GetPlayerItems(strJSONInput);
        PlayerItems playerItems = Deserialization.DeserializePlayerItems(json);
        playerItems.ParseData();
    }

    private void ParseEvents(string strJSONInput)
    {
        string json = GetAPIDatabase.GetPlayerEvents(strJSONInput);
        PlayerEvents playerEvents = Deserialization.DeserializePlayerEvents(json);
        playerEvents.ParseData();
    }
}
