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
    public AudioClip[] walkingSounds;
    public AudioClip jumpSound;
    public AudioClip damageSound;
    public AudioSource audioSource;
    private float walkSoundDuration;
    private Rigidbody2D rb;
    Animator animator;

    void Awake(){
        animator = GetComponent<Animator>();
        waterController = GetComponent<PlayerWaterController>();
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        float speed;
        if (inWater){
            speed = waterSpeed;
            waterController.Change(30f*Time.deltaTime);
        } 
        else speed = moveSpeed;
        if (waterController.GetWaterValue() <= 0) speed = exhaustedSpeed;
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        if (Input.GetButtonDown("Jump") && controller.isGrounded()){
            jump = true;
            waterController.Change(-6f);
            audioSource.clip = jumpSound;
            audioSource.pitch = 1.1f;
            audioSource.volume = 0.3f;
            audioSource.Play();
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
        if (horizontalMove != 0 && controller.canMove()){
            waterController.Change(-3f * Time.fixedDeltaTime);
            if (controller.isGrounded()){
                if (!audioSource.isPlaying){
                    audioSource.clip = walkingSounds[Random.Range(0,walkingSounds.Length)];
                    audioSource.pitch = 1.7f;
                    audioSource.volume = 0.1f;
                    audioSource.Play();
                }
            }
        } 
    }

    public void SetInWater(bool inWater){
        this.inWater = inWater;
        if (inWater) rb.gravityScale = 0.1f;
        else rb.gravityScale = 3;
        
    }

    public bool IsInWater(){
        return inWater;
    }
}
