using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleManager : MonoBehaviour
{
    private int type;
    public SpriteRenderer spriteRenderer;
    void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        type = Random.Range(0,3);
        UpdateColor();
    }

    public int GetCircleType(){
        return type;
    }

    public void SetCircleType(int type){
        this.type = type;
        UpdateColor();
    }

    private void UpdateColor(){
        if (type == 0) spriteRenderer.color = Color.red;
        else if (type == 1) spriteRenderer.color = Color.white;
        else if (type == 2) spriteRenderer.color = Color.blue;
    }
}
