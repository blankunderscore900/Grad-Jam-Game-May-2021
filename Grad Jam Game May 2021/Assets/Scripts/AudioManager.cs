using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    public Slider volume;
    public Slider fxVolume;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        volume.value = PlayerPrefs.GetFloat("MusicVolume");
        fxVolume.value = PlayerPrefs.GetFloat("FxVolume");
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = volume.value;
    }



    public void VolumePrefs()
    {
        PlayerPrefs.SetFloat("MusicVolume", audioSource.volume);
        PlayerPrefs.SetFloat("FxVolume", fxVolume.value);
    }
}