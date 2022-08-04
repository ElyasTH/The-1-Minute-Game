using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField]
    float health = 5f, damageForceX = 100f, damageForceY = 100f, downTime = 2f;

    private Rigidbody2D rb;
    private Animator animator;
    private CharacterController2D controller;
    public GameObject destroyedPrefab;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController2D>();
    }
    public void GetDamaged(float damage, int damageDirection){
        health -= damage;
        rb.AddForce(new Vector2(damageDirection * damageForceX, damageForceY));
        if (health <= 0){
            animator.SetBool("isDead", true);
            animator.SetTrigger("die");
            if (controller != null) controller.StopMoving();
            gameObject.layer = 7;
            if (destroyedPrefab != null){
                animator.SetTrigger("damage");
                StartCoroutine(DestroyCorpse(0.25f, damageDirection));
            } 
            else StartCoroutine(DestroyCorpse(5f, damageDirection));
        }
        else{ 
            animator.SetTrigger("damage");
            if (controller != null){
                StartCoroutine(controller.StopMovingFor(downTime));
            }
        }
    }

    private IEnumerator DestroyCorpse(float duration, int damageDirection){
        yield return new WaitForSeconds(duration);
        if (destroyedPrefab != null){
            GameObject parts = Instantiate(destroyedPrefab, transform.position, Quaternion.identity);
                Rigidbody2D[] rbs = parts.GetComponentsInChildren<Rigidbody2D>();
                foreach(Rigidbody2D r in rbs){
                    r.AddForce(new Vector2(damageDirection * damageForceX/3, damageForceY/3));
                    r.gameObject.layer = 7;
                }
        }
        Destroy(gameObject);
    }
}
