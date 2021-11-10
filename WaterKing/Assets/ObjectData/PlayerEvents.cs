using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class PlayerEvents
{
    [SerializeField] private string player_id;
    [SerializeField] private string events;
    [SerializeField] private string eisUnlocked;

    public void ParseData()
    {
        string[] eventString = events.Split(','); // TODO: UPDATE to correct variable ********
        string[] unlockString = eisUnlocked.Split(',');

        for (int i = 0; i < eventString.Length; i++)
        {
            Event eventObj;
            EventDatabase.events.TryGetValue(eventString[i], out eventObj);

            if (eventObj == null)
            {
                Debug.LogError("PlayerEvents: Unable to find event name in EventDatabase");
                continue;
            }
            bool unlocked = Convert.ToBoolean(int.Parse(unlockString[i]));
            if (eventObj.GetUnlockedStatus() == false && unlocked == true)
            {
                eventObj.SetStatusToUnlocked();
            }
        }
    }
}
