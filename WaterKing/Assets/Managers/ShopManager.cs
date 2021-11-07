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
        string parentPrefabTag = gameObject.transform.parent.tag;

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
                    UpdateCurrencyUI();
                }
                return;

            case "Upgrades Panel":
                int upgradePrice = int.Parse(buttonText.text);

                if (upgradePrice > playerCurrency)
                {
                    button.interactable = false;
                    return;
                }
                else
                {
                    PlayerDataManager.SubtractFromCurrency(upgradePrice);
                    // TODO: Unlock Upgrade in player data ************
                    if (parentPrefabTag == "ShopVehicle")
                    {
                        Debug.LogWarning("ShopVehicle");
                    }
                    else if (parentPrefabTag == "ShopUpgradeItem")
                    {
                        Debug.LogWarning("ShopUpgradeItem");
                    }

                    buttonText.text = PlayerDataManager.PRICE_ZERO_TEXT;
                    button.interactable = false;
                    UpdateCurrencyUI();
                }
                return;

            case "Events Panel":
                int eventPrice = int.Parse(buttonText.text);

                if (eventPrice > playerCurrency)
                {
                    button.interactable = false;
                    return;
                }
                else
                {
                    PlayerDataManager.SubtractFromCurrency(eventPrice);
                    // TODO: Unlock Event in player data ********
                    buttonText.text = PlayerDataManager.PRICE_ZERO_TEXT;
                    button.interactable = false;
                    UpdateCurrencyUI();
                }
                return;
            default:
                return;
        }

    }

    private void UpdateCurrencyUI()
    {
        GameObject currencyObject = GameObject.FindGameObjectWithTag("Currency");
        
        if (currencyObject == null)
        {
            Debug.LogError("ShopManager: Unable to find currency object");
            return;
        }

        Text currencyText = currencyObject.GetComponent<Text>();
        if (currencyText == null)
        {
            Debug.LogError("ShopManager: Unable to find currency text component");
            return;
        }
        
        currencyText.text = PlayerDataManager.GetCurrency().ToString();
    }
}
