using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiController : MonoBehaviour
{
    public TMP_Text txtScore, txtTap;

    private GameController gameController;
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        txtScore.text = gameController.playerScore.ToString("0") + "m";
    }
}
