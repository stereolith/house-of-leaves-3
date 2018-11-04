using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public Path path;

    private int currentSeg; //Current segment (between nodes)
    private float transition; //progression in segment (0-1)
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
        transition += Time.deltaTime * 1 / 2.5f;
        if (transition > 1)
        {
            transition = 0;
            currentSeg++;
        }

        transform.position = path.LinearPosition(currentSeg, transition);
        transform.rotation = path.Orientation(currentSeg, transition);
    }
}
