using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Music : MonoBehaviour
{
    private MusicLibrary music;

    private void Awake()
    {

        music = FindObjectOfType<MusicLibrary>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("In contact with: " + other.gameObject.name);     
        music.MenuMusic.Stop();
        music.Level3Music.Play();
        music.Level3Music.loop = true;
        gameObject.SetActive(false);
    }
}
