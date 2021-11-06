using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    [SerializeField] private GameObject shopItemPrefab;
    [SerializeField] private bool isShop;

    const string PRICE_ZERO_TEXT = "UNLOCKED";

    private GameObject eventDatabaseObject;
    private EventDatabase eventDatabase;
    private GameObject eventsUIContent;

    private void Awake()
    {
        eventDatabaseObject = GameObject.FindGameObjectWithTag("EventDatabase");

        if (eventDatabaseObject == null)
        {
            Debug.LogError("EventManager: Unable to find EventDatabase object");
            return;
        }

        eventDatabase = eventDatabaseObject.GetComponent<EventDatabase>();

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

        if (eventDatabase.events == null || eventDatabase.events.list == null)
        {
            Debug.LogError("EventManager: Events null when creating shop list");
            return;
        }    

        for (int i = 0; i < eventDatabase.events.list.Count; i++)
        {
            Text[] textArray;
            Image[] imageArray;
            GameObject prefabInstance;
            int price = eventDatabase.events.list[i].price;

            prefabInstance = Instantiate(shopItemPrefab);
            textArray = prefabInstance.GetComponentsInChildren<Text>();
            textArray[0].text = eventDatabase.events.list[i].name;
            textArray[1].text = eventDatabase.events.list[i].description;

            imageArray = prefabInstance.GetComponentsInChildren<Image>();
            if (imageArray.Length > 1)
            {
                imageArray[1].sprite = Resources.Load<Sprite>("ShopSprites/" + eventDatabase.events.list[i].name);
            }

            if (price == 0)
            {
                textArray[2].text = PRICE_ZERO_TEXT;
            }
            else
            {
                textArray[2].text = price.ToString();
            }

            prefabInstance.transform.SetParent(eventsUIContent.transform, false);
        }
    }
}
