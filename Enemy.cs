using UnityEngine.UI;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    public float startHealth = 100;
    public float health;

    public int worth = 50;

    public GameObject deathEffect;

    [Header("Slika i Zvuk")]
    public Image healthBar;

    private bool isDead = false;

    public AudioClip deathClip;

    void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isDead)
        {
            Die();
        }
    
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }

    void Die()
    {
        AudioSource.PlayClipAtPoint(deathClip, transform.position);
        isDead = true;

        PlayerStats.Money += worth;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }

}
