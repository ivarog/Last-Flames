using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerPC : MonoBehaviour
{

    [SerializeField] float velocity;
    [SerializeField] GameObject gameCamera;
    // private Rigidbody rb;
    CharacterController character;
    [SerializeField] float sensitivity = 100;
    [SerializeField] Transform playerBody;
    float xRotation = 0;

    private void Start() 
    {
        character = GetComponent<CharacterController>();
    }

    private void FixedUpdate() 
    {
        Move();    
        Rotate();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movement = transform.right * x + transform.forward * z;
        character.Move(movement * Time.deltaTime * velocity);
    }

    void Rotate()
    {
        float rotateX = Input.GetAxis("Camera Horizontal") * sensitivity * Time.deltaTime;
        float rotateY = Input.GetAxis("Camera Vertical") * sensitivity * Time.deltaTime;

        xRotation -= rotateY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        gameCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * rotateX);
    }
}