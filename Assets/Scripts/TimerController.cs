using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    public float timeLeft = 60;
    public TextMeshProUGUI timerText;
    public Canvas winCanvas;

    void Update(){
        timeLeft -= Time.deltaTime;
        timerText.text = Mathf.FloorToInt(timeLeft).ToString();
        if (timeLeft <= 0){
            timerText.enabled = false;
            winCanvas.enabled = true;
            Time.timeScale = 0;
            Destroy(gameObject);
        }
    }
}
