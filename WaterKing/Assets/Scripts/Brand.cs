using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Brand : MonoBehaviour
{
    [SerializeField] GameObject brandMenu;
    private float cashBonus = 0;
    private float ScoreBonus = 0;
    private int Lives = 0;
    void Start()
    {
        brandMenu.SetActive(true);
        //Time.timeScale = 0f;
    }

    public void Resume()
    {
        brandMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    //brands player Chooses
    public void LibertyWater()
    {
        cashBonus = 1.1f;
    }

    public void MiAgua() 
    {
        ScoreBonus = 1.1f;
    }

    public void CarribeanBlue()
    {
        Lives = 2;
    }

    public float getCashBonus()
    {
        return cashBonus;
    }    

    public float getScoreBonus()
    {
        return ScoreBonus;
    }

    public int getLivesBonus()
    {
        return Lives;
    }
}
