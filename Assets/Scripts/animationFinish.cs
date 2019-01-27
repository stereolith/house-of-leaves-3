using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationFinish : MonoBehaviour {

    public GameObject changer;

    public void OnFadeComplete()
    {
        changer.GetComponent<LevelChanger>().OnFadeComplete();
    }
}
