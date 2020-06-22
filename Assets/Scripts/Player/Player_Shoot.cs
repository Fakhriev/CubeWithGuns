using System.Collections;
using UnityEngine;

public class Player_Shoot : MonoBehaviour
{
    public GameObject Bullet;
    public float shootReloadTime;

    public Transform gunHolder;
    public Transform shootPosition;

    private Transform myTarget;
    public bool isCanShoot;

    private void Start()
    {
        isCanShoot = true;
    }

    private void Update()
    {
        if (myTarget != null)
        {
            gunHolder.LookAt(myTarget);

            if (isCanShoot)
                Shoot();
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(shootReloadTime);
        isCanShoot = true;
    }

    private void Shoot()
    {
        Instantiate(Bullet, shootPosition.position, shootPosition.rotation);
        isCanShoot = false;
        StartCoroutine(Reload());
    }

    public void SetTheTarget(Transform _target)
    {
        if(myTarget == null)
        {
            myTarget = _target;
            gunHolder.LookAt(myTarget);

            if(isCanShoot)
                Shoot();
        }
        else
        {
            myTarget = _target;
        }
    }
}
