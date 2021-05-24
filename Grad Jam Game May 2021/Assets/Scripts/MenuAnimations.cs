using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuAnimations : MonoBehaviour
{

    private Animator animator;
    [Header("Buttons")]
    public GameObject titleScreenButton;
    public GameObject MenuFirstButton;
    public GameObject OptionsButton;
    public GameObject BackButton;
    public GameObject QuitButton;
    public GameObject MenuButton;
    public GameObject MenuAboutButton;
    public GameObject AboutButton;

    public float buttonTimer;

    private MusicLibrary music;

    [SerializeField] string LevelName = "MasterVolume";


    private void Awake()
    {
        animator = GetComponent<Animator>();
        music = FindObjectOfType<MusicLibrary>();
    }

    // Start is called before the first frame update
    void Start()
    {
        music.MenuMusic = GameObject.FindGameObjectWithTag("MenuMusic").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void menuStart()
    {

        // Plays the animation for opening to the start menu of the game
        EventSystem.current.SetSelectedGameObject(null);
        animator.SetTrigger("MenuScreen");
        music.MenuMusic.Play();
        music.MenuMusic.loop = true;
        Invoke("MenuStartButton", buttonTimer);
    }

    public void MenuStartButton()
    {
        EventSystem.current.SetSelectedGameObject(MenuFirstButton);
    }

    public void StartGame()
    {
        music.MenuMusic.Stop();
        SceneManager.LoadScene(LevelName);
    }

    public void OptionsMenu()
    {
        // Plays the animation for leaving the start menu
        // and plays the animations for going to the options screen
        animator.SetTrigger("MenuLeave");
        animator.SetTrigger("OptionScreen");
        EventSystem.current.SetSelectedGameObject(null);
        Invoke("OptionsMenuButton", buttonTimer);
    }

    public void OptionsMenuButton()
    {
        EventSystem.current.SetSelectedGameObject(BackButton);
    }

    public void LeaveOptions()
    {
        // Plays the animation for leaving the options menu
        // and plays the animations for going to the start menu
        animator.SetTrigger("OptionLeave");
        animator.SetTrigger("MenuScreen");
        EventSystem.current.SetSelectedGameObject(null);
        Invoke("LeaveOptionsButton", buttonTimer);
    }

    public void LeaveOptionsButton()
    {
        EventSystem.current.SetSelectedGameObject(OptionsButton);
    }

    public void LeaveMenuForQuit()
    {
        // Plays the animation for leaving the Main menu
        // and plays the animations for going to the Quit menu
        animator.SetTrigger("MenuLeave");
        animator.SetTrigger("QuitMenu");
        EventSystem.current.SetSelectedGameObject(null);
        music.MenuMusic.Stop();
        music.MenuMusic.loop = false;
        Invoke("QuitMenu", buttonTimer);
    }

    public void QuitMenu()
    {
        EventSystem.current.SetSelectedGameObject(MenuButton);
    }

    public void LeaveQuit()
    {
        // Plays the animation for leaving the Quit menu
        // and plays the animations for going to the start menu
        animator.SetTrigger("QuitLeave");
        animator.SetTrigger("MenuScreen");
        music.MenuMusic.Play();
        music.MenuMusic.loop = true;
        EventSystem.current.SetSelectedGameObject(null);
        Invoke("BackMenu", buttonTimer);
    }

    public void BackMenu()
    {
        EventSystem.current.SetSelectedGameObject(QuitButton);
    }

    public void EnterAbout()
    {
        // Plays the animation for leaving the Main menu
        // and plays the animations for going to the About menu
        animator.SetTrigger("MenuLeave");
        animator.SetTrigger("EnterAbout");
        EventSystem.current.SetSelectedGameObject(null);
        Invoke("AboutButtonSelect", buttonTimer);
    }

    public void AboutButtonSelect()
    {
        EventSystem.current.SetSelectedGameObject(MenuAboutButton);
    }


    public void AboutMeun()
    {
        // Plays the animation for leaving the About menu
        // and plays the animations for going to the main menu
        animator.SetTrigger("LeaveAbout");
        animator.SetTrigger("MenuScreen");
        EventSystem.current.SetSelectedGameObject(null);
        Invoke("AboutMenuButtonSelect", buttonTimer);
    }

    public void AboutMenuButtonSelect()
    {
        EventSystem.current.SetSelectedGameObject(AboutButton);
    }

    public void QuitGame()
    {
        // Quits the game 
        Application.Quit();
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
