using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private GameObject shopItemPrefab;
    [SerializeField] private bool isShop;

    const string PRICE_ZERO_TEXT = "UNLOCKED";

    private GameObject itemDatabaseObject;
    private ItemDatabase itemDatabase;
    private GameObject upgradesUIContent;

    private void Awake()
    {
        itemDatabaseObject = GameObject.FindGameObjectWithTag("ItemDatabase");

        if (itemDatabaseObject == null)
        {
            Debug.LogError("ItemManager: Unable to find ItemDatabase object");
            return;
        }

        itemDatabase = itemDatabaseObject.GetComponent<ItemDatabase>();

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

        if (itemDatabase.items == null || itemDatabase.items.list == null)
        {
            Debug.LogError("ItemManager: Vehicles null when creating shop list");
            return;
        }

        for (int i = 0; i < itemDatabase.items.list.Count; i++)
        {
            Text[] textArray;
            Image[] imageArray;
            GameObject prefabInstance;
            int price = itemDatabase.items.list[i].price;

            prefabInstance = Instantiate(shopItemPrefab);
            textArray = prefabInstance.GetComponentsInChildren<Text>();
            textArray[0].text = itemDatabase.items.list[i].name;
            textArray[1].text = itemDatabase.items.list[i].description;

            imageArray = prefabInstance.GetComponentsInChildren<Image>();
            if (imageArray.Length > 1)
            {
                imageArray[1].sprite = Resources.Load<Sprite>("ShopSprites/" + itemDatabase.items.list[i].name);
            }

            if (price == 0)
            {
                textArray[2].text = PRICE_ZERO_TEXT;
            }
            else
            {
                textArray[2].text = price.ToString();
            }

            prefabInstance.tag = "ShopUpgradeItem";
            prefabInstance.transform.SetParent(upgradesUIContent.transform, false);
        }
    }
}
