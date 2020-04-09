using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenTrunk : MonoBehaviour
{
    [SerializeField] GameObject trunk;

    private GameObject player;
    private WeaponSelector weaponSelector;

    private void Start() 
    {
        player = GameObject.Find("Player"); 
        weaponSelector = FindObjectOfType<WeaponSelector>();
    }

    void Update()
    {
        LogPicker();
    }

    void LogPicker()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < 2f)
        {
            if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton0))&& !weaponSelector.carryingTrunk)
            {
                weaponSelector.ActivateLogItem();
                trunk.SetActive(false);
            } 
            
        }
    }

}
