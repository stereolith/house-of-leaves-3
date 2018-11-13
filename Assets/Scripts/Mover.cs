using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public Hermite_Spline spline;

    private int currentTargetNode = 1;
    private float moveSpeed = 5;
    private float rotateSpeed = 10;
    private int rotateEvery = 5;
    private bool isCompleted;
    private float transition;

    Vector3 newDir;

    private void Update()
    {
        if (!spline)
            return;
        if (!isCompleted)
        {
            Play();
        }

    }

    private void Play()
    {

        float moveStep = moveSpeed * Time.deltaTime;
        float rotateStep = rotateSpeed * Time.deltaTime;

        if (transform.position == spline.nodes[currentTargetNode]) currentTargetNode++;

        //position
        transform.position = Vector3.MoveTowards(transform.position, spline.nodes[currentTargetNode], moveStep);


        //rotation
        //transition = 1 - Vector3.Distance(transform.position, spline.nodes[currentTargetNode]) / Vector3.Distance(spline.nodes[currentTargetNode - 1], spline.nodes[currentTargetNode]);
        transform.rotation = Quaternion.RotateTowards(spline.nodesRotation[currentTargetNode - 1], spline.nodesRotation[currentTargetNode], rotateStep);

        //rotation update every (rotateEvery) points, using point (rotateEvery) points forward
        /*if (currentTargetNode % rotateEvery == 0)
        {
            Vector3 targetDir = spline.nodes[currentTargetNode + rotateEvery] - transform.position;
            newDir = Vector3.RotateTowards(transform.forward, targetDir, rotateStep, 0.0f);
            Debug.DrawRay(transform.position, newDir, Color.red);
        }
        if(newDir != null)
        {
            transform.rotation = Quaternion.LookRotation(newDir);
        }*/
        
    }
}
