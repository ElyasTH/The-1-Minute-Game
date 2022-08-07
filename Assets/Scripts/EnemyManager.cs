using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public CharacterController2D controller;
    private Transform underWater;
    public float speed = 35f;
    private float horizontalMove = 0f;
    private Animator animator;
    private Damager damager;
    public AudioClip[] walkingSounds;
    public AudioClip attackSound;
    private AudioSource audioSource;

    void Awake(){
        animator = GetComponent<Animator>();
        damager = GetComponent<Damager>();
        underWater = GameObject.FindGameObjectWithTag("UnderWater").transform;
        audioSource = GetComponent<AudioSource>();
    }

    void Update(){
        if (underWater.position.x > transform.position.x) horizontalMove = speed;
        else horizontalMove = -speed;
        if (horizontalMove != 0) animator.SetBool("isRunning", true);
        else animator.SetBool("isRunning", false);
    }

    void FixedUpdate(){
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
        if (controller.isGrounded() && controller.canMove()){
            if (!audioSource.isPlaying){
                audioSource.clip = walkingSounds[Random.Range(0,walkingSounds.Length)];
                audioSource.pitch = 0.75f;
                audioSource.volume = 0.25f;
                audioSource.Play();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if ((col.gameObject.tag == "Obstacle" && !col.gameObject.GetComponent<ObstaclesController>().isThrown) ||
            (col.gameObject.tag == "Player" && !col.gameObject.GetComponent<PlayerAction>().isAttacking())){
            animator.SetTrigger("attack");
            damager.Damage(col.gameObject.GetComponent<Damageable>());
            audioSource.clip = attackSound;
            audioSource.pitch = 1.3f;
            audioSource.volume = 0.35f;
            audioSource.Play();
            StartCoroutine(controller.StopMovingFor(0.8f));
        }
    }
}
