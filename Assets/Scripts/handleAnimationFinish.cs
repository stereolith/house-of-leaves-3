using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handleAnimationFinish : MonoBehaviour {

    public Material opaqueMaterial;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void finishFadeIn()
    {
        Debug.Log("anim finish");
        transform.parent.gameObject.GetComponentInChildren<lightFire>().LightFire();

        GetComponent<Renderer>().material = opaqueMaterial;
    }
}
