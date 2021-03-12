using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turret : MonoBehaviour
{
    public AudioSource playSound;
    private AudioSource ShootSound;
    
    private Transform target;
    
    private float timer2 = 25f;

    private float health1;
    public float healthStart = 100;

    public Image healthBar;

    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Setup")]

    public string enemyTag = "Enemy";
    public float turretSpeed = 10f;

    public Transform partToRotate;
    //public Text timerText;

    public GameObject bulletPrefab;
    public Transform firePoint;

    private float countDown = 2f;
    // Start is called before the first frame update
    void Start()
    {
        //playSound = GetComponent<AudioSource>();
        //destroySound = GetComponent<AudioSource>();
        ShootSound = GetComponent<AudioSource>();
        health1 = healthStart;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;

        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
    
    void Update()
    {
        
        if (timer2 <= 0)
        {

            
            //destroySound.Play();
            Destroy(gameObject);
            


        }
        //Debug.Log(timer);
        // removes countDown once every second
        timer2 -= Time.deltaTime;

        timer2 = Mathf.Clamp(timer2, 0f, Mathf.Infinity);

        

        
        Debug.Log("health " + (4 * timer2) / healthStart);
        healthBar.fillAmount = (4*timer2) / healthStart;

        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);

        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turretSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(fireCountdown <= 0)
        {

            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    void Shoot()
    {
        ShootSound.Play();

        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }


}
