using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float moveSpeed = 40f;
    float horizontalMove = 0f;

    bool jump = false;
    Animator animator;

    void Awake(){
        animator = GetComponent<Animator>();
    }

    void Update(){
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;

        if (Input.GetButtonDown("Jump")){
            jump = true;
        }

        if (horizontalMove != 0)
            animator.SetBool("isRunning", true);
        else 
            animator.SetBool("isRunning", false);

        if (!controller.isGrounded()) animator.SetBool("isJumping", true);
        else animator.SetBool("isJumping", false);
    }

    void FixedUpdate(){
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
