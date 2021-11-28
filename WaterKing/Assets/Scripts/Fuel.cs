using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";

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
    private int firstPlayInt;

    private void Awake()
    {
        playerDataManager = gameObject.GetComponent<PlayerDataManager>();
        level = GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoader>();
    }

    void Start()
    {
       // if(PlayerPrefs.HasKey("currentEnergy"))
      //  {
      //      PlayerPrefs.SetInt("currentEnergy", 3);
      //      Load();
      //      StartCoroutine(RestoreEnergy());
      //  }
     //   else 
      //  {
      //      Load();
      //      StartCoroutine(RestoreEnergy());
      //  }

        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayInt == 0)
        {
            PlayerPrefs.SetInt("currentEnergy", 3);
            PlayerPrefs.SetInt(FirstPlay, -1);
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
            //level.LoadNextLevel(scene);

            if(isRestoring == false)
            {
                if(currentEnergy + 1 == maxEnergy)
                {
                    nextEnergyTime = AddDurration(DateTime.Now);
                }

                StartCoroutine(RestoreEnergy());
            }
            Save();
            level.LoadNextLevel(scene);

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
                    nextDateTime = AddDurration(timeToAdd);
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

    private DateTime AddDurration(DateTime datetime)
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
        //stuff im testing
        currentEnergy = PlayerPrefs.GetInt("currentEnergy");
        nextEnergyTime = StringtoDate(PlayerPrefs.GetString("nextEnergyTime"));
        lastEnergyTime = StringtoDate(PlayerPrefs.GetString("lastEnergyTime"));


        //old
        //currentEnergy = playerDataManager.GetFuelAmount();
        //nextEnergyTime = StringtoDate(PlayerPrefs.GetString("nextEnergyTime"));
        //lastEnergyTime = playerDataManager.GetLastEnergyUpdateTime();

    }

    private void Save()
    {
        //stuff im testing
        PlayerPrefs.SetInt("currentEnergy", currentEnergy);
        PlayerPrefs.SetString("nextEnergyTime", nextEnergyTime.ToString());
        PlayerPrefs.SetString("lastEnergyTime", lastEnergyTime.ToString());


        //old code 
        //  PlayerDataManager.player.fuelAmount = currentEnergy;
        // playerDataManager.SetFuelAmount(currentEnergy);
        // playerDataManager.SetLastEnergyUpdateTime(lastEnergyTime);
    }

    public void OnApplicationFocus(bool focus)
    {
        if(!focus)
        {
            Save();
        }
    }
}
