using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    private Animator animator;
    
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        open();
    }

    public void open()
    {
        animator.SetBool("openDoor", true);
    }

    public void clode()
    {
        animator.SetBool("closeDoor", true);
    }
}
