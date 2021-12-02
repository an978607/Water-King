using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle : MonoBehaviour
{
    [SerializeField] AudioSource effect;

    private void Start()
    {
        onPlay();
    }

    void onPlay()
    {
        effect.Play();
    }
}
