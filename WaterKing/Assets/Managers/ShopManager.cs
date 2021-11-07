using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public void TryPurchase()
    {
        int playerCurrency = PlayerDataManager.GetCurrency();
        
        GameObject parentPanelObject = gameObject.transform.parent.parent.parent.gameObject;
        GameObject titleName = gameObject.transform.parent.Find("TITLE").gameObject;
        Text titleNameText = titleName.GetComponent<Text>();
        Button button = gameObject.GetComponent<Button>();
        Text buttonText = gameObject.GetComponentInChildren<Text>();

        switch (parentPanelObject.name)
        {
            case "Locations Panel":
                Location location = PlayerDataManager.player.locations[titleNameText.text];
                if (location.price > playerCurrency)
                {
                    button.interactable = false;
                    return;
                }
                else
                {
                    PlayerDataManager.SubtractFromCurrency(location.price);
                    location.isUnlocked = true;
                    buttonText.text = PlayerDataManager.PRICE_ZERO_TEXT;
                    button.interactable = false;
                }
                return;

            case "Upgrades Panel":
                Debug.LogWarning(parentPanelObject.name);

                return;

            case "Events Panel":
                Debug.LogWarning(parentPanelObject.name);

                return;
            default:
                return;

        }

    }
}
