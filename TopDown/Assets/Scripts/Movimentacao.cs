using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentacao : MonoBehaviour
{
    private Rigidbody2D rigi;
    private float speedMoveX;
    private float speedMoveY;
    [SerializeField] private float moviment;


    private void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    void Move()
    {
        // pegando a dire��o do movimento
        speedMoveX = Input.GetAxisRaw("Horizontal");
        speedMoveY = Input.GetAxisRaw("Vertical");

        // recuperando a dire��o e fazendo o calculo para as diagonais
        Vector2 direction = new Vector2 (speedMoveX, speedMoveY).normalized;

        rigi.velocity =  direction * moviment;

    }
}
