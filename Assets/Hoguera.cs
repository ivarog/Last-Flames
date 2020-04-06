using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
    [Range(0f, 3f)][SerializeField] float intensity;
    [SerializeField] GameObject lightBonfire;
    [SerializeField] float timeBonfireLife;
    [SerializeField] ParticleSystem fire;
    [SerializeField] ParticleSystem smoke;

    private float speed; 
    private Light lightBonfireComponent;
    private bool canReduceLigth;
    private const float maxIntensity = 3;
    private float startSizeFire;
    private float startSizeSmoke;

    private void Start() 
    {
        lightBonfireComponent = lightBonfire.GetComponent<Light>();  
        startSizeFire = fire.main.startSize.constant;
        startSizeSmoke = smoke.main.startSize.constant;
        speed = intensity / timeBonfireLife;
    }

    private void Update() 
    {
        ReduceIntensityBonfire(speed);
    }

    private void ReduceIntensityBonfire(float speed)
    {
        intensity -= speed * Time.deltaTime;
        ChangeBonfireIntensity(intensity);
    }

    private void ChangeBonfireIntensity(float intensity)
    {
        lightBonfire.transform.position = Vector3.up * intensity;
        lightBonfireComponent.intensity = intensity;
        ParticleSystem.MainModule main = fire.main;
        main.startSize = new ParticleSystem.MinMaxCurve(startSizeFire * intensity / maxIntensity); 
        main = smoke.main;
        main.startSize = new ParticleSystem.MinMaxCurve(startSizeSmoke * intensity / maxIntensity); 

    }

}
