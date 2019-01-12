using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class DropToGround : MonoBehaviour {

    public GameObject ground;
    private Transform[] nodes;

    void Start()
    {

    }

	void Update () {
        nodes = GetComponentsInChildren<Transform>();
        foreach (Transform node in nodes)
        {
            RaycastHit hit;
            Ray lookRay = new Ray(node.position, Vector3.down);
            Physics.Raycast(lookRay, out hit);
            if(hit.transform == ground.transform)
            {
                Debug.Log(hit.transform);
                Debug.Log(node.position.y);
                node.position = new Vector3(node.position.x, hit.point.y, node.position.z);
                Debug.Log("set position to y ");
                Debug.Log(hit.point.y);
            }
            
            //if (hit !== null && hit.collider.gameObject == ground)
            //{
            //    Debug.Log("Hit Ground!");
            //}
        }
        


    }
}
