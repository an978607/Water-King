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
        string playerIDJSON = "{\"player_id\":\"1\"}";
        string json = GetAPIDatabase.GetPlayers(playerIDJSON);

        // Create new player
        //Serialization.SerializeNewPlayerData();
        //Serialization.SerializeNewPlayerVehicles();
        //Serialization.SerializeNewPlayerItems();
        //Serialization.SerializeNewPlayerEvents();
        // Retry Getting player


        PlayerDataManager.player = Deserialization.DeserializePlayer(json);
        PlayerDataManager.player.ParseData();
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
