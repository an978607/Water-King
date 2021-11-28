using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Vehicle
{
    [SerializeField] private int id;
    public string name;
    public string description;
    public int price;
    [SerializeField] private bool isUnlocked;
    [SerializeField] private float speed;

    private Sprite VehicleSprite; // TODO
    public Vehicle(bool isUnlocked, float speed, string name, string description, int price)
    {
        this.isUnlocked = isUnlocked;
        this.speed = speed;
        this.name = name;
        this.description = description;
        this.price = price;
        VehicleSprite = Resources.Load<Sprite>("VehicleSprites/" + name);
    }

    public bool GetUnlockedStatus()
    {
        return isUnlocked;
    }

    public void SetStatusToUnlocked()
    {
        isUnlocked = true;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public int GetVehicleID()
    {
        return id;
    }
}
