using UnityEngine;

public class Enemyattack : MonoBehaviour
{
    public int damage = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // เปลี่ยนจาก PlayerHP เป็น PlayerHealths ให้ตรงกับสคริปต์ของ Player
        PlayerHealths player = other.GetComponent<PlayerHealths>();

        if (player != null)
        {
            player.TakeDamage(damage);
        }
    }
}
