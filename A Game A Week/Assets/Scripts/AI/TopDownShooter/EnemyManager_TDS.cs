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
    private int enemyCount = 0;
    private GameObject[] spawnPoints;
    private bool activate;

    public bool ActivateSpawner() => activate = true;
    public bool DeactivateSpawner() => activate = false;

    void Awake()
    {
        enemySpawn = this;
        timer = Spawntime;
        activate = false;
        spawnPoints = GameObject.FindGameObjectsWithTag("PatrolPoint");
    }

    // Update is called once per frame
    private void Update()
    {
        if(Time.time > timer && activate)
        {
            //if(enemyCount < enemyMax)
            //{
                int patrolPoint = Random.Range(0, spawnPoints.Length);
                Transform position = spawnPoints[patrolPoint].transform;
                Instantiate(enemy, position.position, Quaternion.identity);
            //    enemyCount++;
            //}

            timer += Spawntime;
        }
        else if(Time.time > timer) timer += Spawntime;
    }

    public int DecrementCounter() {return enemyCount--; }

    public void DestroyAllEnemys()
    {
        GameObject[] remaining = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(GameObject enemy in remaining)
        {
            Destroy(enemy);
        }
    }
}
