using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TDS_Player : MonoBehaviour
{
    public int maxHealth;

    private int health;

    private void Awake()
    {
        health = maxHealth;   
    }

    public int GetHealth()
    {
        return health;
    } 

    public void ResetHealth() { health = maxHealth; }

    public void CheckHealth()
    {
        if(health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        TDS_GameManager.manager.GetResults();
        Destroy(this.gameObject);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        TDS_GameManager.manager.UpdateHPCounter();
        CheckHealth();
    }
}
