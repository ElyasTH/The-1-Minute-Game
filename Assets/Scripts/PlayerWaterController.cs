using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWaterController : MonoBehaviour
{
    [SerializeField, Min(0f)]
    private float waterValue = 100f;
    [SerializeField]
    private Slider waterSlider;

    void Awake(){
        waterSlider.maxValue = waterValue;
        waterSlider.minValue = 0f;
        waterSlider.value = waterValue;
    }
    public void Change(float amount){
        waterValue += amount;
        if (waterValue > 100f) waterValue = 100f;
        else if (waterValue < 0f) waterValue = 0f;
        waterSlider.value = waterValue;
    }

    public float GetWaterValue(){
        return waterValue;
    }
}
