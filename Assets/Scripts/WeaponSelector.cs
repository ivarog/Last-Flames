using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour
{

    [SerializeField] GameObject axe;
    [SerializeField] GameObject gun;
    [SerializeField] GameObject logItem;

    bool axeIsActive;
    bool gunIsActive;
    public bool carryingTrunk;
    private AudioSource audioSource;
    Transform axeTransform;
    public bool weaponSwitched = false;

    private void Start() 
    {
        axeIsActive = true;
        gunIsActive = false;    
        axe.SetActive(true);
        gun.SetActive(false);
        logItem.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        axeTransform = axe.transform;
    }

    private void Update() 
    {
        if((Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.JoystickButton3)) && !carryingTrunk)
        {
            ChangeWeapon();
            audioSource.Play();
        }    
    }

    private void ChangeWeapon()
    {
        axeIsActive = !axeIsActive;
        gunIsActive = !gunIsActive;
        weaponSwitched = true;
        UpdateWeaponsState();
    }

    public void UpdateWeaponsState()
    {
        if(axeIsActive)
        {
            axe.SetActive(true);
            axe.transform.position = axeTransform.position;
            axe.transform.rotation = axeTransform.rotation;
            gun.SetActive(false);
        }
        else if(gunIsActive)
        {
            gun.SetActive(true);
            axe.SetActive(false);
        }
    }

    public void DesactivateWeapons()
    {
        gun.SetActive(false);
        axe.SetActive(false);
    }

    public void ActivateLogItem()
    {
        DesactivateWeapons();
        logItem.SetActive(true);
        carryingTrunk = true;
    }

    public void DesactivateLogItem()
    {
        UpdateWeaponsState();
        logItem.SetActive(false);
        carryingTrunk = false;
    }
}
