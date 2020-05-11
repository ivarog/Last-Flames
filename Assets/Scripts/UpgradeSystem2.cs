using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeSystem2 : MonoBehaviour
{
    [SerializeField] Animator canvasAnimator;

    private void Start() {
        Cursor.visible = true;
    }

    public void GunUpdgrade()
    {
        PlayerState.gunDamage = 100f;
        DesactivateButtons();
        StartCoroutine(LoadNextScene());
    }

    public void AxeUpdgrade()
    {
        PlayerState.axeDamage = 75f;
        DesactivateButtons();
        StartCoroutine(LoadNextScene());
    }

    public void TurretUpdgrade()
    {
        PlayerState.turrets = PlayerState.turrets + 1;
        DesactivateButtons();
        StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene()
    {
        canvasAnimator.Play("UpgradeOut");
        yield return new WaitForSeconds(1f);
        PlayerState.actualLevel = 3;
        PlayerState.SavePlayer();
        SceneManager.LoadScene("Level3");
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
