using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public Path path;

    private int currentTargetNode = 0;
    private float speed = 5;
    private bool isCompleted;

    private void Update()
    {
        if (!path)
            return;
        if (!isCompleted)
            Play();
    }

    private void Play()
    {
        Debug.Log(currentTargetNode);

        Debug.Log(path.nodes[currentTargetNode].position);
        float step = speed * Time.deltaTime;

        if (transform.position == path.nodes[currentTargetNode].position) currentTargetNode++;

        transform.position = Vector3.MoveTowards(transform.position, path.nodes[currentTargetNode].position, step);

        //transform.rotation = path.Orientation(currentTargetNode, step);
    }
}
