using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Threading.Tasks;

public static class Deserialization
{
    public static List<Vehicle> DeserializeVehicles(string json)
    {
        VehicleDatabase.Vehicles vehicles = JsonUtility.FromJson<VehicleDatabase.Vehicles>(json);
        return vehicles.list;
    }

    public static List<Trivia> DeserializeTrivia(string json)
    {
        TriviaDatabase.TriviaListClass triviaListClass = JsonUtility.FromJson<TriviaDatabase.TriviaListClass>(json);
        return triviaListClass.list;
    }

    public static List<Obstacle> DeserializeObstacles(string json)
    {
        ObstacleDatabase.Obstacles obstacles = JsonUtility.FromJson<ObstacleDatabase.Obstacles>(json);
        return obstacles.list;
    }

    public static List<Item> DeserializeItems(string json)
    {
        ItemDatabase.Items items = JsonUtility.FromJson<ItemDatabase.Items>(json);
        return items.list;
    }

    public static List<Event> DeserializeEvents(string json)
    {
        EventDatabase.Events events = JsonUtility.FromJson<EventDatabase.Events>(json);
        return events.list;
    }

    public static Player DeserializePlayer(string json)
    {
        Player player = JsonUtility.FromJson<Player>(json);
        return player;
    }
}
