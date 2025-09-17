using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth = 5;
    public int currentHealth = 5;

    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        if (currentHealth <= damage)
        {
            currentHealth = 0;
        }
        else currentHealth -= damage;

        if (currentHealth <= 0)
        {
            if (gameObject.tag == "Enemy")
            {
                gameObject.SetActive(false);
                FindObjectOfType<Score>().AddScore(1);
                //Gameover();
            }
            if (gameObject.tag == "Player")
            {
                FindObjectOfType<Display>().GameOver();
                //gameObject.SetActive(false);
            }
        }
    }
}
