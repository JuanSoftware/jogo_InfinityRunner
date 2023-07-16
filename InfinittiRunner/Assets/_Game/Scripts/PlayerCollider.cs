using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Obstacle"))
        {
            GameController tempGameController = FindObjectOfType<GameController>();
            tempGameController.isDie = true;
        }
    }
}
