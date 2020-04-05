using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoadManager
{

    public delegate void LoadingSceneCallBack();

   public static void LoadScene(int levelID,LoadingSceneCallBack callback)
    {
        
        Global.targetSceneName = "Level"+levelID;
        SceneManager.sceneLoaded += (Scene scene,LoadSceneMode mode)=> {
            callback();
        };
        SceneManager.LoadScene("Loading");
    }

}
