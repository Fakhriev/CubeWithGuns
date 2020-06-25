using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRendererUp;
    [SerializeField] private MeshRenderer meshRendererDown;
    [SerializeField] private Material redMaterial;

    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private Transform upMesh;
    [SerializeField] private float force;
    [SerializeField] private int health;

    [SerializeField] private Player_Controller Player_Controller;
    [SerializeField] private Player_Shoot Player_Shoot;
    [SerializeField] private GameObject gunHolder;
    [SerializeField] private GameObject targetSystem;

    [SerializeField] private GameObject btn_Pause;
    [SerializeField] private GameObject JoyStick;
    [SerializeField] private GameObject restartThings;

    private bool isDead;
    private bool isNotBeDamaged;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
            TakeDamage(collision.transform.position);
    }

    private void TakeDamage(Vector3 _enemyPosition)
    {
        if (isDead || isNotBeDamaged)
            return;

        if(health > 1)
        {
            Vector3 pushVector = new Vector3(-upMesh.forward.x, 5, -upMesh.forward.z);
            playerRb.AddForce(pushVector * force, ForceMode.Impulse);
            health--;

            isNotBeDamaged = true;
            StartCoroutine(CantBeDamagedTimer());
            return;
        }

        health = 0;
        isDead = true;
        meshRendererUp.material = redMaterial;
        meshRendererDown.material = redMaterial;

        Player_Controller.enabled = false;
        Player_Shoot.enabled = false;

        gunHolder.SetActive(false);
        targetSystem.SetActive(false);

        JoyStick.SetActive(false);
        btn_Pause.SetActive(false);
        restartThings.SetActive(true);
    }

    IEnumerator CantBeDamagedTimer()
    {
        yield return new WaitForSeconds(1.5f);
        isNotBeDamaged = false;
    }
}
