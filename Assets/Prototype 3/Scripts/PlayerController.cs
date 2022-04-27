using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    private MoveLeft moveLeftScript;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    public float jumpForce = 10;
    public float gravityMod;
    public bool isOnGround;
    public bool gameOver;
    public bool isSecondJump;

    private float yMaxBound = 6.5f;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        moveLeftScript = GameObject.Find("Background").GetComponent<MoveLeft>();
        //moveLeftScript = GameObject.FindGameObjectsWithTag("Obstacle").;

        Physics.gravity *= gravityMod;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            Jump();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !isOnGround && !isSecondJump)
        {
            Jump();
            isSecondJump = true;
        }
        if (transform.position.y > yMaxBound)
        {
            transform.position = new Vector3(transform.position.x, yMaxBound, transform.position.z);
        }

        if (Input.GetKey(KeyCode.F))
        {
            Dash();
        } else
        {
            moveLeftScript.speed = 30f;
        }
    }

    void Jump()
    {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnGround = false;

        playerAnim.SetTrigger("Jump_trig");
        dirtParticle.Stop();
        playerAudio.PlayOneShot(jumpSound);
    }

    void Dash()
    {
        moveLeftScript.speed = 60f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isOnGround = true;
            isSecondJump = false;
            dirtParticle.Play();
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");

            playerAnim.SetBool("Death_b", true);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound);
        }
    }
}
