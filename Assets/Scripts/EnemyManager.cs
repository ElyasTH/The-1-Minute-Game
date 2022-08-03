using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public CharacterController2D controller;

    public float speed = 35f;
    private float horizontalMove = 0f;
    private Animator animator;

    void Awake(){
        animator = GetComponent<Animator>();
    }

    void Update(){
        horizontalMove = 1f * speed;
        if (horizontalMove != 0) animator.SetBool("isRunning", true);
        else animator.SetBool("isRunning", false);
    }

    void FixedUpdate(){
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
    }

    void OnCollisionEnter2D(Collision2D col){
        var otherRB = col.gameObject.GetComponent<Rigidbody2D>();
        var otherTag = col.gameObject.tag;
        if (otherRB != null && otherTag == "Obstacle" && otherRB.velocity.magnitude > 1) Destroy(this.gameObject);
        else if(otherTag == "Obstacle") animator.SetTrigger("attack");
    }
}
