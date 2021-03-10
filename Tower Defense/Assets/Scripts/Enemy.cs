using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavepointInx = 0;

    public int value = 50;

    // public int health = 100;
    private bool isDead = false;
    public float startHealth = 100;
    private float health;
    public GameObject deathEffect;

    public Image healthBar;

    void Start()
    {
        target = Waypoints.points[0];
        health = startHealth;
    }

    public void TakeDamage(int amount)
    {

        health -= amount;
        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isDead)
        {
            Die();
        }

    }

    void Die()
    {
        isDead = true;
        Destroy(gameObject);
        PlayerStats.Money += value;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);

        Destroy(effect, 5f);
        Destroy(gameObject);
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= .4f)
        {
            GetNextWaypoint();
        }


    }

    void GetNextWaypoint()
    {

        if(wavepointInx >= Waypoints.points.Length - 1) {
            endPath();
            return;
        }
        wavepointInx++;
        target = Waypoints.points[wavepointInx];
    }

    void endPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
