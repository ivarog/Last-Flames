using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeSystem1 : MonoBehaviour
{
    [SerializeField] Animator canvasAnimator;

    private void Start() {
        Cursor.visible = true;
    }

    public void GunUpdgrade()
    {
        PlayerState.gunDamage = 50f;
        DesactivateButtons();
        StartCoroutine(LoadNextScene());
    }

    public void AxeUpdgrade()
    {
        PlayerState.axeDamage = 50f;
        DesactivateButtons();
        StartCoroutine(LoadNextScene());
    }

    public void TurretUpdgrade()
    {
        PlayerState.turrets = 1;
        DesactivateButtons();
        StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene()
    {
        canvasAnimator.Play("UpgradeOut");
        yield return new WaitForSeconds(1f);
        PlayerState.actualLevel = 2;
        PlayerState.SavePlayer();
        SceneManager.LoadScene("Level2");
    }

    void DesactivateButtons()
    {
        Button[] allButtons = FindObjectsOfType<Button>();

        foreach(Button b in allButtons)
        {
            b.interactable = false;
        }
    }
}
