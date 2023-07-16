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

    public bool isOnGround, isMoving, isDie;
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            
        }
    }

    void Restart()
    {
        if (isDie)
        {
            isDie = false;
            myAnimator.SetBool("Die", false);
        }
    }

    void Die()
    {
        if (isDie)
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
        isDie = false;

        InvokeRepeating("CheckOnGround", 0.1f, 0.1f);
        InvokeRepeating("Run", 0.1f, 0.1f);
        InvokeRepeating("Die", 0.1f, 0.1f);

    }

    void Run()
    {
        if (isMoving)
        {
            myAnimator.SetBool("Run", true);
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
