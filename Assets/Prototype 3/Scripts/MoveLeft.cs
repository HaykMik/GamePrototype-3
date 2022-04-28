using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30f;
    private float leftBound = -9;

    private Animator playerAnim;
    private PlayerController playerControllerScript;

    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        playerAnim = GameObject.Find("Player").GetComponent<Animator>();
    }

    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

        if (Input.GetKey(KeyCode.F) && !playerControllerScript.gameOver && playerControllerScript.isOnGround)
        {
            speed = 60f;
            playerAnim.speed = 2f;
        } else
        {
            speed = 30f;
            playerAnim.speed = 1f;
        }
    }

    void Dash()
    {
        speed *= 2;
    }
}
