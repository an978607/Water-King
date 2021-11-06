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
    [SerializeField] private bool isUnlocked;

    private Sprite ItemSprite;

    public Item(int id, bool isUnlocked, string name, string description, int price)
    {
        this.id = id;
        this.isUnlocked = isUnlocked;
        this.name = name;
        this.description = description;
        this.price = price;
        ItemSprite = Resources.Load<Sprite>("ItemSprites/" + name);
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
