using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsController : MonoBehaviour
{
    public GameObject howToPage;
    public GameObject howTo1, howTo2, howTo3, howTo4, howTo5;
    private int howToNum = 1;

    public void OnNext(){
        Time.timeScale = 1f;
        if (SceneManager.GetActiveScene().buildIndex != 3)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else SceneManager.LoadScene(0);
    }

    public void OnRestart(){
        Time.timeScale = 1f;
        if (SceneManager.GetActiveScene().buildIndex != 1)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        else SceneManager.LoadScene(1);
    }

    public void OnExit(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void OnQuit(){
        Application.Quit();
    }

    public void OnHowTo(){
        howToPage.SetActive(true);
        howTo1.SetActive(true);
    }

    public void OnHowToNext(){
        switch(howToNum){
            case 1:{
                howTo1.SetActive(false);
                howTo2.SetActive(true);
            break;
            }
            case 2:{
                howTo2.SetActive(false);
                howTo3.SetActive(true);
            break;
            }
            case 3:{
                howTo3.SetActive(false);
                howTo4.SetActive(true);
            break;
            }
            case 4:{
                howTo4.SetActive(false);
                howTo5.SetActive(true);
            break;
            }
            case 5:{
                howTo5.SetActive(false);
                howToPage.SetActive(false);
            break;
            }
        }
        if (howToNum != 5) howToNum++;
        else howToNum = 1;
    }
}
