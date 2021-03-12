using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;
    private AudioSource impact;

    
    public float speed = 70f;
    public float explosionRad = 0f;
    public int damage = 50;
    public GameObject impactEffect;

    void Start()
    {

        impact = GetComponent<AudioSource>();
     
    }

    public void Seek(Transform _target)
    {

        target = _target;
    }

    

    // Update is called once per frame
    void Update()
    {
        
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

        transform.LookAt(target);
    }
    void HitTarget()
    {
        
        Damage(target);
        GameObject effectInst = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInst, 5f);
        //Destroy(target.gameObject);
        Destroy(gameObject);
        if(explosionRad > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
    }

    void Damage(Transform enemy)
    {
        
        Enemy e = enemy.GetComponent<Enemy>();

        
        e.TakeDamage(damage);

    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRad);
    }

    void Explode()
    {
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRad);
        foreach(Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                
                Damage(collider.transform);
            }
        }
    }
}
