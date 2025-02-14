using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    [SerializeField] private float _velocity;
    [SerializeField] private float direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(_velocity * Time.deltaTime, 0), transform);
        transform.rotation = quaternion.Euler(transform.rotation.y, transform.rotation.x, direction);

        
    }
}
