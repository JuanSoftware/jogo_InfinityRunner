using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed, jumpForce;
    
    [HideInInspector]
    private Rigidbody2D myRB;

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
            Debug.Log("Tecla Espaço pressionada!");
        }
    }

    void Restart()
    {
        if (isDie)
        {
            isDie = false;
            //animação de dead false
        }
    }

    void Die()
    {
        if (isDie)
        {
            isMoving = false;
            //animação de dead true
            //animação de run false
        }
    }
    
    private void Initialize()
    {
        myRB = this.gameObject.GetComponent<Rigidbody2D>();
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
            //animacao run true
            return;
        }
    }

    public void Jump()
    {
        if(myRB.velocity.y == 0 && isMoving)
        {
            myRB.AddForce(transform.up * jumpForce);
            isOnGround = false;
            //animação de pulo true
        }
    }

    void CheckOnGround()
    {
        if(myRB.velocity.y == 0 && !isOnGround)
        {
            isOnGround = true;
            //Animação de pulo false
        }
    }
}
