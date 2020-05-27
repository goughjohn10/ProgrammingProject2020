using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    #region Fields
    
    public float lookRadius = 10f;
    public float health = 10;
    private Transform target;
    private NavMeshAgent agent;
    public float speed = 0.4f;
    public AudioSource zombie;
    public AudioClip attackSound;
    #endregion

    #region Methods
    
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            FaceTarget();
        }
        else
        {
            agent.SetDestination(transform.position); //to stop following
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position);
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation =  Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            zombie.PlayOneShot(attackSound);
            StartCoroutine(KillPlayer());
        }
        else
        {
            StopCoroutine(KillPlayer());
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            StopCoroutine(KillPlayer());
        }
    }

    private void OnDestroy()
    {
        StopCoroutine(KillPlayer());
    }

    IEnumerator KillPlayer()
    {
        yield return new WaitForSeconds(0.5f);
        ScoringSystem.hasCollected = false; 
        SceneManager.LoadScene("DeathScreen");
    }

    public IEnumerator EnemyDeath(float amount)
    {
        health -= amount;
        if (health <= 0)
        { 
            yield return new WaitForSeconds(0.5f);
            Destroy(this.gameObject);
            EnemySpawner.enemyCount -= 1;
        }
    }

    public void TakeDamage() //public version of enemy death, couldn't access coroutine elsewhere
    {
        StartCoroutine(EnemyDeath(10));
    }
    
    #endregion
}
