using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // Vida m�xima do inimigo

    private int currentHealth; // Vida atual do inimigo

    private void Start()
    {
        currentHealth = maxHealth; // Configura a vida atual igual � vida m�xima no in�cio
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Reduz a vida atual pelo valor do dano

        if (currentHealth <= 0)
        {
            Die(); // Se a vida atual for menor ou igual a zero, o inimigo morre
        }
    }

    private void Die()
    {
        // L�gica de morte do inimigo, como pontua��o, anima��o, etc.
        Destroy(gameObject); // Destroi o objeto do inimigo
    }

}
