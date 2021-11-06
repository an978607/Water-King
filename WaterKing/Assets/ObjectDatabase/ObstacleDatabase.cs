using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDatabase : MonoBehaviour
{
    private static GameObject obstacleDatabaseObject;
    public Obstacles obstacles;

    private void Awake()
    {
        obstacleDatabaseObject = GameObject.FindGameObjectWithTag("ObstacleDatabase");
        BuildDatabase();
    }

    public static GameObject GetObstacleDatabaseObject() => obstacleDatabaseObject;

    private void BuildDatabase()
    {
        string json = "{\"list\":" + GetAPIDatabase.GetObstacles() + "}";
        obstacles.list = Deserialization.DeserializeObstacles(json);
    }

    [System.Serializable]
    public class Obstacles
    {
        private static Obstacles obstaclesInstance = null;
        public List<Obstacle> list;
        public static Obstacles GetInstance() => obstaclesInstance = (obstaclesInstance != null) ? obstaclesInstance : new Obstacles();

        private Obstacles()
        {
            list = new List<Obstacle>();
        }
    }
}
