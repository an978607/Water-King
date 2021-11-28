using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class PlayerVehicles
{
    [SerializeField] private int player_id;
    [SerializeField] protected string vehicles;
    [SerializeField] protected string visUnlocked;

    public void ParseData()
    {
        string[] vehicleString = vehicles.Split(','); // TODO: UPDATE to correct variable ********
        string[] unlockString = visUnlocked.Split(',');

        for (int i = 0; i < vehicleString.Length; i++)
        {
            Vehicle vehicle;
            VehicleDatabase.vehicles.TryGetValue(vehicleString[i], out vehicle);

            if (vehicle == null)
            {
                Debug.LogError("PlayerVehicle: Unable to find vehicle name in VehicleDatabase -> " + vehicleString[i]);
                continue;
            }
            bool unlocked = Convert.ToBoolean(int.Parse(unlockString[i]));
            if (vehicle.GetUnlockedStatus() == false && unlocked == true)
            {
                vehicle.SetStatusToUnlocked();
            }
        }
    }
}
