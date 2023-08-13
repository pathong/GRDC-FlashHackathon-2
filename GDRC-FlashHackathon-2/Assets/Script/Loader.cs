using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    public enum Scene
    {
        DayScenes, NightScene, Loading, Question, RunBars, CollectChocolate, StartScene, EndScene
    }
    private static Action onLoaderCallback;
    public static void Load(Scene scene)
    {
        onLoaderCallback = () => {
            SceneManager.LoadScene(Scene.Loading.ToString());
        };
        SceneManager.LoadScene(scene.ToString());
    }

    public static void LoaderCallback()
    {
        if (onLoaderCallback != null){
            onLoaderCallback(); 
            onLoaderCallback = null;
        }
    }
}
