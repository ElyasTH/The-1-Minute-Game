using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraFollow : MonoBehaviour
{

    public Transform PlayerTransform;

    private Vector3 cmOffset;

    [Range(0.001f, 1.0f)]
    public float smoothness = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        cmOffset = transform.position - PlayerTransform.position;
    }

    private void FixedUpdate()
    {
        Vector3 newPos = PlayerTransform.position + cmOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, smoothness);
    }
}
