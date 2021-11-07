using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    [SerializeField] Text energyText;
    [SerializeField] Text timerText;
    [SerializeField] GameObject Trivia;

    private int maxEnergy = 3;
    private int currentEnergy;
    private int restoreDuration;

    private DateTime nextEnergyTime;
    private DateTime lastEnergyTime;

    private bool isRestoring = false;
    private PlayerDataManager playerDataManager;
    LevelLoader level;

    private void Awake()
    {
        playerDataManager = gameObject.GetComponent<PlayerDataManager>();
        level = GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoader>();
    }

    void Start()
    {
        if(PlayerPrefs.HasKey("currentEnergy"))
        {
            PlayerPrefs.SetInt("currentEnergy", 3);
            Load();
            StartCoroutine(RestoreEnergy());
        }
        else 
        {
            Load();
            StartCoroutine(RestoreEnergy());
        }
    }

    public void UseEnergy(int scene)
    {
        if(currentEnergy >= 1)
        {
            currentEnergy--;
            UpdateEnergy();
            level.LoadNextLevel(scene);
            if(isRestoring == false)
            {
                if(currentEnergy + 1 == maxEnergy)
                {
                    nextEnergyTime = AddDurration(DateTime.Now, restoreDuration);
                }

                StartCoroutine(RestoreEnergy());
            }
        }

        else 
        {
            //Trigger Trivia
            Trivia.SetActive(true);
            
            Debug.Log("Insufficient Energy");
        }
    }

    private IEnumerator RestoreEnergy()
    {
        UpdateEnergyTimer();
        isRestoring = true; 

        while(currentEnergy < maxEnergy)
        {
            DateTime currentDateTime = DateTime.Now;
            DateTime nextDateTime = nextEnergyTime;
            bool isEnergyAdding = false;

            while(currentDateTime > nextDateTime )
            {
                if(currentEnergy < maxEnergy)
                {
                    isEnergyAdding = true;
                    currentEnergy++;
                    UpdateEnergy();
                    DateTime timeToAdd = lastEnergyTime > nextDateTime ? lastEnergyTime : nextDateTime;
                    nextDateTime = AddDurration(timeToAdd, restoreDuration);
                }

                else 
                {
                    break;
                }
            }
            if(isEnergyAdding == true)
            {
                lastEnergyTime = DateTime.Now;
                nextEnergyTime = nextDateTime;
            }

            UpdateEnergyTimer();
            UpdateEnergy();
            Save();
            yield return null;
        }
        isRestoring = false;
    }

    private DateTime AddDurration(DateTime datetime, int duration)
    {
        return datetime.AddMinutes(30);
    }

    private void UpdateEnergy()
    {
        energyText.text = currentEnergy.ToString() + "/" + maxEnergy.ToString();
    }

    private void UpdateEnergyTimer()
    {
        if(currentEnergy >= maxEnergy)
        {
            timerText.text = "FULL";
            return;
        }

        TimeSpan time = nextEnergyTime - DateTime.Now;
        string timeValue = String.Format("{0:00}:{1:00}", time.Minutes, time.Seconds);
        timerText.text = timeValue;
    }

    private DateTime StringtoDate(string datetime) 
    { 
        if(String.IsNullOrEmpty(datetime))
        {
            return DateTime.Now;
        }
        else 
        {
            return DateTime.Parse(datetime);
        }
    }

    public void AddEnergy(int amount)
    {
        currentEnergy += amount;
    }

    private void Load()
    {
        currentEnergy = playerDataManager.GetFuelAmount();
        nextEnergyTime = StringtoDate(PlayerPrefs.GetString("nextEnergyTime"));
        lastEnergyTime = playerDataManager.GetLastEnergyUpdateTime();

    }

    private void Save()
    {
        PlayerDataManager.player.fuelAmount = currentEnergy;
       // playerDataManager.SetFuelAmount(currentEnergy);
        PlayerPrefs.SetString("nextEnergyTime", nextEnergyTime.ToString());
        playerDataManager.SetLastEnergyUpdateTime(lastEnergyTime);
    }
}
