using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Movement : MonoBehaviour
{
    public Rigidbody bulletRb;
    public float speed;

    public float minStopTimer;
    public float maxStopTimer;

    private void Start()
    {
        Destroy(gameObject, 2);
    }

    private void FixedUpdate()
    {
        bulletRb.MovePosition(transform.position + transform.forward * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Target")
            StartCoroutine(StopTimer());
    }

    IEnumerator StopTimer()
    {
        float timer = Random.Range(minStopTimer, maxStopTimer);
        yield return new WaitForSeconds(timer);
        speed = 0;
    }
}
