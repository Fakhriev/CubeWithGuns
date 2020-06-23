using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public Rigidbody enemyRb;

    private Transform playerTransform;
    private bool isDead;

    private void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if (isDead)
            return;

        transform.LookAt(playerTransform);
    }

    private void LandToGround()
    {
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

    public void Death()
    {
        isDead = true;
        enemyRb.isKinematic = true;
    }
}
