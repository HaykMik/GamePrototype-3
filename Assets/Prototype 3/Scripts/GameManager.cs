using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    private PlayerController playerControllerScript;

    public float score;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            TimeSpan time = TimeSpan.FromSeconds(score);

            if (playerControllerScript.dash)
            {
                score += Time.deltaTime * 2;     
            } else
            {
                score += Time.deltaTime;
            }

            Debug.Log($"Score - {time.Seconds}");
        }
    }
}
