using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private PlayerController playerControllerScripts;

    void Start()
    {
        playerControllerScripts = GameObject.Find("Player").GetComponent<PlayerController>();

        float startDelay = Random.Range(1.0f, 4.0f);
        Invoke("SpawnObstacle", startDelay);
    }

    void SpawnObstacle()
    {
        Vector3 spawnPos = new Vector3(25, 0, 0);
        int randomObstacle = Random.Range(0, obstaclePrefabs.Length);
        
        if (!playerControllerScripts.gameOver)
        {
            Instantiate(obstaclePrefabs[randomObstacle], spawnPos, obstaclePrefabs[randomObstacle].transform.rotation);
        }

        float spawnInterval = Random.Range(2.0f, 4.0f);
        Invoke("SpawnObstacle", spawnInterval);
    }
}
