using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location
{
    public string name;
    public int score;
    public bool isUnlocked;

    public Location(string name, bool isUnlocked, int score)
    {
        this.name = name;
        this.score = score;
        this.isUnlocked = isUnlocked;
    }
}
