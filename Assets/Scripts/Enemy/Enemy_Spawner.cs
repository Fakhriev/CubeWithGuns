using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    public GameObject EnemyPrefab;

    public float spawnTimer;

    // z[-10, 40]. x[-40, 10];
    public float minX;
    public float maxX;
    public float yPosition;
    public float minZ;
    public float maxZ;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnTimer, spawnTimer);
        //StartCoroutine(CancelInvokeTimer());
    }

    private void SpawnEnemy()
    {
        float xPosition = Random.Range(minX, maxX);
        float zPosition = Random.Range(minZ, maxZ);

        Vector3 spawnPosition = new Vector3(xPosition, yPosition, zPosition);
        Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);
    }

    IEnumerator CancelInvokeTimer()
    {
        yield return new WaitForSeconds(10);
        CancelInvoke();
    }
}
