using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float damageAmount = 30f; // ดาเมจที่ผู้เล่นทำได้

    // ฟังก์ชันนี้จะทำงานเมื่อตัวละครเดินไปชนกับวัตถุอื่น (ที่มี Collider แบบปกติ ไม่ใช่ Trigger)
    void OnCollisionEnter2D(Collision2D collision)
    {
        // เช็คว่าวัตถุที่ชน มี Tag ว่า "Enemy" หรือไม่
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // ดึงข้อมูลสคริปต์ EnemyStats จากตัวศัตรู
            EnemyStats enemy = collision.gameObject.GetComponent<EnemyStats>();

            if (enemy != null)
            {
                // คำนวณทิศทางกระเด้ง (จากตัวผู้เล่นพุ่งไปหาศัตรู)
                Vector2 hitDir = (collision.transform.position - transform.position).normalized;

                // สั่งให้ศัตรูรับดาเมจและกระเด้งถอยหลัง
                enemy.TakeDamage(damageAmount, hitDir);
            }
        }
    }
}