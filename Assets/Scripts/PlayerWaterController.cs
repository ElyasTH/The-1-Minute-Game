using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerWaterController : MonoBehaviour
{
    [SerializeField, Min(0f)]
    private float maxWaterValue = 100f;
    private float waterValue;
    [SerializeField]
    private Slider waterSlider;
    public TextMeshProUGUI warningText;

    void Awake(){
        waterValue = maxWaterValue;
        waterSlider.maxValue = waterValue;
        waterSlider.minValue = 0f;
        waterSlider.value = waterValue;
    }
    public void Change(float amount){
        waterValue += amount;
        if (waterValue > maxWaterValue) waterValue = maxWaterValue;
        else if (waterValue < 0f) waterValue = 0f;
        waterSlider.value = waterValue;

        if (waterValue <= 0){
            warningText.enabled = true;
        }
        else warningText.enabled = false;
    }

    public float GetWaterValue(){
        return waterValue;
    }
}
