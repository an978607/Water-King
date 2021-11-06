using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VehicleManager : MonoBehaviour
{
    [SerializeField] private GameObject shopItemPrefab;
    [SerializeField] private bool isShop;

    const string PRICE_ZERO_TEXT = "UNLOCKED";

    private GameObject vehicleDatabaseObject;
    private VehicleDatabase vehicleDatabase;
    private GameObject upgradesUIContent;

    private void Awake()
    {
        vehicleDatabaseObject = GameObject.FindGameObjectWithTag("VehicleDatabase");

        if (vehicleDatabaseObject == null)
        {
            Debug.LogError("VehicleManager: Unable to find VehicleDatabase object");
            return;
        }

        vehicleDatabase = vehicleDatabaseObject.GetComponent<VehicleDatabase>();

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

        if (vehicleDatabase.vehicles == null || vehicleDatabase.vehicles.list == null)
        {
            Debug.LogError("VehicleManager: Vehicles null when creating shop list");
            return;
        }

        for (int i = 0; i < vehicleDatabase.vehicles.list.Count; i++)
        {
            Text[] textArray;
            Image[] imageArray;
            GameObject prefabInstance;
            int price = vehicleDatabase.vehicles.list[i].price;

            prefabInstance = Instantiate(shopItemPrefab);
            textArray = prefabInstance.GetComponentsInChildren<Text>();
            textArray[0].text = vehicleDatabase.vehicles.list[i].name;
            textArray[1].text = vehicleDatabase.vehicles.list[i].description;

            imageArray = prefabInstance.GetComponentsInChildren<Image>();
            if (imageArray.Length > 1)
            {
                imageArray[1].sprite = Resources.Load<Sprite>("ShopSprites/" + vehicleDatabase.vehicles.list[i].name);
            }
            
            if (price == 0)
            {
                textArray[2].text = PRICE_ZERO_TEXT;
            }
            else
            {
                textArray[2].text = price.ToString();
            }

            prefabInstance.transform.SetParent(upgradesUIContent.transform, false);
        }
    }
}
