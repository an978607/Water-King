using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime;

    public void LoadNextLevel(int level)
    {
        StartCoroutine(LoadLevel(level));
    }


    IEnumerator LoadLevel(int level)
    {
           //get time to be running
            Time.timeScale = 1f;

            //play animation
            transition.SetTrigger("Start");

            //wait
            yield return new WaitForSeconds(transitionTime);

            //load next scene
            SceneManager.LoadScene(level);
    }
     

}
