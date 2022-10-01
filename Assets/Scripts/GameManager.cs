using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UIDriver uiDriver;
    public ViewFinderSwiper viewFinderSwiper;
    RadarEnemy[] radarEnemies;

    void Start()
    {
        Application.targetFrameRate = 60;
        radarEnemies = GameObject.FindObjectsOfType<RadarEnemy>();
    }

    float _TimeElapsed;
    float _loopTimeElapsed = 7f;
    void Update()
    {
        _TimeElapsed += Time.deltaTime;
        _loopTimeElapsed += Time.deltaTime;
        if (_loopTimeElapsed > 10)
        {
            // Reset AlreadyRevealed de tt le monde
            foreach(RadarEnemy radarEnemy in radarEnemies)
            {
                radarEnemy.AlreadyRevealed = false;
            }

            viewFinderSwiper.Swipe();
            _loopTimeElapsed = 0f;
            Debug.Log("Swipe");
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        uiDriver.TimeTillNextScan = 10 - _loopTimeElapsed;
    }
}