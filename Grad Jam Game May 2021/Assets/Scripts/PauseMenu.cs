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
    [SerializeField]
    [Tooltip("Showing the player how much lives they have")]
    public TextMeshProUGUI liveTexts;
    public bool gameIsPaused;
    private Animator animator;
    public GameObject PauseButton, OptionsButton, ExitButton;

    // Start is called before the first frame update
    void Start()
    {
        GameScreen = GameObject.Find("GameScreen");
        PauseScreen = GameObject.Find("PauseScreen");
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
        }
    }

    public void UpdateLives()
    {
        liveTexts.text = "Lives: " + FindObjectOfType<GM>().playerLives.ToString();
    }
}
