using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{


    [Header("Velocity and Force Values")]
    [SerializeField] float constantVel;
    [SerializeField] float bounceForce = 10f;

    [Header("Debuff Effect Values")]
    [SerializeField] float debuffEffectVel;
    [SerializeField] float debuffTimerConstant;
    float vel;
    float direction;
    Rigidbody2D rb;
    float debuffTimer;
    bool debuffActive;
    [HideInInspector] static public bool death;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        death = false;
        debuffActive = false;
        anim.SetBool("Stun", false);
        vel = constantVel;
    }

    void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(vel * direction, 0);
        
        if(death && vel > 0)
        {
            Debug.Log("morreu");
            vel = 0;
            
        }

        if(Input.GetKeyDown(KeyCode.R) && death)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        
        if(debuffActive && !death)
        {

            debuffTimer -= Time.deltaTime;
            vel = debuffEffectVel;
            if(debuffTimer <= 0)
            {
                debuffActive = false;
                vel = constantVel;
                anim.SetBool("Stun", false);
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
            anim.SetBool("Stun", true);
        }
    }

}
