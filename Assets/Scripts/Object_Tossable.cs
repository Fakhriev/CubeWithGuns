using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Tossable : MonoBehaviour
{
    public Rigidbody myRb;
    public Collider myCollider;

    public string state;
    private GameObject owner;

    private void Start()
    {
        state = "Free";
        gameObject.tag = "Tossable";
        myRb = GetComponent<Rigidbody>();
        myCollider = GetComponent<Collider>();
    }

    public void BallTaked(GameObject _owner)
    {
        state = "Taked";
        owner = _owner;
        ParametresOn(true);
    }

    public void Object_Shoot(Vector3 _direction)
    {
        state = "Fly";
        ParametresOn(false);

        myRb.AddForce(_direction, ForceMode.Impulse);
        StartCoroutine(OwnerNull());
        StartCoroutine(StateTimer());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (state == "Fly" && collision.gameObject != owner) //&& collision.gameObject.tag == "Player")
            PushTheTempo(collision.rigidbody);
    }

    private void PushTheTempo(Rigidbody _rbToPush)
    {
        _rbToPush.AddForce(myRb.velocity, ForceMode.Impulse);
    }

    private void ParametresOn(bool taked)
    {
        if (taked)
        {
            myCollider.enabled = false;
            myRb.isKinematic = true;

            myRb.useGravity = false;
            myRb.velocity = Vector3.zero;

            return;
        }

        myCollider.enabled = true;
        myRb.isKinematic = false;
        myRb.useGravity = true;
    }

    IEnumerator OwnerNull()
    {
        yield return new WaitForSeconds(1);
        owner = null;
    }

    IEnumerator StateTimer()
    {
        yield return new WaitForSeconds(7.5f);
        state = "Free";
    }
}
