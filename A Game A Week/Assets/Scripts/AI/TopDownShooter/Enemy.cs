using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int score;
    public  int health = 10;
    public int damageImpact;
    private bool playerNear = false;
    private void CheckDamage()
    {
        if(health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        TDS_GameManager.manager.IncreaseScore(score);
        EnemyManager_TDS.enemySpawn.DecrementCounter();
        Destroy(this.gameObject);
    }



    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case "Player":
                other.gameObject.GetComponent<TDS_Player>().TakeDamage(damageImpact);
                Death();
                break;
            case "Bullet":
                health -= other.gameObject.GetComponent<PhysicalBullets>().damageImpact;
                CheckDamage();
                break;
            default:
                break;
        }
    }
    
}
