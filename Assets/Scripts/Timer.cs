using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class Timer : MonoBehaviour
{
    public Text timerText; 
    public float timeRemaining = 37f; 

    void Start()
    {
        UpdateTimerText(); 
    }

    void Update()
    {
        timeRemaining -= Time.deltaTime;
        UpdateTimerText();

        if (timeRemaining <= 0)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }

    public void increaseTimer(float time)
    {
        timeRemaining += time;
    }

    private void UpdateTimerText()
    {
        timerText.text = $"{Mathf.Round(timeRemaining)} secondes restantes";
    }
}
