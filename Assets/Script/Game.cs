using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Game : MonoBehaviour
{
    private float levelTime;
    private int totalPoints;
    private TMPro.TextMeshProUGUI gameMenuText;

    [SerializeField]
    private BaddieSpawner spawner;
    private Transform gameMenu;
    private Bases bases;
    private bool isRoundOver;

    private void Start()
    {
        levelTime = 10f;
    }

    private void Update()
    {
        levelTime -= Time.deltaTime;
        if (levelTime <= 0 && !isRoundOver)
        {
            // end round
            CompleteRound();
        }
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
}