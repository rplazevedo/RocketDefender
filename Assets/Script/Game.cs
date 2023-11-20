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

    public int roundNumber = 0;

    private void Update()
    {
        levelTime -= Time.deltaTime; 
        if ((levelTime <= 0 || bases.BaseCount == 0) && !isRoundOver)
        {
            // end round
            CompleteRound();
        }
        timerText.text = levelTime.ToString("00");
    }

    void CompleteRound()
    {
        isRoundOver = true;
        spawner.Stop();
        gameMenu.gameObject.SetActive(true);
        if (roundNumber == 0)
        {
            gameMenuText.text = string.Format("Start Game");
        }
        else
        {
            totalPoints += bases.BaseCount * 36;
            gameMenuText.text = string.Format("Round {0} Complete!\n{1} bases remaining\n{2} total points", roundNumber, bases.BaseCount, totalPoints);
        }
        Time.timeScale = 0;
        roundNumber++;
    }

    public void StartNextRound()
    {
        isRoundOver = false;
        Time.timeScale = 1f;
        levelTime = totalLevelTime;
        StartCoroutine(spawner.StartSpawning());
        gameMenu.gameObject.SetActive(false);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}