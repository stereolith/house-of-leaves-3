using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTarget : MonoBehaviour {

    public void Selected()
    {
        Debug.Log("interaction target selected");
        Animator[] animators = transform.parent.GetComponentsInChildren<Animator>();
        GetComponent<BoxCollider>().enabled = false;
        foreach(Animator a in animators)
        {
            a.SetTrigger("startSpiral");
            a.SetTrigger("fadeInOeffnung");
        }
    }
}
