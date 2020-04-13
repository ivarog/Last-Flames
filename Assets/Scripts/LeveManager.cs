using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeveManager : MonoBehaviour
{
    [SerializeField] float gameTime;
    [SerializeField] Animator animator;
    [SerializeField] GameObject countdown;

    private AudioManager audioManager;
    private Text textCountdown;
    bool canPlayClock = false;

    private void Start() 
    {
        AudioManager.instance.Play("Ambient");
        textCountdown = countdown.GetComponent<Text>();
        animator.Play("Clock");
    }

    private void Update() 
    {
        Counter();    
    }

    private void Counter()
    {
        if(gameTime > 0) 
        {
            gameTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(gameTime / 60F);
            int seconds = Mathf.FloorToInt(gameTime - minutes * 60);
            textCountdown.text = minutes + ":" + seconds;
        }

        if(gameTime <= 0)
        {
            animator.Play("Win");
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject enemy in enemies)
            {
                enemy.GetComponent<EnemyController>().iAmDead = true;
            }
            StartCoroutine(ReturnToMenu());
        }
    }

    public void GameOver()
    {
        animator.Play("Fail");
        StartCoroutine(ReturnToMenu());
    }

    IEnumerator ReturnToMenu()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Menu");
        AudioManager.instance.Stop("Ambient");
    }

    
}
