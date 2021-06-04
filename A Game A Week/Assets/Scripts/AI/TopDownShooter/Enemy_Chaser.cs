using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Chaser : MonoBehaviour
{
    private Transform player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Look();
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void Look()
    {
        transform.LookAt(player.transform.position);
    }
}
