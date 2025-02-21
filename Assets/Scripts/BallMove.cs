using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    [SerializeField] float _velocity;
    [SerializeField] float direction;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //transform.Translate(new Vector3(_velocity * Time.deltaTime, 0), transform);
        //transform.rotation = quaternion.Euler(transform.rotation.y, transform.rotation.x, direction);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("bloco1"))
        {
            Destroy(col.gameObject);
        }
        else if (col.gameObject.CompareTag("Morte"))
        {
            Destroy(gameObject);
            Debug.Log("perdeu");
        }
 
    }

}
