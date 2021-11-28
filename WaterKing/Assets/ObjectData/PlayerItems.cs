using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class PlayerItems
{
    [SerializeField] private int player_id;
    [SerializeField] private string items;
    [SerializeField] private string iisUnlocked;
    [SerializeField] private string count;

    public void ParseData()
    {
        string[] itemString = items.Split(','); // TODO: UPDATE to correct variable ********
        string[] unlockString = iisUnlocked.Split(',');
        string[] countString = count.Split(',');

        for (int i = 0; i < itemString.Length; i++)
        {
            Item item;
            ItemDatabase.items.TryGetValue(itemString[i], out item);

            if (item == null)
            {
                Debug.LogError("PlayerItems: Unable to find item name in ItemDatabase -> " + itemString[i]);
                continue;
            }
            bool unlocked = Convert.ToBoolean(int.Parse(unlockString[i]));
            if (item.GetUnlockedStatus() == false && unlocked == true)
            {
                item.SetStatusToUnlocked();
            }

            item.count = int.Parse(countString[i]);
        }
    }
}
