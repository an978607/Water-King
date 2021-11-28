using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GooglePlayGames;

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
        // Get player data
        string playerEmail = "{\"email\":\"" + PlayGamesPlatform.Instance.GetUserEmail() + "\"}";
        string json = GetAPIDatabase.GetPlayers(playerEmail);
        PlayerDataManager.player = Deserialization.DeserializePlayer(json);
        string playerIDJSON = "{\"player_id\":\""+ PlayerDataManager.player.player_id +"\"}";
        PlayerDataManager.player.ParseData(playerIDJSON);
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
