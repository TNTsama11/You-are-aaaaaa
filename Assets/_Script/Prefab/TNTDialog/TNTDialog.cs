using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TNTDialog : MonoBehaviour
{
    public Text dialogText; //显示的文字
    public Button nextBtn; //继续按钮
    public Image characterImg; //头像
    public Text tittleText; //标题
    private bool autoPlay; //自动播放
    private float autoPlaySleep; //自动播放暂停时间
    private bool hideAtEnd; //对话结束时是否自动隐藏

    public string[] scentences; //保存对话语句
    private int index; //语句索引
    private float speed;

    public delegate void DialogHandler();
    public event DialogHandler onDialogEnd;
    
    void Awake()
    {
        nextBtn.onClick.AddListener(OnNextBtnClicked);
        HideDialog();
    }


    public void ShowDialog(string scentencesName,float typingSpeed)
    {
        this.gameObject.SetActive(true);
        scentences = LoadScentences(scentencesName);
        speed = typingSpeed;
        StartCoroutine(Type());
    }


    public void HideDialog()
    {
        this.gameObject.SetActive(false);
    }


    private IEnumerator Type() //逐字显示
    {
        nextBtn.gameObject.SetActive(false);
        dialogText.text = string.Empty;     
        foreach (char word in scentences[index])
        {
            dialogText.text += word;
            yield return new WaitForSeconds(speed);
        }

        if (autoPlay)
        {
            yield return new WaitForSeconds(autoPlaySleep);
            Next();
        }
        else
        {
            nextBtn.gameObject.SetActive(true);
        }
        
    }


    private void OnNextBtnClicked()
    {
        Next();
    }


    private void Next()
    {
        if (scentences.Length > index + 1)
        {
            index++;
            StartCoroutine(Type());
        }
        else
        {
            if (hideAtEnd)
            {
                HideDialog();
            }
            index = 0;

            if (onDialogEnd != null)
            {
                onDialogEnd();
            }
        }
    }


    public void SetAutoPlay(bool a,float sleep)
    {
        autoPlay = a;
        autoPlaySleep = sleep;
    }


    public void SetHideAtEnd(bool a)
    {
        hideAtEnd = a;
    }


    public void SetTittle(string tittle)
    {
        tittleText.text = tittle;
    }


    public void SetCharacterImg(Sprite img)
    {
        if (img != null)
        {
            characterImg.sprite = img;
        }
    }


    public  string[] LoadScentences(string name)
    {
        string fileContents = ReadDialogData(name);
        if (fileContents == string.Empty)
        {
            return new string[0];
        }
        TNTDialogData data = JsonMapper.ToObject<TNTDialogData>(fileContents);
        string[] scentences = data.Scentences.ToArray();
        return scentences;
    }


    private string ReadDialogData(string name)
    {
        try
        {
            string path = Application.streamingAssetsPath + "/DialogData_" + name + ".Json";
            if (!File.Exists(path))
            {
                return null;
            }
            using (StreamReader file = new StreamReader(path))
            {
                string fileContents = file.ReadToEnd();
                return fileContents;
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
            return string.Empty;
        }

    }

}
