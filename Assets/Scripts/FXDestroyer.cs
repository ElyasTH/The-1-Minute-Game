using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXDestroyer : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
    }
}
