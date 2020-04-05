using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class StarHole : MonoBehaviour
{
    public Transform starHolePoint;
    public Button nextBtn;

    private void Awake()
    {
        nextBtn.onClick.AddListener(OnNextBtnClick);
    }

    private void OnNextBtnClick()
    {
        SceneLoadManager.LoadingSceneCallBack callback = new SceneLoadManager.LoadingSceneCallBack(UnlockNextLevel);
        SceneLoadManager.LoadScene(2,callback);
    }

    private void UnlockNextLevel()
    {
        LevelSystem.SetLevelsStatus(2, true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject go = collision.gameObject;
        this.transform.DOScale(2f, 0.5f).SetEase(Ease.InOutElastic).OnComplete(()=> {
            go.GetComponent<FllowMouse>().isGrab = true;
            go.GetComponent<FllowMouse>().isFollow = false;
            go.GetComponent<Rigidbody2D>().simulated=false;
            go.transform.position = this.transform.position;
            go.transform.parent = this.transform;
            this.transform.DOScale(0.5f, 0.5f).OnComplete(()=> {
                this.transform.DOLocalRotate(new Vector3(0, 0, 180f), 0.5f).OnComplete(()=> {
                    this.transform.DOMove(starHolePoint.position, 0.5f).SetEase(Ease.InBounce);
                });
            });
        });
    }
}
