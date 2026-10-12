using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;    // จุดที่ใช้เช็คระยะโจมตี
    public float attackRange = 0.8f; // รัศมีการโจมตี
    public LayerMask enemyLayers;    // เลเยอร์ของศัตรู (เพื่อให้โจมตีโดนเฉพาะศัตรู)
    public float attackDamage = 30f; // ดาเมจในการโจมตีแต่ละครั้ง

    void Update()
    {
        // เมื่อกดปุ่ม Spacebar จะสั่งโจมตี
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
        // สร้างวงกลมจำลองเพื่อเช็คว่ามีศัตรูอยู่ในรัศมีไหม
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // วนลูปจัดการศัตรูที่โดนโจมตี
        foreach (Collider2D enemy in hitEnemies)
        {
            EnemyStats enemyStats = enemy.GetComponent<EnemyStats>();
            if (enemyStats != null)
            {
                // คำนวณทิศทางกระเด้ง
                Vector2 hitDir = (enemy.transform.position - transform.position).normalized;
                // ส่งดาเมจและแรงกระเด้งให้ศัตรู
                enemyStats.TakeDamage(attackDamage, hitDir);
            }
        }
    }

    // ฟังก์ชันช่วยแสดงวงกลมขอบเขตการตีในหน้า Editor (Scene View)
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}