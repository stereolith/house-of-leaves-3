using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gangEnger : MonoBehaviour
{

    public Transform playerTransform;
    private Collider boxCollider;

    private Animator anim;

    // Use this for initialization
    void Start()
    {
        boxCollider = GetComponent<Collider>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boxCollider.bounds.Contains(playerTransform.position))
        {
            Debug.Log("collide");
            anim.SetTrigger("trigger_eng");
        }
    }
}
