using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    AudioSource audioSource;

    private void Start() 
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();    
        Cursor.lockState = CursorLockMode.None;
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Story");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
