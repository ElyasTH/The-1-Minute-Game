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

    }

    void FixedUpdate(){
        
    }
}
