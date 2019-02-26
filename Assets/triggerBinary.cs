using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerBinary : MonoBehaviour
{

    private Collider boxCollider;

    private Animator anim;

    // Use this for initialization
    void Start()
    {
        boxCollider = GameObject.Find("Links").GetComponent<Collider>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boxCollider.bounds.Contains(transform.position))
        {
            Debug.Log("collide");
            anim.SetTrigger("trigger_binary");
        }
    }
}
