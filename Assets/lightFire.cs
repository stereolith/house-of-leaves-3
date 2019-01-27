using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightFire : MonoBehaviour {

    public void LightFire()
    {
        Debug.Log("light fire");
        GetComponent<Animator>().SetTrigger("lightFire");
    }
}
