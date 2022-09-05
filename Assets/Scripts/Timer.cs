using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    public Action OnTimesUp;

    [SerializeField]
    float initialTime = 300f;

    [SerializeField]
    private Text timerText;


    private void Update()
    {
        if (initialTime > 0)
        {
            initialTime -= Time.deltaTime;
        }
        else
        {
            initialTime = 0;
            OnTimesUp?.Invoke();
            return;
        }

        DisplayTime(initialTime);
    }

    void DisplayTime(float amountToDisplay)
    {
        if (amountToDisplay < 0)
        {
            amountToDisplay = 0;
        }

        float seconds = Mathf.FloorToInt(amountToDisplay);

        timerText.text = seconds.ToString();
    }
}