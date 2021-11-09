using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationInfo : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] float cashBonus;
    [SerializeField] float scoreBonus;
    // Start is called before the first frame update
    void Start()
    {
        //get all the bonuses due to upgrades here?
    }

    // Update is called once per frame
    public float getTime()
    {
        return time;
    }

    public float getCashBonus()
    {
        return cashBonus;
    }

    public float getScoreBonus()
    {
        return scoreBonus;
    }
}
