using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EventDatabase : MonoBehaviour
{
    private static GameObject eventDatabaseObject;
    public static Dictionary<string, Event> events;
    private void Awake()
    {
        eventDatabaseObject = GameObject.FindGameObjectWithTag("EventDatabase");
        if (events == null)
        {
            BuildDatabase();
        }
    }

    public static GameObject GetEventDatabaseObject() => eventDatabaseObject;

    private void BuildDatabase()
    {
        string json = "{\"list\":" + GetAPIDatabase.GetEvents() + "}";
        List<Event> eventList = Deserialization.DeserializeEvents(json);
        events = new Dictionary<string, Event>();
        foreach(Event e in eventList.OrderBy(key => key.price))
        {
            if (events.ContainsKey(e.Name))
            {
                Debug.LogError("EventDatabase: Unable to add duplicate event, check remote database -> " + e.Name);
                continue;
            }
            events.Add(e.Name, e);
        }
    }

    [System.Serializable]
    public class Events
    {
        private static Events eventsInstance = null;
        public List<Event> list;
        public static Events GetInstance() => eventsInstance = (eventsInstance != null) ? eventsInstance : new Events();

        private Events()
        {
            list = new List<Event>();
        }
    }
}
