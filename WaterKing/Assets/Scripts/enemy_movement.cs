using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    score call;

    // Start is called before the first frame update
    void Start()
    {
        call = FindObjectOfType<score>();
    }

    // Update is called once per frame
    void Update()
    {
        // moves enemy object to the left
        if(Time.timeScale == 1f)
        {
            transform.Translate((float)-10*Time.deltaTime, 0, 0);
        }

        // if it gets off screen it will remove the object
        if(transform.position.x <= -15)
        {
            call.Enemy_Destroyed();
            Destroy(this.gameObject);
        }
    }
}
