using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hide : MonoBehaviour {

    public Transform playerTransform;
    private Collider boxCollider;
    private Animator animator;
    private GameObject[] toHide;

    // Use this for initialization
    void Start()
    {
        boxCollider = GetComponent<Collider>();
        animator = GetComponent<Animator>();
        toHide = GameObject.FindGameObjectsWithTag("toHide");
    }

    // Update is called once per frame
    void Update () {
        if (boxCollider.bounds.Contains(playerTransform.position))
        {
            Debug.Log("collide");
            foreach(GameObject go in toHide)
            {
                go.SetActive(false);
            }
        }
    }
}

