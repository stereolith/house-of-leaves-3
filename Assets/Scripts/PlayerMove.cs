﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {

    public int walkSpeed = 5;
    private Transform target = null;
    private bool isWalking = false;
    private Animator animator;
    private LookSelect lookSelect;
    private bool changeScene = false;
    public bool deactivateOnSelect = true;

    private bool path = false;
    private Hermite_Spline spline = null;
    private int currentTargetNode = 0;
    public float pathWalkSpeed = 25;
    public float rotateSpeed = 6;
    public int rotateEvery = 1;
    private bool isCompleted;
    private float transition;
    Vector3 newDir;

    void Awake()
    {
        animator = GetComponent<Animator>();
        lookSelect = GetComponent<LookSelect>();
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if (!isWalking)
        {

            if(path)
            {
                //Debug.Log(spline.nodes[0]);
                WalkAlongPath();
            }
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
            if(!isWalking) //Check once target reached: teleport target, walk path, bike path
            {
                Transform teleportTarget = target.GetComponent<WalkTarget>().GetTarget();
                if (teleportTarget != null)
                {
                    transform.parent.position = teleportTarget.position;
                }


                Hermite_Spline walk_path = target.GetComponent<WalkTarget>().getWalk_path();
                if(target.GetComponent<WalkTarget>().getPathSpeed() != 0)
                {
                    Debug.Log("path speed set to ");
                    Debug.Log(target.GetComponent<WalkTarget>().getPathSpeed());
                    pathWalkSpeed = target.GetComponent<WalkTarget>().getPathSpeed();
                }
                if (walk_path != null)
                {
                    path = true;
                    spline = walk_path;
                    transform.parent.position = spline.nodes[0]; //teleport to first node
                    Debug.Log("Walk along path started");
                }

                changeScene = target.GetComponent<WalkTarget>().getChangeScene();
                if(changeScene && walk_path == null)
                {
                    Debug.Log("change scene");
                    {
                        GameObject.Find("LevelChanger").GetComponent<LevelChanger>().NextScene();
                    }
                }

                Hermite_Spline bike_path = target.GetComponent<WalkTarget>().getBike_path();
                GameObject bike = target.GetComponent<WalkTarget>().getBike();
                if (bike_path != null && bike != null)
                {
                    Debug.Log("Bike and path detected");
                    GetComponent<Camera>().enabled = false;
                    bike.GetComponent<Mover>().setMoving(true);
                }
                if(deactivateOnSelect)
                {
                    target.GetComponent<WalkTarget>().deactivateSelf();
                }
            }
        }
        
    }
    
    bool WalkTo() //returns false if target is reached
    {
        float moveStep = pathWalkSpeed * Time.deltaTime;
        Vector3 targetPos = target.position;
        targetPos.y = transform.parent.position.y;
        transform.parent.position = Vector3.MoveTowards(transform.parent.position, targetPos, moveStep);
        if (Vector3.Distance(transform.parent.position, targetPos) < 2.0)
        {
            currentTargetNode = 0;
            Debug.Log("Stop walking");
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


    private void WalkAlongPath()
    {
        if(currentTargetNode == spline.nodes.Count)
        {
            if(target.GetComponent<WalkTarget>().getChangeScene())
            {
                GameObject.Find("LevelChanger").GetComponent<LevelChanger>().NextScene();
            }
            spline = null;
            path = false;
        }

        float moveStep = pathWalkSpeed * Time.deltaTime;
        float rotateStep = rotateSpeed * Time.deltaTime;

        Quaternion lastRotation = transform.parent.rotation;

        //Debug.Log(currentTargetNode);

        //position
        transform.parent.position = Vector3.MoveTowards(transform.parent.position, spline.nodes[currentTargetNode], moveStep);

        if (transform.parent.position == spline.nodes[currentTargetNode])
        {
            currentTargetNode++;
        }

        Quaternion currentRotation = transform.rotation;

        Vector3 targetDir = spline.nodes[currentTargetNode + rotateEvery] - transform.parent.position;
        newDir = Vector3.RotateTowards(transform.parent.forward, targetDir, rotateStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
