using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerDatabase : MonoBehaviour
{
    private static GameObject playerDatabaseObject;
    public Players player;

    private void Start()
    {
        playerDatabaseObject = GameObject.FindGameObjectWithTag("PlayerDatabase");
        GetPlayerFromDatabase();
    }

    public static GameObject GetPlayerDatabaseObject() => playerDatabaseObject;

    public void GetPlayerFromDatabase()
    {
        // This string successfully gets players from the database
        //string json = "{\"list\":" + GetAPIDatabase.GetPlayers() + "}";
        string json = GetAPIDatabase.GetPlayers();
        PlayerDataManager.player = Deserialization.DeserializePlayer(json);
        PlayerDataManager.player.ParseData();

        // TODO *******************
        //if (PlayerDataManager.player == null) // TODO: REMOVE *************************
        //{
        //    PlayerDataManager.player = new Player();
        //    PlayerDataManager.player.currency = 25;
        //    PlayerDataManager.player.fuelAmount = 3;
        //    PlayerDataManager.player.lastEnegeryUpdateTime = DateTime.Now;
        //    PlayerDataManager.player.scoreAtLocation1 = 0;
        //}
    }

    [System.Serializable]
    public class Players
    {
        private static Players playerInstance = null;
        public List<Player> list;
        public static Players GetInstance() => playerInstance = (playerInstance != null) ? playerInstance : new Players();

        private Players()
        {
            list = new List<Player>();
        }
    }
}
