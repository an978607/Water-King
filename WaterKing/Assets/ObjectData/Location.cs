using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location
{
    public int index;
    public string name;
    public int score;
    public bool isUnlocked;
    public int price;

    public Location(int index, string name, bool isUnlocked, int score, int price)
    {
        this.index = index;
        this.name = name;
        this.score = score;
        this.isUnlocked = isUnlocked;
        this.price = price;
    }
}
