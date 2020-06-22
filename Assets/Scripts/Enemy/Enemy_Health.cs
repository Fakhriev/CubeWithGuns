using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public Enemy_Movement Enemy_Movement;

    public GameObject enemyMesh;
    public GameObject enemyDeathParticle;

    public float falseActiveTime;

    public int health;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            PlayerTouched();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
            TakeDamage();
    }

    private void TakeDamage()
    {
        health--;

        if(health == 0)
        {
            Enemy_Movement.Death();
            Death();
        }
    }

    private void Death()
    {
        enemyMesh.SetActive(false);

        enemyDeathParticle.transform.SetParent(null);
        enemyDeathParticle.SetActive(true);

        Destroy(gameObject, 1.5f);
        gameObject.SetActive(false); //Временно
        //StartCoroutine(FalseActiveTimer());
    }

    IEnumerator FalseActiveTimer()
    {
        yield return new WaitForSeconds(falseActiveTime);
        gameObject.SetActive(false);
    }

    private void PlayerTouched()
    {

    }
}
