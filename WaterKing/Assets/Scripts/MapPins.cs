using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MapPins : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1f;
    }
    public void turnOffNextFrame(GameObject thisObj)
    {
        StartCoroutine(turnOffNextFrame_Method(thisObj));
    }
    IEnumerator turnOffNextFrame_Method(GameObject thisObj)
    {
        yield return new WaitForSeconds(.1f);
        thisObj.SetActive(false);
    }
}

