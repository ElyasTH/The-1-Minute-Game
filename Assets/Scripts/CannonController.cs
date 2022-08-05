using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField, Min(0f)]
    private float shootForce = 500f;
    public Transform shootPoint;
    public GameObject ballPrefab;
    public GameObject shootFX;
    private GameObject shotBall;
    private bool loaded = false;
    private Animator animator;

    void Awake(){
        animator = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag == "CannonBall" && col.gameObject != shotBall && !loaded){
            loaded = true;
            Destroy(col.gameObject);
        }
    }

    public void Shoot(){
        if (!loaded) return;
        shotBall = Instantiate(ballPrefab, shootPoint.position, Quaternion.identity);
        Instantiate(shootFX, shootPoint.position, Quaternion.identity);
        int direction = 0;
        if (shootPoint.position.x > transform.position.x) direction = 1;
        else direction = -1;
        shotBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(direction*shootForce, 0));
        animator.SetTrigger("Shoot");
        shotBall.GetComponent<CannonBallContoller>().Shoot();
        loaded = false;
    }
}
