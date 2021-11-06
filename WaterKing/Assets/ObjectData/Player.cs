using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Player
{
    public int currency;
    public int fuelAmount;
    public DateTime lastEnegeryUpdateTime;
    public int totalScore;

    // Score at each location
    public int scoreAtLocation1; // Temporary
   
}
