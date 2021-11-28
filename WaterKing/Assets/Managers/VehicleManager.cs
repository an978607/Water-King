using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VehicleManager : MonoBehaviour
{
    [SerializeField] private GameObject shopItemPrefab;
    [SerializeField] private bool isShop;

    const string PRICE_ZERO_TEXT = "UNLOCKED";
    public static string SELECTED_TEXT = "SELECTED";
    public static string SELECT_TEXT = "SELECT";
    public static Dictionary<string, GameObject> vehiclePrefabs;
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

            vehiclePrefabs = new Dictionary<string, GameObject>();
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
                if (PlayerDataManager.player.selectedVehicle == vehicle.Value.name)
                {
                    textArray[2].text = SELECTED_TEXT;
                    prefabInstance.GetComponentInChildren<Button>().interactable = false;
                }
                else
                {
                    textArray[2].text = SELECT_TEXT;
                }
            }
            else
            {
                if (price > PlayerDataManager.GetCurrency())
                {
                    prefabInstance.GetComponentInChildren<Button>().interactable = false;
                }

                textArray[2].text = price.ToString();
            }

            prefabInstance.tag = "ShopVehicle";
            prefabInstance.transform.SetParent(upgradesUIContent.transform, false);
            vehiclePrefabs.Add(vehicle.Value.name, prefabInstance);
        }
    }
}
