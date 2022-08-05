using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    [SerializeField, Min(0f)]
    private float moveSpeed = 40f, waterSpeed = 20f, exhaustedSpeed = 10f;
    float horizontalMove = 0f;
    private PlayerWaterController waterController;
    public bool jump = false, inWater = false;
    Animator animator;

    void Awake(){
        animator = GetComponent<Animator>();
        waterController = GetComponent<PlayerWaterController>();
    }

    void Update(){
        float speed;
        if (inWater){
            speed = waterSpeed;
            waterController.Change(10f*Time.deltaTime);
        } 
        else speed = moveSpeed;
        if (waterController.GetWaterValue() <= 0) speed = exhaustedSpeed;
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        if (Input.GetButtonDown("Jump")){
            jump = true;
            waterController.Change(-6f);
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
        if (horizontalMove != 0) waterController.Change(-3f * Time.fixedDeltaTime);
    }

    public void SetInWater(bool inWater){
        this.inWater = inWater;
    }

    public bool IsInWater(){
        return inWater;
    }
}
