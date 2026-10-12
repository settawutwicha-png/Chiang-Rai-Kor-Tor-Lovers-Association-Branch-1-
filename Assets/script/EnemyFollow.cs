using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed = 3f;
    public float stopDistance = 0.5f;

    private Transform player;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogWarning("หาวัตถุที่มี Tag 'Player' ไม่พบ!");
        }
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.position);

            if (distance > stopDistance)
            {
                // 1. เดินเข้าหาผู้เล่น (โค้ดเดิม)
                transform.position = Vector2.MoveTowards(
                    transform.position,
                    player.position,
                    speed * Time.deltaTime
                );

                // 2. หันหน้าเข้าหาผู้เล่น (เอาโค้ดใหม่มาใส่ตรงนี้)
                Vector3 direction = player.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
    }
}