using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEvent : MonoBehaviour
{
    PlayerDataManager player; 
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDataManager>();
    }

    private void Promotion()
    {
        //always beneficial players gets 2.5% of their current cash (CAN ONLY BE BOUGHT ONCE)
        //player.AddToCurrency(player.);
    }
   
}
