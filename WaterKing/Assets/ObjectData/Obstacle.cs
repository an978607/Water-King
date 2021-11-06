using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Obstacle
{
    [SerializeField] private int id;
    public string name;
    [SerializeField] private int hitPoints;

    private Sprite ObstacleSprite;

    public Obstacle(int id, string name, int hitPoints)
    {
        this.id = id;
        this.name = name;
        this.hitPoints = hitPoints;
        ObstacleSprite = Resources.Load<Sprite>("ObstacleSprites/" + name);
    }

    public int GetHitPoints()
    {
        return hitPoints;
    }
}

