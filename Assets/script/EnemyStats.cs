using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public float knockbackMultiplier = 5f;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageAmount, Vector2 hitDir)
    {
        currentHealth -= damageAmount;
        Debug.Log("เลือดศัตรูเหลือ: " + currentHealth);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.AddForce(hitDir * knockbackMultiplier, ForceMode2D.Impulse);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}