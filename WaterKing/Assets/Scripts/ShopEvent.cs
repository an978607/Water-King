using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEvent : MonoBehaviour
{
    public static void Promotion()
    {
        //always beneficial players gets 2.5% of their current cash (CAN ONLY BE BOUGHT ONCE)
        //player.AddToCurrency(player.);
        int bonus = (int)(PlayerDataManager.GetCurrency() * 0.1);
        PlayerDataManager.AddToCurrency(bonus);
    }

    public  void Advertisement()
    {
        int num = Random.Range(0, 10);

        if (num <= 3)
        {
            int bonus = (int)(PlayerDataManager.GetCurrency() * 0.1);
            PlayerDataManager.AddToCurrency(bonus);
        }

        else
        {
            int deduction = (int)(PlayerDataManager.GetCurrency() * 0.1);
            PlayerDataManager.SubtractFromCurrency(deduction);
        }
    }

    public void RivalShutdown()
    {
        int bonus = (int)(PlayerDataManager.GetCurrency() * 0.15);
        PlayerDataManager.AddToCurrency(bonus);
    }
}
