using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
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

    public float buttonTimer;


    private void Awake()
    {
        animator = GetComponent<Animator>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void menuStart()
    {
        // Plays the animation for opening to the start menu of the game
        EventSystem.current.SetSelectedGameObject(null);
        animator.SetTrigger("NextScreen");
        Invoke("MenuStartButton", buttonTimer);
    }

    public void MenuStartButton()
    {
        EventSystem.current.SetSelectedGameObject(MenuFirstButton);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OptionsMenu()
    {
        // Plays the animation for leaving the start menu
        // and plays the animations for going to the options screen
        animator.SetTrigger("BackScreen");
        animator.SetTrigger("OptionsMenu");
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
        animator.SetTrigger("LeaveOptions");
        animator.SetTrigger("NextScreen");
        EventSystem.current.SetSelectedGameObject(null);
        Invoke("LeaveOptionsButton", buttonTimer);
    }

    public void LeaveOptionsButton()
    {
        EventSystem.current.SetSelectedGameObject(OptionsButton);
    }

    public void LeaveMenuForQuit()
    {
        // Plays the animation for leaving the options menu
        // and plays the animations for going to the start menu
        animator.SetTrigger("LeaveOptions");
        animator.SetTrigger("NextScreen");
        EventSystem.current.SetSelectedGameObject(null);
        Invoke("QuitMenu", buttonTimer);
    }

    public void QuitMenu()
    {
        EventSystem.current.SetSelectedGameObject(MenuButton);
    }

    public void LeaveQuit()
    {
        // Plays the animation for leaving the options menu
        // and plays the animations for going to the start menu
        animator.SetTrigger("LeaveOptions");
        animator.SetTrigger("NextScreen");
        EventSystem.current.SetSelectedGameObject(null);
        Invoke("BackMenun", buttonTimer);
    }

    public void BackMenu()
    {
        EventSystem.current.SetSelectedGameObject(QuitButton);
    }

    public void QuitGame()
    {
        // Quits the game 
        Application.Quit();
    }

}