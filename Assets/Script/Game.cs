using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    [SerializeField]
    private float totalLevelTime = 30f;

    private float levelTime;
    private int totalPoints;

    [SerializeField]
    private TextMeshProUGUI gameMenuText;
    [SerializeField]
    private TextMeshProUGUI timerText;
    [SerializeField]
    private BaddieSpawner spawner;
    
    [SerializeField]
    private Transform gameMenu;

    [SerializeField]
    private Bases bases;
    private bool isRoundOver;

    private void Update()
    {
        levelTime -= Time.deltaTime;
        if (levelTime <= 0 && !isRoundOver)
        {
            // end round
            CompleteRound();
        }
        timerText.text = levelTime.ToString("00");
    }

    void CompleteRound()
    {
        isRoundOver = true;
        totalPoints += bases.BaseCount * 36;
        spawner.Stop();
        gameMenu.gameObject.SetActive(true);
        gameMenuText.text = string.Format("{0} bases remaining\n{1} total points", bases.BaseCount, totalPoints);
        Time.timeScale = 0;
    }

    public void StartNextRound()
    {
        isRoundOver = false;
        Time.timeScale = 1f;
        levelTime = totalLevelTime;
        StartCoroutine(spawner.StartSpawning());
        gameMenu.gameObject.SetActive(false);
    }
}