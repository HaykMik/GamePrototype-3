using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;

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
        Physics.gravity *= gravityMod;

        // Get components
        {
            playerRb = GetComponent<Rigidbody>();

            playerAnim = GetComponent<Animator>();

            playerAudio = GetComponent<AudioSource>();
        }

    }

    void Update()
    {
        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            Jump();
            isSecondJump = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !isOnGround && !isSecondJump)
        {
            isSecondJump = true;
            Jump();
            playerAnim.Play("Running_Jump", 3,0f);
        }

        // Bound for jumping
        if (transform.position.y > yMaxBound)
        {
            transform.position = new Vector3(transform.position.x, yMaxBound, transform.position.z);
        }
    }

    void Jump()
    {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnGround = false;

        if (!isSecondJump) { playerAnim.Play("Running_Jump"); }

        dirtParticle.Stop();
        playerAudio.PlayOneShot(jumpSound);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isOnGround = true;
            dirtParticle.Play();
            playerAnim.SetFloat("Speed_f", 1f);
        }
        if (collision.gameObject.CompareTag("Obstacle") )
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
