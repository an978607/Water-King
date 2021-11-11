using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Serialization
{
    public static void SerializeNewVehicle(Vehicle vehicle)
    {
        //string json = JsonUtility.ToJson(vehicles);
        string json = "{\"name\":\"" + vehicle.name +
            "\",\"description\":\"" + vehicle.description +
            "\",\"isUnlocked\":\"" + Convert.ToInt32(vehicle.GetUnlockedStatus())
            + "\",\"price\":\"" + vehicle.price + "\",\"speed\":\""  + vehicle.GetSpeed() + "\"}";
        Debug.Log("Serializing vehicles");
        //SaveJSON("Vehicles", json);
        PostAPIDatabase.PostVehicle(json);

    }

    // ** Need to rewrite to work with DataEditor Window
    public static void Serialize(TriviaDatabase.TriviaListClass triviaListClass)
    {
        string json = JsonUtility.ToJson(triviaListClass);
        Debug.Log("Serializing trivia");
        //SaveJSON("Trivia", json);
        PostAPIDatabase.PostTrivia(json);
    }

    //public static void Serialize(ObstacleDatabase.Obstacles obstacles)
    //{
    //    string json = JsonUtility.ToJson(obstacles);
    //    Debug.Log("Serializing obstacles");
    //    //SaveJSON("Obstacles", json);
    //    PostAPIDatabase.PostObstacle(json);
    //}

    public static void SerializeNewItem(Item item)
    {
        //string json = JsonUtility.ToJson(items);
        string json = "{\"name\":\"" + item.name +
            "\",\"description\":\"" + item.description +
            "\",\"isUnlocked\":\"" + Convert.ToInt32(item.GetUnlockedStatus())
            + "\",\"price\":\"" + item.price +
            "\",\"count\":\"" + item.count + "\"}";
        Debug.Log("Serializing items");
        Debug.Log(json);
        //SaveJSON("Items", json);
        PostAPIDatabase.PostItem(json);
    }

    public static void SerializeUpdatedItem(Item item)
    {
        //string json = JsonUtility.ToJson(items);
        string json = "{\"name\":\"" + item.name +
            "\",\"isUnlocked\":\"" + Convert.ToInt32(item.GetUnlockedStatus())
            + "\",\"price\":\"" + item.price +
            "\",\"count\":\"" + item.count + "\"}";
        Debug.Log("Serializing items");
        Debug.Log(json);
        //SaveJSON("Items", json);
        PutAPIDatabase.UpdateItems(json);

    }

    public static void SerializeNewEvent(Event eventObj)
    {
        //string json = JsonUtility.ToJson(events);
        string json = "{\"Name\":\"" + eventObj.Name + 
            "\",\"description\":\"" + eventObj.description +
            "\",\"isUnlocked\":\"" + Convert.ToInt32(eventObj.GetUnlockedStatus())
            + "\",\"price\":\"" + eventObj.price +  "\"}";
        //Debug.Log(json);
        Debug.Log("Serializing events");
        //SaveJSON("Events", json);
        PostAPIDatabase.PostEvent(json);
    }

    // TODO: UPDATE VALUES PASSED *****************
    public static void Serialize(Player player)
    {
        if (player != null)
        {
            string json = "{\"currency\":\"" + player.currency + 
                "\",\"totalScore\":\"" + player.totalScore + 
                "\",\"lastEnergyUpdateTime\":\"" + player.lastEnergyUpdateTime.ToString("yyyy-MM-dd HH:mm:ss") +
                "\",\"fuelAmount\":\"" + player.fuelAmount +
                "\",\"protection\":\"" + player.protection +
                "\",\"upgrade\":\"" + player.upgrade + 
                "\",\"time\":\"" + player.time +
                "\",\"selectedVehicle\":\"" + player.selectedVehicle +
                "\"}";
            Debug.Log("Serializing player");
            PutAPIDatabase.UpdatePlayer(json);
        }

    }

    public static void Serialize(Location location)
    {
        string json = "{\"locationName\":\"" + location.name + "\",\"score\":\"" + location.score + "\",\"isUnlocked\":\"" + Convert.ToInt32(location.isUnlocked) + "\"}";
        Debug.Log("Serializing location");
        PutAPIDatabase.UpdateLocations(json);
    }
    public static void Serialize(Vehicle vehicle)
    {
        string json = "{\"vehicleName\":\"" + vehicle.name + "\",\"isUnlocked\":\"" + Convert.ToInt32(vehicle.GetUnlockedStatus()) + "\",\"selectedVehicle\":\"" + vehicle.name + "\"}";
        Debug.Log(json);
        Debug.Log("Serializing vehicle");
        PutAPIDatabase.UpdatePlayerVehicles(json);
    }

    public static void Serialize(Item item)
    {
        string json = "{\"count\":\"" + item.count + 
            "\",\"isUnlocked\":\"" + 
            Convert.ToInt32(item.GetUnlockedStatus()) +
             "\",\"itemName\":\"" + item.name + "\"}";
        Debug.Log(json);
        Debug.Log("Serializing item");
        PutAPIDatabase.UpdatePlayerItems(json);
    }

    public static void Serialize(Event eventObj)
    {
        string json = "{\"eventName\":\"" + eventObj.Name + "\",\"isUnlocked\":\"" + Convert.ToInt32(eventObj.GetUnlockedStatus()) + "\"}";
        Debug.Log(json);
        Debug.Log("Serializing event");
        PutAPIDatabase.UpdatePlayerEvents(json);
    }

    private static string SaveJSON(string type, string json)
    {
        File.WriteAllText(Application.dataPath + "/Resources/" + type + ".json", json);
        return json;
    }
}
