using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Menu_CameraRotator : MonoBehaviour
{
    [SerializeField] private Transform cameraRotator;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float rotationStartTime;

    private bool rotationAble;
    private float yRotation;

    private void Start()
    {
        return;
        StartCoroutine(RotationStartTimer());
    }

    private void Update()
    {
        if (!rotationAble)
            return;

        yRotation -= rotateSpeed * Time.deltaTime;
        cameraRotator.transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    IEnumerator RotationStartTimer()
    {
        yield return new WaitForSeconds(rotationStartTime);
        rotationAble = true;
    }
}
