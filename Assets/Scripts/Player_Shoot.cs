using System.Collections;
using UnityEngine;

public class Player_Shoot : MonoBehaviour
{
    public GameObject Bullet;

    public Transform gunHolder;
    public Transform shootPosition;

    public Transform myTarget;
    public float shootReloadTime;

    private bool isCanShoot;

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
            Shoot();
        }
        else
        {
            myTarget = _target;
        }
    }
}
