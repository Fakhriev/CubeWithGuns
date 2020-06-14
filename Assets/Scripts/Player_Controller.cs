using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    public Rigidbody playerRB;
    public Transform PlayerMesh;
    public VariableJoystick Joystick;

    public float walkSpeed;
    public float runSpeed;
    public float moveTypeAmountForJoystick;

    private float currentSpeed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            RestartScene();

        if(Joystick.Vertical != 0 || Joystick.Horizontal != 0)
        {
            PlayerMesh.transform.eulerAngles = new Vector3(0, Mathf.Atan2(Joystick.Vertical, Joystick.Horizontal) * -180 / Mathf.PI, 0);

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
        playerRB.MovePosition(transform.position + PlayerMesh.transform.forward * currentSpeed * Time.fixedDeltaTime);
    }

    private void RestartScene()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }
}
