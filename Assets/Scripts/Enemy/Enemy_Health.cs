using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public GameObject enemyMesh;
    public GameObject enemyDeathParticle;
    public Enemy_Movement Enemy_Movement;

    public int health;

    private bool isDead;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            PlayerTouched();
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.tag == "Bullet" && !other.attachedRigidbody.isKinematic)
        {
            TakeDamage();
        }*/
    }

    private void TakeDamage()
    {
        health--;

        if(health <= 0 && !isDead)
        {
            isDead = true;
            Enemy_Movement.Death();
            Death();
        }
    }

    private void Death()
    {
        Enemy_DeathCount.EnemyDeath();
        enemyMesh.SetActive(false);

        enemyDeathParticle.transform.SetParent(null);
        enemyDeathParticle.SetActive(true);

        Destroy(gameObject, 1.5f);
        gameObject.SetActive(false);
    }

    private void PlayerTouched()
    {

    }

    public void DoDamage(int _damage)
    {
        health -= _damage;
        //Debug.Log("Me: " + gameObject.name + ", TakeDame: " + _damage);

        if (health <= 0 && !isDead)
        {
            isDead = true;
            Enemy_Movement.Death();
            Death();
        }
    }
}
