using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public Slider healthSlider;
    private Damageable damageable;
    public Canvas gameOverCanvas;

    void Awake(){
        damageable = GetComponent<Damageable>();
        healthSlider.maxValue = healthSlider.value = damageable.GetHealth();
    }

    void Update(){
        healthSlider.value = damageable.GetHealth();
        if (healthSlider.value <= 0){
            StartCoroutine(GameOver());
        }
    }

    private IEnumerator GameOver(){
        yield return new WaitForSeconds(1f);
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
    }
}
