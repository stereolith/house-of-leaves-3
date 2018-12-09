using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeLocalMovement : MonoBehaviour {

    public float maxYRotation = 25;

    private float lastYAngle = 0;
    private float sumYAngle = 0;
    private int cycles = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float diffYAngle = transform.parent.rotation.eulerAngles.y - lastYAngle;
        sumYAngle += diffYAngle;
        if (cycles % 5 == 0)
        {
            Debug.Log(sumYAngle);
            sumYAngle = -1 * sumYAngle;
            float currentYAngle = transform.rotation.eulerAngles.y;
            if (sumYAngle > maxYRotation) sumYAngle = maxYRotation;
            if (sumYAngle < (-1.0f * maxYRotation)) sumYAngle = -1.0f * maxYRotation;
            transform.rotation = Quaternion.Euler(0, 0, sumYAngle);
            sumYAngle = 0;
        }
        lastYAngle = transform.rotation.eulerAngles.y;
        cycles++;
    }
}
