using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeHole : MonoBehaviour
{
    private SpriteRenderer mySpriteRender;
    private void Awake()
    {
        mySpriteRender = this.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.name);
        mySpriteRender.DOColor(Color.red, 0.2f).SetLoops(4,LoopType.Yoyo);

    }

}
