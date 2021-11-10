using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioManger : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string MusicPref = "MusicPref";
    private static readonly string SFXPref = "SFXPref";

    private int firstPlayInt;
    public Slider musicSlider, sfxSlider;
    private float musicFloat, sfxFloat;


    public AudioSource musicAudio;
    public AudioSource[] sfxAudio;

    // Start is called before the first frame update
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if(firstPlayInt == 0)
        {
            musicFloat = .125f;
            sfxFloat = .125f;
            musicSlider.value = musicFloat;
            sfxSlider.value = sfxFloat;
            PlayerPrefs.SetFloat(MusicPref, musicFloat);
            PlayerPrefs.SetFloat(SFXPref, sfxFloat);
            PlayerPrefs.SetInt(FirstPlay,-1);
        }
        else
        {
            musicFloat = PlayerPrefs.GetFloat(MusicPref);
            musicSlider.value = musicFloat;

            sfxFloat = PlayerPrefs.GetFloat(SFXPref);
            sfxSlider.value = sfxFloat;
        }
    }

    public void SaveSound()
    {
        PlayerPrefs.SetFloat(MusicPref, musicSlider.value);
        PlayerPrefs.SetFloat(SFXPref, sfxSlider.value);
    }

    private void OnApplicationFocus(bool infocus)
    {
        if(!infocus)
        {
            SaveSound();
        }
    }

    public void UpdateSound()
    {
        musicAudio.volume = musicSlider.value;

        for (int i = 0; i < sfxAudio.Length; i++)
        {
            sfxAudio[i].volume = sfxSlider.value;
        }
    }
}
