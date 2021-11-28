﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopEvent : MonoBehaviour
{
    private GameObject Result;
    private Text ResultText;
    static ShopEvent instance;

    public void Start()
    {
        Result = GameObject.FindGameObjectWithTag("Event");
        ResultText = GameObject.FindGameObjectWithTag("EventText").GetComponent<Text>();
        instance = this;
    }

    public void Promotion()
    {
        //always beneficial players gets 2.5% of their current cash (CAN ONLY BE BOUGHT ONCE)
        //player.AddToCurrency(player.);
        instance.Result.SetActive(true);
        ResultText.text = "WOW Everything went great and you got a ton of cash!";
       

        int bonus = (int)(PlayerDataManager.GetCurrency() * 0.1);
        PlayerDataManager.AddToCurrency(bonus);
        Debug.Log("Promotion");
    }

    public void Advertisement()
    {
        int num = Random.Range(0, 10);

        if (num <= 3)
        {
            int bonus = (int)(PlayerDataManager.GetCurrency() * 0.1);
            PlayerDataManager.AddToCurrency(bonus);
            Debug.Log("Advertisment Positive");
            Result.SetActive(true);
            ResultText.text = "WOW Everything went great and you got a ton of cash!";
        }

        else
        {
            int deduction = (int)(PlayerDataManager.GetCurrency() * 0.1);
            PlayerDataManager.SubtractFromCurrency(deduction);
            Debug.Log("Advertisment Negative");
            Result.SetActive(true);
            ResultText.text = "OH NO! They did a bad job and now you look bad.";
        }
    }

    public void RivalShutdown()
    {
        int bonus = (int)(PlayerDataManager.GetCurrency() * 0.15);
        PlayerDataManager.AddToCurrency(bonus);
        Debug.Log("RivalShutdown");
        Result.SetActive(true);
        ResultText.text = "WOW Everything went great and you got a ton of cash!";
    }
}
