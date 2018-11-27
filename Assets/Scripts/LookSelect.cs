using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookSelect : MonoBehaviour {

    public Image progressCircle;

    public float timeToSelect = 3f;
    public float regainHitTimeout = 1f;
    private float regainHitCountdown;
    private bool selecting = false;
    private float timeOnTarget = 0f;
    private Animator animator;

    public GameObject RaycastSelect()
    {
        RaycastHit hit;
        Ray lookRay = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(lookRay, out hit) && hit.collider.tag == "moveTarget" && !hit.collider.bounds.Contains(transform.position)) //raycast hit moveTarget target
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
                StopEmission(hit);
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

    void StopEmission(RaycastHit hit)
    {
        //Stop Particle Emission at target
        ParticleSystem targetParticles = hit.transform.GetComponent<ParticleSystem>();
        var emission = targetParticles.emission;
        emission.rateOverTime = 0;
    }

    /*void UpdateProgress() //Manipulate emission/lifetime/speed at lookselect
    {
        float ease = CircularEaseOut(timeOnTarget / timeToSelect);

        var emission = targetParticles.emission;
        var main = targetParticles.main;

        float rate = 5f + ease * 20f;
        float startLifetime = 2f + ease * 2f;
        float startSpeed = 5f + ease * 10f;

        emission.rate = rate;
        main.startLifetime = startLifetime;
        main.startSpeed = startSpeed;
    }*/
    void UpdateProgressCircle()
    {
        progressCircle.fillAmount = timeOnTarget / timeToSelect;
    }

    static public float CircularEaseOut(float p)
    {
        return Mathf.Sqrt((2 - p) * p);
    }
}
