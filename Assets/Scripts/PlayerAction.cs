using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAction : MonoBehaviour
{   
    private GameObject touchingObject;
    private GameObject takenObject;
    private PlayerWaterController waterController;
    private CharacterController2D controller;
    private DoorController touchingDoor;
    private Damager damager;
    private bool isExhausted;
    private Animator animator;
    private Rigidbody2D rb;
    private bool attack = false;
    public AudioClip attackSound;
    private AudioSource audioSource;
    public float attackForce = 4500f;

    void Awake(){
        waterController = GetComponent<PlayerWaterController>();
        controller = GetComponent<CharacterController2D>();
        damager = GetComponent<Damager>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }
    
    void Update(){
        if (waterController.GetWaterValue() <= 0){
            isExhausted = true;
            if (takenObject != null) takenObject.GetComponent<ObstaclesController>().Throw();
            takenObject = null;
        }
        else isExhausted = false;
        if (controller.canMove()){
            if (Input.GetButtonDown("Use")){
                if (touchingObject != null && takenObject == null && touchingObject.tag != "Cannon" && !isExhausted){
                    takenObject = touchingObject;
                    touchingObject.GetComponent<ObstaclesController>().Take();
                }
                else if (takenObject != null){
                    takenObject.GetComponent<ObstaclesController>().Throw();
                    takenObject = null;
                    waterController.Change(-6f);
                }
                else if (touchingObject?.tag == "Cannon"){
                    touchingObject?.GetComponent<CannonController>().Shoot();
                }
            }
            else if (Input.GetButtonDown("Enter")){
                touchingDoor?.Travel(transform);
            }
            else if (Input.GetButtonDown("Attack") && !attack && !isExhausted && controller.isGrounded()){
                animator.SetTrigger("Attack");
                int direction = 0;
                if (controller.isFacingRight()) direction = 1;
                else direction = -1;
                rb.AddForce(new Vector2(direction*attackForce, 0));
                attack = true;
                waterController.Change(-35f);
                audioSource.clip = attackSound;
                audioSource.pitch = 2f;
                audioSource.volume = 0.5f;
                audioSource.Play();
            }
        }

        if (takenObject != null) waterController.Change(-5f * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "CannonBall" || collision.gameObject.tag == "Cannon"){
            touchingObject = collision.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "CannonBall" || collision.gameObject.tag == "Cannon"){
            touchingObject = null;
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if (attack){
            Damageable damageableObject = col.gameObject.GetComponent<Damageable>();
            if (damageableObject != null) damager.Damage(damageableObject);
            UnAttack();
        }
    }

    public void SetDoor(DoorController doorController){
        this.touchingDoor = doorController;
    }

    public void UnAttack(){
        attack = false;
    }

    public bool isAttacking(){
        return attack;
    }
}
