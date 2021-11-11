using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    private static GameObject itemDatabaseObject;
    public static Dictionary<string, Item> items;

    private void Awake()
    {
        itemDatabaseObject = GameObject.FindGameObjectWithTag("ItemDatabase");
        if (items == null)
        {
            BuildDatabase();
        }
    }

    public static GameObject GetItemDatabaseObject() => itemDatabaseObject;

    private void BuildDatabase()
    {
        string json = "{\"list\":" + GetAPIDatabase.GetItems() + "}";
        List<Item> itemsList = Deserialization.DeserializeItems(json);
        items = new Dictionary<string, Item>();
        foreach (Item i in itemsList)
        {
            if (items.ContainsKey(i.name))
            {
                Debug.LogError("ItemDatabase: Unable to add duplicate item, check remote database -> " + i.name);
                continue;
            }

            items.Add(i.name, i);
        }
    }

    [System.Serializable]
    public class Items
    {
        private static Items itemsInstance = null;
        public List<Item> list;
        public static Items GetInstance() => itemsInstance = (itemsInstance != null) ? itemsInstance : new Items();

        private Items()
        {
            list = new List<Item>();
        }
    }
}
