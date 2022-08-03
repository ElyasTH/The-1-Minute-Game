using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    public Transform takePosition;
    public GameObject player;
    private bool isTaken;
    private Rigidbody2D rb;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    void Update(){
        if (isTaken){
            transform.position = takePosition.position;
            rb.velocity = Vector2.zero;
        }
    }

    public void Take(){
        isTaken = true;
        gameObject.layer = 6;
        rb.gravityScale = 0f;
        rb.freezeRotation = true;
    }

    public void Throw(){
        isTaken = false;
        rb.gravityScale = 2f;
        int sign = 0;
        if (player.GetComponent<CharacterController2D>().isFacingRight()) sign = 1;
        else sign = -1;
        rb.AddForce(new Vector3(sign*3000f, 2000f, 0f));
        // rb.freezeRotation = false;
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.layer == 0 && !isTaken){
            gameObject.layer = 0;
        }
    }

}
