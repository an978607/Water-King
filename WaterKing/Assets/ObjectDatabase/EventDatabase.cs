using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDatabase : MonoBehaviour
{
    private static GameObject eventDatabaseObject;
    public Events events;
    private void Awake()
    {
        eventDatabaseObject = GameObject.FindGameObjectWithTag("EventDatabase");
        BuildDatabase();
    }

    public static GameObject GetEventDatabaseObject() => eventDatabaseObject;

    private void BuildDatabase()
    {
        string json = "{\"list\":" + GetAPIDatabase.GetEvents() + "}";
        events.list = Deserialization.DeserializeEvents(json);
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
