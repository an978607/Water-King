using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerDatabase : MonoBehaviour
{
    private static GameObject playerDatabaseObject;


    private void Awake()
    {
        playerDatabaseObject = GameObject.FindGameObjectWithTag("PlayerDatabase");
        GetPlayerFromDatabase();
    }

    public static GameObject GetPlayerDatabaseObject() => playerDatabaseObject;

    public void GetPlayerFromDatabase()
    {
        string json = "{\"list\":" + GetAPIDatabase.GetVehicles() + "}";
        // PlayerDataManager.player = Deserialization.DeserializePlayer(json); TODO *******************
        if (PlayerDataManager.player == null) // TODO: REMOVE *************************
        {
            PlayerDataManager.player = new Player();
            PlayerDataManager.player.currency = 25;
            PlayerDataManager.player.fuelAmount = 3;
            PlayerDataManager.player.lastEnegeryUpdateTime = DateTime.Now;
            PlayerDataManager.player.scoreAtLocation1 = 0;
        }
    }
}
