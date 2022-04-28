using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30f;
    private float leftBound = -9;

    private Animator playerAnim;
    private PlayerController playerControllerScript;
    private Score scoreScript;

    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        playerAnim = GameObject.Find("Player").GetComponent<Animator>();
        scoreScript = GameObject.Find("Main Camera").GetComponent<Score>();
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
            speed = 55f;
            playerAnim.speed = 2f;
            scoreScript.score += Time.deltaTime * 2;
        } else
        {
            speed = 30f;
            playerAnim.speed = 1f;
        }
    }
}
