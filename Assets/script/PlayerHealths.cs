using UnityEngine;
using UnityEngine.UI; // เรียกใช้ระบบ UI

public class PlayerHealths : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 100f;
    public float currentHealth;

    [Header("UI Reference")]
    public Slider hpSlider; // เปลี่ยนมารับค่า Slider แทน Image

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHPUI();
    }

    void Update()
    {
        // [ทดสอบ] กด Spacebar ลดเลือด
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10f);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        UpdateHPUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHPUI()
    {
        if (hpSlider != null)
        {
            // คำนวณค่า Slider (0.0 ถึง 1.0)
            hpSlider.value = currentHealth / maxHealth;
        }
    }

    void Die()
    {
        Debug.Log("Player ตายแล้ว!");
    }
}