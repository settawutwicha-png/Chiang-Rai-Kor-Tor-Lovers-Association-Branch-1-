using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float reflectDamage = 30f; // ดาเมจที่มอนจะโดนเมื่อมาชนตัวเรา
    public float knockbackForce = 5f; // แรงผลักให้มอนกระเด็นถอยหลังเมื่อชน

    // ฟังก์ชันนี้จะทำงานอัตโนมัติเมื่อมี Collider ของมอนเข้ามาชนตัว Player
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 1. ตรวจสอบว่าสิ่งที่มาชนเรามี Tag ว่า "Enemy" หรือไม่
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // 2. ถ้าใช่ ให้ดึงสคริปต์ EnemyStats ของมอนตัวนั้นออกมา
            EnemyStats enemyStats = collision.gameObject.GetComponent<EnemyStats>();

            if (enemyStats != null)
            {
                // 3. คำนวณทิศทางกระเด้งถอยหลัง (จากตัว Player ไปหาตัว Enemy)
                Vector2 knockbackDir = (collision.transform.position - transform.position).normalized;

                // 4. ส่งดาเมจและแรงกระเด็นไปให้มอน
                enemyStats.TakeDamage(reflectDamage, knockbackDir);

                Debug.Log("มอนสเตอร์มาชนโดนตัว! โดนดาเมจสะท้อนไป: " + reflectDamage);
            }
        }
    }
}