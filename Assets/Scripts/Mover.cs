using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public Hermite_Spline spline;

    private int currentTargetNode = 1;
    private float moveSpeed = 5;
    private float rotateSpeed = 3;
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

        Quaternion toRotation = new Quaternion();
        Quaternion lastRotation = transform.rotation;

        //position
        transform.position = Vector3.MoveTowards(transform.position, spline.nodes[currentTargetNode], moveStep);

        if (transform.position == spline.nodes[currentTargetNode])
        {
            currentTargetNode++;

            /*Vector3 direction = spline.nodes[currentTargetNode] - transform.position;
            toRotation = Quaternion.FromToRotation(transform.position, spline.nodes[currentTargetNode]);
            toRotation = transform.rotation * toRotation;
            Debug.Log("toRotation");
            Debug.Log(toRotation);
            lastRotation = transform.rotation;
            Debug.Log("lastRotation");
            Debug.Log(lastRotation);*/
        }

        //rotation
        /*transition = 1 - Vector3.Distance(transform.position, spline.nodes[currentTargetNode]) / Vector3.Distance(spline.nodes[currentTargetNode - 1], spline.nodes[currentTargetNode]);

        Debug.Log(transition);
        transform.LookAt(spline.nodes[currentTargetNode]);*/


        //rotation update every (rotateEvery) points, using point (rotateEvery) points forward
        Quaternion currentRotation = transform.rotation;

        Vector3 targetDir = spline.nodes[currentTargetNode + rotateEvery] - transform.position;
        newDir = Vector3.RotateTowards(transform.forward, targetDir, rotateStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
