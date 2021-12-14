using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerProperties playerproperties;
    [SerializeField] float speed;
    [SerializeField] float normalspeed;
    [SerializeField] float jumpSpeed;
    [SerializeField]  Rigidbody2D rb; 
    [SerializeField] bool isGrounded;

    private void Awake()
    {        
        
        rb = GetComponent<Rigidbody2D>();
        isGrounded = false;
        speed = playerproperties.speedmove;
        jumpSpeed = playerproperties.jumpSpeed;
        normalspeed = speed;
    }

    void Start()
    {
        speed = 0;
    }

    public void OnLeftButtonDown()
    {
        if (speed >= 0)
        {
            speed = -normalspeed;
        }
    }
    public void OnRightButtonDown()
    {
        if (speed <= 0)
        {
            speed = normalspeed;
        }
    }

    public void OnButtonUp()
    {
        speed = 0f;
    }
    public void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = Vector3.up * jumpSpeed;
        }
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector3(speed, rb.velocity.y);
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Platform"))
        {
            transform.parent=collision.transform;
            isGrounded = true;
        }

    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Platform"))
        {
            transform.parent=null;
            isGrounded = false;
        }
    }  
   
}






