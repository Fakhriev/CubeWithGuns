using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public Rigidbody enemyRb;
    [SerializeField] private float speed;

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

    private void FixedUpdate()
    {
        if (transform.position.y > 1)
            return;

        enemyRb.MovePosition(transform.position + transform.forward * speed * Time.fixedDeltaTime);
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
