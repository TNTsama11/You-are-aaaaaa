using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using UnityEngine.Networking;
using System;

public class LevelsMenu : MonoBehaviour
{
    public GameObject levelCardPfb;
    public Transform levelContent;
    private List<LevelCards> levelsList = new List<LevelCards>();
    public Button cancelButton;
    public GameObject[] poems;

    string path = Application.streamingAssetsPath+ "/LevelData.Json";

    void Awake()
    {
        cancelButton.onClick.AddListener(OnCancelBtnClick);
    }

    private void OnCancelBtnClick()
    {
        foreach (var item in poems)
        {
            item.SetActive(false);
        }
        this.GetComponent<UIAnimation>().StartOutAnimation();
    }

    void Start()
    {
        StartCoroutine(AddLevelCard());
    }

    void Update()
    {
        
    }

    //private void ReadJson(string path)
    //{
    //    StartCoroutine(GetJson(path));
    //}

    //IEnumerator GetJson(string path)
    //{
    //    using (UnityWebRequest request = UnityWebRequest.Get(path))
    //    {
    //        yield return request.SendWebRequest();
    //        JsonData data = JsonMapper.ToObject(request.downloadHandler.text);
    //        AddLevelCard(data);
    //    }
    //}

    private IEnumerator AddLevelCard()
    {
        List<LevelCard> levelCardList = LevelSystem.LoadLevels();
        foreach(var item in levelCardList)
        {
            GameObject go = Instantiate(levelCardPfb, levelContent);
            LevelCards card= go.GetComponent<LevelCards>();
            card.ID = item.ID;
            card.SetName(item.Name);
            card.SetImg(item.BackGroundID);
            if (item.Unlock == 0)
            {
                card.SetActive(false);
            }
            levelsList.Add(card);
        }
        yield return null;
        //int lastLevel=1;
        //if (PlayerPrefs.HasKey("LastLevel"))
        //{
        //    lastLevel = PlayerPrefs.GetInt("LastLevel");
        //}
        //else
        //{
        //    PlayerPrefs.SetInt("LastLevel", 1);
        //}

        //for(int i=lastLevel; i < levelsList.Count; i++)
        //{
        //    levelsList[i].SetActive(false);
        //    levelsList[i].SetButtonActive(false);
        //}

    }
}
