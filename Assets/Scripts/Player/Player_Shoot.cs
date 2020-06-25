using System.Collections;
using UnityEngine;

public class Player_Shoot : MonoBehaviour
{
    public Transform gunHolder;
    [SerializeField] private SphereCollider targetSphereCollider;
    [SerializeField] private AudioSource audioSource;

    public GameObject Bullet;
    public float shootReloadTime;
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
        audioSource.Play();
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

    public Transform NewWeaponEquipped(GameObject _Bullet, float _shootReloadTime, Transform _shootPosition, float _range, AudioClip _shootClip)
    {
        Bullet = _Bullet;
        shootReloadTime = _shootReloadTime;
        shootPosition = _shootPosition;
        audioSource.clip = _shootClip;

        targetSphereCollider.radius = 7.5f + _range;

        return gunHolder;
    }
}
