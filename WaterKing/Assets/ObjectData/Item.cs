using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    [SerializeField] private int id;
    public string name;
    public string description;
    public int price;
    public int count;
    [SerializeField] private bool isUnlocked;
    [System.NonSerialized] public int maxCount;

    public Item(bool isUnlocked, string name, string description, int price, int count)
    {
        this.isUnlocked = isUnlocked;
        this.name = name;
        this.description = description;
        this.price = price;
        this.count = count;
    }

    public bool GetUnlockedStatus()
    {
        return isUnlocked;
    }

    public void SetStatusToUnlocked()
    {
        isUnlocked = true;
    }

    public int GetItemID()
    {
        return id;
    }
}
