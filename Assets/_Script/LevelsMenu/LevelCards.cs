using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCards : MonoBehaviour
{
    public int ID;
    public string levelName;
    public GameObject mask;
    public Text levelNameText;
    public Button btn;

    public void SetActive(bool act)
    {
        mask.SetActive(!act);
        btn.interactable = act;
    }

    public void SetImg(int id)
    {
        Sprite sprite = Resources.Load<Sprite>("LevelBG/bg" + id);
        if (sprite != null)
        {
            this.GetComponent<Image>().sprite = sprite;
        }
    }

    public void SetName(string name)
    {
        levelName = name;
        levelNameText.text = name;
    }

    private void Start()
    {
        btn.onClick.AddListener(OnBtnClick);
    }

    private void OnBtnClick()
    {
        LoadingScene("Level" + ID);
    }

    private void LoadingScene(string scene)
    {
        Global.targetSceneName = scene;
        SceneManager.LoadScene("Loading");
    }

    //public void SetButtonActive(bool act)
    //{
    //    btn.interactable = act;
    //}
}
