using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_TargetSystem : MonoBehaviour
{
    public Player_Controller Player_Controller;
    public Transform target;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            SetTheTarget();
    }

    private void SetTheTarget()
    {
        Player_Controller.currentTarget = Player_Controller.currentTarget == null ? target : null;
    }
}
