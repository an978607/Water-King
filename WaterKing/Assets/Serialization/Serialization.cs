using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Serialization
{
    public static void Serialize(VehicleDatabase.Vehicles vehicles)
    {
        string json = JsonUtility.ToJson(vehicles);
        Debug.Log("Serializing vehicles");
        SaveJSON("Vehicles", json);
        PostAPIDatabase.PostVehicle(json);

    }

    public static void Serialize(TriviaDatabase.TriviaListClass triviaListClass)
    {
        string json = JsonUtility.ToJson(triviaListClass);
        Debug.Log("Serializing trivia");
        SaveJSON("Trivia", json);
        PostAPIDatabase.PostTrivia(json);
    }

    public static void Serialize(ObstacleDatabase.Obstacles obstacles)
    {
        string json = JsonUtility.ToJson(obstacles);
        Debug.Log("Serializing obstacles");
        SaveJSON("Obstacles", json);
        PostAPIDatabase.PostObstacle(json);
    }

    public static void Serialize(ItemDatabase.Items items)
    {
        string json = JsonUtility.ToJson(items);
        Debug.Log("Serializing items");
        SaveJSON("Items", json);
        PostAPIDatabase.PostItem(json);
    }

    public static void Serialize(EventDatabase.Events events)
    {
        string json = JsonUtility.ToJson(events);
        Debug.Log("Serializing events");
        SaveJSON("Events", json);
        PostAPIDatabase.PostEvent(json);
    }

    public static void Serialize(PlayerDatabase.Players player)
    {
        string json = JsonUtility.ToJson(player);
        //string json = "{\"currency\": 5,\"fuelAmount\": 3,\"totalScore\": 0,\"upgrade\":1,\"time\":2.4,\"protection\":2,\"price\":32}";
        Debug.Log("Serializing players");
        SaveJSON("Players", json);
        PostAPIDatabase.PostPlayer(json);
    }

    private static string SaveJSON(string type, string json)
    {
        File.WriteAllText(Application.dataPath + "/Resources/" + type + ".json", json);
        return json;
    }
}
