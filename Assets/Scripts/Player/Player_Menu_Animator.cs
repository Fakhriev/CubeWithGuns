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

    public void SpinRandomAnimation()
    {
        int rnd = Random.Range(0, 10);

        if(rnd == 9)
        {
            int anim = Random.Range(0, 3);

            if (anim == 0)
                Look1();

            if (anim == 1)
                Look2();

            if (anim == 2)
                Spin1();
        }
    }
}
