using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed, jumpForce;
    
    [HideInInspector]
    private Rigidbody2D myRB;

    private Animator myAnimator;

    public bool isOnGround, isMoving;
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector2.right * (speed * Time.deltaTime), Space.World);
        }
        
    }

    void Restart()
    {
        GameController tempGameController = FindObjectOfType<GameController>();
        
        if (tempGameController.isDie)
        {
            tempGameController.isDie = false;
            myAnimator.SetBool("Die", false);
        }
    }

    void Die()
    {
        GameController tempGameController = FindObjectOfType<GameController>();
        if (tempGameController.isDie)
        {
            isMoving = false;
            myAnimator.SetBool("Die", true);
            myAnimator.SetBool("Run", false);
        }
    }
    
    private void Initialize()
    {
        myRB = this.gameObject.GetComponent<Rigidbody2D>();
        myAnimator = this.gameObject.GetComponent<Animator>();
        isOnGround = true;
        isMoving = false;
        GameController tempGameController = FindObjectOfType<GameController>();
        tempGameController.isDie = false;


        InvokeRepeating("CheckOnGround", 0.1f, 0.1f);
        InvokeRepeating("Run", 0.1f, 0.1f);
        InvokeRepeating("Die", 0.1f, 0.1f);

    }

    void Run()
    {
        if (isMoving)
        {
            myAnimator.SetBool("Run", true);
            GameController tempGameController = FindObjectOfType<GameController>();
            tempGameController.gameStart = true;
            return;
        }
    }

    public void Jump()
    {
        if(myRB.velocity.y == 0 && isMoving)
        {
            myRB.AddForce(transform.up * jumpForce);
            isOnGround = false;
            myAnimator.SetBool("Jump", true);
        }
    }

    void CheckOnGround()
    {
        if(myRB.velocity.y == 0 && !isOnGround)
        {
            isOnGround = true;
            myAnimator.SetBool("Jump", false);
        }
    }
}
