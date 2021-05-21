using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_ObjectPooling : MonoBehaviour
{
    public static Bullet_ObjectPooling bullet;
    private int maxBullets, currentBullets = 0;

    private void Awake()
    {
        if (bullet == null) 
            bullet = this;
        else
            Destroy(this.gameObject);

    }

    public void SetBullets(int amount) => maxBullets = amount;

    public void CreateBullet(GameObject bullet, Transform startPos) 
    {
        if(currentBullets <= maxBullets)
        {
            Instantiate(bullet, startPos.position, startPos.rotation);
            currentBullets++;
        }

    }

    public void RemoveBullet() => currentBullets--;
}
