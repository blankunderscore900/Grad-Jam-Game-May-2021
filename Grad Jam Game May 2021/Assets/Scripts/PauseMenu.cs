using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class PauseMenu : MonoBehaviour
{

    [Header("Game Menus")]
    private GameObject GameScreen;
    private GameObject PauseScreen;
    private GameObject PauseOptionsScreen;
    [SerializeField]
    [Tooltip("Showing the player how much lives they have")]
    public TextMeshProUGUI liveTexts;
    public bool gameIsPaused;
    private Animator animator;
    public float buttonTimer;
    public GameObject PauseButton, OptionsButton, ExitButton, BackButton;



    private MusicLibrary music;
    [SerializeField] string _SongLevel = "MasterVolume";

    private void Awake()
    {
        GameScreen = GameObject.Find("GameScreen");
        PauseScreen = GameObject.Find("PauseScreen");
        PauseOptionsScreen = GameObject.Find("PauseOptionsScreen");
        music = FindObjectOfType<MusicLibrary>();
        PauseScreen.SetActive(false);
        PauseOptionsScreen.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        music.MenuMusic = GameObject.Find(_SongLevel).GetComponent<AudioSource>();
        music.MenuMusic.Play();
        music.MenuMusic.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        gameIsPaused = !gameIsPaused;
        // pausing the game will bring up the pause menu
        if(gameIsPaused)
        {
            Time.timeScale = 0f;
            GameScreen.SetActive(false);
            PauseScreen.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(PauseButton);
        }
        else
        {
            Time.timeScale = 1f;
            GameScreen.SetActive(true);
            PauseScreen.SetActive(false);
            PauseOptionsScreen.SetActive(false);
        }
    }


    public void MenuScreen()
    {
        Time.timeScale = 1f;
        music.MenuMusic.Stop();
        music.Level1Music.Stop();
        music.Level2Music.Stop();
        music.Level3Music.Stop();
        music.Level4Music.Stop();
        music.Level5Music.Stop();
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseOptionsMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(BackButton);
        //Invoke("OptionsMenuButton", buttonTimer);
    }

    public void MainPauseMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(OptionsButton);
        //Invoke("OptionsMenuButton", buttonTimer);
    }

    public void PlaySoundEffect()
    {
        music.ButtonFX.Play();
    }
    public void PlayEnterEffect()
    {
        music.EnterFX.Play();
    }

}
