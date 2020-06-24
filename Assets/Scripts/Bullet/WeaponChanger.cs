using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponChanger : MonoBehaviour
{
    [SerializeField] private Player_Shoot Player_Shoot;
    [SerializeField] private GameObject[] weaponPrefabsArray = new GameObject[0];
    [SerializeField] private Button btn_ChangeWeapon;

    public int weaponIndex;
    private GameObject oldWeapon;

    private void Start()
    {
        btn_ChangeWeapon.onClick.AddListener(ChangeWeapon);
        ChangeWeapon();   
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
            ChangeWeapon();
    }

    private void ChangeWeapon()
    {
        if(oldWeapon != null)
            Destroy(oldWeapon);

        GameObject newWeapon = Instantiate(weaponPrefabsArray[weaponIndex], transform.position, Quaternion.identity);
        Weapon weaponComponent = newWeapon.GetComponent<Weapon>();

        GameObject bullet = weaponComponent.GetBullet();
        float shootReloadTime = weaponComponent.GetShootReloadTime();
        Transform shootPosition = weaponComponent.GetShootPosition();
        float range = weaponComponent.GetShootRange();

        Transform gunHolder = Player_Shoot.NewWeaponEquipped(bullet, shootReloadTime, shootPosition, range);

        newWeapon.transform.rotation = gunHolder.rotation;
        newWeapon.transform.position = gunHolder.position;
        newWeapon.transform.SetParent(gunHolder);

        weaponIndex++;
        oldWeapon = newWeapon;

        if (weaponIndex == weaponPrefabsArray.Length)
            weaponIndex = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            ChangeWeapon();
    }
}
