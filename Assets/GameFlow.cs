using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    [SerializeField]
    private Timer timer;

    [SerializeField]
    string[] choosenTile = new string[2];

    private void OnEnable()
    {
        timer.OnTimesUp += OnGameOver;
    }
    private void OnDisable()
    {
        timer.OnTimesUp -= OnGameOver;
    }

    void OnGameOver()
    {
        Debug.Log("GameOver");
    }
}
