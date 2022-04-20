using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.AddForce(Vector3.up * 1000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
