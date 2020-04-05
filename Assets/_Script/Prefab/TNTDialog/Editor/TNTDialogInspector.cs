using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TNTDialogController))]
public class TNTDialogInspector : Editor
{
    TNTDialogController mTarget;


    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        mTarget = target as TNTDialogController;
        mTarget.CharacterImg = EditorGUILayout.ObjectField("Character", mTarget.CharacterImg, typeof(Sprite), true) as Sprite;
        mTarget.HideAtEnd = EditorGUILayout.Toggle("HideAtEnd", mTarget.HideAtEnd);
        mTarget.AutoPlay = EditorGUILayout.Toggle("AutoPlay", mTarget.AutoPlay);
        if (mTarget.AutoPlay)
        {
            mTarget.AutoPlaySleep = EditorGUILayout.FloatField("Sleep", mTarget.AutoPlaySleep);
        }
    }

}
