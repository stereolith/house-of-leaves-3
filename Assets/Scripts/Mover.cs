using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    public Hermite_Spline spline;
    public bool moving = false;
    public bool goToFootOnFinish = true;
    public bool changeSceneOnFinish = false;
    public GameObject toInstantiate;

    private int currentTargetNode = 1;
    public float moveSpeed = 50;
    public float rotateSpeed = 6;
    public int rotateEvery = 5;
    private bool isCompleted;
    private float transition;

    Vector3 newDir;

    private void Awake()
    {
        //transform.position = spline.nodes[0];
    }

    private void Update()
    {
        if (!spline || !moving)
            return;
        if (!isCompleted)
        {
            Play();
        }
    }

    public void setMoving(bool mov)
    {
        moving = mov;
    }

    private void enableLookSelect()
    {

    }

    private void Play()
    {
        if(currentTargetNode == spline.nodes.Count)
        {
            spline = null;
            isCompleted = true;
            Debug.Log("bike path end reached");
            if(changeSceneOnFinish)
            {
                GameObject.Find("LevelChanger").GetComponent<LevelChanger>().NextScene();
            }
            if(goToFootOnFinish)
            {
                //Instantiate(toInstantiate, transform.position, transform.rotation);
                //GameObject.Find("first-person").gameObject.SetActive(false);
                GameObject player = GameObject.Find("Player");
                player.transform.position = transform.position;
                player.transform.position = new Vector3(player.transform.position.x - 10, player.transform.position.y, player.transform.position.z);
                player.GetComponentInChildren<Camera>().enabled = true;
                //GameObject.Find("Player(Clone)").get
                //GameObject.Find("Player(Clone)/Camera").gameObject.SetActive(true);

                Debug.Log("goToFootOnFinish");

            }
            return;
        }
        float moveStep = moveSpeed * Time.deltaTime;
        float rotateStep = rotateSpeed * Time.deltaTime;

        Quaternion toRotation = new Quaternion();
        Quaternion lastRotation = transform.rotation;

        //position
        transform.position = Vector3.MoveTowards(transform.position, spline.nodes[currentTargetNode], moveStep);

        if (transform.position == spline.nodes[currentTargetNode])
        {
            currentTargetNode++;
        }

        Quaternion currentRotation = transform.rotation;

        Vector3 targetDir = spline.nodes[currentTargetNode + rotateEvery] - transform.position;
        newDir = Vector3.RotateTowards(transform.forward, targetDir, rotateStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
