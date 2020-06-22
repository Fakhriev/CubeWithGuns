using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_DeathParticle : MonoBehaviour
{
    private void OnEnable()
    {
        Destroy(gameObject, 1.5f);
    }
}
