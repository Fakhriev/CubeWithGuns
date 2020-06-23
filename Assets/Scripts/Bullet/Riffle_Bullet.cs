using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riffle_Bullet : Bullet_Patron
{
    private bool hitted;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NoHit")
            return;

        if (other.gameObject.tag == "Enemy" && !hitted)
        {
            hitted = true;
            OnTriggerEnter_BulletPatron(other);
        }
    }
}
