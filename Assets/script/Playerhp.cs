using UnityEngine;
using UnityEngine.UI; // 1. เพิ่มบรรทัดนี้เพื่อให้เรียกใช้ UI Slider ได้

public class PlayerHP : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    [Header("UI Reference")]
    public Slider hpSlider; // 2. สร้างช่องสำหรับลาก Slider หลอดเลือดมาใส่

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHPUI(); // อัปเดตหน้าจอตั้งแต่เริ่มเกม
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // ป้องกันไม่ให้เลือดติดลบ

        Debug.Log("Player took damage! Current HP: " + currentHealth);

        UpdateHPUI(); // อัปเดตหลอดเลือดทุกครั้งที่เลือดลด

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHPUI()
    {
        if (hpSlider != null)
        {
            // คำนวณสัดส่วนค่าเลือดเป็น 0.0 ถึง 1.0 สำหรับ Slider
            hpSlider.value = (float)currentHealth / maxHealth;
        }
    }

    void Die()
    {
        Debug.Log("Player Died!");
        // โค้ดสำหรับตอนผู้เล่นตาย (เช่น รีสตาร์ทฉาก)
    }
}