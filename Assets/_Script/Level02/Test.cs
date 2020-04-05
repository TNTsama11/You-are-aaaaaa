using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public TNTDialogController controller;
    private TNTDialog dialog;

    public void Click()
    {
        dialog= controller.ShowDialog();
        dialog.onDialogEnd += TestLog;
    }

    private void TestLog()
    {
        Debug.Log("对话结束");
        dialog.onDialogEnd -= TestLog;
    }
}
