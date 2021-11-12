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

    public void Promotion()
    {
        //always beneficial players gets 2.5% of their current cash (CAN ONLY BE BOUGHT ONCE)
        //player.AddToCurrency(player.);
        PlayerDataManager.SubtractFromCurrency(15000);
        int bonus = (int)(PlayerDataManager.GetCurrency() * 0.1);
        player.AddToCurrency(bonus);
    }

    public void Advertisement()
    {
        PlayerDataManager.SubtractFromCurrency(10000);
        int num = Random.Range(0, 10);

        if (num <= 3)
        {
            int bonus = (int)(PlayerDataManager.GetCurrency() * 0.1);
            player.AddToCurrency(bonus);
        }

        else
        {
            int deduction = (int)(PlayerDataManager.GetCurrency() * 0.1);
            PlayerDataManager.SubtractFromCurrency(deduction);
        }
    }

    public void RivalShutdown()
    {
        PlayerDataManager.SubtractFromCurrency(20000);
        int bonus = (int)(PlayerDataManager.GetCurrency() * 0.15);
        player.AddToCurrency(bonus);
    }
}
