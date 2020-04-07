using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTDialogController : MonoBehaviour
{

    public TNTDialog Dialog;

    public string Tittle;
    [HideInInspector]
    public Sprite CharacterImg;

    public string ScentencesName; //台词名字
    [Range(1, 100)]
    public int TypingSpeed;
    [HideInInspector]
    public bool HideAtEnd;
    [HideInInspector]
    public bool AutoPlay;
    [HideInInspector]
    public float AutoPlaySleep;



    public TNTDialog ShowDialog()
    {
        float typeSpeed = 1f / TypingSpeed;
        Dialog.SetHideAtEnd(HideAtEnd);
        Dialog.SetAutoPlay(AutoPlay, AutoPlaySleep);
        Dialog.SetTittle(Tittle);
        Dialog.SetCharacterImg(CharacterImg);
        Dialog.ShowDialog(ScentencesName, typeSpeed);
        return Dialog;
    }
   
}
