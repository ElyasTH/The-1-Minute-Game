using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public CharacterController2D controller;

    public float speed = 35f;
    private float horizontalMove = 0f;
    private Animator animator;
    private Damager damager;

    void Awake(){
        animator = GetComponent<Animator>();
        damager = GetComponent<Damager>();
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
        if ((col.gameObject.tag == "Obstacle" && !col.gameObject.GetComponent<ObstaclesController>().isThrown) ||
            col.gameObject.tag == "Player"){
            animator.SetTrigger("attack");
            damager.Damage(col.gameObject.GetComponent<Damageable>());
            StartCoroutine(controller.StopMovingFor(0.8f));
        }
    }
}
