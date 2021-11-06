using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_hit_detection : MonoBehaviour
{
    private float time = 0;
    public Text life;
    public GameObject failScreen;
    public player_movement state;
    public int lives;
    GameObject score;
    public score num;

    private void Awake()
    {
        score = GameObject.FindGameObjectWithTag("Score");
        if (score == null)
        {
            return;
        }

        num = score.GetComponent<score>();
    }

    // Start is called before the first frame update
    void Start()
    {
        life.text = lives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time = time - Time.deltaTime;
        }

        else
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    // turn player red when it hits an enemy, then turn back to white after 1 second
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == state.state || this.gameObject.GetComponent<Renderer>().material.color == Color.red)
        {
            return;
        }

        this.gameObject.GetComponent<Renderer>().material.color = Color.red;
        time = 1;
        lives = lives - 1;
        num.multiplier = 1;
        life.text = lives.ToString();

        if(lives == 0) 
        {
            Time.timeScale = 0f;
            failScreen.SetActive(true);
        }
    }
}
