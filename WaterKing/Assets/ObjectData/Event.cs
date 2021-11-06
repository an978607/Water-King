using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Event
{
    [SerializeField] private int id;
    public string name;
    public string description;
    public int price;
    [SerializeField] private bool isUnlocked;

    [System.NonSerialized]
    private Sprite EventSprite;

    public Event(int id, bool isUnlocked, string name, string description, int price)
    {
        this.id = id;
        this.isUnlocked = isUnlocked;
        this.name = name;
        this.description = description;
        this.price = price;
        EventSprite = Resources.Load<Sprite>("EventSprites/" + name);
    }

    public bool GetUnlockedStatus()
    {
        return isUnlocked;
    }

    public void SetStatusToUnlocked()
    {
        isUnlocked = true;
    }

    public int GetEventID()
    {
        return id;
    }
}
