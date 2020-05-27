
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10;

    public float range = 100;

    public Camera fpsCam;

    public ParticleSystem muzzleFlash;

    public GameObject impactEffect;

    public AudioSource gunShot;
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        gunShot.Play();
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);

            EnemyController target = hit.transform.GetComponent<EnemyController>();
            if (target != null)
            {
                target.TakeDamage();
                Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                hit.transform.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
            }
        }
        
    }
}
