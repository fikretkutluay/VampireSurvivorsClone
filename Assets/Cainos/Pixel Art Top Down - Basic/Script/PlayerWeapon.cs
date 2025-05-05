using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float timer;
    public PlayerStats playerStats;
    

    private void Start()
    {
        if (playerStats == null)
        {
            playerStats = GetComponent<PlayerStats>();
        }
    }

    private void Update()
    {
        if (playerStats == null) return;
        timer += Time.deltaTime;
        if (timer >= playerStats.fireRate)
        {
            Fire();
            timer = 0f;
        }
    }

    private void Fire()
    {
        Vector2 direction = GetClosestEnemyDirection(); 
        if (direction != Vector2.zero)
        {
            GameObject bullet = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Projectile proj = bullet.GetComponent<Projectile>();
            proj.SetDirection(direction);
            proj.SetDamage((float)playerStats.damage);

        }
    }

    Vector2 GetClosestEnemyDirection()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        Vector2 closestDirection = Vector2.zero;

        foreach (GameObject enemy in enemies)
        {
            float dist = Vector2.Distance(transform.position, enemy.transform.position);
            if (dist < closestDistance)
            {
                closestDistance = dist;
                closestDirection = (enemy.transform.position - transform.position).normalized;
            }
        }

        return closestDirection;
    }

}
