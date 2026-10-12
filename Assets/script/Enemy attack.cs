using UnityEngine;

public class Enemyattack : MonoBehaviour
{
    public int damage = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHP player = 
            other.GetComponent<PlayerHP>();

        if(player != null)
        {

            player.TakeDamage(damage);

        }
    }

    // Update is called once per frame
    
}
