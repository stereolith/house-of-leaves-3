using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bike : MonoBehaviour {

    public Transform bikeTransform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        bikeTransform.Translate(1,0,0);
	}
}
