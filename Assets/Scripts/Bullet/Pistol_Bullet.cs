using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol_Bullet : Bullet_Patron
{
    [SerializeField] private float pushForce;

    private Rigidbody hittedRigidbody;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NoHit")
            return;

        if(other.gameObject.tag == "Enemy" && hittedRigidbody == null)
        {
            OnTriggerEnter_BulletPatron(other);

            hittedRigidbody = other.attachedRigidbody;
            StartCoroutine(PushTimer());
        }
    }

    IEnumerator PushTimer()
    {
        yield return new WaitForSeconds(stopTimer);
        PistolBullet_Hit();
    }

    private void PistolBullet_Hit()
    {
        hittedRigidbody.AddForce(hittedRigidbody.transform.forward * -pushForce, ForceMode.Impulse);
    }
}
