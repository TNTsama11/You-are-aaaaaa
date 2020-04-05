using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public enum Levels
{
    Level01,
    Level02,
    Level03,
}

public class TipsBtn : MonoBehaviour
{
    public GameObject tips;
    public Text tipsText;
    private bool isShow = false;
    string path = Application.streamingAssetsPath + "/TipsData.Json";
    public Levels levels;

    void Awake()
    {
        this.GetComponent<Button>().onClick.AddListener(OnTipsBtnClick);
    }

    private void OnTipsBtnClick()
    {
        if (isShow)
        {
            tips.SetActive(false);
            isShow = false;
        }
        else
        {
            tips.SetActive(true);
            isShow = true;
            if (tipsText.text != string.Empty)
            {
                return;
            }
            StartCoroutine(GetData(path));
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    IEnumerator GetData(string path)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(path))
        {
            yield return request.SendWebRequest();
            JsonData data = JsonMapper.ToObject(request.downloadHandler.text);
            tipsText.text = data[Enum.GetName(typeof(Levels),levels)]["Data"].ToString();
        }
    }
}
