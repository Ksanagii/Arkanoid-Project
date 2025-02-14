using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float vel;
    float direction;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");
        if(direction > 0)
        {
            rb.velocity = new Vector2(vel * 1, 0);
        }
        else if (direction < 0)
        {
            rb.velocity = new Vector2(vel * -1, 0);
        }
        else{rb.velocity = new Vector2(0, 0);}
    }
}
