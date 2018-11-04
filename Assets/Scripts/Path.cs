using System.Collections;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class Path : MonoBehaviour {

    private Transform[] nodes;

    private void Start()
    {
        nodes = GetComponentsInChildren<Transform>();
    }

    private void OnDrawGizmos() //each frame camera is moving in scene view
    {
        for (int i = 0; i < nodes.Length - 1; i++)
        {
            Handles.DrawDottedLine(nodes[i].position, nodes[i + 1].position, 3.0f);
        }
    }
}
