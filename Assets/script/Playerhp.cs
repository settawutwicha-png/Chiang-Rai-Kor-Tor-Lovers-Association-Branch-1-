using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 100f;
    public float currentHealth;

    [Header("UI Reference")]
    public Image hpBarFill; // ช่องสำหรับเชื่อมต่อกับภาพ Fill ใน UI

    void Start()
    {
        // กำหนดให้เลือดเริ่มต้นเต็ม
        currentHealth = maxHealth;
        UpdateHPUI();
    }

    void Update()
    {
        // โค้ดสำหรับทดสอบ: กดปุ่ม Spacebar บนคีย์บอร์ดเพื่อลองลดเลือดทีละ 10
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10f);
        }
    }

    // ฟังก์ชันสำหรับรับความเสียหาย (โดนศัตรูโจมตี)
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth); // ล็อคไม่ให้เลือดติดลบ

        UpdateHPUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // ฟังก์ชันอัปเดตความยาวหลอดเลือดบน UI
    void UpdateHPUI()
    {
        if (hpBarFill != null)
        {
            // สั่งปรับค่า Fill Amount (สัดส่วน 0.0 ถึง 1.0)
            hpBarFill.fillAmount = currentHealth / maxHealth;
        }
    }

    void Die()
    {
        Debug.Log("Player ตายแล้ว!");
    }
}