using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_hit_detection : MonoBehaviour
{
    [SerializeField] ParticleSystem hitParticle;
    private float time = 0;
    public Text life;
    public GameObject failScreen;
    public player_movement state;
    private int lives = 3;
    private int miAgua;
    private int bonusLives;
    score score;
    Bonus upgrades;
    


    private void Awake()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<score>();
        if (score == null)
        {
            return;
        }

        //get the lives upgrades and add it to the base of 3 
        upgrades = GameObject.FindGameObjectWithTag("UpgradesInfo").GetComponent<Bonus>();
        bonusLives = upgrades.getLivesBonus();
        lives = lives + bonusLives;
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
        playParticle();
        time = 1;
        lives = lives - 1;
        life.text = lives.ToString();

        if(lives == 0) 
        {
            Time.timeScale = 0f;
            failScreen.SetActive(true);
        }
    }

    public void setmiAgua(int brandBonus)
    {
        miAgua = brandBonus;

        //add it to lives and update UI
        lives = lives + brandBonus;

        //update UI 
        life.text = lives.ToString();
    }

    public void playParticle()
    {
        hitParticle.Play();
    }
}
