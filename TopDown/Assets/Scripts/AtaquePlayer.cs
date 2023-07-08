using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaquePlayer : MonoBehaviour
{

    [SerializeField] private Transform attackPoint;
    [SerializeField] private float  attackRange = 1f;
    [SerializeField] private int attackDamage = 10; // vai ser auterado mais tarde , quando tiver vontade de colocar os atributos
    private LayerMask enemyLayer;
    private bool canAttack = true;
    private float cooldownAttack = 1f;


    /*========= attackranged =========*/

    [SerializeField] private GameObject bulletPrefab;
    public float velocidadeProjetil = 5f;





    public void attackMelee()
    {
        if (canAttack)
        {
            StartCoroutine(ActiveCooldown());

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

            for (int i = 0; i < hitEnemies.Length; i++)
            {
                hitEnemies[i].GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            }
        }
    }

    public void attackRanged()
    {
        if (canAttack)
        {
            StartCoroutine(ActiveCooldown());

            GameObject projetil = Instantiate(bulletPrefab, attackPoint.position, Quaternion.identity);
            Rigidbody2D rb = projetil.GetComponent<Rigidbody2D>();

            // Defina a direção do projétil com base na entrada do jogador ou posição do inimigo
            Vector2 direcao = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            rb.velocity = direcao.normalized * velocidadeProjetil;

            // Destrua o projétil após um determinado tempo
            Destroy(projetil, 2f);

            // Aguarde um tempo antes de permitir outro ataque
            StartCoroutine(ActiveCooldown());

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            attackMelee();
        }

        //if (Input.GetButton("Fire2"))
        //{
        //    attackRanged();
        //}
    }

    // Função auxiliar para ativar um cooldown após um ataque
    private System.Collections.IEnumerator ActiveCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(cooldownAttack);
        canAttack = true;
    }

    // Visualização do alcance do ataque no Editor da Unity
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
