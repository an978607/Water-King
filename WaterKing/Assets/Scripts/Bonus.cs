using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float timerBonus;
    [SerializeField] int livesBonus;
    [SerializeField] int storageBonus;

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
    public int getLivesBonus()
    {
        return livesBonus ;
    }
    public float getstorageBonus()
    {
        return storageBonus;
    }
}
