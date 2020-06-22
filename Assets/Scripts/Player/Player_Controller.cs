using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    public Rigidbody playerRB;
    public Transform upPart;
    public Transform downPart;

    public VariableJoystick Joystick;

    public float walkSpeed;
    public float runSpeed;
    public float moveTypeAmountForJoystick;

    private float currentSpeed;
    private Transform myTarget;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            RestartScene();

        if (myTarget != null)
            upPart.transform.LookAt(myTarget);
        else
            upPart.rotation = downPart.rotation;

        if (Joystick.Vertical != 0 || Joystick.Horizontal != 0)
        {
            downPart.transform.eulerAngles = new Vector3(0, Mathf.Atan2(Joystick.Vertical, Joystick.Horizontal) * -180 / Mathf.PI, 0);

            if (Mathf.Abs(Joystick.Vertical) < moveTypeAmountForJoystick && Mathf.Abs(Joystick.Horizontal) < moveTypeAmountForJoystick)
            {
                currentSpeed = walkSpeed;
            }

            if (Mathf.Abs(Joystick.Vertical) > moveTypeAmountForJoystick || Mathf.Abs(Joystick.Horizontal) > moveTypeAmountForJoystick)
            {
                currentSpeed = runSpeed;
            }
        }
        else
        {
            currentSpeed = 0;
        }
    }

    private void FixedUpdate()
    {
        playerRB.MovePosition(transform.position + downPart.forward * currentSpeed * Time.fixedDeltaTime);
    }

    private void RestartScene()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }

    public void SetTheTarget(Transform _target) 
    {
        myTarget = _target;

        if(myTarget != null)
            upPart.transform.LookAt(myTarget);
    }
}
