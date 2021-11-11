using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    private void TryPurchase()
    {
        
        int playerCurrency = PlayerDataManager.GetCurrency();
        
        GameObject parentPanelObject = gameObject.transform.parent.parent.parent.gameObject;
        GameObject titleName = gameObject.transform.parent.Find("TITLE").gameObject;
        Text titleNameText = titleName.GetComponent<Text>();
        Button button = gameObject.GetComponent<Button>();
        Text buttonText = gameObject.GetComponentInChildren<Text>();
        string parentPrefabTag = gameObject.transform.parent.tag;

        Transform shopUITransform = gameObject.transform.root.Find("Shop UI");
        if (shopUITransform == null)
        {
            Debug.LogError("ShopManager: Unable to find shop UI transform");
            return;
        }

        Transform confirmPurchaseTransform = shopUITransform.Find("Confirm Purchase");
        if (confirmPurchaseTransform == null)
        {
            Debug.LogError("ShopManager: Unable to find confirm purchase transform");
            return;
        }

        confirmPurchaseTransform.gameObject.SetActive(false);

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
                    PlayerDataManager.SavePlayerData(location);
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
                    if (parentPrefabTag == "ShopVehicle")
                    {
                        Vehicle vehicle = VehicleDatabase.vehicles[titleNameText.text];
                        vehicle.SetStatusToUnlocked();
                        buttonText.text = PlayerDataManager.PRICE_ZERO_TEXT;
                        button.interactable = false;
                        PlayerDataManager.SavePlayerData(vehicle);
                    }
                    else if (parentPrefabTag == "ShopUpgradeItem")
                    {
                        Item item = ItemDatabase.items[titleNameText.text];
                        item.SetStatusToUnlocked();
                        buttonText.text = PlayerDataManager.PRICE_ZERO_TEXT;
                        button.interactable = false;
                        PlayerDataManager.SavePlayerData(item);
                    }

                    buttonText.text = PlayerDataManager.PRICE_ZERO_TEXT;
                    button.interactable = false;
                    UpdateCurrencyUI();
                }
                return;

            case "Events Panel":
                Event eventObj = EventDatabase.events[titleNameText.text];
                int eventPrice = int.Parse(buttonText.text);

                if (eventPrice > playerCurrency)
                {
                    button.interactable = false;
                    return;
                }
                else
                {
                    PlayerDataManager.SubtractFromCurrency(eventPrice);
                    eventObj.SetStatusToUnlocked();
                    buttonText.text = PlayerDataManager.PRICE_ZERO_TEXT;
                    button.interactable = false;
                    UpdateCurrencyUI();
                    PlayerDataManager.SavePlayerData(eventObj);
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

    public void AskConfirmPurchase()
    {
        Transform backgroundTransform = GetConfirmBackgroundTransform();
        if (backgroundTransform == null)
        {
            Debug.LogError("ShopManager: Unable to get background transform");
            return;
        }

        Button confirmButton = GetConfirmButton(backgroundTransform);
        if (confirmButton == null)
        {
            Debug.LogError("ShopManager: Unable to get confirm button");
            return;
        }

        Button closeButton = GetCloseConfirmButton(backgroundTransform);
        if (closeButton == null)
        {
            Debug.LogError("ShopManager: Unable to get close button");
            return;
        }

        Transform currentCurrencyTransform = backgroundTransform.Find("Current");
        if (currentCurrencyTransform == null)
        {
            Debug.LogError("ShopManager: Unable to get current currency transform");
            return;
        }
        int playerCurrency = PlayerDataManager.GetCurrency();
        currentCurrencyTransform.GetComponent<Text>().text = playerCurrency.ToString();

        Transform potentialCurrencyTransform = backgroundTransform.Find("Potential");
        if (potentialCurrencyTransform == null)
        {
            Debug.LogError("ShopManager: Unable to get potential currency transform");
            return;
        }

        int price = int.Parse(gameObject.GetComponentInChildren<Text>().text);
        int potentialPrice = playerCurrency - price;
        potentialCurrencyTransform.GetComponent<Text>().text = potentialPrice.ToString();

        confirmButton.onClick.AddListener(PurchaseConfirmed);
        confirmButton.onClick.AddListener(delegate { RemoveConfirmScreenButtonListeners(confirmButton, closeButton); });
        closeButton.onClick.AddListener(delegate {RemoveConfirmScreenButtonListeners(confirmButton, closeButton);});
    }

    private Transform GetConfirmBackgroundTransform()
    {
        Transform shopUITransform = gameObject.transform.root.Find("Shop UI");
        if (shopUITransform == null)
        {
            Debug.LogError("ShopManager: Unable to find shop UI transform");
            return null;
        }

        Transform confirmPurchaseTransform = shopUITransform.Find("Confirm Purchase");
        if (confirmPurchaseTransform == null)
        {
            Debug.LogError("ShopManager: Unable to find confirm purchase transform");
            return null;
        }

        confirmPurchaseTransform.gameObject.SetActive(true);

        Transform backgroundTransform = confirmPurchaseTransform.Find("Background");
        if (backgroundTransform == null)
        {
            Debug.LogError("ShopManager: Unable to find background transform");
            return null;
        }
        return backgroundTransform;
    }

    private Button GetConfirmButton(Transform backgroundTransform)
    {
        Transform confirmTranform = backgroundTransform.Find("Confirm");
        if (confirmTranform == null)
        {
            Debug.LogError("ShopManager: Unable to find confirm transform");
            return null;
        }

        return confirmTranform.gameObject.GetComponent<Button>();
    }

    private Button GetCloseConfirmButton(Transform backgroundTransform)
    {
        Transform closeTranform = backgroundTransform.Find("Close");
        if (closeTranform == null)
        {
            Debug.LogError("ShopManager: Unable to find close transform");
            return null;
        }
        return closeTranform.gameObject.GetComponent<Button>();
    }

    private void RemoveConfirmScreenButtonListeners(Button confirmButton, Button closeButton)
    {
        confirmButton.onClick.RemoveAllListeners();
        closeButton.onClick.RemoveAllListeners();
    }

    private void PurchaseConfirmed()
    {
        TryPurchase();
    }
}
