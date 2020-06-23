using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Patron : Bullet
{
    [SerializeField] private float minStopTimer;
    [SerializeField] private float maxStopTimer;

    protected float stopTimer;
    private GameObject hittedObject;

    private void Start()
    {
        StartCoroutine(DestoyTimer());
    }

    private void Update()
    {
        if (hittedObject != null && !hittedObject.activeInHierarchy && gameObject.activeInHierarchy)
        {
            float lifeTime = Random.Range(1, 3);
            Destroy(gameObject, lifeTime);

            gameObject.SetActive(false);
        }
    }
    
    protected void OnTriggerEnter_BulletPatron(Collider other)
    {
        OnTriggerEnter_Bullet(other);
        BulletPatronHit(other.gameObject.name);

        hittedObject = other.gameObject;
        StartCoroutine(StopTimer());
    }

    IEnumerator StopTimer()
    {
        float timer = Random.Range(minStopTimer, maxStopTimer);
        stopTimer = timer;
        yield return new WaitForSeconds(timer);

        speed = 0;
        bulletRb.isKinematic = true;
        transform.SetParent(hittedObject.transform);
    }

    IEnumerator DestoyTimer()
    {
        yield return new WaitForSeconds(5);

        if(transform.parent == null)
        {
            float lifeTime = Random.Range(1, 3);
            Destroy(gameObject, lifeTime);
        }
    }

    private void BulletPatronHit(string _name)
    {
        //Debug.Log("BulletPatronHit(): " + _name);
    }
}
