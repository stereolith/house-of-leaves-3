﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

    public Animator an_top;
    public Animator an_bot;

    public bool rightMouseToAdvance = false;

    private int levelToLoad;

    void Update ()
    {
        if(Input.GetMouseButtonDown(1) && rightMouseToAdvance)
        {
            FadeToLevel(0);
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
	
    public void NextScene()
    {
        Debug.Log("next scene");
        Debug.Log(SceneManager.sceneCountInBuildSettings);
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        if (SceneManager.sceneCountInBuildSettings == SceneManager.GetActiveScene().buildIndex + 1)
        {
            FadeToLevel(1);
        }
        else
        {
            FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        an_bot.SetTrigger("close");
        an_top.SetTrigger("close");
    }  
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
