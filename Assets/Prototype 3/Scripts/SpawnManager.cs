using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay;
    private float repeatRate;
    private PlayerController playerControllerScripts;

    void Start()
    {
        playerControllerScripts = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay = Random.Range(1f, 5f), repeatRate = Random.Range(1f, 5f));
    }

    void SpawnObstacle()
    {
        int index = Random.Range(0, obstaclePrefabs.Length);

        if (playerControllerScripts.gameOver == false)
        {
            Instantiate(obstaclePrefabs[index], spawnPos, obstaclePrefabs[index].transform.rotation);
        }
    }
}
