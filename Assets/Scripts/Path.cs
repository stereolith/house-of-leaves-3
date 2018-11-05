using System.Collections;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class Path : MonoBehaviour {

    public Transform[] nodes;

    private void Start()
    {
        nodes = GetComponentsInChildren<Transform>();
    }

    public Vector3 LinearPosition(int seg, float ratio)
    {
        Vector3 p1 = nodes[seg].position;
        Vector3 p2 = nodes[seg + 1].position;

        return Vector3.Lerp(p1 ,p2 ,ratio);
    }

    public Quaternion Orientation(int seg, float ratio)
    {
        Quaternion q1 = nodes[seg].rotation;
        Quaternion q2 = nodes[seg + 1].rotation;

        return Quaternion.Lerp(q1, q2, ratio);
    }

    private void OnDrawGizmos() //each frame camera is moving in scene view
    {
        for (int i = 0; i < nodes.Length - 1; i++)
        {
            Handles.DrawDottedLine(nodes[i].position, nodes[i + 1].position, 3.0f);
        }
    }
}
