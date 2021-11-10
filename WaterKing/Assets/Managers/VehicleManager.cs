using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VehicleManager : MonoBehaviour
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
                Debug.LogError("VehicleManager: Unable to find UpgradesUIContent object");
                return;
            }

            CreateVehicleShopItemList();
        }
    }

    void CreateVehicleShopItemList()
    {

        if (VehicleDatabase.vehicles == null)
        {
            Debug.LogError("VehicleManager: Vehicles null when creating shop list");
            return;
        }

        foreach (KeyValuePair<string, Vehicle> vehicle in VehicleDatabase.vehicles)
        {
            Text[] textArray;
            Image[] imageArray;
            GameObject prefabInstance;
            int price = vehicle.Value.price;

            prefabInstance = Instantiate(shopItemPrefab);
            textArray = prefabInstance.GetComponentsInChildren<Text>();
            textArray[0].text = vehicle.Value.name;
            textArray[1].text = vehicle.Value.description;

            imageArray = prefabInstance.GetComponentsInChildren<Image>();
            if (imageArray.Length > 1)
            {
                imageArray[1].sprite = Resources.Load<Sprite>("ShopSprites/" + vehicle.Value.name);
            }
            
            if (vehicle.Value.GetUnlockedStatus())
            {
                textArray[2].text = PRICE_ZERO_TEXT;
            }
            else
            {
                textArray[2].text = price.ToString();
            }

            prefabInstance.tag = "ShopVehicle";
            prefabInstance.transform.SetParent(upgradesUIContent.transform, false);
        }
    }
}
