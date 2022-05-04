using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30f;
    private float leftBound = -9;

    private PlayerController playerControllerScript;

    private void Start()
    {
        // Get components
        {
            playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        }
    }

    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            if (playerControllerScript.dash)
            { 
                transform.Translate(Vector3.left * Time.deltaTime * (speed * 2)); 
            } else
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
