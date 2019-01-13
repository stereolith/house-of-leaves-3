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

    private bool path = false;
    private Hermite_Spline spline = null;
    private int currentTargetNode = 0;
    public float pathWalkSpeed = 50;
    public float rotateSpeed = 6;
    public int rotateEvery = 5;
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
        if(!isWalking)
        {

            if(path)
            {
                Debug.Log(spline.nodes[0]);
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
                if (walk_path != null)
                {
                    path = true;
                    spline = walk_path;
                    //transform.parent.position = spline.nodes[0]; //teleport to first node
                    Debug.Log("Walk along path started");
                }

                Hermite_Spline bike_path = target.GetComponent<WalkTarget>().getBike_path();
                GameObject bike = target.GetComponent<WalkTarget>().getBike();
                if (bike_path != null && bike != null)
                {
                    Debug.Log("Bike and path detected");
                    gameObject.SetActive(false);
                    bike.GetComponent<Mover>().setMoving(true);
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


    private void WalkAlongPath()
    {
        if(currentTargetNode == spline.nodes.Count)
        {
            spline = null;
            path = false;
        }

        float moveStep = pathWalkSpeed * Time.deltaTime;
        float rotateStep = rotateSpeed * Time.deltaTime;

        Quaternion lastRotation = transform.parent.rotation;

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
