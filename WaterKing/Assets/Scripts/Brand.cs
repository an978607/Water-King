using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Brand : MonoBehaviour
{
    [SerializeField] GameObject brandMenu;
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
}
