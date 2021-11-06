using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // the type of enemies that it can spawn
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject brandMenu;

    // Start is called before the first frame update
    void Start()
    {
        // select a random float from 0 to 3
        float delay = Random.Range(0f, 3f);
        
        // calls SpawnObject, "delay" randomly delay the first enemy for 0 to 3 seconds
        Invoke("SpawnObject", delay);
    }

    public void SpawnObject()
    {
            int type = Random.Range(1, 4);

        if (brandMenu.activeSelf == false)
        {
            // spawns the enemy
            switch (type)
            {
                case 1:
                    Instantiate(spawn1, transform.position, transform.rotation);
                    break;

                case 2:
                    Instantiate(spawn2, transform.position, transform.rotation);
                    break;

                case 3:
                    Instantiate(spawn3, transform.position, transform.rotation);
                    break;
            }
        }
            // select a random float from 1 to 3
            float delay = Random.Range(3f, 4f);

            // recursive call SpawnObject, "delay" randomly deplay the first enemy for 1 to 3 seconds
            Invoke("SpawnObject", delay);
        }
}