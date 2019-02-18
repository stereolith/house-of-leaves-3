using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookSelectTitle : MonoBehaviour
{

    public Image progressCircle;

    public float timeToSelect = 3f;
    public float regainHitTimeout = 1f;
    private float regainHitCountdown;
    private bool selecting = false;
    private float timeOnTarget = 0f;
    private Animator animator;

    private Transform target;

    void Update()
    {
        GameObject hit = RaycastSelect();
        if (hit != null)
        {
            target = hit.transform;
            bool changeScene = hit.GetComponent<WalkTarget>().getChangeScene();
            if (changeScene)
            {
                Debug.Log("change scene");
                GameObject.Find("LevelChanger").GetComponent<LevelChanger>().NextScene();
            }
        }
    }

    public GameObject RaycastSelect()
    {
        RaycastHit hit;
        Ray lookRay = new Ray(transform.position, transform.forward);
        int layerMask = 1 << 9; //only hit layer 9: "WalkTarget"

        if (Physics.Raycast(lookRay, out hit, layerMask) && hit.collider.tag == "moveTarget" && !hit.collider.bounds.Contains(transform.position)) //raycast hit moveTarget target
        {
            selecting = true;
            regainHitCountdown = regainHitTimeout;
            timeOnTarget += Time.deltaTime;
            UpdateProgressCircle();
            if (timeOnTarget >= timeToSelect)
            {
                Debug.Log("Succesfully selected!!");
                selecting = false;
                timeOnTarget = 0f;
                UpdateProgressCircle();
                if (hit.transform.gameObject.GetComponent<InteractionTarget>() != null)
                {
                    hit.transform.gameObject.GetComponent<InteractionTarget>().Selected();
                    return null;
                }
                return hit.transform.gameObject;
            }
        }
        else if (selecting)
        {
            regainHitCountdown -= Time.deltaTime;
            if (regainHitCountdown <= 0)
            {
                selecting = false;
                regainHitCountdown = regainHitTimeout;
                timeOnTarget = 0f;
                UpdateProgressCircle();
                Debug.Log("sorry, Timeout!");

            }
        }
        return null;
    }

    void UpdateProgressCircle()
    {
        progressCircle.fillAmount = timeOnTarget / timeToSelect;
    }

    static public float CircularEaseOut(float p)
    {
        return Mathf.Sqrt((2 - p) * p);
    }
}
