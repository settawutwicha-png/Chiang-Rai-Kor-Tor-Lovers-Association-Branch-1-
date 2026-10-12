using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour
{
    [Header("Stats")]
    public float maxHealth = 100f;
    private float currentHealth;
    public int expReward = 50; // ค่า EXP ที่ผู้เล่นจะได้รับเมื่อศัตรูตาย

    [Header("Knockback Settings")]
    public float knockbackForce = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    // ฟังก์ชันนี้ถูกเรียกเมื่อศัตรูถูกโจมตี (รับค่า ดาเมจ และ ทิศทางที่จะให้กระเด้ง)
    public void TakeDamage(float damage, Vector2 hitDirection)
    {
        currentHealth -= damage;
        Debug.Log("Enemy โดนดาเมจ! เลือดเหลือ: " + currentHealth);

        // 1. ทำให้ศัตรูกระเด้ง
        if (rb != null)
        {
            // ล้างความเร็วเก่าก่อนแล้วออกแรงผลักไปตามทิศทางที่โดนตี
            rb.linearVelocity = Vector2.zero;
            rb.AddForce(hitDirection * knockbackForce, ForceMode2D.Impulse);
        }

        // 2. เช็คว่าตายหรือยัง
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // แจ้งผู้เล่นว่าตัวนี้ตายแล้ว (เพื่อให้ได้ EXP / Level)
        // ค้นหา Player และเพิ่ม EXP
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            PlayerLevel playerLevel = player.GetComponent<PlayerLevel>();
            if (playerLevel != null)
            {
                playerLevel.AddExp(expReward);
            }
        }

        // ทำลายวัตถุศัตรูทิ้ง
        Destroy(gameObject);
    }
}