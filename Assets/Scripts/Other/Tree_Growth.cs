using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_Growth : MonoBehaviour
{
    public MeshFilter meshFilter;
    public Mesh[] treeMesh = new Mesh[0];

    public float growthTime;
    private int meshIndex;

    private void Start()
    {
        StartCoroutine(GrowthTimer());
    }

    IEnumerator GrowthTimer()
    {

        float time = Random.Range(growthTime - 10, growthTime + 10);
        yield return new WaitForSeconds(time);
        meshIndex++;
        meshFilter.mesh = treeMesh[meshIndex];

        if (meshIndex != treeMesh.Length - 1)
            StartCoroutine(GrowthTimer());
    }
}
