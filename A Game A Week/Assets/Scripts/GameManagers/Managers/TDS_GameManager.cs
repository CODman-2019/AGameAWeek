using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDS_GameManager : MonoBehaviour
{
    public static TDS_GameManager manager;
    public int currentScore;
    private int highScore;

    private void Awake(){ manager = this; }

    public void ResetScore()
    {
        currentScore = 0;
    }

    public int IncreaseScore(int add) => currentScore += add;
   
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
