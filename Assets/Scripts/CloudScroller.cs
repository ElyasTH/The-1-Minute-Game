using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScroller : MonoBehaviour
{
    public float speed = 10f;
    public Transform endPoint;
    public Transform startPoint;

    void Update()
    {
        Vector3 newPos = transform.position + Vector3.left * speed * Time.deltaTime;
        transform.position = newPos;
        if (transform.position.x <= endPoint.position.x){
            transform.position = startPoint.position;
        }
    }
}
