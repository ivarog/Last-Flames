using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : MonoBehaviour
{
    [SerializeField] ParticleSystem treeParticles;
    [SerializeField] float damage;

    private Animator animator;
    bool isCutting;

    private void Start() 
    {
        animator = GetComponent<Animator>();    
    }

    void Update()
    {
        InputController();
    }

    void InputController()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isCutting = true;
            animator.SetInteger("AxeState", 1);
        }    
        else if(Input.GetMouseButtonUp(0))
        {
            isCutting = false;
            animator.SetInteger("AxeState", 0);
        }
    }

    private void OnCollisionEnter(Collision other) 
    {

        if(other.gameObject.tag == "Tree" && isCutting)  
        {
            ParticleSystem actualParticle = Instantiate(treeParticles, other.contacts[0].point, Quaternion.identity, transform);
            Destroy(actualParticle, 3f);
            other.gameObject.GetComponent<Tree>().HitTree(damage);
        }  
    }
}
