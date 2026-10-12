using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // ฟังก์ชันรับดาเมจ + ทิศทางกระเด็น (รองรับ PlayerAttack และ PlayerCombat)
    public void TakeDamage(float damageAmount, Vector2 hitDir)
    {
        currentHealth -= damageAmount;
        Debug.Log("Enemy Health: " + currentHealth);

        // แรงกระเด็นถอยหลังเมื่อโดนโจมตี
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(hitDir * 5f, ForceMode2D.Impulse);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Overload สำรองกรณีส่งมาแค่ดาเมจค่าเดียว
    public void TakeDamage(float damageAmount)
    {
        TakeDamage(damageAmount, Vector2.zero);
    }

    void Die()
    {
        Destroy(gameObject);
    }
}