using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleInfo : MonoBehaviour
{
    [SerializeField] float cashBonus;
    [SerializeField] int baseStorage;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(baseStorage);
        
    }

    // Update is called once per frame
    public float getCashBonus()
    {
        return cashBonus;
    }

    public float getStorage()
    {
        return baseStorage;
    }
}
