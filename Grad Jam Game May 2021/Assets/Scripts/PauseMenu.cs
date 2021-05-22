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

    private void Awake()
    {
        GameScreen = GameObject.Find("GameScreen");
        PauseScreen = GameObject.Find("PauseScreen");
        PauseOptionsScreen = GameObject.Find("PauseOptionsScreen");
        PauseScreen.SetActive(false);
        PauseOptionsScreen.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateLives();
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

    public void UpdateLives()
    {
        liveTexts.text = "Lives: " + FindObjectOfType<GM>().playerLives.ToString();
    }

    public void MenuScreen()
    {
        Time.timeScale = 1f;
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

}
