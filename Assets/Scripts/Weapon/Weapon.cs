using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float shootReloadTime;
    [SerializeField] private Transform shootPosition;
    [SerializeField] private float shootRange;
    [SerializeField] private AudioClip shootClip;

    public GameObject GetBullet()
    {
        return bullet;
    }

    public float GetShootReloadTime()
    {
        return shootReloadTime;
    }

    public Transform GetShootPosition()
    {
        return shootPosition;
    }

    public float GetShootRange()
    {
        return shootRange;
    }

    public AudioClip GetShootSound()
    {
        return shootClip;
    }
}
