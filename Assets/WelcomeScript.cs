using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WelcomeScript : MonoBehaviour
{
    public Text hellText;
    public float fadeSpeed = 5;
    public bool enterance=false;
    public float timeRemaining = 30f; // The timer duration
    private bool timerIsRunning = false;
    public UnityEvent onTimerEnd; // Optional: Event to trigger when the timer ends
    void Start () {
        hellText.color = Color.white;
    }
    void Update () {
        ColorChange();
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);
            }
            else
            {
                // Timer has ended
                timeRemaining = 0;
                timerIsRunning = false;
                onTimerEnd.Invoke(); // Trigger the event if any are subscribed
                                LoadGameOverScene(); // Load the Game Over scene
                //Scorer.LoadSceneAndKeepValue();
            }
        }
    }
    void OnTriggerEnter(Collider col){
        timerIsRunning = true;
        if (col.gameObject.tag == "Player")  enterance = true;
    }
    void OnTriggerExit(Collider col) {
        if (col.gameObject.tag == "Player")  enterance = false;
     }
    private void ColorChange(){
      if (enterance)
        hellText.color = Color.Lerp(hellText.color, Color.white, fadeSpeed *Time.deltaTime);
    //   if (!enterance)
    //     hellText.color = Color.Lerp(hellText.color, Color.clear, fadeSpeed *Time.deltaTime);
    }
    private void UpdateTimerDisplay(float timeToDisplay)
    {
        if (hellText != null)
        {
            timeToDisplay += 1; // To ensure we round up the timer display
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            hellText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
    private void LoadGameOverScene()
    {
        SceneManager.LoadScene(2);
    }
}
