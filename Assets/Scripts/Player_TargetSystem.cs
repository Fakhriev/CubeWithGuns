using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_TargetSystem : MonoBehaviour
{
    public Player_Controller Player_Controller;
    public Player_Shoot Player_Shoot;
    public Transform Target;

    private Transform myTarget;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            SetTheTarget();
    }

    private void SetTheTarget()
    {
        myTarget = Target;
        Player_Controller.SetTheTarget(myTarget);
        Player_Shoot.SetTheTarget(myTarget);
    }
}
