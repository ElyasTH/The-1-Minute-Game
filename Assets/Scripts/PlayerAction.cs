using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{   
    private GameObject touchingObstacle;
    private GameObject takenObstacle;
    void Update(){
        if (Input.GetButtonDown("Use")){
            if (touchingObstacle != null && takenObstacle == null){
                takenObstacle = touchingObstacle;
                touchingObstacle.GetComponent<ObstaclesController>().Take();
            }
            else if (takenObstacle != null){
                takenObstacle.GetComponent<ObstaclesController>().Throw();
                takenObstacle = null;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Obstacle"){
            touchingObstacle = collision.gameObject;
        }
    }

    void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.tag == "Obstacle"){
            touchingObstacle = null;
        }
    }

    
}
