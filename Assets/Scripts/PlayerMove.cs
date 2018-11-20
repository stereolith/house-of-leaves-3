using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {

    public Image progressCircle;

    public float timeToSelect = 1000f;
    public float regainHitTimeout = 50f;
    private float regainHitCountdown;
    private bool selecting;
    private float timeOnTarget = 0f;

    void Awake()
    {
        regainHitCountdown = regainHitTimeout;
    }

    void Update()
    {
        RaycastHit hit;
        Ray lookRay = new Ray(transform.position, transform.forward);

        if(Physics.Raycast(lookRay, out hit))
        {
            if(hit.collider.tag == "moveTarget")
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
                }
            } else if (selecting)
            {
                regainHitCountdown -= Time.deltaTime;
                if (regainHitCountdown <= 0)
                {
                    selecting = false;
                    regainHitCountdown = regainHitTimeout;
                    timeOnTarget = 0f;
                    Debug.Log("sorry, Timeout!");
                }
            }
        }
    }

    void UpdateProgressCircle()
    {
        progressCircle.fillAmount = timeOnTarget / timeToSelect;
    }
}
