using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeInCamp : MonoBehaviour {

    private Animator[] animators;
    public Transform playerTransform;

    private Collider boxCollider;

    bool collided = false;

    // Use this for initialization
    void Start () {
        animators = GetComponentsInChildren<Animator>();
        boxCollider = GetComponentsInChildren<Collider>()[0];
	}
	
	// Update is called once per frame
	void Update () {
        if(!collided)
        {
            if (boxCollider.bounds.Contains(playerTransform.position))
            {
                fadeIn();
                collided = true;
                Debug.Log("collide");
            }
        }

    }

    public void fadeIn()
    {
        foreach (Animator animator in animators)
        {
            animator.SetTrigger("fadeIn");
        }
    }
}
