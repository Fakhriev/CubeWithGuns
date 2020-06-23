using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected Rigidbody bulletRb;
    [SerializeField] protected float speed;
    [SerializeField] protected int damage;

    [SerializeField] protected GameObject hitEffect;

    private Enemy_Health Enemy_Health;

    private void FixedUpdate()
    {
        if (speed > 0)
            bulletRb.MovePosition(transform.position + transform.forward * speed * Time.fixedDeltaTime);
    }

    protected void OnTriggerEnter_Bullet(Collider other)
    {
        BulletClassHit(other.gameObject);
    }

    private void BulletClassHit(GameObject _hittedEnemy)
    {
        Enemy_Health = _hittedEnemy.GetComponent<Enemy_Health>();
        Enemy_Health.DoDamage(damage);
        
        if (hitEffect == null)
        {
            //Debug.Log("BulletClassHitPrivate(): " + _name);
            return;
        }

        GameObject _hitEffect = Instantiate(hitEffect, transform.position, Quaternion.Euler(0, 180, 0));
        Destroy(_hitEffect, 1);
    }
}
