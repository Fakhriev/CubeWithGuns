using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Bullet : Bullet
{
    [SerializeField] private GameObject mesh;
    [SerializeField] private GameObject track;
    [SerializeField] private int maxPenetrationNumber;

    private int penetrationNumber;

    private void Start()
    {
        float lifeTime = Random.Range(2, 5);
        //Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NoHit")
            return;

        if (other.gameObject.tag == "Enemy")
        {
            OnTriggerEnter_Bullet(other);
            LaserBullet_Hit();
        }
    }

    private void LaserBullet_Hit()
    {
        penetrationNumber++;

        if(penetrationNumber >= maxPenetrationNumber)
        {
            StartCoroutine(StopTimer());
        }
    }

    IEnumerator StopTimer()
    {
        yield return new WaitForSeconds(0.03f);
        speed = 0;
        mesh.SetActive(false);
    }
}
