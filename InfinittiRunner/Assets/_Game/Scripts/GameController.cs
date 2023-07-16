using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public float playerScore;

    public bool gameStart,isDie;
    
    void Start()
    {
        playerScore = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart && !isDie)
        {
            playerScore += Time.deltaTime;
        }
    }
}
