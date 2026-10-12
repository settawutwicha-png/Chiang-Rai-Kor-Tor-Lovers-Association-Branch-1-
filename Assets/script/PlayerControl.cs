using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        // รับค่าปุ่มกด WASD หรือ ลูกศร (ค่า -1 ถึง 1)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // คำนวณทิศทาง
        Vector3 moveDirection = new Vector3(moveX, moveY, 0f).normalized;

        // ขยับพิกัดตัวละครโดยตรง
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}