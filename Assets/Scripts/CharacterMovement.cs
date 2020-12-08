using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController2D controller;
    
    public float speed = 10f;
    float horizontalMove;
    

    bool jump = false;
    bool canJump = true;
    bool jumpDown = false;
    
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal")* speed;
    
        if (Input.GetKeyDown("w") & canJump)
        {
            jump = true;
            canJump = false;
        }
        if (Input.GetButtonDown("Jump") || Input.GetKeyDown("s"))
        {
            jumpDown = true;
        }
    
    
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump, jumpDown);
        jump = false;
        jumpDown = false;
    
    }
    
    private void FixedUpdate()
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "ground")
        {
            canJump = true;
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.transform.tag == "ground")
        {
            canJump = false;
        }
    }

}
