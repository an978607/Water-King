using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Serialization
{
    public static void Serialize(VehicleDatabase.Vehicles vehicles)
    {
        PostAPIDatabase post = new PostAPIDatabase();
        string json = JsonUtility.ToJson(vehicles);
        Debug.Log("Serializing vehicles");
        SaveJSON("Vehicles", json);
        post.postVehicle(json);
       
    }

    public static void Serialize(TriviaDatabase.TriviaListClass triviaListClass)
    {
        PostAPIDatabase post = new PostAPIDatabase();
        string json = JsonUtility.ToJson(triviaListClass);
        Debug.Log("Serializing trivia");
        SaveJSON("Trivia", json);
        post.postTrivia(json);
    }

    public static void Serialize(ObstacleDatabase.Obstacles obstacles)
    {
        PostAPIDatabase post = new PostAPIDatabase();
        string json = JsonUtility.ToJson(obstacles);
        Debug.Log("Serializing obstacles");
        SaveJSON("Obstacles", json);
        post.postObstacle(json);
    }

    public static void Serialize(ItemDatabase.Items items)
    {
        PostAPIDatabase post = new PostAPIDatabase();
        string json = JsonUtility.ToJson(items);
        Debug.Log("Serializing items");
        SaveJSON("Items", json);
        post.postItem(json);
    }

    public static void Serialize(EventDatabase.Events events)
    {
        PostAPIDatabase post = new PostAPIDatabase();
        string json = JsonUtility.ToJson(events);
        Debug.Log("Serializing events");
        SaveJSON("Events", json);
        post.postEvent(json);
    }

    private static string SaveJSON(string type, string json)
    {
        File.WriteAllText(Application.dataPath + "/Resources/" + type + ".json", json);
        return json;
    }
}
