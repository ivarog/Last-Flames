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
    [SerializeField] float damageFlame;
    [SerializeField] AudioClip warningSound;
    [SerializeField] AudioClip deadSound;

    private Bonfire bonfireScript;
    bool canReduceFlameOnce = true;
    public bool iAmDead = false;
    private bool warningPlayed = false;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        bonfire = GameObject.Find("Bonfire");
        bonfireScript = bonfire.GetComponent<Bonfire>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(bonfire.transform.position);

        if(Mathf.Abs(Vector3.Distance(transform.position, bonfire.transform.position)) <= 12f && !warningPlayed)
        {
            warningPlayed = true;
            audioSource.PlayOneShot(warningSound);
        }

        ReachBonfire();
    }

    private void ReachBonfire()
    {
        if(Mathf.Abs(Vector3.Distance(transform.position, bonfire.transform.position)) <= 0.8f)
        {
            agent.isStopped = true;
            animator.SetBool("EnemyDead", true);
            iAmDead = true;
            Destroy(gameObject, 8f);
            if(canReduceFlameOnce) 
            {
                canReduceFlameOnce = false;
                bonfireScript.ReduceFlame(damageFlame);
            }
        }
    }

    public void DamageEnemy(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            agent.isStopped = true;
            animator.SetBool("EnemyDead", true);
            iAmDead = true;
            audioSource.PlayOneShot(deadSound);
            Destroy(gameObject, 8f);
        }
    }
}
