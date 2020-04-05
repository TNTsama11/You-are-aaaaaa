using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{

    public Button startGameButton;
    public Button exitGameButton;
    public Button textButton;
    public GameObject Levels;
    public Text messageText;
    public GameObject[] poems;
    //点击计数
    private int clickCount = 0;

    private bool isCanExit=false;
    
    void Awake()
    {
        startGameButton.onClick.AddListener(OnStartBtnClick);
        exitGameButton.onClick.AddListener(OnExitBtnClick);
        textButton.onClick.AddListener(OnTextBtnClick);
        textButton.gameObject.SetActive(false);
    }

    private void OnTextBtnClick()
    {
        Debug.Log("游戏已退出");
        Application.Quit();
    }

    private void OnExitBtnClick()
    {
        if (isCanExit)
        {
            return ;
        }
        System.Random random = new System.Random();
        int i = random.Next(1, 7);
        Debug.Log(i);
        messageText.text = GetMessage(i);       
    }

    private void OnStartBtnClick()
    {
        messageText.text = string.Empty;
        Levels.GetComponent<UIAnimation>().StartInAnimation(()=>{
            foreach(var item in poems)
            {
                item.SetActive(true);
                item.GetComponent<Poems>().StartPoems();
            }

        });
    }

    private string GetMessage(int i)
    {
        switch (i)
        {
            case 1:
                return "不，你不想";
            case 2:

                return "退出将会丢失所有进度，所以你不想退出";
            case 3:

                return "你真的要退出？还是再想想吧";

            case 4:

                return "嘿！伙计，冷静点儿，你不想这样";

            case 5:

                return "。。。";
            case 6:
                isCanExit = true;
                textButton.gameObject.SetActive(true);
                return "emm，既然你这么想退出，按“100次ESC”，请";
                
        }
        return "";
    }


    private void CanExit()
    {
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (isCanExit&&Input.GetKeyDown(KeyCode.Escape))
        {
            clickCount++;
            exitGameButton.gameObject.transform.Find("Text").GetComponent<Text>().text = "已按"+clickCount + "次";
            if (clickCount >= 100)
            {
                messageText.text = "天真，你有没有审题啊？";
                clickCount = 0;
                exitGameButton.gameObject.transform.Find("Text").GetComponent<Text>().text = "我想退出";
                isCanExit = false;
            }
        }
    }
}
