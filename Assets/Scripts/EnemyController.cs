using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] GameObject bonfire;
    [SerializeField] Animator animator;
    [SerializeField] float health;

    // Start is called before the first frame update
    void Start()
    {
        bonfire = GameObject.Find("Bonfire");
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(bonfire.transform.position);
        ReachBonfire();
    }

    private void ReachBonfire()
    {
        if(Mathf.Abs(Vector3.Distance(transform.position, bonfire.transform.position)) <= 0.8f)
        {
            agent.isStopped = true;
            animator.SetBool("EnemyDead", true);
            Destroy(gameObject, 8f);
        }
    }

    public void DamageEnemy(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            agent.isStopped = true;
            animator.SetBool("EnemyDead", true);
            Destroy(gameObject, 8f);
        }
    }
}
