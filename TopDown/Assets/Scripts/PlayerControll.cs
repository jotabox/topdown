using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    private Rigidbody2D rigi;
    private float speedMoveX;
    private float speedMoveY;
    [SerializeField] private float moviment;


    private void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    void Move()
    {
        // pegando a direção do movimento
        speedMoveX = Input.GetAxisRaw("Horizontal");
        speedMoveY = Input.GetAxisRaw("Vertical");

        // recuperando a direção e fazendo o calculo para as diagonais
        Vector2 direction = new Vector2(speedMoveX, speedMoveY).normalized;

        rigi.velocity = direction * moviment;
    }
}
