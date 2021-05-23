using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTransfer : MonoBehaviour
{
    // Start is called before the first frame update
    private MusicLibrary music;

    public string next;

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    /// 
    private void Awake()
    {
        music = FindObjectOfType<MusicLibrary>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("In contact with: " + other.gameObject.name);     
        music.MenuMusic.Stop();
        music.Level1Music.Stop();
        music.Level2Music.Stop();
        music.Level3Music.Stop();
        music.Level4Music.Stop();
        music.Level5Music.Stop();
        SceneManager.LoadScene(next);
    }

}
