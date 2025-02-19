using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class SpawnerDebuff : MonoBehaviour
{
    // UnityEngine.Random random = new UnityEngine.Random();   
    [SerializeField] GameObject debuff;
    float spawnTimer;
    [SerializeField] float spawnInterval;
    // Start is called before the first frame update
    void Start()
    {
        

        
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0;
            spawnDebuff();
            
        }
    }

    void spawnDebuff()
    {
        float randomPositionX = UnityEngine.Random.Range(transform.position.x -10, transform.position.x + 10);
        Instantiate(debuff, new Vector3(randomPositionX, transform.position.y, transform.position.z), transform.rotation);
    }



}
