using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] GameObject bonfire;
    [SerializeField] Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        bonfire = GameObject.Find("Bonfire");
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(bonfire.transform.position);
        if(Mathf.Abs(Vector3.Distance(transform.position, bonfire.transform.position)) <= 0.5f)
        {
            agent.isStopped = true;
            animator.SetBool("BonfireReached", true);
            Destroy(gameObject, 8f);
        }
    }
}
