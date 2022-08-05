using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAction : MonoBehaviour
{   
    private GameObject touchingObject;
    private GameObject takenObject;
    private PlayerWaterController waterController;

    private DoorController touchingDoor;
    private bool isExhausted;

    void Awake(){
        waterController = GetComponent<PlayerWaterController>();
    }
    
    void Update(){
        if (waterController.GetWaterValue() <= 0) isExhausted = true;
        else isExhausted = false;
        if (Input.GetButtonDown("Use")){
            if (touchingObject != null && takenObject == null && touchingObject.tag != "Cannon" && !isExhausted){
                takenObject = touchingObject;
                touchingObject.GetComponent<ObstaclesController>().Take();
            }
            else if (takenObject != null){
                takenObject.GetComponent<ObstaclesController>().Throw();
                takenObject = null;
                waterController.Change(-6f);
            }
            else if (touchingObject?.tag == "Cannon"){
                touchingObject?.GetComponent<CannonController>().Shoot();
            }
        }
        else if (Input.GetButtonDown("Enter")){
            touchingDoor?.Travel(transform);
        }

        if (takenObject != null) waterController.Change(-5f * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "CannonBall" || collision.gameObject.tag == "Cannon"){
            touchingObject = collision.gameObject;
        }
    }

    void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "CannonBall" || collision.gameObject.tag == "Cannon"){
            touchingObject = null;
        }
    }

    public void SetDoor(DoorController doorController){
        this.touchingDoor = doorController;
    }
}
