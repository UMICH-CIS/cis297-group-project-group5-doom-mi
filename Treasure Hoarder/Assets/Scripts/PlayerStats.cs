using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth = 100;
    public float Tabloons = 0;
    
    public float currentHealth; 
    public HealthBar healthBar;
    public bool immuned;
    public float immunityCooldown;
    public float startimmunityCooldown;
    public EnemyStats enemyStats;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        immunityCooldown = startimmunityCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (immuned && immunityCooldown >= 0)
        {
            ImmunityCooldown();
        }
        else
        {
            immuned = false;
            immunityCooldown = startimmunityCooldown;
        }

        if (currentHealth <= 0)
        {
            Death();
        }

    }
    void ImmunityCooldown()
    {
        immunityCooldown -= Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Enemy" && !immuned)
        {
            TakeDamage(5);
            immuned = true;
            FindObjectOfType<AudioManager>().Play("Player Hit");
        }

        if (collision.gameObject.name == "Thief" && !immuned)
        {
            TakeDamage(10);
            immuned = true;
            FindObjectOfType<AudioManager>().Play("Player Hit");
        }

        if (collision.gameObject.name == "Barrel" && !immuned)
        {
            TakeDamage(15);
            immuned = true;
            FindObjectOfType<AudioManager>().Play("Player Hit");
        }

        if (collision.gameObject.name == "Bringer" && !immuned)
        {
            TakeDamage(100);
            immuned = true;
            FindObjectOfType<AudioManager>().Play("Player Hit");
        }
    }
    
    void TakeDamage(float damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    void Death()
    {
        SceneManager.LoadScene(2);
    }
}



