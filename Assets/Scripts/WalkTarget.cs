﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkTarget : MonoBehaviour {

    public Transform teleportTarget = null;
    public Hermite_Spline bike_path = null;
    public GameObject bike = null;
    public Hermite_Spline walk_path = null;

    public Transform GetTarget()
    {
        return teleportTarget;
    }
    public Hermite_Spline getBike_path()
    {
        return bike_path;
    }
    public GameObject getBike()
    {
        return bike;
    }
    public Hermite_Spline getWalk_path()
    {
        return walk_path;
    }
}
