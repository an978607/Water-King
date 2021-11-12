using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    // Serialized for testing purposes switch to private once connected database 
    private float timerBonus;
    private int livesBonus;
    private int storageBonus;

    void Start()
    {
        //these should be based on whether or not the player has purchased a bonus from the shop
        timerBonus = PlayerDataManager.player.time;
        livesBonus = PlayerDataManager.player.protection;
        storageBonus = PlayerDataManager.player.upgrade;
    }


    public float getTimerBonus()
    {
        return timerBonus;
    }
    public int getLivesBonus()
    {
        return livesBonus ;
    }
    public int getstorageBonus()
    {
        return storageBonus;
    }
}
