using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class SpawnerDebuff : MonoBehaviour
{
    // UnityEngine.Random random = new UnityEngine.Random();   
    [SerializeField] GameObject debuff;
    GameObject instantiatedPrefab;
    float spawnTimer;
    [SerializeField] float spawnInterval;

    void Start()
    {
        

        
        
    }

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
        instantiatedPrefab = Instantiate(debuff, new Vector3(randomPositionX, transform.position.y, transform.position.z), transform.rotation);
        
        Destroy(instantiatedPrefab, 2f);

    }

    // fazer cair bolinhas verdes que dão pontos para o player


}
