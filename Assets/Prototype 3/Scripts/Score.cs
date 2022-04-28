using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Score : MonoBehaviour
{
    public float score;

    private PlayerController playerControllerScript;

    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            score += Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(score);
            Debug.Log(time.Seconds);
        }
    }
}
