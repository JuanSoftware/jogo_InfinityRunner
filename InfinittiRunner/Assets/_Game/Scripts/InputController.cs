using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    // Start is called before the first frame update
    private Player myPlayer;

    private GameController gameController;

    private UiController uiController;
    void Start()
    {
        myPlayer = FindAnyObjectByType<Player>();
        gameController = FindAnyObjectByType<GameController>();
        uiController = FindObjectOfType<UiController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (!myPlayer.isMoving && !gameController.isDie)
            {
                myPlayer.isMoving = true;
                uiController.txtTap.gameObject.SetActive(false);
            }
            else
            {
                myPlayer.Jump();
            }
                
            }
    }
}
