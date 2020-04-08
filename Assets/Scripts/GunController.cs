using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    [SerializeField] GameObject bullet;
    [SerializeField] AudioClip shoot;
    [SerializeField] float fireRate = 1;
    [SerializeField] float speed = 30;

    Animator revolver;
    
    private float nextFire = 0.0F;

    private void Start() 
    {
        revolver = GetComponent<Animator>();    
    }

    void Update() 
    {
        Shoot();
    }

    private void Shoot()
    {
        if ((Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Mouse0)) && Time.time > nextFire) 
        {
            nextFire = Time.time + fireRate;
            GameObject projectile = Instantiate(bullet, Camera.main.transform.position + (Camera.main.transform.forward * 0.35f), Quaternion.identity);
            projectile.transform.rotation = Quaternion.FromToRotation(projectile.transform.up, Camera.main.transform.forward);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity= Camera.main.transform.forward * speed;

            revolver.SetTrigger("Shoot");

            // if(shoot != null) AudioSource.PlayClipAtPoint(shoot, projectile.transform.position, 1.0F);
            Destroy(projectile, 5f);
        }
    }
}
    