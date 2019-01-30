using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wendeltreppeAnimationFinish : MonoBehaviour {

    private GameObject walkTarget;

    void Awake()
    {
        walkTarget = GameObject.Find("walkTarget_walkPath");
        walkTarget.SetActive(false);
    }

	public void handleANimationFinish()
    {
        Debug.Log(walkTarget);
        walkTarget.SetActive(true);
    }
}
