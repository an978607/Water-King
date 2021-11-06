using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    private static GameObject itemDatabaseObject;
    public Items items;

    private void Awake()
    {
        itemDatabaseObject = GameObject.FindGameObjectWithTag("ItemDatabase");
        BuildDatabase();
    }

    public static GameObject GetItemDatabaseObject() => itemDatabaseObject;

    private void BuildDatabase()
    {
        string json = "{\"list\":" + GetAPIDatabase.GetItems() + "}";
        items.list = Deserialization.DeserializeItems(json);
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
