using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float vel;
    float direction;
    Rigidbody2D rb;
    [SerializeField] float bounceForce = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(vel * direction, 0);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("ball"))
        {
            Vector2 contactPoint = col.contacts[0].point;
            Vector2 platformCenter = GetComponent<Collider2D>().bounds.center;


            // Calcula a direcao do impulso com base no ponto de colisao
            float hitFactor = (contactPoint.x - platformCenter.x) / (GetComponent<Collider2D>().bounds.size.x / 2);


            // Aplica o impulso na bola
            Rigidbody2D ballRb = col.gameObject.GetComponent<Rigidbody2D>();
            if (ballRb != null)
            {
                // Aplique o impulso com base no hitFactor e na forca de impulso
                Vector2 bounceDirection = new Vector2(hitFactor, 1).normalized; // Direcao para cima e para os lados
                ballRb.velocity = bounceDirection * bounceForce; // Aplica o impulso na bola
            }
        if (col.gameObject.CompareTag(" Debuffer"))
        {
            // algum debuff no player
        }

        }
    }
}
