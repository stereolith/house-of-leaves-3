using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {

    public int walkSpeed = 5;
    private Transform target = null;
    private bool isWalking = false;
    private Animator animator;
    private LookSelect lookSelect;

    void Awake()
    {
        animator = GetComponent<Animator>();
        lookSelect = GetComponent<LookSelect>();
    }

    void Update()
    {
        if(!isWalking)
        {
            GameObject hit = lookSelect.RaycastSelect();
            if(hit != null)
            {
                animator.Play("Walk");
                target = hit.transform;
                isWalking = true;
            }
        }
        else
        {
            isWalking = WalkTo();
        }
        
    }
    
    bool WalkTo() //returns false if target is reached
    {
        float moveStep = walkSpeed * Time.deltaTime;
        Vector3 targetPos = target.position;
        targetPos.y = transform.parent.position.y;
        transform.parent.position = Vector3.MoveTowards(transform.parent.position, targetPos, moveStep);
        if (transform.parent.position == targetPos)
        {
            animator.Play("Idle");
            return false;
        }
        else
        {
            return true;
        }

    }


    void lookAtSmooth(Transform rotTarget) //ToDo: rotation muss mauseingabe (PlayerLook.cs) überschreiben
    {
        Vector3 targetDir = rotTarget.position - transform.position;
        targetDir.y = 0f;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(targetDir), Time.deltaTime);
    }
}
