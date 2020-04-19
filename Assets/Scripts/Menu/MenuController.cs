using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] Button continueButton;
    [SerializeField] GameObject panelNewGame;

    AudioSource audioSource;

    private void Start() 
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();    
        Cursor.visible = true;
        PlayerState.LoadPlayer();
        
        if(!PlayerState.introPlayed)
        {
            continueButton.interactable = false;
        }
        Debug.Log(PlayerState.introPlayed + "Intro");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void NewGame()
    {
        if(PlayerState.introPlayed)
        {
            panelNewGame.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("Story");
        }
    }

    public void NewGameConfirm()
    {
        PlayerState.ResetPlayer();
        SceneManager.LoadScene("Story");

    }

    public void ContinueGame()
    {        
        SceneManager.LoadScene("Level" + PlayerState.actualLevel);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
