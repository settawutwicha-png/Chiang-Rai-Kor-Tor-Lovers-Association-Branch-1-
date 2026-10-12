using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target; // ลากตัว Enemy มาใส่ช่องนี้
    public Vector3 offset;   // ระยะห่าง (เช่น ให้ลอยอยู่เหนือหัวนิดนึง)

    void Update()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
}