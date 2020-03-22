using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float velocity;
    [SerializeField] GameObject gameCamera;
    // private Rigidbody rb;
    CharacterController character;

    private void Start() 
    {
        character = GetComponent<CharacterController>();
    }

    private void FixedUpdate() 
    {
        Move();    
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movement = transform.right * x + transform.forward * z;
        Vector3 eulerCameraRotation = Camera.main.transform.localRotation.eulerAngles;
        transform.rotation = Quaternion.Euler(new Vector3(0f, eulerCameraRotation.y, 0f));
        character.Move(movement * Time.deltaTime * velocity);
        gameCamera.transform.position = transform.position + new Vector3(0.0f, 0.4f, 0.0f);
    }
}