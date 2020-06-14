using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pawn_Shoot : MonoBehaviour
{
    public Transform tossObjectPosition;
    public GameObject tossObjectCollider;
    public Button shootButton;

    public Rigidbody myRb;
    public Transform playerMesh;
    public float force;

    public Object_Tossable myTossObject;

    private void Start()
    {
        shootButton.onClick.AddListener(ShootBall);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ShootBall();
    }

    private void ShootBall()
    {
        if (myTossObject == null)
            return;

        myTossObject.Object_Shoot(playerMesh.forward * force);
        myTossObject.transform.SetParent(null);

        tossObjectCollider.gameObject.SetActive(false);
        //myRb.AddForce(-playerMesh.forward * (force / 3), ForceMode.Impulse);

        StartCoroutine(BallTime());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tossable" && myTossObject == null)
        {
            myTossObject = collision.gameObject.GetComponent<Object_Tossable>();

            if (myTossObject.state != "Free")
            {
                myTossObject = null;
                return;
            }

            myTossObject.BallTaked(gameObject);
            TakeTossObject(myTossObject);
        }
    }

    private void TakeTossObject(Object_Tossable _ball)
    {
        tossObjectCollider.gameObject.SetActive(true);
        myTossObject.transform.SetParent(tossObjectPosition);
        myTossObject.transform.position = tossObjectPosition.position;
    }

    IEnumerator BallTime()
    {
        yield return new WaitForSeconds(0.25f);
        myTossObject = null;
    }
}
