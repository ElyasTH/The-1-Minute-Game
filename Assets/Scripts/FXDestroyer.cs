using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXDestroyer : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        if (audioSource != null) Destroy(gameObject, audioSource.clip.length);
        else Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
    }
}
