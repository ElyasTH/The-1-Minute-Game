using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallContoller : MonoBehaviour
{
    Collider2D[] inRadius = null;
    [SerializeField]
    private float explosionForceMulti = 5;
    [SerializeField]
    private float explosionRadius = 5;
    private Damager damager;
    private bool isShot = false;
    public GameObject explosionFX;

    void Awake(){
        damager = GetComponent<Damager>();
    }
    void Explode(){
        Instantiate(explosionFX, transform.position, Quaternion.identity);
        inRadius = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D o in inRadius) 
        {
            Rigidbody2D o_rb = o.GetComponent<Rigidbody2D>();
            if (o_rb != null) 
            {
                Vector2 distance = o.transform.position - transform.position;
                Damageable damageableObject = o.GetComponent<Damageable>();
                if (damageableObject != null) damager.Damage(damageableObject);
            }
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag != "Cannon" && isShot) Explode();
    }

    public void Shoot(){
        isShot = true;
    }
}
