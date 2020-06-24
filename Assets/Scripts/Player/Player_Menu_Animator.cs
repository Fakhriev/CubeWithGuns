using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Player_Menu_Animator : MonoBehaviour
{
    [SerializeField] private Animator Animator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
            Look1();

        if (Input.GetKeyDown(KeyCode.Keypad2))
            Look2();

        if (Input.GetKeyDown(KeyCode.Keypad3))
            Spin1();
    }

    private void Look1()
    {
        Animator.SetTrigger("Look1");
    }

    private void Look2()
    {
        Animator.SetTrigger("Look2");
    }

    private void Spin1()
    {
        Animator.SetTrigger("Spin1");
    }
}
