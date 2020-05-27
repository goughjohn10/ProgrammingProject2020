
using System.Collections;
using UnityEngine;

public class gunTarget : MonoBehaviour
{
    public float health = 50;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            
        }
    }
}
