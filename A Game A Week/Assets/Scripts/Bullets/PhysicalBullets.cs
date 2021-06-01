using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalBullets : MonoBehaviour
{
    public float speed;
    public int damageImpact;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, 0f, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Bullet_ObjectPooling.bullet.RemoveBullet();
        Destroy(this.gameObject);
    }
}
