using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float timerBonus;
    [SerializeField] float scoreBonus;
    [SerializeField] float cashBonus;

    void Start()
    {
        //these should be based on whether or not the player has purchased a bonus
        Debug.Log(timerBonus);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getTimerBonus()
    {
        return timerBonus;
    }
}
