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
        post.postVehicle(json);
       
    }

    public static void Serialize(TriviaDatabase.TriviaListClass triviaListClass)
    {
        PostAPIDatabase post = new PostAPIDatabase();
        string json = JsonUtility.ToJson(triviaListClass);
        Debug.Log("Serializing trivia");
        post.postTrivia(json);
    }

    public static void Serialize(ObstacleDatabase.Obstacles obstacles)
    {
        PostAPIDatabase post = new PostAPIDatabase();
        string json = JsonUtility.ToJson(obstacles);
        Debug.Log("Serializing obstacles");
        post.postObstacle(json);
    }

    public static void Serialize(ItemDatabase.Items items)
    {
        PostAPIDatabase post = new PostAPIDatabase();
        string json = JsonUtility.ToJson(items);
        Debug.Log("Serializing items");
        post.postItem(json);
    }

    public static void Serialize(EventDatabase.Events events)
    {
        PostAPIDatabase post = new PostAPIDatabase();
        string json = JsonUtility.ToJson(events);
        Debug.Log("Serializing events");
        post.postEvent(json);
    }

    // Local testing only
    private static string SaveJSON(string type, string json)
    {
        File.WriteAllText(Application.dataPath + "/Resources/" + type + ".json", json);
        return json;
    }
}
