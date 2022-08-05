using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWaterController : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D col){
        var playerMovement = col.gameObject.GetComponent<PlayerMovement>();
        playerMovement?.SetInWater(true);
    }

    void OnTriggerExit2D(Collider2D col){
        var playerMovement = col.gameObject.GetComponent<PlayerMovement>();
        playerMovement?.SetInWater(false);
    }
}
