using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] Button continueButton;
    [SerializeField] GameObject panelNewGame;
    [SerializeField] GameObject panelLoading;

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
        panelLoading.SetActive(true);
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
            panelLoading.SetActive(true);
        }
    }

    public void NewGameConfirm()
    {
        PlayerState.ResetPlayer();
        SceneManager.LoadScene("Story");
        panelLoading.SetActive(true);

    }

    public void ContinueGame()
    {        
        SceneManager.LoadScene("Level" + PlayerState.actualLevel);
        panelLoading.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
