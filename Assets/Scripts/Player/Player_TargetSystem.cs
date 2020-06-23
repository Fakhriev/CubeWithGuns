using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_TargetSystem : MonoBehaviour
{
    public Player_Controller Player_Controller;
    public Player_Shoot Player_Shoot;
    public Transform targetCircle;

    private Transform myTarget;
    private List<Rigidbody> targetList = new List<Rigidbody>();

    private void Update()
    {
        if(targetList.Count > 0)
        {
            targetCircle.position = targetList[0].position;

            for (int i = 0; i < targetList.Count; i++)//Если кто-то из врагов стал Kinematick(Умер), то убрать его из таргетЛиста
            {
                if (targetList[i].isKinematic == true)
                {
                    targetList.RemoveAt(i);

                    if (targetList.Count > 0)
                        SetTheTarget(targetList[0].transform);

                    if (targetList.Count == 0)
                    {
                        SetTheTarget(null);
                        targetCircle.gameObject.SetActive(false);
                    }

                    break;
                }
            }
        }

        if(targetList.Count > 1)
        {
            for (int i = 1; i < targetList.Count; i++)//Если кто-то из врагов стал ближе, чем основной таргет, то сделать ближнего новым таргетом
            {
                float currentTargetRange = Vector3.Distance(transform.position, myTarget.position);
                
                if(Vector3.Distance(transform.position, targetList[i].position) < currentTargetRange)
                {

                    Rigidbody buble = targetList[0];
                    targetList[0] = targetList[i];
                    targetList[i] = buble;

                    SetTheTarget(targetList[0].transform);
                    break;
                }
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            if (!targetList.Contains(other.attachedRigidbody))
            {
                if (targetList.Count == 0)
                    SetTheTarget(other.transform);

                targetList.Add(other.attachedRigidbody);
                targetCircle.gameObject.SetActive(true);
            }   
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            if (targetList.Contains(other.attachedRigidbody))
            {
                targetList.Remove(other.attachedRigidbody);

                if (targetList.Count > 0)
                    SetTheTarget(targetList[0].transform);

                if (targetList.Count == 0)
                {
                    SetTheTarget(null);
                    targetCircle.gameObject.SetActive(false);
                }
            }
        }
    }

    private void SetTheTarget(Transform _target)
    {
        myTarget = _target;

        Player_Controller.SetTheTarget(myTarget);
        Player_Shoot.SetTheTarget(myTarget);
    }
}
