using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public TNTDialogController dialogController;
    public GameObject baseView;
    public GameObject tips;
    public Faucet faucet;
    private TNTDialog dialog;


    void Start()
    {
        baseView.SetActive(false);
        tips.SetActive(false);
        dialog = dialogController.ShowDialog();
        dialog.onDialogEnd += OnDialogEnd;
    }

    private void OnDialogEnd()
    {
        baseView.SetActive(true);
        dialogController.ScentencesName = "s2s2";
        dialogController.ShowDialog();
        dialog.onDialogEnd -= OnDialogEnd;
        dialog.onDialogEnd += StartGame;
    }

    private void StartGame()
    {
        LineManager.Instance.isDraw = true;
        faucet.FaucetOn();
        tips.SetActive(true);
        dialog.onDialogEnd -= StartGame;
    }

    void Update()
    {
        
    }


}
