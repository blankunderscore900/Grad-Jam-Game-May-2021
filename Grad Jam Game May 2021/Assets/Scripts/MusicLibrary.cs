using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLibrary : MonoBehaviour
{

    [Header("Music")]
    [Tooltip("This song will play in the menu")]
    public AudioSource MenuMusic;
    [Tooltip("This song will play in Level 1")]
    public AudioSource Level1Music;
    [Tooltip("This song will play in Level 2.1")]
    public AudioSource Level2Music;
    [Tooltip("This song will play in Level 2.2")]
    public AudioSource Level3Music;
    [Tooltip("This song will play in Level 3")]
    public AudioSource Level4Music;
    [Tooltip("This song will play in Level 3")]
    public AudioSource Level5Music;

    [Header("SoundEffects")]
    [Tooltip("This will play when you select a button")]
    public AudioSource ButtonFX;
    [Tooltip("This will play when you enter a button")]
    public AudioSource EnterFX;
    [Tooltip("This will play when you enter a button")]
    public AudioSource JumpFX;
    [Tooltip("This will play when you enter a button")]
    public AudioSource CollisionFX;
    [Tooltip("This will play when you enter a button")]
    public AudioSource DeathSFX;
    [Tooltip("This will play when you hit a switch")]
    public AudioSource SwitchSFX;
    [Tooltip("This will play when you enter a button")]
    public AudioSource EmitterSFX;


    public static MusicLibrary instance;



    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

}
