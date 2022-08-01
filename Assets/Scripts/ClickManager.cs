using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public ObjectGenerator objectGenerator;

    void Awake(){
        objectGenerator.Generate();
    }
    void Update(){
        if (Input.GetMouseButtonDown(0)){
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null){
                print(hit.collider.gameObject.name + " was clicked!");
                if (hit.collider.gameObject.GetComponent<CircleManager>().GetCircleType() == 2)
                    hit.collider.gameObject.GetComponent<CircleManager>().SetCircleType(1);
                else if (hit.collider.gameObject.GetComponent<CircleManager>().GetCircleType() == 1){
                    Destroy(hit.collider.gameObject);
                }
            }
        }

        GameObject[] circles = GameObject.FindGameObjectsWithTag("Circle");
        for (int i = 0; i < circles.Length; i++){
            if (circles[i].GetComponent<CircleManager>().GetCircleType() == 1 ||
                circles[i].GetComponent<CircleManager>().GetCircleType() == 2){
                    return;
            }
        }
        for (int i = 0; i < circles.Length; i++){
            Destroy(circles[i].gameObject);
        }
        objectGenerator.Generate();
    }
}
