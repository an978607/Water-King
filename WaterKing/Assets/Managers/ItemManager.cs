using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private GameObject shopItemPrefab;
    [SerializeField] private bool isShop;

    const string PRICE_ZERO_TEXT = "UNLOCKED";
    private GameObject upgradesUIContent;

    private void Awake()
    {
        if (isShop)
        {
            upgradesUIContent = GameObject.FindGameObjectWithTag("UpgradesUIContent");
            if (upgradesUIContent == null)
            {
                Debug.LogError("ItemManager: Unable to find UpgradesUIContent object");
                return;
            }

            CreateItemShopItemList();
        }
    }

    void CreateItemShopItemList()
    {

        if (ItemDatabase.items == null)
        {
            Debug.LogError("ItemManager: items null when creating shop list");
            return;
        }

        foreach (KeyValuePair<string, Item> item in ItemDatabase.items)
        {
            Text[] textArray;
            Image[] imageArray;
            GameObject prefabInstance;
            int price = item.Value.price;

            prefabInstance = Instantiate(shopItemPrefab);
            textArray = prefabInstance.GetComponentsInChildren<Text>();
            textArray[0].text = item.Value.name;
            textArray[1].text = item.Value.description;

            imageArray = prefabInstance.GetComponentsInChildren<Image>();
            if (imageArray.Length > 1)
            {
                imageArray[1].sprite = Resources.Load<Sprite>("ShopSprites/" + item.Value.name);
            }

            if (item.Value.GetUnlockedStatus())
            {
                textArray[2].text = PRICE_ZERO_TEXT;
                prefabInstance.GetComponentInChildren<Button>().interactable = false;
            }
            else
            {
                int itemPrice = price;
                if (item.Value.count > 1)
                {
                    itemPrice = ShopManager.GetNextPrice(price, item.Value.count);
                }
                textArray[2].text = itemPrice.ToString();
                if (itemPrice > PlayerDataManager.GetCurrency())
                {
                    prefabInstance.GetComponentInChildren<Button>().interactable = false;
                }

            }

            prefabInstance.tag = "ShopUpgradeItem";
            prefabInstance.transform.SetParent(upgradesUIContent.transform, false);
        }
    }
}
