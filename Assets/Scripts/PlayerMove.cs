using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {

    public Image progressCircle;

    public float timeToSelect = 1000f;
    public float regainHitTimeout = 50f;
    public int walkSpeed = 5;
    private float regainHitCountdown;
    private bool selecting;
    private float timeOnTarget = 0f;
    private Transform target = null;
    private bool isWalking = false;

    void Awake()
    {
        regainHitCountdown = regainHitTimeout;
    }

    void Update()
    {
        if(!isWalking)
        {
            RaycastSelect();
        }
        else
        {
            WalkTo();
        }
        
    }

    void RaycastSelect()
    {
        RaycastHit hit;
        Ray lookRay = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(lookRay, out hit))
        {
            if (hit.collider.tag == "moveTarget")
            {
                selecting = true;
                regainHitCountdown = regainHitTimeout;
                timeOnTarget += Time.deltaTime;
                UpdateProgressCircle();
                if (timeOnTarget >= timeToSelect)
                {
                    Debug.Log("Succesfully selected!!");
                    target = hit.transform;
                    isWalking = true;
                    selecting = false;
                    timeOnTarget = 0f;
                }
            }
            else if (selecting)
            {
                regainHitCountdown -= Time.deltaTime;
                if (regainHitCountdown <= 0)
                {
                    selecting = false;
                    regainHitCountdown = regainHitTimeout;
                    timeOnTarget = 0f;
                    UpdateProgressCircle();
                    Debug.Log("sorry, Timeout!");
                }
            }
        }
    }

    void UpdateProgressCircle()
    {
        progressCircle.fillAmount = timeOnTarget / timeToSelect;
    }

    void WalkTo()
    {
        float moveStep = walkSpeed * Time.deltaTime;
        Vector3 targetPos = target.position;
        targetPos.y = transform.parent.position.y;
        transform.parent.position = Vector3.MoveTowards(transform.parent.position, targetPos, moveStep);

    }


    void lookAtSmooth(Transform rotTarget) //ToDo: rotation muss mauseingabe (PlayerLook.cs) überschreiben
    {
        Vector3 targetDir = rotTarget.position - transform.position;
        targetDir.y = 0f;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(targetDir), Time.deltaTime);
    }
}
