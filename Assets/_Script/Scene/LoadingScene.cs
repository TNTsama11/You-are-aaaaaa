using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LoadingScene : MonoBehaviour
{
    public Image loadingBar;
    public int progressSpeed=1;
    int currentProgress;
    int targetProgress;
    
    void Start()
    {
        loadingBar.fillAmount = 0;
        currentProgress = 0;
        targetProgress = 0;
        StartCoroutine(Loading(Global.targetSceneName));
    }

    private IEnumerator Loading(string targetScene)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(targetScene);
        asyncOperation.allowSceneActivation = false;
        while (asyncOperation.progress < 0.9f)
        {
            targetProgress = (int)(asyncOperation.progress * 100); //会卡在0.89999所以转换成int
            yield return LoadProgress();
        }
        targetProgress = 100;
        yield return LoadProgress();
        asyncOperation.allowSceneActivation = true;
    }

    private IEnumerator<WaitForEndOfFrame> LoadProgress()
    {
        while (currentProgress < targetProgress)
        {
            loadingBar.fillAmount = (float)currentProgress / 100;
            currentProgress+=progressSpeed;
            yield return new WaitForEndOfFrame();
        }
    }
}
