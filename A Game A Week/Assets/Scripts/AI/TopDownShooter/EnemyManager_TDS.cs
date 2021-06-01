using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager_TDS : MonoBehaviour
{
    public static EnemyManager_TDS enemySpawn;
    public float Spawntime;
    public int enemyMax;
    public GameObject enemy;

    private float timer;
    private int enemyCount;
    private GameObject[] spawnPoints;

    void Awake()
    {
        enemySpawn = this;
        timer = Spawntime;
        enemyCount = 0;

        spawnPoints = GameObject.FindGameObjectsWithTag("PatrolPoint");
    }

    // Update is called once per frame
    private void Update()
    {
        if(Time.time >= timer)
        {
            timer += Spawntime;

            if(enemyCount < enemyMax)
            {
                int patrolPoint = Random.Range(0, spawnPoints.Length);
                Transform position = spawnPoints[patrolPoint].transform;
                Instantiate(enemy, position.position, Quaternion.identity);
                enemyCount++;
            }

        }
    }

    public void DecrementCounter() { enemyCount--; }
}
