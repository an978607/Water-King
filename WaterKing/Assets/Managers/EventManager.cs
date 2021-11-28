using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    [SerializeField] private GameObject shopItemPrefab;
    [SerializeField] private bool isShop;

    const string PRICE_ZERO_TEXT = "UNLOCKED";
    private GameObject eventsUIContent;

    private void Awake()
    {
        if (isShop)
        {
            eventsUIContent = GameObject.FindGameObjectWithTag("EventsUIContent");
            if (eventsUIContent == null)
            {
                Debug.LogError("EventManager: Unable to find EventsUIContent object");
                return;
            }

            CreateEventShopItemList();
        }
    }

    void CreateEventShopItemList()
    {
        if (EventDatabase.events == null)
        {
            Debug.LogError("EventManager: Events null when creating shop list");
            return;
        }    

       foreach (KeyValuePair<string, Event> eventObj in EventDatabase.events)
        {
            Text[] textArray;
            Image[] imageArray;
            GameObject prefabInstance;
            int price = eventObj.Value.price;

            prefabInstance = Instantiate(shopItemPrefab);
            textArray = prefabInstance.GetComponentsInChildren<Text>();
            textArray[0].text = eventObj.Value.Name;
            textArray[1].text = eventObj.Value.description;

            imageArray = prefabInstance.GetComponentsInChildren<Image>();
            if (imageArray.Length > 1)
            {
                imageArray[1].sprite = Resources.Load<Sprite>("ShopSprites/" + eventObj.Value.Name);
            }

            if (eventObj.Value.GetUnlockedStatus())
            {
                textArray[2].text = PRICE_ZERO_TEXT;
                prefabInstance.GetComponentInChildren<Button>().interactable = false;
            }
            else
            {
                if (price > PlayerDataManager.GetCurrency())
                {
                    prefabInstance.GetComponentInChildren<Button>().interactable = false;
                }

                textArray[2].text = price.ToString();
            }

            prefabInstance.transform.SetParent(eventsUIContent.transform, false);
        }
    }
}
