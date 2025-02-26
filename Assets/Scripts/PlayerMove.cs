using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool death;
    [SerializeField] float vel;
    float direction;
    Rigidbody2D rb;
    [SerializeField] float bounceForce = 10f;
    [SerializeField] float debuffTimerConstant;
    float debuffTimer;
    [SerializeField] bool debuffActive;
    [SerializeField] float debuffEffectVel;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        death = false;
        debuffActive = false;
    }

    void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(vel * direction, 0);
        if(death && vel > 0)
        {
            vel = 0;
        }

        if(debuffActive)
        {
            Debug.Log("debuffer ativado");
            
            debuffTimer -= Time.deltaTime;
            vel = debuffEffectVel;
            if(debuffTimer <= 0)
            {
                debuffActive = false;
                vel = 9;
                Debug.Log("debuffer desativado");
            }
        }
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
                ballRb.linearVelocity = bounceDirection * bounceForce; // Aplica o impulso na bola
            }

        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("debuffer"))
        {
            debuffActive = true;
            Destroy(col.gameObject);
            Debug.Log("debuff no player");
            debuffTimer = debuffTimerConstant;
        }
    }

}
