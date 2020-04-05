using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIAnimation : MonoBehaviour
{
    private bool isShow=false;
    public Transform outPos;
    public Transform inPos;
    [Range(0f,2f)]
    public float time;
    public Ease ease = Ease.Linear;

    public delegate void CallBack();
    /// <summary>
    /// 进入动画
    /// </summary>
    /// <param name="callBack">回调</param>
    public void StartInAnimation(CallBack callBack=null)
    {
        if (isShow)
        {
            return;
        }
        isShow = true;
        this.transform.DOMove(inPos.position,time).SetEase(ease).OnComplete(()=> {
            if (callBack != null)
            {
                callBack();
            }
        });
    }
    /// <summary>
    /// 离开动画
    /// </summary>
    /// <param name="callBack">回调</param>
    public void StartOutAnimation(CallBack callBack = null)
    {
        if (!isShow)
        {
            return;
        }
        isShow = false;
        this.transform.DOMove(outPos.position, time).SetEase(ease).OnComplete(() => {
            if (callBack != null)
            {
                callBack();
            }
        });
    }

    void Awake()
    {
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
