using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    // Rigidbody2D rb;
    [HideInInspector] static public int points;
    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        // rb = GetComponent<Rigidbody2D>();
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
            points++;
        }
        else if (col.gameObject.CompareTag("Morte"))
        {
            PlayerMove.death = true;
            Destroy(gameObject);
            Debug.Log("perdeu");
        }
 
    }

}
