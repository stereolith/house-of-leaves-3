using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorAutoOpen : MonoBehaviour {

    public Transform playerTransform;
    private Collider boxCollider;

    private Animator anim;

	// Use this for initialization
	void Start () {
        boxCollider = GetComponentsInChildren<Collider>()[0];
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (boxCollider.bounds.Contains(playerTransform.position))
        {
            anim.SetTrigger("open_door");
        }
    }
}
