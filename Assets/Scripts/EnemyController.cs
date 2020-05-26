using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;

    private Transform target;

    private NavMeshAgent agent;

    public float speed = 0.4f;

    public Animation deathFlash;
    
    public GameObject sparksTwo;

    public Animation enemyDeath;
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
        Debug.Log(EnemySpawner.enemyCount);
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
        if (other.transform.CompareTag("Sword") && SwordSwing.isSwinging == true)
        {
            EnemySpawner.enemyCount -= 1;
            sparksTwo.SetActive(true);
            StartCoroutine(EnemyDeath());
        }
        
        if (other.transform.CompareTag("Player"))
        {
            StartCoroutine(KillPlayer());
        }
        else
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
        //PLAY SOUND
        yield return new WaitForSeconds(2); //instead of health
        SceneManager.LoadScene("DeathScreen");
    }

    IEnumerator EnemyDeath()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);
    }
}
