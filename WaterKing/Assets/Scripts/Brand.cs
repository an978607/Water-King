using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Brand : MonoBehaviour
{
    [SerializeField] GameObject brandMenu;

    //places it can make changes to 
    score score;
    player_hit_detection lives;
    // Cash cash

    void Start()
    {
        brandMenu.SetActive(true);

        //this can make changes in 3 game elements (cash, Health, and Score)
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<score>();
        lives = GameObject.FindGameObjectWithTag("VehicleInfo").GetComponent<player_hit_detection>();


    }

    public void Resume()
    {
        brandMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    //brands player Chooses
    public void LibertyWater()
    {
        Debug.Log("Player Choose Liberty Water");
    }

    public void MiAgua() 
    {
        lives.setmiAgua(2);
        Debug.Log("Player Choose MiAgua");
    }

    public void CarribeanBlue()
    {
        Debug.Log("Player Choose Carribean");
        score.setBrandScore(1.1f);
    }
}
