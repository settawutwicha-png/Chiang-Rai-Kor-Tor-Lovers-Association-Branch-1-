using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    public EnemyStats enemyStats;
    public Text healthText; // ลาก Text ใน UI มาใส่ช่องนี้

    void Update()
    {
        if (enemyStats != null && healthText != null)
        {
            healthText.text = "HP: " + enemyStats.currentHealth + " / " + enemyStats.maxHealth;
        }
    }
}