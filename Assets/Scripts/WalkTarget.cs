using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkTarget : MonoBehaviour {

    public Transform teleportTarget = null;

    public Transform GetTarget()
    {
        return teleportTarget;
    }
}
