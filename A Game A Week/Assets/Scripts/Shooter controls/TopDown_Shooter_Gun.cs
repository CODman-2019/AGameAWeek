using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDown_Shooter_Gun : MonoBehaviour
{
    public GameObject gun_Bullets;
    public Transform bullet_ExitPoint;
    public int bullets = 10;

    // Start is called before the first frame update
    void Start()
    {
        Bullet_ObjectPooling.bullet.SetBullets(bullets);
    }

    // Update is called once per frame
    void Update()
    {
        GunRotation();
        GunShoot();
    }

    private void GunShoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Ray gunAim = new Ray(bullet_ExitPoint.position,);
            
            Bullet_ObjectPooling.bullet.CreateBullet(gun_Bullets, bullet_ExitPoint);
        }
    }

    void GunRotation()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(camRay, out rayLength))
        {
            Vector3 pointToLook = camRay.GetPoint(rayLength);
            //Debug.DrawLine(camRay.origin, pointToLook, Color.blue);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }
}



        //float mouseX = Input.mousePosition.x;
        //float mouseY = Input.mousePosition.y;
        //float mouseZ = Input.mousePosition.z;
        //Debug.Log(mouseX + " " + mouseY + " " +mouseZ);

        //float xLook = Input.mousePosition.x - transform.position.x;
        //float yLook = Input.mousePosition.y - transform.position.z;

        //Vector3 look = new Vector3(xLook, 0f, yLook);
        
        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector3 Lookdir = Input.mousePosition - transform.position;
        
        //float angle = Mathf.Atan2(Lookdir.x, Lookdir.z) * Mathf.Rad2Deg - 90f;

        //transform.rotation = Quaternion.Euler(0, angle, 0);
        //transform.LookAt(look);

        ////
        //

        ////
        //
        ////this.GetComponent<Rigidbody>().rotation;