using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FensterAutoOpen : MonoBehaviour
{

    public Transform playerTransform;
    private Collider boxCollider;
    private Animator[] animators;

    private Animator anim;

    // Use this for initialization
    void Start()
    {
        boxCollider = GameObject.Find("walkTarget_insideTurm").GetComponent<Collider>();
        animators = GetComponentsInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boxCollider.bounds.Contains(playerTransform.position))
        {
            Debug.Log("collide");
            foreach (Animator a in animators)
            {
                a.SetTrigger("trigger_window_anim");
            Debug.Log("window open");
            }
        }
    }
}
