using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleInfo : MonoBehaviour
{
    [SerializeField] float cashBonus;
    [SerializeField] int baseStorage;
    
    public float getCashBonus()
    {
        return cashBonus;
    }

    public int getStorage()
    {
        return baseStorage;
    }
}
