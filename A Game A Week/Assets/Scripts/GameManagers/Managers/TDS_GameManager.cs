using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TDS_GameManager : MonoBehaviour
{
    public static TDS_GameManager manager;
    public Text scoreCounter;
    public Text scoreText, hiScoreText;
    public Slider hpCounter;
    public GameObject titlePanel, gamePanel, resultPanel;

    public GameObject playerPrefab;

    private enum panel
    {
        title,
        game,
        result
    }
    private panel currentPanel;
    private int currentScore;
    private int hiScore;

    private void Awake() {
        manager = this;
        ResetScore();
        currentPanel = panel.title;
        ChangeScreens();
    }

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
    private void UpdateScore()
    {
        scoreCounter.text = currentScore.ToString();
    }

    private void UpdateResultsScoreText()
    {
        scoreText.text = currentScore.ToString();
        hiScoreText.text = hiScore.ToString();
    }

    public void IncreaseScore(int add)
    {
        currentScore += add;
        UpdateScore();
    }

    public int GetScore() => currentScore;
    public void CheckHighScore()
    {
        if (currentScore > hiScore) hiScore = currentScore;
    }

    public void ResetGame()
    {
        ResetScore();
        GameMaster.master.ReloadScene();
    }

    public void GetTitle()
    {
        currentPanel = panel.title;
        ChangeScreens();
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement_TopDown>().DeactivateMovement();
        //EnemyManager_TDS.enemySpawn.DeactivateSpawner();
        GetComponent<EnemyManager_TDS>().DeactivateSpawner();
    }
    public void GetGame()
    {
        currentPanel = panel.game;
        ChangeScreens();
        ResetScore();
        Instantiate(playerPrefab, new Vector3(), Quaternion.identity);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TargetFollow>().target = GameObject.FindGameObjectWithTag("Player");
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement_TopDown>().ActivateMovement();
        //GameObject.FindGameObjectWithTag("Player").GetComponent<TDS_Player>().ResetHealth();
        UpdateHPCounter();
        //EnemyManager_TDS.enemySpawn.ActivateSpawner();
        GetComponent<EnemyManager_TDS>().ActivateSpawner();
    }
    public void GetResults()
    {
        EnemyManager_TDS.enemySpawn.DestroyAllEnemys();
        GetComponent<EnemyManager_TDS>().DeactivateSpawner();
        currentPanel = panel.result;
        CheckHighScore();
        ChangeScreens();
        UpdateResultsScoreText();
    }

    private void ChangeScreens()
    {
        switch (currentPanel)
        {
            case panel.title:
                titlePanel.SetActive(true);
                gamePanel.SetActive(false);
                resultPanel.SetActive(false);
                break;
            case panel.game:
                titlePanel.SetActive(false);
                gamePanel.SetActive(true);
                resultPanel.SetActive(false);
                break;
            case panel.result:
                titlePanel.SetActive(false);
                gamePanel.SetActive(false);
                resultPanel.SetActive(true);
                break;
        }
    }


}
