using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public Rigidbody enemyRb;
    public Transform playerTransform;

    public bool isDead;

    private void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if (isDead)
            return;

        if(!enemyRb.isKinematic && transform.position.y <= 0.5f)
        {
            LandToGround();
        }

        transform.LookAt(playerTransform);
    }

    private void LandToGround()
    {
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        enemyRb.isKinematic = true;
    }

    public void Death()
    {
        isDead = true;
        enemyRb.isKinematic = false;
    }
}
