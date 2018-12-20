﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

    public Animator an_top;
    public Animator an_bot;

    private int levelToLoad;

    void Update ()
    {
        if(Input.GetMouseButtonDown(0))
        {
            FadeToLevel(0);
        }
    }
	
    public void NextScene()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
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
