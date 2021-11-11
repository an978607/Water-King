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
        Debug.Log(json);
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
            + "\",\"price\":\"" + item.price + "\"}";
        Debug.Log("Serializing items");
        //SaveJSON("Items", json);
        PostAPIDatabase.PostItem(json);
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

    public static void Serialize(Player player)
    {
        string json = JsonUtility.ToJson(player);
        Debug.Log("Serializing player");
        PostAPIDatabase.PostPlayer(json);
    }

    public static void Serialize(Location location)
    {
        string json = "{\"locationName\":\"" + location.name + "\",\"score\":\"" + location.score + "\",\"isUnlocked\":\"" + Convert.ToInt32(location.isUnlocked) + "\"}";
        Debug.Log(json);
        Debug.Log("Serializing location");
        PutAPIDatabase.UpdateLocations(json);
    }
    public static void Serialize(Vehicle vehicle)
    {
        string json = "{\"vehicles\":\"" + vehicle.name + "\",\"visUnlocked\":\"" + Convert.ToInt32(vehicle.GetUnlockedStatus()) + "\"}";
        Debug.Log(json);
        Debug.Log("Serializing vehicle");
        //PutAPIDatabase.UpdatePlayerItems(json);
    }

    public static void Serialize(Item item)
    {
        string json = "{\"items\":\"" + item.name + "\",\"iisUnlocked\":\"" + Convert.ToInt32(item.GetUnlockedStatus()) + "\"}";
        Debug.Log(json);
        Debug.Log("Serializing item");
        //PutAPIDatabase.UpdatePlayerItems(json);
    }

    public static void Serialize(Event eventObj)
    {
        string json = "{\"events\":\"" + eventObj.Name + "\",\"eisUnlocked\":\"" + Convert.ToInt32(eventObj.GetUnlockedStatus()) + "\"}";
        Debug.Log(json);
        Debug.Log("Serializing event");
        //PutAPIDatabase.UpdatePlayerItems(json);
    }

    private static string SaveJSON(string type, string json)
    {
        File.WriteAllText(Application.dataPath + "/Resources/" + type + ".json", json);
        return json;
    }
}
