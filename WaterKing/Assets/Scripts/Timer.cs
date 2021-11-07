using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float timeValue;
    public Text timeText;
    public GameObject endScreen;
    LocationInfo info;
    Bonus upgrades;
    [SerializeField]GameObject brandMenu;

    private void Start()
    {
        //get the levels initial time
        info = GameObject.FindGameObjectWithTag("LocationInfo").GetComponent<LocationInfo>();
        upgrades = GameObject.FindGameObjectWithTag("UpgradesInfo").GetComponent<Bonus>();
        timeValue = info.getTime();

        //apply multipliers to time
        timeValue = timeValue + (timeValue * upgrades.getTimerBonus());

        Debug.Log("New Time Calculated");
    }


    // Update is called once per frame
    void Update()
    {
        if(brandMenu.activeInHierarchy == false)
        {
            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;
            }
            else
            {
                timeValue = 0;
            }
            displayTime(timeValue);

            if (timeValue == 0)
            {
                if (endScreen.activeInHierarchy == true)
                {
                    return;
                }
                else
                {
                    endScreen.SetActive(true);
                    Time.timeScale = 0f;
                }
            }
        }
    }

    void displayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0 )
        {
            timeToDisplay = 0;
        }

        //calculate minutes
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);

        //calculate seconds
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
