using UnityEngine;

public class PlayerHP : MonoBehaviour
{

    public int maxHP = 100;
    public int currentHP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        if(currentHP < 0)
        {

            currentHP = 0;

        }

        Debug.Log("Player HP :" + currentHP);

        if(currentHP == 0)
        {

            Debug.Log("Player Died");

        }
    }
}
