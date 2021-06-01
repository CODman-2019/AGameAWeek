using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TDS_GameManager : MonoBehaviour
{
    public static TDS_GameManager manager;
    public Text ScoreCounter;
    public Slider hpCounter;

    private int currentScore;
    private int highScore;


    private void Awake() { manager = this; ResetScore(); }

    public void ResetScore()
    {
        currentScore = 0;
        UpdateScore();
    }

    public void ResetHPCounter()
    {
        hpCounter.value = hpCounter.maxValue;
    }

    public void UpdateHPCounter()
    {
        hpCounter.value = GameObject.FindGameObjectWithTag("Player").GetComponent<TDS_Player>().GetHealth() / 100f;
    }

    public void IncreaseScore(int add)
    {
        currentScore += add;
        UpdateScore();
    }

    private void UpdateScore()
    {
        ScoreCounter.text = currentScore.ToString();
    }

    public int GetScore() => currentScore;

    public void SetHighScore()
    {
        if (currentScore > highScore) highScore = currentScore;
    }

    public void ResetGame()
    {
        ResetScore();
        GameMaster.master.ReloadScene();
    }

}
