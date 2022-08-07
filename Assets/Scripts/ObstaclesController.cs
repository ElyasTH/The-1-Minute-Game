using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    public Transform takePosition;
    public GameObject player;
    private bool isTaken;
    [HideInInspector]
    public bool isThrown;
    private Rigidbody2D rb;
    private Damager damager;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        damager = GetComponent<Damager>();
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
        isThrown = true;
        rb.gravityScale = 2f;
        int sign = 0;
        if (player.GetComponent<CharacterController2D>().isFacingRight()) sign = 1;
        else sign = -1;
        rb.AddForce(new Vector3(sign*3000f, 2000f, 0f));
        StartCoroutine(ResetLayer());
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.layer == 0 && !isTaken){
            isThrown = false;
        }

        if (gameObject.tag == "CannonBall") return;
        var objectToDamage = collision.gameObject.GetComponent<Damageable>();
        if (isThrown && objectToDamage != null && isThrown){
            damager?.Damage(objectToDamage);
        } 
    }

    private IEnumerator ResetLayer(){
        yield return new WaitForSeconds(0.2f);
        if (gameObject.tag == "Obstacle") gameObject.layer = 8;
        else gameObject.layer = 11;
    }
}
