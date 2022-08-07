using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWaterController : MonoBehaviour
{
    public Camera camera;
    public Canvas gameOverCanvas;
    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Player"){
            var playerMovement = col.gameObject.GetComponent<PlayerMovement>();
            playerMovement?.SetInWater(true);
        }
        else if (col.gameObject.tag == "Enemy"){
            StartCoroutine(GameOver(col.gameObject));
        }
    }

    void OnTriggerExit2D(Collider2D col){
        var playerMovement = col.gameObject.GetComponent<PlayerMovement>();
        playerMovement?.SetInWater(false);
    }

    private IEnumerator GameOver(GameObject enemy){
        camera.GetComponent<CameraFollow>().PlayerTransform = enemy.transform;
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0;
        gameOverCanvas.enabled = true;
    }
}
