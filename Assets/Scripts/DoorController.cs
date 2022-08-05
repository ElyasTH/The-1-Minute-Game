using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform destination;
    private Animator animator;

    void OnTriggerEnter2D(Collider2D col){
        PlayerAction playerAction = col.gameObject.GetComponent<PlayerAction>();
        playerAction?.SetDoor(this);
    }

    void OnTriggerExit2D(Collider2D col){
        PlayerAction playerAction = col.gameObject.GetComponent<PlayerAction>();
        playerAction?.SetDoor(null);
    }

    public void Travel(Transform player){
        player.position = destination.position;
    }
}
